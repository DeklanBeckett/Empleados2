
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Login.Models;
using Login.Data; // Asegúrate de tener el namespace correcto

public class EmpleadosController : Controller     //herencia de la clase controller 
{
   public readonly  DatabaseContext _context; // llamar base de datos   //_context parametro

    public EmpleadosController( DatabaseContext context)  // define el constructor construnctor
    {
        _context = context;   //p - v
    }

    // Acción para mostrar la lista de trabajos
    public async Task<IActionResult> Index()  //get
    {
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


}