using System;
using System.Collections.Generic;
using Cidadezinha.Classes.Controladores;
using Cidadezinha.Classes.Enums;
using Cidadezinha.Classes.Geradores;
using Cidadezinha.Classes.Profissão;

namespace Cidadezinha.Classes.Instancias
{
    public class Pessoa
    {  
        #region Imutavel
        public readonly string Nome , Sobrenome;
        public readonly DateTime DataNascimento;
        public DateTime DataObito;
        public readonly Sexo Sexo_;
        public readonly Pessoa Pai ,Mae;
        #endregion

        #region Mutavel
        public int Idade;
        public Fase Fase_;
        public bool Vivo;
        public int Sorte;// -50 | 50
        public int Felicidade;//-100 | 100
        public Profissao Profissao_;
        public int Conduta; // -100 | 100
        public Dictionary<int,Relacionamento> Relacionamentos;
        public List<Pessoa> Filhos;
        public Pessoa Conjuge;
        #endregion

        public Pessoa(){
            Random aleatorio = new Random();

            this.Nome = "Nome";
            this.Sobrenome = "Sobrenome";
            this.Sexo_ = (Sexo)aleatorio.Next(1,3);

            Idade = 23;
            DataNascimento = Tempo.DataAtual.AddYears(- Idade);

            Fase_ = VerificarFase();
            Felicidade = aleatorio.Next(-100,100);
            Sorte = aleatorio.Next(-100,100);
            Profissao_ = null;
            Conduta = aleatorio.Next(-100,100);
            Pai = null;
            Mae = null;
            Conjuge = null;
            Filhos = new List<Pessoa>();
        }

        public Pessoa(string Nome,string SobreNome,Sexo Sexo_,Pessoa Pai,Pessoa Mae){
            this.Nome = Nome;
            this.Sobrenome = new Random().Next(1,3) == 1? Pai.Sobrenome : Mae.Sobrenome;
            this.Sexo_ = Sexo_;
            this.Pai = Pai;
            this.Mae = Mae;
            DataNascimento = Tempo.DataAtual;

            Idade = 0;
            Fase_ = VerificarFase();
            Felicidade = 0;
            Sorte = 0;
            Profissao_ = null;
            Conduta = 0;
            Filhos = new List<Pessoa>();
            Conjuge = null;
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

        /// <summary>
        /// Mata a instancia
        /// </summary>
        public void Morte(){

            Vivo = false;
        }

        public void Acasalar(Pessoa outro){
            //RANDOM
            Random random = new Random();
            int chance = random.Next(0,100);

            //crianço
            Pessoa Filho = null;

            //DADOS
            Sexo filhoGenero = chance > 49 ? Sexo.Masculino:Sexo.Feminino ;           
            string filhoNome = GeradorString.ReturnNome(filhoGenero);
            string filhoSobreNome = new Random().Next(1,3) == 1? this.Sobrenome:outro.Sobrenome ;

            Filho = new Pessoa(filhoNome,filhoSobreNome,filhoGenero,this,outro);
            Filhos.Add(Filho);
            
        }
    


    }
}