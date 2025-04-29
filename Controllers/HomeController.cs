using Microsoft.AspNetCore.Mvc;
using Class.Models; 
using System.Linq; 
using Microsoft.EntityFrameworkCore; 
using Class.Data;


namespace Class.Controllers
{
    public class HomeController : Controller
    {
        private readonly BancoContext _context;


        public HomeController(BancoContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {

            var contatos = _context.Contatos.ToList();

            if (contatos == null || !contatos.Any())
            {
                
                return View("NenhumContato"); 
            }

            return View(contatos);
        }
    }
}
