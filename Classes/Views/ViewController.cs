using System;
using System.Collections.Generic;
using Cidadezinha.Classes.Controladores;

namespace Projeto_RandomCity.Classes.Views
{
    /// <summary>
    /// Classe onde ficará qualquer interação com a tela
    /// Somente essa classe usara Console.WriteLine\ReadLine 
    /// </summary>
    public static class ViewController
    {
        /// <summary>
        /// Variavel onde ficara salva todas as informações dos acontecimentos em geral
        /// </summary>
        public static List<string> Resumo = new List<string>();

        public static void MostrarAcontecimentos(){
            foreach (string item in Resumo)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Data atual : " + Tempo.DataAtual.ToShortDateString() + "\n");
            Resumo = new List<string>();
        }
    }
}