using DbServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbServer.Domain.Interfaces
{
    public interface ILancamentoRepository
    {
        void Insert(Lancamento obj);

        void Update(Lancamento obj);

        void Remove(int id);

        Lancamento Select(int id);

        IList<Lancamento> SelectAll();

        IList<Lancamento> SelectByContaCorrente(int idConta);

        decimal SumCredit(int idConta);
        decimal SumDebit(int idConta);

    }
}
