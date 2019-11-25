using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Senai.OpFlix_Manha.Domains;
using WebAPI.Senai.OpFlix_Manha.Interfaces;

namespace WebAPI.Senai.OpFlix_Manha.Repositories
{
    public class LancamentosRepository : ILancamento
    {
        public void Atualizar(Sfs Lancamento)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Sfs sfBuscado = ctx.Sfs.Find(Lancamento.IdSf);
                sfBuscado.Titulo = Lancamento.Titulo;
                sfBuscado.Sinopse = Lancamento.Sinopse;
                sfBuscado.TempoD = Lancamento.TempoD;
                sfBuscado.IdCat = Lancamento.IdCat;
                sfBuscado.IdTipo = Lancamento.IdTipo;
                sfBuscado.FaixaEtaria = Lancamento.FaixaEtaria;
                sfBuscado.Descricao = Lancamento.Descricao;
                sfBuscado.Plataforma = Lancamento.Plataforma;
                ctx.Sfs.Update(sfBuscado);
                ctx.SaveChanges();
            }
        }

        public void Cadastrar(Sfs Lancamento)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Sfs.Add(Lancamento);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Sfs.Remove(ctx.Sfs.FirstOrDefault(x => x.IdSf == id));
                ctx.Sfs.Remove(ctx.Sfs.Find(id));
                ctx.SaveChanges();
            }
        }

        public List<Sfs> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Sfs.ToList();
            }
        }
        public List<Sfs> FiltrarPorPlataforma (int lol)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Sfs.Where(x => x.Plataforma == lol).ToList();
            }
        }
        public List<Sfs> FiltrarPorData (DateTime xisde)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Sfs.Where(x => x.DataLancamento.ToShortDateString() == xisde.ToShortDateString()).ToList();
            }
        }
    }
}
