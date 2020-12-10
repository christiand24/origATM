using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TestOrigin.Domain.Entities
{
    public class Tarjeta
    {
        public int TarjetaId { get; set; }
        [MaxLength(16)]
        [Required]
        public string Numero { get; set; }
        [Required]
        public int PIN { get; set; }
        [Required]
        public int Reintentos { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [Required]
        public decimal Balance { get; set; }
        [Required]
        public bool Bloqueada { get; set; }
        [Required]
        public DateTime FechaVencimiento { get; set; }
    }
}
