using System;
using System.Collections.Generic;
using Cidadezinha.Classes.BancoDeDados;
using Cidadezinha.Classes.Controladores;
using Cidadezinha.Classes.Enums;
using Cidadezinha.Classes.Profissão;
using Cidadezinha.Classes.Geradores;

namespace Cidadezinha.Classes.Instancias
{
    [Serializable]
    public class Pessoa
    {  
        #region Imutavel
        /// <summary>
        /// [IMUTAVEL]  
        /// Define o ID da pessoa  
        /// É usado para a mesma ser identificada pelas outras pessoas
        /// </summary>
        public readonly int ID;
        /// <summary>
        /// [IMUTAVEL]  
        /// Nome da Pessoa      
        /// Gerado aleatoriamente
        /// </summary>
        public readonly string Nome;
        /// <summary>
        /// [IMUTAVEL]  
        /// Sobrenome da pessoa  
        /// Definido pelo sobrenome do pai ou da mãe (50/50)
        /// </summary>
        public readonly string Sobrenome;
        /// <summary>
        /// [IMUTAVEL]  
        /// Define a data de nascimento da Pessoa
        /// </summary>
        public readonly DateTime DataNascimento;
        /// <summary>
        /// [IMUTAVEL]  
        /// Define a data de obito da Pessoa
        /// </summary>
        public DateTime DataObito;
        /// <summary>
        /// [IMUTAVEL]  
        /// Define o genero da Pessoa  
        /// Apenas masculino e Feminino  
        /// XX E XXtentação ;-;
        /// </summary>
        public readonly Sexo Sexo_;
        /// <summary>
        /// [IMUTAVEL]  
        /// Define o Pai da Pessoa  
        /// </summary>
        public readonly int IDPai;
        /// <summary>
        /// [IMUTAVEL]  
        /// Define a Mae da Pessoa
        /// </summary>
        public readonly int IDMae;

        /// <summary>
        /// Banco de dados para todas as pessoas  
        /// Onde é retirado todos os nomes aleatorios  
        /// </summary>
        public static NomeDataBase nomes = new NomeDataBase();
        #endregion

        #region Mutavel
            
            #region variaveis privadas 
                private int felicidade;
                private int sorte;
                private int conduta;
            #endregion
        #region Propriedades
        public int Idade {
            get;
            private set;
        }
        public Fase Fase_{
            get;
            private set;
        }
        public bool Vivo{
            get;
            set;
        }
        
        public int Sorte{
            get{
                return sorte;
            }
            set{
                if(value > 50 || sorte < -50){
                    value = 0;
                }
                sorte = value;
            }
        }
        
        public int Felicidade{
            private get{
                return felicidade;
            }
            set{
                if(value > 1000 || value < -1000){
                    value = 0;
                }
                felicidade = value;
            }
        }
        public int Conduta{
            private get;
            set;
        }

        public Profissao Profissao_{
            get;
            set;
        }
        public List<int> Filhos{
            get;
            set;
        }
        #endregion
        /// <summary>
        /// Define a longevidade da pessoa.....  
        /// </summary>
        public int Espectativa{
            get;
            private set;
        }
        /// <summary>
        /// Todos os relacionamentos aqui da pessoa são salvos aqui  
        /// ID da pessoa/nivel de relacionamento
        /// </summary>
        public Dictionary<int,int> Relacionamentos{
            get;
            private set;
        }
        #endregion

        /// <summary>
        /// Cria uma pessoa na fase adulta com todos os atributos aleatorios  
        /// </summary>
        public Pessoa(int ID){
            Random aleatorio = new Random();

            this.Sexo_ = (Sexo)aleatorio.Next(1,3);
            this.Nome = nomes.PegarAleatorio(this.Sexo_);
            this.Sobrenome = nomes.PegarAleatorio();

            Idade = aleatorio.Next(18,30);
            DataNascimento = Tempo.DataAtual.AddYears(- Idade).AddMonths(aleatorio.Next(-12,12)).AddDays(aleatorio.Next(-30,30));

            //status
            Fase_ = VerificarFase();
            Felicidade = aleatorio.Next(-100,100);
            Sorte = aleatorio.Next(-100,100);
            Conduta = aleatorio.Next(-100,100);
            Espectativa = aleatorio.Next(10,50);
            Vivo = true;
            
            Profissao_ = null;
            //Relacionamento
            IDPai = -1;
            IDMae = -1;
            Filhos = new List<int>();

            //Feedback
            Acontecimentos.Nascimento(this);
        }
        
        /// <summary>
        /// Cria uma pessoa no inicio de sua vida  
        /// Todos os atributos padrões 
        /// </summary>
        /// <param name="Nome">Nome que será dado a criança</param>
        /// <param name="Sexo_">Sexo da criança</param>
        /// <param name="Pai">Instancia que é definida como pai da criança</param>
        /// <param name="Mae">Instancia que é definida como mãe da criança</param>
        public Pessoa(string Nome,Sexo Sexo_,Pessoa Pai,Pessoa Mae){
            Random rdm = new Random();
            this.Nome = Nome;
            this.Sobrenome = rdm.Next(1,3) == 1? Pai.Sobrenome : Mae.Sobrenome;
            this.Sexo_ = Sexo_;
            this.IDPai = Pai.ID;
            this.IDMae = Mae.ID;
            this.DataNascimento = Tempo.DataAtual;

            this.Idade = 0;
            this.Fase_ = VerificarFase();
            
            this.Felicidade = 0;
            this.Sorte = 0;
            this.Conduta = 0;
            this.Espectativa = rdm.Next(55,103);
            this.Profissao_ = null;
            this.Vivo = true;
            
            this.Filhos = new List<int>();

            this.SetarRelacionamento(Pai.ID,rdm.Next(0,100));
            this.SetarRelacionamento(Mae.ID,rdm.Next(0,100));

            Acontecimentos.Nascimento(this);
        }
        /// <summary>
        /// Verifica a fase atual da Pessoa
        /// </summary>
        /// <returns>Retorna a fase atual do individuo</returns>
        private Fase VerificarFase(){

            if(Idade < 14){
                return Fase.Infancia;
            }else if(Idade < 18){
                return Fase.Adolescencia;
            }else if(Idade < 50){
                return Fase.Adulto;
            }else{
                return Fase.Idoso;
            }  
        }

        public void Envelhecer(){
            Idade ++;
            Espectativa --;

            if(Espectativa <= 0){
                Morte();
                Acontecimentos.Morte(this);
            }else{
                Fase_ = VerificarFase();
                Acontecimentos.Envelhecer(this);
            }
            
        }

        /// <summary>
        /// Mata a instancia
        /// </summary>
        public void Morte(){
            Fase_ = Fase.Morto;
            Vivo = false;
        }

        public static void Acasalar(Pessoa pessoa,Pessoa par){
            //RANDOM
            Random random = new Random();
            //crianço
            Pessoa Filho = null;

            //DADOS
            Sexo filhoGenero = random.Next(0,100) > 49 ? Sexo.Masculino:Sexo.Feminino ;           
            string filhoNome = "";

            Filho = new Pessoa(filhoNome,filhoGenero,pessoa,par);

            pessoa.SetarRelacionamento(Filho.ID,random.Next(0,100));
            par.SetarRelacionamento(Filho.ID,random.Next(0,100));

            pessoa.Filhos.Add(Filho.ID);
            par.Filhos.Add(Filho.ID);
        }

        public override bool Equals(object obj)
        {
            
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return true;
        }
        
        
        public override int GetHashCode()
        {
            throw new MissingMethodException(";-;") ;
        }

        public void SetarRelacionamento(int id, int valorInicial) => Relacionamentos[id] = valorInicial;

    }
}