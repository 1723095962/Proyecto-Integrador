using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationPrueba.Entities
{
    public class Conyuge
    {
        public int ConyugeId { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        [NotMapped]
        public string NombreCompleto { get { return $"{Nombre} {Apellido}"; } }

        [ForeignKey("Empleado")]
        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }
    }
}