using System;
using Cidadezinha.Classes.Enums;
using Cidadezinha.Classes.Instancias;
using Projeto_RandomCity.Classes.Views;

namespace Cidadezinha.Classes.Controladores
{
    public static class Tempo
    {
        public static DateTime DataAtual = DateTime.Parse("23/04/1990");
        public static Timeskip Pulos = Timeskip.Mes;

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
            foreach (Pessoa pessoa in Cidade.Pessoas.Populacao)
            {
                if(DataAtual.Year - pessoa.Idade > pessoa.DataNascimento.Year && DataAtual.Month >= pessoa.DataNascimento.Month && DataAtual.Day >= pessoa.DataNascimento.Day){
                    pessoa.Envelhecer();
                    ViewController.Resumo.Add($"{pessoa.Nome} {pessoa.Sobrenome} agora tem {pessoa.Idade} anos");
                }
            }
        }
    }
}