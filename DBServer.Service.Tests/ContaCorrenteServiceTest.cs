using DbServer.Domain.Entities;
using DbServer.Domain.Interfaces;
using DbServer.Service;
using Moq;
using System;
using Xunit;

namespace DBServer.Service.Tests
{
    public class ContaCorrenteServiceTest
    {
        private ContaCorrenteService _contaCorrenteService;

        public ContaCorrenteServiceTest()
        {
            var contaCorrenteRepository = new Mock<IContaCorrenteRepository>();
            contaCorrenteRepository.Setup(x => x.SelectByNumber("111")).Returns((string i) =>
            {
                return new ContaCorrente()
                {
                    Id = 1,
                    Numero = "111"
                };
            });

            var lancamentoRepository = new Mock<ILancamentoRepository>();
            lancamentoRepository.Setup(x => x.Select(1)).Returns((int i) =>
            {
                return new Lancamento()
                {
                    Id = 1,
                    IDContaOrigem = 1,
                    IDContaDestino = 2,
                    Valor = 200,
                };
            });

            _contaCorrenteService = new ContaCorrenteService(contaCorrenteRepository.Object, lancamentoRepository.Object);
        }

        [Fact]
        public void ShouldInsertObject()
        {
            var obj = new ContaCorrente() {
                Numero = "333"
            };
            var result = _contaCorrenteService.Insert(obj);
            Assert.Equal("333", result.Numero);
        }

        [Fact]
        public void ShouldReturnObject()
        {
            var result = _contaCorrenteService.SelectByNumber("111");
            Assert.Equal("111", result.Numero);
        }

        [Fact]
        public void ShouldNotReturnObject()
        {
            var result = _contaCorrenteService.SelectByNumber("222");
            Assert.Null(result);
        }
    }
}
