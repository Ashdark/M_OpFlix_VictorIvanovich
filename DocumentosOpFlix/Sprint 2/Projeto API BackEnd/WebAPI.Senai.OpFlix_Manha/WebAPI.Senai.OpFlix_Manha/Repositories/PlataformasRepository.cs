using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Senai.OpFlix_Manha.Domains;
using WebAPI.Senai.OpFlix_Manha.Interfaces;

namespace WebAPI.Senai.OpFlix_Manha.Repositories
{
    public class PlataformasRepository : IPlataforma
    {
        public void Atualizar(Plataformas plataforma)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Plataformas plataformabuscada = ctx.Plataformas.Find(plataforma.IdPlataforma);
                plataformabuscada.Nome = plataforma.Nome;
                ctx.Plataformas.Update(plataformabuscada);
                ctx.SaveChanges();
            }
        }

        public void Cadastrar(Plataformas plataforma)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Plataformas.Add(plataforma);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Plataformas.Remove(ctx.Plataformas.FirstOrDefault(x => x.IdPlataforma == id));
                ctx.Plataformas.Remove(ctx.Plataformas.Find(id));
                ctx.SaveChanges();
            }
        }

        public List<Plataformas> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Plataformas.ToList();
            }
        }
    }
}
