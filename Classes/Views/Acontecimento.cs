using Cidadezinha.Classes.Controladores;
using Cidadezinha.Classes.Instancias;
using Cidadezinha.Classes.Views;

namespace Cidadezinha.Classes.Views
{
    public static class Acontecimentos
    {
        public static void Nascimento(Pessoa pessoa){
            ViewController.ResumoNascimentos.Add($"{pessoa.Nome} {pessoa.Sobrenome} nasceu no dia {pessoa.DataNascimento.ToShortDateString()}");
        }
        public static void Envelhecer(Pessoa pessoa){
            ViewController.ResumoAcontecimentos.Add($"{pessoa.Nome} {pessoa.Sobrenome} agora tem {pessoa.Idade} anos");
        }
        public static void Acasalar(Pessoa pai,Pessoa mae){
           ViewController.ResumoAcontecimentos.Add($"{pai.Nome} {pai.Sobrenome} e {mae.Nome} {mae.Sobrenome} tiveram um filho!");
        }
        public static void Morte(Pessoa pessoa){
            ViewController.ResumoMortes.Add($"{pessoa.Nome} {pessoa.Sobrenome} morreu aos {pessoa.Idade} anos");
        }
        public static void MostrarRelacionamento(Pessoa pessoa,Pessoa par,string relacionamento){
            ViewController.ResumoAcontecimentos.Add($"{pessoa.Nome} {pessoa.Sobrenome} e {par.Nome} {par.Sobrenome} agora são {relacionamento}");
        }
    }
}