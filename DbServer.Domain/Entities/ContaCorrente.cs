using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DbServer.Domain.Entities
{
    public class ContaCorrente : BaseEntity
    {
        public string Numero { get; set; }

        [NotMapped]
        public decimal Creditos { get; set; }

        [NotMapped]
        public decimal Debitos { get; set; }

        [NotMapped]
        public decimal Saldo { get { return Creditos - Debitos; } }
    }
}
