using System;
using System.Collections.Generic;
using Cidadezinha.Classes.BancoDeDados;
using Cidadezinha.Classes.Controladores;
using Cidadezinha.Classes.Enums;
using Cidadezinha.Classes.Profissão;
using Cidadezinha.Classes.Geradores;

namespace Cidadezinha.Classes.Instancias
{
    /// <summary>
    /// Classe generalizada para todas as pessoas
    /// </summary>
    [Serializable]
    public class Pessoa : Entidade
    {  
        #region Imutavel
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
        /// Banco de dados para todas as pessoas  
        /// Onde é retirado todos os nomes aleatorios  
        /// </summary>
        public static NomeDataBase nomes = new NomeDataBase();
        #endregion

        #region Mutavel           
        private int felicidade;
        private int sorte;
        private int conduta;
        
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
        public Pessoa(int ID) : base(Entidade.Entidades++){
            Random aleatorio = new Random();
            Nome = nomes.PegarAleatorio(this.Sexo_);
            Sobrenome = nomes.PegarAleatorio();

            Idade = aleatorio.Next(18,30);        

            //status
            Fase_ = VerificarFase();
            Felicidade = aleatorio.Next(-100,100);
            Sorte = aleatorio.Next(-100,100);
            Conduta = aleatorio.Next(-100,100);
            Espectativa = aleatorio.Next(10,50);
            Vivo = true;
            
            Profissao_ = null;

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
        public Pessoa(string Nome,Sexo Sexo_,Pessoa Pai,Pessoa Mae) : base(Entidade.Entidades++,Sexo_,Pai,Mae){
            Random rdm = new Random();
            this.Nome = Nome;
            this.Sobrenome = rdm.Next(1,3) == 1? Pai.Sobrenome : Mae.Sobrenome;
            
            this.Felicidade = 0;
            this.Sorte = 0;
            this.Conduta = 0;
            this.Espectativa = rdm.Next(55,103);
            this.Profissao_ = null;
            
            this.Filhos = new List<int>();

            this.Relacionamentos[Pai.ID] = rdm.Next(0,100);
            this.Relacionamentos[Mae.ID] = rdm.Next(0,100);

            Acontecimentos.Nascimento(this);
        }
        /// <summary>
        /// Verifica a fase atual da Pessoa
        /// </summary>
        /// <returns>Retorna a fase atual do individuo</returns>
        public override Fase VerificarFase(){

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

        public override void Envelhecer(){
            Idade ++;
            Espectativa --;

            if(Espectativa <= 0){
                Morte();
                DataObito = Tempo.DataAtual;
                Acontecimentos.Morte(this);
            }else{
                Fase_ = VerificarFase();
                Acontecimentos.Envelhecer(this);
            }
            
        }
        public static void Acasalar(Pessoa pessoa,Pessoa par){
            //RANDOM
            Random random = new Random();
            //crianço
            Pessoa Filho = null;

            //DADOS da crianço
            Sexo filhoGenero = random.Next(0,100) > 49 ? Sexo.Masculino:Sexo.Feminino ;           
            string filhoNome = "";

            Filho = new Pessoa(filhoNome,filhoGenero,pessoa,par);

            //aumenta o relacionamento da pessoa com o par e com o filho
            pessoa.Relacionamentos[par.ID] += random.Next(0,100);
            pessoa.Relacionamentos[Filho.ID] += random.Next(0,100);
            //e vise versa
            par.Relacionamentos[pessoa.ID] += random.Next(0,100);
            par.Relacionamentos[Filho.ID] += random.Next(0,100);

            //adiciona o id de crianças como filhos de cada um das pessoas
            pessoa.Filhos.Add(Filho.ID);
            par.Filhos.Add(Filho.ID);
        }

        public override bool Equals(object obj)
        {
            if(obj == null && this.GetType() != obj.GetType()){
                return false;
            }else{
                return true;  
            }
        }
        
        
        public override int GetHashCode()
        {
            throw new MissingMethodException(";-;") ;
        }
        

    }
}