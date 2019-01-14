using System;
using Cidadezinha.Classes.Enums;
using Cidadezinha.Classes.Instancias;

namespace Cidadezinha.Classes.Controladores
{
    public static class Tempo
    {
        public static DateTime DataAtual = DateTime.Parse("23/04/1990");
        public static Timeskip Pulos = Timeskip.Ano;

        /// <summary>
        /// Pula uma quantidade de tempo apos um grupo de acontecimentos  
        /// </summary>
        public static void PularTempo(){
            switch(Pulos){
                case Timeskip.Ano:
                    DataAtual = DataAtual.AddYears(1);
                    break;
                case Timeskip.Dia:
                    DataAtual = DataAtual.AddDays(1);
                    break;
                default:
                    DataAtual = DataAtual.AddMonths(1);
                    break;
            }
        }

        public static void Envelhecer(){
            /* Exemplo : 
            ** Data atual       : 23/04/1990
            ** Data nascimento  : 20/03/1960 (29 anos)
            **/
            foreach (Pessoa pessoa in Cidade.Pessoas.Populacao)
            {
                if(pessoa.Vivo){
                    if(DataAtual.Year - pessoa.Idade > pessoa.DataNascimento.Year){
                        pessoa.Envelhecer();
                    }else if (DataAtual.Year - pessoa.Idade == pessoa.DataNascimento.Year){
                        if(pessoa.DataNascimento.Month < DataAtual.Month){
                            pessoa.Envelhecer();
                        }else if(pessoa.DataNascimento.Month == DataAtual.Month && pessoa.DataNascimento.Day < DataAtual.Day){
                            pessoa.Envelhecer();
                        }
                    }
                }
            }
        }
    }
}