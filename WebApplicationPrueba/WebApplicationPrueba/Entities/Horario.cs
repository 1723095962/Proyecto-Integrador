using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationPrueba.Entities
{
    public class Horario 
    {
        public int HorarioId { get; set; }
        public string AsignarEntrada { get; set; }
        public string AsignarSalida { get; set; }
        public string HoraEntrada { get; set; }
        public string HoraSalida { get; set; }
        public string ObtenerHorario { get; set; }

        public Empleado HorasTrabajo { get; set; }
    }
}
