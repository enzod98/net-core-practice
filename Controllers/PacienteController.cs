using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turnos.Models;

namespace Turnos.Controllers
{
    public class PacienteController : Controller
    {
        private readonly TurnosContext _context;
        public PacienteController(TurnosContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Paciente.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if( id == null ) return NotFound();
            Paciente paciente = await _context.Paciente.FirstOrDefaultAsync(p => p.IdPaciente == id);
            if( paciente == null) return NotFound();
            return View(paciente);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken ] //Valida que la solicitud venga del formulario de la vista de nuestra app
        public async Task<IActionResult> Create([Bind("IdPaciente,Nombre,Apellido,Direccion,Telefono,Email")] Paciente paciente)
        {
            if( !ModelState.IsValid ) return View(paciente);

            _context.Add(paciente);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if( id == null ) return NotFound();
            Paciente paciente = await _context.Paciente.FindAsync(id);
            if (paciente == null) return NotFound();
            return View(paciente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( int? id, [Bind("IdPaciente,Nombre,Apellido,Direccion,Telefono,Email")] Paciente paciente)
        {
            if( id != paciente.IdPaciente ) return BadRequest();
            if( !ModelState.IsValid ) return View(paciente);
            _context.Update(paciente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if( id == null ) return NotFound();
            Paciente paciente = await _context.Paciente.FindAsync(id);
            if( paciente == null ) return NotFound();
            return View(paciente);
        }

        [HttpPost, ActionName("Delete")]//Definimos un Alias para el método
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if( id == null ) return NotFound();
            Paciente paciente = await _context.Paciente.FindAsync(id);
            _context.Remove(paciente);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}