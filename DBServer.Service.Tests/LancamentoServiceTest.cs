using DbServer.Domain.Entities;
using DbServer.Domain.Interfaces;
using DbServer.Service;
using Moq;
using System;
using Xunit;

namespace DBServer.Service.Tests
{
    public class LancamentoServiceTest
    {
        private LancamentoService _LancamentoService;

        public LancamentoServiceTest()
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

            contaCorrenteRepository.Setup(x => x.SelectByNumber("222")).Returns((string i) =>
            {
                return new ContaCorrente()
                {
                    Id = 1,
                    Numero = "222"
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

            _LancamentoService = new LancamentoService(contaCorrenteRepository.Object, lancamentoRepository.Object);
        }

        [Fact]
        public void ShouldInsertObject()
        {
            var obj = new Lancamento() {
                NumeroContaOrigem = "111",
                NumeroContaDestino = "222",
                Valor = 100
            };
            var result = _LancamentoService.Insert(obj);
            Assert.Equal(100, result.Valor);
        }

      
    }
}
