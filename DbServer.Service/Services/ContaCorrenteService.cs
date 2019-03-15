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

    public class ContaCorrenteService : IContaCorrenteService
    {
        private IContaCorrenteRepository _repository;
        private ILancamentoRepository _lancamentoRepo;

        public ContaCorrenteService(IContaCorrenteRepository _contaCorrenteRepository, ILancamentoRepository _lancamentoRepository)
        {
            _repository = _contaCorrenteRepository;
            _lancamentoRepo = _lancamentoRepository;
        }

        public ContaCorrente Insert(ContaCorrente obj)
        {
            _repository.Insert(obj);
            return obj;
        }

        public ContaCorrente Update(ContaCorrente obj)
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

        public IList<ContaCorrente> Select() => _repository.SelectAll();

        public ContaCorrente SelectByNumber(string numero)
        {
            if (string.IsNullOrEmpty(numero))
                throw new ArgumentException("O numero não pode ser vazio.");

            var contaCorrente = _repository.SelectByNumber(numero);
            if (contaCorrente != null)
            {
                contaCorrente.Creditos = _lancamentoRepo.SumCredit(contaCorrente.Id);
                contaCorrente.Debitos = _lancamentoRepo.SumDebit(contaCorrente.Id);
            }
            return contaCorrente;
        }
    }
}
