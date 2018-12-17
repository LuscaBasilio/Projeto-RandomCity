using System;
using System.Collections.Generic;
using Cidadezinha.Classes.Enums;
using Cidadezinha.Classes.Profissão;

namespace Cidadezinha.Classes.Instancias
{
    public class Pessoa
    {
        #region Imutavel
        public readonly string Nome , Sobrenome;
        public readonly DateTime DataNascimento;
        public DateTime DataObito;
        public readonly Sexo Sexo_;
        #endregion

        #region Mutavel
        public int Idade;
        public bool Vivo;
        public int sorte;// -50 | 50
        public int Felicidade;//-100 | 100
        public Profissao Profissao_;
        public int Conduta; // -100 | 100
        #endregion
    }
}