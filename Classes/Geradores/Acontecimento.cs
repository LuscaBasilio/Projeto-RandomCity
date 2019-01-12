using Cidadezinha.Classes.Controladores;
using Cidadezinha.Classes.Instancias;
using Cidadezinha.Classes.Views;

namespace Cidadezinha.Classes.Geradores
{
    public static class Acontecimentos
    {
        public static void Nascimento(Pessoa pessoa){
            ViewController.Resumo.Add($"{pessoa.Nome} {pessoa.Sobrenome} nasceu no dia {pessoa.DataNascimento.ToShortDateString()}");
        }
        public static void Envelhecer(Pessoa pessoa){
            ViewController.Resumo.Add($"{pessoa.Nome} {pessoa.Sobrenome} agora tem {pessoa.Idade} anos");
        }

        public static void Acasalar(Pessoa pessoa,Pessoa par){
            ViewController.Resumo.Add($"");
        }
        public static void Morte(Pessoa pessoa){
            ViewController.Resumo.Add($"{pessoa.Nome} {pessoa.Sobrenome} morreu aos {pessoa.Idade} anos");
        }
    }
}