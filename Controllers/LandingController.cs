using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Login.Data;

namespace Empleados2.Controllers{
    public class LandingController : Controller{


        
        public IActionResult Index(){
            return View();
        }
    }

    
}