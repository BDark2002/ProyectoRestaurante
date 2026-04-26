using System;
using System.Collections.Generic;
using System.Text;

namespace DL.Models
{
    public class DTOs
    {



        public class DtoSPGetAll
        {
            public int IdRestaurante { get; set; }
            public string Nombre { get; set; }
            public byte[] Logo { get; set; }
            public DateTime FechaApertura { get; set; }
            public DateTime FechaCierre { get; set; }

            //direccion

            public string Calle { get; set; }

            public string NumeroInterior { get; set; }

            public string NumeroExterior { get; set; }

            //colonia

            public string NombreColonia { get; set; }

            public string CodigoPostal { get; set; }

            //municipio

            public string NombreMunicipio { get; set; }

            //estado

            public string NombreEstado { get; set; }
        }

    }
}
