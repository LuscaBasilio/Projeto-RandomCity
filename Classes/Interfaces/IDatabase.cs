using System.Collections.Generic;

namespace Cidadezinha.Classes.Interfaces
{
    public interface IDatabase <T>
    {
        void Adicionar(T elemento);
        T BuscarPorId(int id);
        List<T> Carregar();
        void Salvar();
        int Quantidade();
        void Gerar(int quantidade);
    }
}