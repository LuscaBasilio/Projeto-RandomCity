using System.Collections.Generic;
using System.IO;
using System.Linq;
using Cidadezinha.Classes.Enums;

namespace Cidadezinha.Classes.BancoDeDados
{
    public class NomeDataBase
    {
        /// <summary>
        /// Caminho onde fica armazenado o banco de dados onde está salvo todos os nomes masculinos
        /// </summary>
        private const string CaminhoMasculino = @"Database/NomesMasculinos.txt";
        /// <summary>
        /// Caminho onde fica armazenado o banco de dados onde está salvo todos os nomes Femininos
        /// </summary>
        private const string CaminhoFeminino = @"Database/NomesFemininos.txt";
        /// <summary>
        /// Caminho onde fica armazenado o banco de dados onde está salvo todos os sobrenomes
        /// </summary>
        private const string CaminhoSobrenome = @"Database/Sobrenomes.txt";

        public readonly List<string> ListaMasculino , ListaFeminino , ListaSobrenome;

        /// <summary>
        /// Construtor unico do NomeDatabase  
        /// Importa todos os itens dos arquivos para as listas de nomes/sobrenomes
        /// </summary>
        public NomeDataBase(){
            ListaMasculino = ImportarTexto(CaminhoMasculino);
            ListaFeminino = ImportarTexto(CaminhoFeminino);
            ListaSobrenome = ImportarTexto(CaminhoSobrenome);
        }
        /// <summary>
        /// Retorna um valor aleatorio da Lista selecionada
        /// </summary>
        /// <param name="sexo">Define qual tipo de nome será retornado</param>
        /// <returns>Retorna um nome baseado no sexo Selecionadp</returns>
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
        /// <summary>
        /// Metodo uncio pra retornar um sobrenome aleatorio  
        /// Apenas usado pelos 10 primeiros cidadões gerados
        /// </summary>
        /// <returns>Retorna um sobrenome aleatorio</returns>
        public string PegarAleatorio(){
            System.Random rdm = new System.Random();
            return ListaSobrenome.ToArray()[rdm.Next(0,ListaSobrenome.Count)];
        }

        /// <summary>
        /// Retorna uma lista de strings importadas de um arquivo.txt
        /// </summary>
        /// <param name="arquivo">Local do arquivo que será importado e retornado em forma de lista</param>
        /// <returns>Retorna uma lista com todas strings do arquivo selecionado</returns>
        public List<string> ImportarTexto(string arquivo) => File.ReadAllLines(arquivo).ToList();

    }
}