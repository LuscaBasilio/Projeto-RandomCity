using System;
using Cidadezinha.Classes.Enums;

namespace Cidadezinha.Classes.Controladores
{
    public static class Tempo
    {
        public static DateTime DataAtual = DateTime.Parse("23/04/1990");
        public static Timeskip Pulos = Timeskip.Mes;

        public static void PularTempo(){
            switch(Pulos){
                case Timeskip.Ano:
                    DataAtual.AddYears(1);
                    break;
                case Timeskip.Dia:
                    DataAtual.AddDays(1);
                    break;
                default:
                    DataAtual.AddMonths(1);
                    break;
            }
        }
    }
}