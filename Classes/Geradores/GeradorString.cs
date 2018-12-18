using Cidadezinha.Classes.Enums;

namespace Cidadezinha.Classes.Geradores
{
    public static class GeradorString
    {
        public static string ReturnNome(Sexo sexo){
            if(sexo.Equals(Sexo.Feminino)){
                return "Claudia";
            }else{
                return "Claudio";
            }
        }
    }
}