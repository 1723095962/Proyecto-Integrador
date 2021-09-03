using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationPrueba.Entities
{
    public class Hijo
    {
        public int HijoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        [NotMapped]
        public string NombreCompleto { get { return $"{Nombre} {Apellido}"; } }

        [NotMapped]
        public Double Edad { get { return DateTime.Now.Subtract(Nacimiento).TotalDays / 365; } }

        [NotMapped]
        public bool EsCarga { get { return Edad < 18; } }

        public DateTime Nacimiento { get; set; }

        public Empleado Ancestro { get; set; }
    }
}