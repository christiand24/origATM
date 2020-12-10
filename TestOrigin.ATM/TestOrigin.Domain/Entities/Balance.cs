using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestOrigin.Domain.Entities
{
    public class Balance
    {
        public int BalanceId { get; set; }
        [Required]
        public int TarjetaId { get; set; }
        [Required]
        public DateTime FechaOperacion { get; set; }
        public Tarjeta BalanceTarjeta { get; set; }
    }
}
