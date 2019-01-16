using System;
using System.Collections.Generic;
using System.Linq;
using Cidadezinha.Classes.Controladores;

namespace Cidadezinha.Classes.Views
{
    /// <summary>
    /// Classe onde ficará qualquer interação com a tela
    /// Somente essa classe usara Console.WriteLine\ReadLine 
    /// </summary>
    public static class ViewController
    {

        public static List<string> ResumoNascimentos = new List<string>();
        public static List<string> ResumoAcontecimentos = new List<string>();
        public static List<string> ResumoMortes = new List<string>();

        public static void MostrarAcontecimentos(){
            Mostrar(ref ResumoNascimentos);
            Mostrar(ref ResumoAcontecimentos);
            Mostrar(ref ResumoMortes);
            
            Console.WriteLine("Data atual : " + Tempo.DataAtual.ToShortDateString() + "\n");
        }

        private static void Mostrar(ref List<string> acontecimentos){
            if(acontecimentos.Count>0){
                acontecimentos.ForEach(item => Console.WriteLine($"{item}"));
                Console.WriteLine("");
            }
            acontecimentos = new List<string>();
        }
    }
}