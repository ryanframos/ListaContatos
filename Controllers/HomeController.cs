using Microsoft.AspNetCore.Mvc;
using Class.Models; // Certifique-se de que o namespace está correto
using System.Linq; // Para usar o método .Any()
using Microsoft.EntityFrameworkCore; // Para trabalhar com Entity Framework
using Class.Data;


namespace Class.Controllers
{
    public class HomeController : Controller
    {
        private readonly BancoContext _context;

        // Construtor para injeção de dependência do DbContext
        public HomeController(BancoContext context)
        {
            _context = context;
        }

        // Ação para exibir a lista de contatos
        public IActionResult Index()
        {
            // Recupera todos os contatos do banco de dados
            var contatos = _context.Contatos.ToList();

            // Verifique se a lista de contatos é nula ou vazia
            if (contatos == null || !contatos.Any())
            {
                // Caso não haja contatos, redireciona para uma view com uma mensagem
                return View("NenhumContato"); // Ou você pode criar uma view personalizada
            }

            // Passa a lista de contatos para a view
            return View(contatos);
        }
    }
}
