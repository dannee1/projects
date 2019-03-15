using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbServer.Api.DTO
{
    public class LancamentoDTO
    {
        public string NumeroContaOrigem { get; set; }
        public string NumeroContaDestino { get; set; }
        public decimal Valor { get; set; }
    }
}
