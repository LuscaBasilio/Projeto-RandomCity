using System;
using System.Collections.Generic;
using Cidadezinha.Classes.Controladores;
using Cidadezinha.Classes.Enums;
using Cidadezinha.Classes.Interfaces;

namespace Cidadezinha.Classes.Instancias
{
    /// <summary>
    /// Classe Generalizada para todas as instancias vivas
    /// </summary>
    [Serializable]
    public abstract class Entidade : IEntidade
    {
        public static int Entidades;
        /// <summary>
        /// [IMUTAVEL]  
        /// Define o ID da entidade  
        /// É usado para a mesma ser identificada pelas outras entidades
        /// </summary>
        public readonly int ID;
        /// <summary>
        /// [IMUTAVEL]  
        /// Define a data de nascimento da Pessoa
        /// </summary>
        public readonly DateTime DataNascimento;
        /// <summary>
        /// [IMUTAVEL]  
        /// Define a data de obito da Pessoa
        /// </summary>
        protected DateTime DataObito;
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
        /// Lista com todos os filhos da entidade (armazena apena seus IDs)
        /// </summary>
        public List<int> Filhos{
            get;
            set;
        }
        /// <summary>
        /// Verifica se a entidade atual está viva
        /// </summary>s
        public bool Vivo{
            get;
            set;
        }
        /// <summary>
        /// Define a idade da entidade
        /// </summary>
        public int Idade {
            get;
            protected set;
        }
        /// <summary>
        /// Define a fase atual da entidade
        /// </summary>
        public Fase Fase_{
            get;
            protected set;
        }
        /// <summary>
        /// Define a longevidade da entidade.....  
        /// </summary>
        public int Espectativa{
            get;
            protected set;
        }
        /// <summary>
        /// Construtor padrão da classe Entidade  
        /// Cria uma entidade com valores aleatorios
        /// </summary>
        /// <param name="ID">ID da entidade</param>
        public Entidade(int ID){
            Random aleatorio = new Random();
            this.ID = ID;
            Idade = aleatorio.Next(18,30);    
            Sexo_ = (Sexo)aleatorio.Next(1,3);
            DataNascimento = Tempo.DataAtual.AddYears(- Idade).AddMonths(aleatorio.Next(-12,12)).AddDays(aleatorio.Next(-30,30));
            Vivo = true;
            Fase_ = VerificarFase();
            IDPai = -1;
            IDMae = -1;
            Filhos = new List<int>();
        }
        
        /// <summary>
        /// Construtor para entidade com parentes (pai/mãe)
        /// Todos os atributos padrões
        /// </summary>
        /// <param name="ID">ID da entidade</param>
        /// <param name="sexo">Sexo da entidade</param>
        /// <param name="pai">Instancia que é definida como pai da entidade</param>
        /// <param name="mae">Instancia que é definida como mãe da entidade</param>
        public Entidade(int ID,Sexo sexo , Entidade pai,Entidade mae){
            this.ID = ID;
            this.Sexo_ = sexo;
            this.Vivo = true;

            this.DataNascimento = Tempo.DataAtual;
            this.Idade = 0;
            this.Fase_ = VerificarFase();

            this.IDPai = pai.ID;
            this.IDMae = mae.ID;
            this.Filhos = new List<int>();
        }

        public virtual void Envelhecer()
        {
            Idade ++;
            Espectativa --;

            if(Espectativa <= 0){
                Morte();
                DataObito = Tempo.DataAtual;
            }else{
                Fase_ = VerificarFase();
            }
        }

        public virtual void Morte()
        {
            Fase_ = Fase.Morto;
            Vivo = false;
        }

        public virtual Fase VerificarFase()
        {
            if(Idade < 20){
                return Fase.Infancia;
            }else if(Idade < 40){
                return Fase.Adolescencia;
            }else if(Idade < 60){
                return Fase.Adulto;
            }else{
                return Fase.Idoso;
            }  
        }

        public static void Acasalar(Entidade entidade,Entidade par){
            
        }
    }
}