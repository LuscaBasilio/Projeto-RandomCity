using Cidadezinha.Classes.Enums;

namespace Cidadezinha.Classes.Interfaces
{
    public interface IEntidade
    {
        Fase VerificarFase();
        void Envelhecer();
        void Morte();
    }
}