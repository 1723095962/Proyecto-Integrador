using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationPrueba.Entities
{
    public class Productos
    {
        public int ProductosId { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public DateTime FechaCompra { get; set; }
        public DateTime FechaCaducidad { get; set; }
        public float Precio { get; set; }
        public string Descripcion { get; set; }

    }
}
