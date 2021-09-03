using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationPrueba.Data;
using WebApplicationPrueba.Entities;

namespace WebApplicationPrueba.Controllers
{
    public partial class ConsultasController : Controller
    {
        ApplicationDbContext _context;

        public ConsultasController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public IEnumerable<Departamento> Departamentos()
        {
            return _context.Departamentos;
        }

        public IEnumerable<Empleado> Empleados()
        {
            //return _context.Empleados.OrderBy(e =>e.Apellido);
            //return _context.Empleados.OrderByDescending(e => e.Apellido);
            //return _context.Empleados
            //    .OrderBy(e => e.Nombre)
            //    .ThenBy(e => e.Apellido);

            var empleados = _context.Empleados.ToList();
            

            var menorRapido = empleados.Min(e => e.Salario); //no procedimental

            return empleados.OrderBy(e => e.NombreCompleto);
        }
    }
}
