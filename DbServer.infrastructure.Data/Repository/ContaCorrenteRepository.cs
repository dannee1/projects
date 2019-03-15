using DbServer.Data.Context;
using DbServer.Domain.Entities;
using DbServer.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbServer.Data.Repository
{
    public class ContaCorrenteRepository : IContaCorrenteRepository
    {
        private readonly SqlContext _context;

        public ContaCorrenteRepository(SqlContext context)
        {
            _context = context;
        }

        public void Insert(ContaCorrente obj)
        {
            _context.Set<ContaCorrente>().Add(obj);
            _context.SaveChanges();
        }

        public void Update(ContaCorrente obj)
        {
            _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            _context.Set<ContaCorrente>().Remove(Select(id));
            _context.SaveChanges();
        }

        public IList<ContaCorrente> SelectAll()
        {
            return _context.Set<ContaCorrente>().ToList();
        }

        public ContaCorrente Select(int id)
        {
            return _context.Set<ContaCorrente>().Find(id);
        }

        public ContaCorrente SelectByNumber(string numero)
        {
            return _context.Set<ContaCorrente>().FirstOrDefault(p => p.Numero == numero);
        }
    }
}
