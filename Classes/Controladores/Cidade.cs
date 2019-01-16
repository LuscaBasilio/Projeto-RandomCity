using Cidadezinha.Classes.BancoDeDados;

namespace Cidadezinha.Classes.Controladores
{
    public class Cidade
    {
        public static PessoaDataBase Pessoas = new PessoaDataBase();
        public float AguaTotal;
        public float ComidaTotal;
        public float EnergiaTotal;
        public float AguaAtual;
        public float ComidaAtual;
        public float EnergiaAtual;

        public Cidade(){
            AguaTotal = 10;
            ComidaTotal = 10;
            EnergiaTotal = 10;
        }

        public void CalcularGastos(){

        }
        
    }
}