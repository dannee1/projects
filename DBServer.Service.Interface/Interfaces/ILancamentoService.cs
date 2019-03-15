using DbServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbServer.Service.Interface
{
    public interface ILancamentoService
    {
        Lancamento Insert(Lancamento obj);

        Lancamento Update(Lancamento obj);

        void Delete(int id);

        IList<Lancamento> Select();

        Lancamento Select(int id);
       
    }
}
