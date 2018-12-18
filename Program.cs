using System;
using Cidadezinha.Classes.Controladores;

namespace Cidadezinha
{
    class Program
    {
        static void Main(string[] args)
        {
            Cidade NomeDaCidade = new Cidade(10);

            do{
                
                Tempo.PularTempo();
            }while(NomeDaCidade.Populacao.Count > 0);
        }
    }
}
