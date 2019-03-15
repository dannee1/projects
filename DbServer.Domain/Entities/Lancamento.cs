using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DbServer.Domain.Entities
{
    public class Lancamento : BaseEntity
    {
        public int IDContaOrigem { get; set; }
        public int IDContaDestino { get; set; }
        public decimal Valor { get; set; }

        [NotMapped]
        public string NumeroContaOrigem { get; set; }
        [NotMapped]
        public string NumeroContaDestino { get; set; }
    }
}
