using AutoMapper;
using DbServer.Api.Controllers;
using DbServer.Domain.Entities;
using DbServer.Domain.Interfaces;
using DbServer.Service.Interface;
using Moq;
using System;
using Xunit;

namespace DBServer.Api.Test
{
    public class ContaCorrenteControllerTest
    {
        private ContaCorrenteController controller;
        private readonly IMapper _mapper;

        public ContaCorrenteControllerTest(IMapper mapper)
        {
            _mapper = mapper;

            var contaCorrenteRepository = new Mock<IContaCorrenteRepository>();
            contaCorrenteRepository.Setup(x => x.SelectByNumber("111")).Returns((string i) =>
            {
                return new ContaCorrente()
                {
                    Id = 1,
                    Numero = "111"
                };
            });

            var contaCorrenteService = new Mock<IContaCorrenteService>();
            contaCorrenteRepository.Setup(x => x.SelectByNumber("111")).Returns((string i) =>
            {
                return new ContaCorrente()
                {
                    Id = 1,
                    Numero = "111"
                };
            });

            controller = new ContaCorrenteController(contaCorrenteRepository.Object, contaCorrenteService.Object, _mapper);

        }

        [Fact]
        public void ShoudReturnObject()
        {
            var obj = controller.Get("111");
            Assert.NotNull(obj);

        }
    }
}
