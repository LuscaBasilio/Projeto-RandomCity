using System;
using System.Collections.Generic;
using Cidadezinha.Classes.Enums;

namespace Cidadezinha.Classes.Instancias
{
    public class Pessoa
    {
        #region Imutavel
        public readonly string Nome , Sobrenome;
        public readonly DateTime DataNascimento;
        public DateTime DataObito;
        #endregion
        #region Mutavel
        public int Idade;
        public readonly Sexo Sexo_;
        public bool Vivo;
        #endregion
    }
}