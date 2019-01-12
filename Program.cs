using System;
using Cidadezinha.Classes.Controladores;
using Cidadezinha.Classes.Views;

namespace Cidadezinha
{
    class Program
    {
        private static Cidade NomeDaCidade = new Cidade();
        static void Main(string[] args)
        {
            do{
                Tempo.Envelhecer();
                ViewController.MostrarAcontecimentos();
                Tempo.PularTempo();
                Console.ReadKey();
            }while(Cidade.Pessoas.Quantidade() > 0);
        }
    }
}
