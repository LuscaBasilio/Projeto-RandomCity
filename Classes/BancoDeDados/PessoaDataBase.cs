using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Cidadezinha.Classes.Instancias;

namespace Projeto_RandomCity.Classes.BancoDeDados
{
    public class PessoaDataBase
    {
        private const string CaminhoCidade = @"Database/Cidade.dat";
        public List<Pessoa> Populacao{
            get;
            private set;
        }

        public PessoaDataBase(){
            if(File.Exists(CaminhoCidade)){

            }else{
                Gerar(10);
            }
        }
        
        private void Gerar(int populacao){
            Populacao = new List<Pessoa>();
            for (int i = 0; i < populacao; i++)
            {
                Populacao.Add(new Pessoa(Populacao.Count+1));
            }
        }

        public void AdicionarCidadao(Pessoa pessoa){
            Populacao.Add(pessoa);
            Salvar();
        }

        private List<Pessoa> Carregar(){
            byte[] bytes = File.ReadAllBytes(CaminhoCidade);
            MemoryStream memoria = new MemoryStream();
            memoria.Read(bytes);
            BinaryFormatter leitor = new BinaryFormatter();  
            return leitor.Deserialize(memoria) as List<Pessoa>;
        }

        private void Salvar(){

        }
        public Pessoa ProcurarPorID(int id){
            Pessoa P = null;
            return P;
        }
    }
}