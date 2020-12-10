using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestOrigin.ATM.Model
{
    public class TarjetaVM
    {
        public string Numero { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal Balance { get; set; }
    }
}
