using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Senai.OpFlix_Manha.Domains;
using WebAPI.Senai.OpFlix_Manha.Interfaces;

namespace WebAPI.Senai.OpFlix_Manha.Repositories
{
    public class LocalizacoesRepository : ILocalizacoes
    {
        private readonly IMongoCollection<Localizacoes> _localizacoes;


        public LocalizacoesRepository()
        {

            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("m_opflix");
            _localizacoes = database.GetCollection<Localizacoes>("localizacoes");

        }



        public void Cadastrar(Localizacoes Localizacao)
        {
            _localizacoes.InsertOne(Localizacao);
        }

        public List<Localizacoes> Listar()
        {
            return _localizacoes.Find(l => true).ToList();
        }
    }
}
