using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

using Cidadezinha.Classes.Instancias;
using Cidadezinha.Classes.Interfaces;

namespace Cidadezinha.Classes.BancoDeDados
{
    public class PessoaDataBase : IDatabase<Pessoa>
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
        
        public void Gerar(int populacao){
            if(Populacao == null){
                Populacao = new List<Pessoa>();
                for (int i = 0; i < populacao; i++)
                {
                    Populacao.Add(new Pessoa());
                }
            }
        }

        public void Adicionar(Pessoa pessoa){
            Populacao.Add(pessoa);
            Salvar();
        }

        public List<Pessoa> Carregar(){
            byte[] bytes = File.ReadAllBytes(CaminhoCidade);
            MemoryStream memoria = new MemoryStream();
            memoria.Read(bytes);
            BinaryFormatter leitor = new BinaryFormatter();  
            return leitor.Deserialize(memoria) as List<Pessoa>;
        }

        public void Salvar(){

        }
        
        public Pessoa BuscarPorId(int id){
            return Populacao.Find(item => item.ID == id);
        }
        
        public int Quantidade() => Populacao.Count(item => item.Vivo);

        public List<Pessoa> PopulacaoViva() => Populacao.FindAll(item => item.Vivo);

    }
}