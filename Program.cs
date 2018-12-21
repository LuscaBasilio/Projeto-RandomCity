using System;
using Cidadezinha.Classes.Controladores;
using Projeto_RandomCity.Classes.Views;

namespace Cidadezinha
{
    class Program
    {
        private static Cidade NomeDaCidade = new Cidade(10);
        static void Main(string[] args)
        {
            do{
                Tempo.Envelhecer(NomeDaCidade);
                ViewController.MostrarAcontecimentos();
                Tempo.PularTempo();
                Console.ReadKey();
            }while(NomeDaCidade.Populacao.Count > 0);
        }
    }
}
