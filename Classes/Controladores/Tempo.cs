using System;
using System.Collections.Generic;
using Cidadezinha.Classes.Enums;
using Cidadezinha.Classes.Instancias;
using Cidadezinha.Classes.Views;

namespace Cidadezinha.Classes.Controladores
{
    public static class Tempo
    {
        public static DateTime DataAtual = DateTime.Parse("23/04/1990");
        public static Timeskip Pulos = Timeskip.Semana;

        /// <summary>
        /// Pula uma quantidade de tempo apos um grupo de acontecimentos  
        /// </summary>
        private static void PularTempo(){
            switch(Pulos){
                case Timeskip.Ano:
                    DataAtual = DataAtual.AddYears(1);
                    break;
                case Timeskip.Dia:
                    DataAtual = DataAtual.AddDays(1);
                    break;
                case Timeskip.Semana:
                    DataAtual = DataAtual.AddDays(7);
                    break;
                default:
                    DataAtual = DataAtual.AddMonths(1);
                    break;
            }
        }
        
        public static void Avancar(){
            Interagir();
            Envelhecer();
            ViewController.MostrarAcontecimentos();
            PularTempo();
        }

        private static void Interagir(){
            Random rdm = new Random();

            int T = rdm.Next(0,10 * (int)Pulos);
            List<Pessoa> pessoas = Cidade.Pessoas.PopulacaoViva();

            for (int i = 0; i < T; i++)
            {
                Pessoa pessoa1 = pessoas[rdm.Next(0,pessoas.Count)];
                Pessoa pessoa2 = pessoas[rdm.Next(0,pessoas.Count)];
                Pessoa.Interagir(pessoa1,pessoa2);
            }
        }

        private static void Envelhecer(){
            /* Exemplo : 
            ** Data atual       : 23/04/1990
            ** Data nascimento  : 20/03/1960 (29 anos)
            **/
            foreach (Pessoa pessoa in Cidade.Pessoas.PopulacaoViva())
            {
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