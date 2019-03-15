using DbServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbServer.Domain.Interfaces
{
    public interface IContaCorrenteRepository
    {
        void Insert(ContaCorrente obj);

        void Update(ContaCorrente obj);

        void Remove(int id);

        ContaCorrente Select(int id);

        IList<ContaCorrente> SelectAll();

        ContaCorrente SelectByNumber(string numero);
    }
}
