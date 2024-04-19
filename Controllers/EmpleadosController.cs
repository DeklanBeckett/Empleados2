
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Login.Models;
using Login.Data; // Asegúrate de tener el namespace correcto

namespace Empleados.Controllers
{
public class EmpleadosController : Controller     //herencia de la clase controller 
{
   public readonly  DatabaseContext _context; // llamar base de datos   //_context parametro

    public EmpleadosController( DatabaseContext context)  // define el constructor construnctor
    {
        _context = context;   //p - v
    }

    // Acción para mostrar la lista de trabajos
    public async Task<IActionResult> Index2()  //get
    {   
        @ViewBag.Nombre =  HttpContext.Session.GetString("Nombre");
        @ViewBag.Id =  HttpContext.Session.GetInt32("Id");
        var Emp = await _context.Empleados.ToListAsync();
        return View(Emp);   //se llama a la tabla
    }

    public IActionResult Create( )
{
    return View();
}

[HttpPost]
public  IActionResult Create(Empleado y){
    _context.Empleados.Add(y);
     _context.SaveChanges();
    return RedirectToAction("Index", "Landing");

}

  // Acción para editar un trabajo existente
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var J = await _context.Empleados.FirstOrDefaultAsync(J=> J.id == id);
        if (J == null)
        {
            return NotFound();
        }

        return View(J);
    }

    [HttpPost]

    public async Task<IActionResult> Edit(int id, Empleado Emp)
    {
        if (id != Emp.id)
        {
            return NotFound();
        }

        if (ModelState.IsValid) //validacion de  reglas  clase job  
        {
            _context.Update(Emp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(Emp);
    }

    // Acción para eliminar un trabajo

public IActionResult Eliminar(){

    
            return View();
        }

public IActionResult Delete(int? id)
{

    var Emp = _context.Empleados.FirstOrDefault(m => m.id == id);
   

    _context.Empleados.Remove(Emp);
    _context.SaveChanges();

    return RedirectToAction("Eliminar"); // 
}


public IActionResult Cerrar(){
    HttpContext.Session.Clear();
    return RedirectToAction("Index", "Landing");
}

public async Task<IActionResult> Index()  //get
    {   
        @ViewBag.Nombre =  HttpContext.Session.GetString("Nombre");
        @ViewBag.Id =  HttpContext.Session.GetInt32("Id");
        var Emp = await _context.Empleados.ToListAsync();
        return View(Emp);   //se llama a la tabla
    }

}
}