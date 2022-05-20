using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turnos.Models;

namespace Turnos.Controllers
{
    public class EspecialidadController : Controller
    {
        private readonly TurnosContext _context;
        public EspecialidadController(TurnosContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Especialidad.ToListAsync());
        }
        
        public async Task<IActionResult> Edit(int? id)
        {
            if( id == null) return NotFound();

            var especialidad = await _context.Especialidad.FindAsync(id);
            
            if( especialidad == null) return NotFound();

            return View(especialidad);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("IdEspecialidad,Descripcion")] Especialidad especialidad)
        {
            if( id != especialidad.IdEspecialidad) return BadRequest();
            
            if(ModelState.IsValid) //Si el bind que hicimos en los parámetreos fue correcto, esto va ser true
            {
                _context.Update(especialidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(especialidad);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if( id == null) return NotFound();
            
            Especialidad especialidad = await _context.Especialidad.FirstOrDefaultAsync( especialidad => especialidad.IdEspecialidad == id);

            if( especialidad == null ) return NotFound();

            return View(especialidad);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Especialidad especialidad = await _context.Especialidad.FindAsync(id);
            if( especialidad == null ) return NotFound();

            _context.Especialidad.Remove(especialidad);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("IdEspecialidad,Descripcion")] Especialidad especialidad)
        {
            if(ModelState.IsValid)
            {
                _context.Add(especialidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(especialidad);
        }
    }
}