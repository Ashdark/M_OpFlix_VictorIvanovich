using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Senai.OpFlix_Manha.Domains;

namespace WebAPI.Senai.OpFlix_Manha.Interfaces
{
    public interface ILocalizacoes
    {

        void Cadastrar(Localizacoes localizacao);
        List<Localizacoes> Listar();

    }
}
