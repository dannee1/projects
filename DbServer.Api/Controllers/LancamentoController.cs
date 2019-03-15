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
    public class LancamentoController : Controller
    {
        private readonly ILancamentoService _lancamentoService;
        private readonly ILancamentoRepository _lancamentoRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        public LancamentoController(ILancamentoRepository lancamentoRepository, ILancamentoService lancamentoService, IMapper mapper)
        {
            _lancamentoRepository = lancamentoRepository;
            _lancamentoService = lancamentoService;
            _mapper = mapper;
        }

        /// <summary>
        /// Cria um novo lançamento
        /// </summary>
        /// <param name="item">Conta de Origem, Destino e valor para transação</param> 
        [HttpPost("CriarLancamento")]
        public IActionResult Post([FromBody] LancamentoDTO item)
        {
            try
            {               
                var obj = this._lancamentoService.Insert(item.Mapear<LancamentoDTO, Lancamento>(this._mapper));
                return new ObjectResult(obj.Mapear<Lancamento, LancamentoDTO>(this._mapper));
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

    }
}