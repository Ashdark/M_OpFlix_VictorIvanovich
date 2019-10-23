using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Senai.OpFlix_Manha.Domains;
using WebAPI.Senai.OpFlix_Manha.Interfaces;

namespace WebAPI.Senai.OpFlix_Manha.Repositories
{
    public class FavoritosRepository : IFavorito
    {
        public List<Favoritos> BuscarPorUsuario(int it)
        {
            using(OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Favoritos.Where(x => x.IdUsuario == it).Include(x => x.SF).ToList();
            }
        }

        public void Cadastrar(Favoritos favorito)
        {
            using(OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Favoritos.Add(favorito);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int Int,int Int2)
        {
            using (OpFlixContext ctx = new OpFlixContext())
                {
                ctx.Favoritos.Remove(ctx.Favoritos.Find(Int, Int2));
                ctx.SaveChanges();
                }
        }

        public List<Favoritos> FiltrarPorData(DateTime Data)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Favoritos.Where(x => x.SF.DataLancamento == Data).Include(X => X.SF).ToList();
            }
        }

        public List<Favoritos> FiltrarPorPlataforma(int lol)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Favoritos.Where(x => x.SF.Plataforma == lol).Include(X => X.SF).ToList();
            }
        }

        public List<Favoritos> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Favoritos.Include(x => x.Usuario).Include(x => x.SF).ToList();
            }
        }
    }
}
