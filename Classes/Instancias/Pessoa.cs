using System;
using System.Collections.Generic;
using Cidadezinha.Classes.BancoDeDados;
using Cidadezinha.Classes.Controladores;
using Cidadezinha.Classes.Enums;
using Cidadezinha.Classes.Profissão;
using Cidadezinha.Classes.Views;

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
            get{
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
        public int IDConjuge{
            get;
            private set;
        }
        /// <summary>
        /// Todos os relacionamentos aqui da pessoa são salvos aqui  
        /// ID da pessoa/nivel de relacionamento
        /// </summary>
        private Dictionary<int,int> Relacionamentos;
        #endregion

        /// <summary>
        /// Cria uma pessoa na fase adulta com todos os atributos aleatorios  
        /// </summary>
        public Pessoa() : base(Entidade.Entidades++){
            Random aleatorio = new Random();
            Nome = nomes.PegarAleatorio(this.Sexo_);
            Sobrenome = nomes.PegarAleatorio();    

            //status
            Felicidade = aleatorio.Next(-100,100);
            Sorte = aleatorio.Next(-100,100);
            Conduta = aleatorio.Next(-100,100);
            Espectativa = aleatorio.Next(10,50);
            
            Profissao_ = null;
            this.IDConjuge = -1;

            Relacionamentos = new Dictionary<int, int>();
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
            this.Espectativa = rdm.Next(55,104);
            this.Profissao_ = null;
            this.IDConjuge = -1;

            Relacionamentos = new Dictionary<int, int>();

            this.AumentarRelacionamento(Pai.ID , rdm.Next(0,100));
            this.AumentarRelacionamento(Mae.ID , rdm.Next(0,100));

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

        public void EfeitoDeInteracao(int valor){
            Felicidade += valor / 10;

            if(valor > 30) 
                Espectativa ++;
            else if(valor < -30)
                Espectativa --;
        }

        public static void Interagir(Pessoa pessoa,Pessoa par){
            Random rdm = new Random();
            //variavel responsavel por verificar o relacionamento de ambos
            string relacionamento = ValidacaoPessoa.VerificarRelacionamento(par,pessoa);

            //verifica o nivel do relacionamento e retorna 2 valores possiveis como resultado da interação (valor minimo , valor maximo)
            ValidacaoPessoa.VerificarInteracao(pessoa,par,out int valormin,out int valormax);

            //variavel onde cria um nivel de interação (define o impacto dessa interação na relação dos 2 ;-; )
            int nivelInteracao = rdm.Next(valormin,valormax);

            //aumenta o relacionamento e a felicidade (ou diminiu .. tudo depende do nivelInteração)
            pessoa.AumentarRelacionamento(par.ID,nivelInteracao);
            pessoa.EfeitoDeInteracao(nivelInteracao);

            par.AumentarRelacionamento(pessoa.ID,nivelInteracao);
            par.EfeitoDeInteracao(nivelInteracao);
            
            //Verifica o relacionamento dos 2 e se nenum deles tem conjuge (traição nau ;-; )
            if(relacionamento == "Conjuge" || (relacionamento == "Melhores Amigos" && !pessoa.TemConjuge() && !par.TemConjuge())){
                if(rdm.Next(0,11) < 6){
                    Pessoa.Acasalar(pessoa,par);
                }
            }
            //Apenas mostra mensagem se houver alguma mudança
            string newRelacionamento = ValidacaoPessoa.VerificarRelacionamento(par,pessoa);
            if(newRelacionamento != relacionamento && newRelacionamento != "Desconhecidos"){
                Acontecimentos.MostrarRelacionamento(pessoa,par,newRelacionamento);
            }
        }

        public static void Acasalar(Pessoa pessoa,Pessoa par){
            //RANDOM
            Random random = new Random();
            //crianço
            Pessoa Filho = null;

            //Chance de nascer uma criança
            if(pessoa.Sexo_ != par.Sexo_){
                if(random.Next(0,11) < 6){
                    //DADOS da crianço
                    Sexo filhoGenero = random.Next(0,101) > 49 ? Sexo.Masculino:Sexo.Feminino ;           
                    string filhoNome = nomes.PegarAleatorio(filhoGenero);

                    Pessoa pai = pessoa.Sexo_ == Sexo.Masculino? pessoa: par;
                    Pessoa mae = pessoa.Equals(pai)?par:pessoa;

                    Filho = new Pessoa(filhoNome,filhoGenero,pai,mae);

                    pai.AumentarRelacionamento(Filho.ID,random.Next(0,51));
                    mae.AumentarRelacionamento(Filho.ID,random.Next(0,51));

                    //adiciona o id de crianças como filhos de cada um das pessoas
                    pessoa.Filhos.Add(Filho.ID);
                    par.Filhos.Add(Filho.ID);

                    Acontecimentos.Acasalar(pai,mae);
                }
            }
            //aumenta o relacionamento da pessoa com o par
            pessoa.Relacionamentos[par.ID] += random.Next(0,51);
            par.Relacionamentos[pessoa.ID] += random.Next(0,51);
            pessoa.IDConjuge = par.ID;
            //e a felicidade
            pessoa.EfeitoDeInteracao(random.Next(0,101));
            par.EfeitoDeInteracao(random.Next(0,101));
            par.IDConjuge = pessoa.ID;
            
        }

        public void AumentarRelacionamento(int ID,int valor){
            if(!Relacionamentos.ContainsKey(ID))
                Relacionamentos.Add(ID,valor);
            else
                Relacionamentos[ID] += valor;
        }

        public int VerRelacionamento(int ID){
            if(!Relacionamentos.ContainsKey(ID))
                return 0;
            return Relacionamentos[ID];
        }

        public bool Conhece(int ID) => Relacionamentos.ContainsKey(ID);

        public override bool Equals(object obj)
        {
            if(obj == null && this.GetType() != obj.GetType()){
                return false;
            }else{
                return true;  
            }
        }

        public bool TemConjuge(){
            Pessoa conjuge = Cidade.Pessoas.BuscarPorId(IDConjuge);
            if(conjuge != null){
                if(!conjuge.Vivo){
                    IDConjuge = -1;
                    return false;
                }
            }
            return true;
        }

        public bool Equals(Pessoa pessoa){
            if(this.Sexo_ != pessoa.Sexo_ || this.Fase_ != pessoa.Fase_){
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