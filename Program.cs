using System;
using Cidadezinha.Classes.Controladores;

namespace Cidadezinha
{
    class Program
    {
        static void Main(string[] args)
        {
            do{
                
                Tempo.PularTempo();
            }while(Cidade.Populacao > 0);
        }
    }
}
