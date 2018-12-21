using System;
using Cidadezinha.Classes.Controladores;
using Projeto_RandomCity.Classes.Views;

namespace Cidadezinha
{
    class Program
    {
        static void Main(string[] args)
        {
            Cidade NomeDaCidade = new Cidade(10);

            do{
                ViewController.MostrarAcontecimentos();
                Tempo.PularTempo();
                Tempo.Envelhecer(NomeDaCidade);
                Console.ReadKey();
            }while(NomeDaCidade.Populacao.Count > 0);
        }
    }
}
