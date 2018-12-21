using System.Collections.Generic;
using System.IO;
using System.Linq;
using Cidadezinha.Classes.Enums;

namespace Cidadezinha.Classes.BancoDeDados
{
    public class NomeDataBase
    {
        private const string CaminhoMasculino = @"Database/NomesMasculinos.txt";
        private const string CaminhoFeminino = @"Database/NomesFemininos.txt";
        private const string CaminhoSobrenome = @"Database/Sobrenomes.txt";

        public readonly List<string> ListaMasculino , ListaFeminino , ListaSobrenome;

        public NomeDataBase(){
            ListaMasculino = ImportarTexto(CaminhoMasculino);
            ListaFeminino = ImportarTexto(CaminhoFeminino);
            ListaSobrenome = ImportarTexto(CaminhoSobrenome);
        }
        public string PegarAleatorio(Sexo sexo){
            int t ;
            System.Random rdm = new System.Random();
            switch (sexo)
            {
                case Sexo.Masculino:
                    t = ListaMasculino.Count;
                    return ListaMasculino.ToArray()[rdm.Next(0,t)];
                default:
                    t = ListaFeminino.Count;
                    return ListaFeminino.ToArray()[rdm.Next(0,t)];
            }
        }

        public string PegarAleatorio(){
            System.Random rdm = new System.Random();
            return ListaSobrenome.ToArray()[rdm.Next(0,ListaSobrenome.Count)];
        }

        public List<string> ImportarTexto(string arquivo) => File.ReadAllLines(arquivo).ToList();

    }
}