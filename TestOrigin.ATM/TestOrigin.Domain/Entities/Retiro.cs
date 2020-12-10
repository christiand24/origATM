using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TestOrigin.Domain.Entities
{
    public class Retiro
    {
        public int RetiroId { get; set; }
        [Required]
        public int TarjetaId { get; set; }
        [Required]
        public DateTime FechaOperacion { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [Required]
        public decimal CantidadOperada { get; set; }
    
        public Tarjeta RetiroTarjeta { get; set; }
    }
}
