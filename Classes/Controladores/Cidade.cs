using System.Collections.Generic;
using Cidadezinha.Classes.Instancias;

namespace Cidadezinha.Classes.Controladores
{
    public class Cidade
    {
        public List<Pessoa> Populacao;
        public float AguaTotal, ComidaTotal, EnergiaTotal;
        public float AguaAtual, ComidaAtual, EnergiaAtual;

        public Cidade(int populacao){
            Populacao = new List<Pessoa>();
            for (int i = 0; i < populacao; i++)
            {
                Populacao.Add(new Pessoa());
            }
        }

        public void CalcularGastos(){

        }
    }
}