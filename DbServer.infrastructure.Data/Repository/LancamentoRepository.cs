using DbServer.Data.Context;
using DbServer.Domain.Entities;
using DbServer.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbServer.Data.Repository
{
    public class LancamentoRepository : ILancamentoRepository
    {
        private readonly SqlContext _context;

        public LancamentoRepository(SqlContext context)
        {
            _context = context;
        }

        public void Insert(Lancamento obj)
        {
            _context.Set<Lancamento>().Add(obj);
            _context.SaveChanges();
        }

        public void Update(Lancamento obj)
        {
            _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            _context.Set<Lancamento>().Remove(Select(id));
            _context.SaveChanges();
        }

        public IList<Lancamento> SelectAll()
        {
            return _context.Set<Lancamento>().ToList();
        }

        public IList<Lancamento> SelectByContaCorrente(int idConta)
        {
            return _context.Set<Lancamento>().Where(p => p.IDContaOrigem == idConta).ToList();
        }

        public Lancamento Select(int id)
        {
            return _context.Set<Lancamento>().Find(id);
        }

        public decimal SumCredit(int idConta)
        {
            return _context.Set<Lancamento>().Where(p => p.IDContaDestino == idConta).Sum(p => p.Valor);
        }

        public decimal SumDebit(int idConta)
        {
            return _context.Set<Lancamento>().Where(p => p.IDContaOrigem == idConta).Sum(p => p.Valor);
        }
    }
}
