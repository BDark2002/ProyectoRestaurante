using System;
using System.Collections.Generic;
using System.Text;

namespace ML
{
    public class Restaurante
    {

        public int IdRestaurante { get; set; }
        public string Nombre { get; set; }
        public byte[]? Logo { get; set; }
        public DateTime? FechaApertura { get; set; }
        public DateTime? FechaCierre { get; set; }
        public ML.Direccion Direccion { get; set; }
        public List<object> Restaurantes { get; set; }
    }
}
