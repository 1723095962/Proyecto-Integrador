using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationPrueba.Entities
{
    public class Proveedor
    {
        public int ProveedorId { get; set; }
        public int Codigo { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Producto { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }

        [NotMapped]
        public string NombreCompleto { get { return $"{Nombre} {Apellido}"; } }

        public float Salario { get; set; }
        public DateTime Fecha_nacimiento { get; set; }

    }
}
