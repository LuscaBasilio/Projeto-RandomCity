using Cidadezinha.Classes.Controladores;
using Cidadezinha.Classes.Instancias;
using Projeto_RandomCity.Classes.Views;

namespace Projeto_RandomCity.Classes.Geradores
{
    public static class Acontecimentos
    {
        public static void Nascimento(Pessoa pessoa){
            ViewController.Resumo.Add($"{pessoa.Nome} {pessoa.Sobrenome} nasceu no dia {pessoa.DataNascimento.ToShortDateString()}");
        }
    }
}