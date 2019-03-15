using DbServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbServer.Service.Interface
{
    public interface IContaCorrenteService
    {
        ContaCorrente Insert(ContaCorrente obj);

        ContaCorrente Update(ContaCorrente obj);

        void Delete(int id);

        IList<ContaCorrente> Select();

        ContaCorrente SelectByNumber(string numero);
    }
}
