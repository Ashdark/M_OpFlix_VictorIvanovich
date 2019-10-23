using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Senai.OpFlix_Manha.Domains;
using WebAPI.Senai.OpFlix_Manha.Interfaces;

namespace WebAPI.Senai.OpFlix_Manha.Repositories
{
    public class TiposSfRepository : ITipoSf
    {
        public List<TiposSf> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.TiposSf.ToList();
            }
        }
    }
}
