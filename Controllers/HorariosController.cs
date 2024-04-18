using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Login.Models;
using Login.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace Empleados.Controllers{
        public class HorariosController : Controller{
        
        public readonly  DatabaseContext _context;

        public HorariosController( DatabaseContext context)  // define el constructor construnctor
        {
            _context = context;   //p - v
        }

        public async Task<IActionResult> Index(){
            return View(await _context.Horarios.ToListAsync());
        }

        // public async Task<IActionResult> Create(int Id){
        //     var c = await _context.Horarios.FindAsync(Id);
        //     var nombre = await _context.Empleados.FirstOrDefaultAsync(em => em.id == Id);
        //     ViewBag.Nombre = nombre.nombre;
        //     ViewBag.Id = nombre.id;
        //     return View(c);
        // }

        public async Task<IActionResult> Create(){
            return View();
        }


        [HttpPost]
        public IActionResult Create(Horario h){
            _context.Horarios.Add(h);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Horario h){
            _context.Horarios.Update(h);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        }
}
