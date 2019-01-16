using System;
using Cidadezinha.Classes.Instancias;

namespace Cidadezinha.Classes.Controladores
{
    public static class ValidacaoPessoa
    {

        public static string VerificarFelicidade(int felicidade){
            string Felicidade = "Feliz";
            return Felicidade;
        }   

        public static void VerificarInteracao(Pessoa pessoa1,Pessoa pessoa2 , out int valormin , out int valormax){
            Random rdm = new Random();

            int Felicidade = ((pessoa1.Felicidade + pessoa2.Felicidade) / 100)/2 ;

            switch(VerificarRelacionamento(pessoa1,pessoa2)){
                case "Conhecidos":
                case "Desconhecidos":
                    valormin = -1 * (int)Tempo.Pulos + Felicidade;
                    valormax = 3 * (int)Tempo.Pulos + Felicidade;
                    break;
                case "Colegas":
                    valormin = -1 *(int)Tempo.Pulos + Felicidade;
                    valormax = 10 * (int)Tempo.Pulos + Felicidade;
                    break;
                case "Amigos":
                    valormin = -1 *(int)Tempo.Pulos + Felicidade;
                    valormax = 10 * (int)Tempo.Pulos + Felicidade;
                    break;
                case "Melhores Amigos":
                    valormin = -1 *(int)Tempo.Pulos + Felicidade;
                    valormax = 10 * (int)Tempo.Pulos + Felicidade;
                    break;
                case "Conjuge":
                    valormin = -1 *(int)Tempo.Pulos + Felicidade;
                    valormax = 20 * (int)Tempo.Pulos + Felicidade;
                    break;
                case "Inimigos":
                default:
                    valormin = -1 * (int)Tempo.Pulos + Felicidade;
                    valormax = 1 * (int)Tempo.Pulos + Felicidade;
                    break;

            }
        }
        public static string VerificarConduta(int conduta){
            string Conduta = "Padrão";

            return Conduta;
        }
        /// <summary>
        /// Verifica o valor de relacionamento entre 2 pessoas pegando ambos e dividindo por 2  
        /// O retorno é definido pelas seguintes regras  
        /// Entre -200 e -1 : **Inimigos**  
        /// Entre 0 e 19    : **Conhecidos**  
        /// Entre 20 e 50   : **Colegas**   
        /// Entre 50 e 100  : **Amigos**
        /// Entre 100 e 150 : **Melhores amigos**  
        /// 150 Ou mais     : **Conjuge**
        /// caso eles não possuam um valor (null) para o relacionamento .false.false .será retornado **Desconhecidos**
        /// </summary>
        /// <param name="pessoa1"></param>
        /// <param name="pessoa2"></param>
        /// <returns>Retorna em forma de string o nivel do relacionamento entre 2 pessoas</returns>
        public static string VerificarRelacionamento(Pessoa pessoa1,Pessoa pessoa2){
            int relacionamento;
            if(pessoa1.Conhece(pessoa2.ID)){
                relacionamento = (pessoa1.VerRelacionamento(pessoa2.ID) + pessoa2.VerRelacionamento(pessoa1.ID) ) / 2;
                
                if(relacionamento>-200 && relacionamento<0){
                    return "Inimigos";
                }else if(relacionamento >= 0 && relacionamento <=200){
                    if(relacionamento < 20){
                        return "Conhecidos";
                    }else if(relacionamento < 50){
                        return "Colegas";
                    }else if(relacionamento < 100){
                        return "Amigos";
                    }else if(relacionamento == 150){
                        return "Melhores Amigos";
                    }else{
                        return "Conjuge";
                    }
                }
            }
            return "Desconhecidos";
        }
    }
}