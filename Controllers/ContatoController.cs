using Microsoft.AspNetCore.Mvc;
using Class.Models;
using Class.Data;

namespace Class.Controllers
{
    public class ContatoController : Controller
    {
        private readonly BancoContext _bancoContext;

        public ContatoController(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public IActionResult Index()
        {
            var contatos = _bancoContext.Contatos.ToList();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            if (ModelState.IsValid)
            {
                _bancoContext.Contatos.Add(contato);
                _bancoContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contato);
        }

        public IActionResult Editar(int id)
        {
            var contato = _bancoContext.Contatos.Find(id);
            return View(contato);
        }

        [HttpPost]
        public IActionResult Editar(ContatoModel contato)
        {
            if (ModelState.IsValid)
            {
                _bancoContext.Contatos.Update(contato);
                _bancoContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contato);
        }

        public IActionResult Excluir(int id)
        {
            var contato = _bancoContext.Contatos.Find(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            var contato = _bancoContext.Contatos.Find(id);

            if (contato != null)
            {
                _bancoContext.Contatos.Remove(contato);
                _bancoContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
