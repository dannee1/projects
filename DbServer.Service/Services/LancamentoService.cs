using DbServer.Domain.Entities;
using DbServer.Domain.Interfaces;
using DbServer.Service.Interface;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using DbServer.Data.Repository;
using System.Linq;

namespace DbServer.Service
{
    public class LancamentoService : ILancamentoService
    {
        private IContaCorrenteRepository _contaCorrenteRepository;
        private ILancamentoRepository _repository;

        public LancamentoService(IContaCorrenteRepository contaCorrenteRepository, ILancamentoRepository _lancamentoRepository)
        {
            _contaCorrenteRepository = contaCorrenteRepository;
            _repository = _lancamentoRepository;
        }

        public Lancamento Insert(Lancamento obj)
        {
            var contaOrigem = _contaCorrenteRepository.SelectByNumber(obj.NumeroContaOrigem);
            var contaDestino = _contaCorrenteRepository.SelectByNumber(obj.NumeroContaDestino);
            obj.IDContaOrigem = contaOrigem.Id;
            obj.IDContaDestino = contaDestino.Id;
            _repository.Insert(obj);
            return obj;
        }

        public Lancamento Update(Lancamento obj)
        {
            _repository.Update(obj);
            return obj;
        }

        public void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("O Id não pode ser zero.");

            _repository.Remove(id);
        }

        public IList<Lancamento> Select() => _repository.SelectAll();

        public Lancamento Select(int id)
        {
            return _repository.Select(id);
        }
    }
}
