using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationPrueba.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }

        [NotMapped]
        public string NombreCompleto { get { return $"{Nombre} {Apellido}"; } }
        public DateTime Fecha_nacimiento { get; set; }


    }
}
