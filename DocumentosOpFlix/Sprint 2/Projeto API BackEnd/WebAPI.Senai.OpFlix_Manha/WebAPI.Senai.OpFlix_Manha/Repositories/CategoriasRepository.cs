using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Senai.OpFlix_Manha.Domains;
using WebAPI.Senai.OpFlix_Manha.Interfaces;

namespace WebAPI.Senai.OpFlix_Manha.Repositories
{
    public class CategoriasRepository : ICategoria
    {
        public void Atualizar(Categorias categoria)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Categorias categoriabuscada = ctx.Categorias.Find(categoria.IdCat);
                categoriabuscada.NomeCat = categoria.NomeCat;
                ctx.Categorias.Update(categoriabuscada);
                ctx.SaveChanges();
            }
        }

        public void Cadastrar(Categorias categoria)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Categorias.Add(categoria);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Categorias.Remove(ctx.Categorias.FirstOrDefault(x => x.IdCat == id));
                ctx.Categorias.Remove(ctx.Categorias.Find(id));
                ctx.SaveChanges();
            }
        }

        public List<Categorias> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Categorias.ToList();
            }
        }
    }
}
