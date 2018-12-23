using System;
using System.Collections.Generic;
using Cidadezinha.Classes.BancoDeDados;
using Cidadezinha.Classes.Controladores;
using Cidadezinha.Classes.Enums;
using Cidadezinha.Classes.Profissão;
using Projeto_RandomCity.Classes.Geradores;

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
            get;
            set;
        }
        public int Felicidade{
            get;
            set;
        }
        public Profissao Profissao_{
            get;
            set;
        }
        public int Conduta{
            get;
            set;
        }
        public List<int> Filhos{
            get;
            set;
        }
        /// <summary>
        /// Todos os relacionamentos aqui da pessoa são salvos aqui  
        /// int = id da pessoa  
        /// string = nivel de relacionamento
        /// </summary>
        public Dictionary<int,string> Relacionamentos{
            get;
            set;
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
        /// <param name="Nome"></param>
        /// <param name="SobreNome"></param>
        /// <param name="Sexo_"></param>
        /// <param name="Pai"></param>
        /// <param name="Mae"></param>
        public Pessoa(string Nome,string SobreNome,Sexo Sexo_,Pessoa Pai,Pessoa Mae){
            this.Nome = Nome;
            this.Sobrenome = new Random().Next(1,3) == 1? Pai.Sobrenome : Mae.Sobrenome;
            this.Sexo_ = Sexo_;
            this.IDPai = Pai.ID;
            this.IDMae = Mae.ID;
            DataNascimento = Tempo.DataAtual;

            Idade = 0;
            Fase_ = VerificarFase();
            
            Felicidade = 0;
            Sorte = 0;
            Conduta = 0;
            Profissao_ = null;
            Vivo = true;
            
            Filhos = new List<int>();

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
            }else if(Idade < 103){
                return Fase.Idoso;
            }else if(Idade >= 103){
                Vivo = false;
                return Fase.Idoso;
            }

            return Fase.Infancia;
            
        }

        public void Envelhecer(){
            Idade ++;
            Fase_ = VerificarFase();
            Acontecimentos.Envelhecer(this);
        }

        /// <summary>
        /// Mata a instancia
        /// </summary>
        public void Morte(){
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
            string filhoSobreNome = random.Next(1,3) == 1? pessoa.Sobrenome:par.Sobrenome ;

            Filho = new Pessoa(filhoNome,filhoSobreNome,filhoGenero,pessoa,par);

            pessoa.Filhos.Add(Filho.ID);
            par.Filhos.Add(Filho.ID);
            
        }
    


    }
}