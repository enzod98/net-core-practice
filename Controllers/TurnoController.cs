using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Turnos.Models;

namespace Turnos.Controllers
{
    public class TurnoController : Controller
    {
        private readonly TurnosContext _context;
        private IConfiguration _configuration;
        public TurnoController(TurnosContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            ViewData["IdMedico"] = 
                new SelectList( from medico in _context.Medico.ToList()
                                select new { IdMedico = medico.IdMedico, NombreCompleto = $"{medico.Nombre} { medico.Apellido}" },
                                "IdMedico", "NombreCompleto");

            ViewData["IdPaciente"] = 
                new SelectList( from paciente in _context.Paciente.ToList()
                                select new { IdPaciente = paciente.IdPaciente, NombreCompleto = $"{paciente.Nombre} { paciente.Apellido}" },
                                "IdPaciente", "NombreCompleto");
            return View();
        }

        public JsonResult ObtenerTurnos(int idMedico)
        {
            var turnos = _context.Turno.Where( t => t.IdMedico == idMedico)
            .Select(t => new { 
                t.IdTurno, 
                t.IdMedico, 
                t.IdPaciente, 
                t.FechaHoraInicio, 
                t.FechaHoraFin, 
                Paciente= t.Paciente.Nombre + " " + t.Paciente.Apellido })

            .ToList();

            return Json(turnos);
        }

        [HttpPost]
        public JsonResult GrabarTurno(Turno turno)
        {
            var ok = false;
            try
            {
                _context.Turno.Add(turno);
                _context.SaveChanges();
                ok = true;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

            return Json(new {
                ok = ok
            });
        }

        [HttpPost]
        public JsonResult EliminarTurno(int idTurno)
        {
            var ok = false;
            try
            {
                var turno = _context.Turno.FirstOrDefault( t => t.IdTurno == idTurno);
                if( turno == null ) throw new Exception("El turno con este id no existe");
                
                _context.Turno.Remove(turno);
                _context.SaveChanges();
                ok = true;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

            return Json(new {
                ok = ok
            });
        }
    }
}