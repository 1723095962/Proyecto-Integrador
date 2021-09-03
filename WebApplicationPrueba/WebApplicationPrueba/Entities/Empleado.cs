 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationPrueba.Entities
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        public string Cedula { get; set; }
        public string Titulo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        [NotMapped]
        public string NombreCompleto { get { return $"{Nombre} {Apellido}, {Titulo}"; } }

        public float Salario { get; set; }
        public DateTime Nacimiento { get; set; }

        [NotMapped]
        public Double Edad { get { return DateTime.Now.Subtract(Nacimiento).TotalDays / 365; } }

        public Departamento Departamento { get; set; }
        public Conyuge Conyuge { get; set; }
        public List<Hijo> Dependientes { get; set; }

        public List<Curso> Cursos { get; set; }

        public List<Horario> Horarios { get; set; }
        public int HijoId { get; internal set; }
    }
}
