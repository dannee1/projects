using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbServer.Api.DTO;
using DbServer.Domain.Entities;
using DbServer.Domain.Interfaces;
using DbServer.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DbServer.Api.Extentions;

namespace DbServer.Api.Controllers
{
    /// <summary>
    /// Post stest
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ContaCorrenteController : Controller
    {
        private readonly IContaCorrenteService _contaCorrenteService;
        private readonly IContaCorrenteRepository _contaCorrenteRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        public ContaCorrenteController(IContaCorrenteRepository contaCorrenteRepository, IContaCorrenteService contaCorrenteService, IMapper mapper)
        {
            _contaCorrenteRepository = contaCorrenteRepository;
            _contaCorrenteService = contaCorrenteService;
            _mapper = mapper;
        }
        
        /// <summary>
        /// Cria uma nova conta corrente
        /// </summary>
        /// <param name="item">Objeto com os dados da conta</param> 
        [HttpPost("CriarConta")]
        public IActionResult Post([FromBody] ContaCorrenteDTO item)
        {
            try
            {
                var obj = this._contaCorrenteService.Insert(item.Mapear<ContaCorrenteDTO, ContaCorrente>(this._mapper));
                return new ObjectResult(obj.Mapear<ContaCorrente, ContaCorrenteDTO>(this._mapper));
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Retorna o saldo da conta
        /// </summary>
        /// <param name="numero">Número da conta corrente ex: "000123"</param> 
        [HttpGet("ObterSaldo/{numero}")]
        public IActionResult Get(string numero)
        {
            try
            {
                return new ObjectResult(this._contaCorrenteService.SelectByNumber(numero));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}