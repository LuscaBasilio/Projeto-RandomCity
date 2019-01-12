namespace Cidadezinha.Classes.Controladores
{
    public static class ValidacaoPessoa
    {

        public static string VerificarFelicidade(int felicidade){
            string Felicidade = "Feliz";
            return Felicidade;
        }   
        public static string VerificarConduta(int conduta){
            string Conduta = "Padrão";

            return Conduta;
        }
        /// <summary>
        /// Verifica o valor de relacionamento entre 2 pessoas pegando ambos e dividindo por 2  
        /// O retorno é definido pelas seguintes regras  
        /// Entre -100 e -1 : **Inimigos**  
        /// Entre 0 e 19    : **Desconhecidos**  
        /// Entre 20 e 99   : **Conhecidos**   
        /// Entre 100 e 200 : **Amigos**
        /// 200             : **Melhores amigos**  
        /// Parentes  
        /// Entre 200 e 400 : **Conjuge**
        /// </summary>
        /// <param name="pessoa1"></param>
        /// <param name="pessoa2"></param>
        /// <returns>Retorna em forma de string o nivel do relacionamento entre 2 pessoas</returns>
        public static string VerificarRelacionamento(int pessoa1,int pessoa2){
            string Relacionamento = null;
            int relacionamento = pessoa1 + pessoa2 / 2;

            if(relacionamento>-100 && relacionamento<0){
                Relacionamento = "Inimigos";
            }else if(relacionamento >= 0 && relacionamento <=200){
                if(relacionamento < 20){
                    Relacionamento = "Desconhecidos";
                }else if(relacionamento < 100){
                    Relacionamento = "Conhecidos";
                }else if(relacionamento < 200){
                    Relacionamento = "Amigos";
                }else if(relacionamento == 200){
                    Relacionamento = "Melhores Amigos";
                }else{
                    Relacionamento = "Conjuge";
                 }
            }
            return Relacionamento;
        }
    }
}