using System;
using Cidadezinha.Classes.Enums;
using Cidadezinha.Classes.Instancias;
using Projeto_RandomCity.Classes.Views;

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
            {   // 1990 - 29 > 1960
                if(DataAtual.Year - pessoa.Idade > pessoa.DataNascimento.Year){
                    pessoa.Envelhecer();
                //1990
                }else if (DataAtual.Year - pessoa.Idade == pessoa.DataNascimento.Year){
                    if(DataAtual.Month < pessoa.DataNascimento.Month){
                        pessoa.Envelhecer();
                    }else if(DataAtual.Month == pessoa.DataNascimento.Month && DataAtual.Day < pessoa.DataNascimento.Day){
                        pessoa.Envelhecer();
                    }
                }
            }
        }
    }
}