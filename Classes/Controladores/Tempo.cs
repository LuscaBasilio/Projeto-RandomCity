using System;
using Cidadezinha.Classes.Enums;
using Cidadezinha.Classes.Instancias;

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

        public static void Envelhecer(Cidade cidade){
            foreach (Pessoa item in cidade.Populacao)
            {
                
            }
        }
    }
}