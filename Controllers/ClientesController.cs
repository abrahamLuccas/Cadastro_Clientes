using cadastro_clientes.Data;
using cadastro_clientes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cadastro_clientes.Controllers
{
    public class ClientesController : Controller
    {
        private readonly AppCont _appCont;

        public ClientesController(AppCont appCont)
        {
            _appCont = appCont;
        }

        public IActionResult Index()
        {
            var allClients = _appCont.Clientes.ToList();
            return View(allClients);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(
            [Bind("Name, Telefone, Email, Pais, Cidade, Complemento, Bairro, Rua, Numero, Cep, UF")]
            Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _appCont.Clientes.Add(cliente);
                await _appCont.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        [HttpGet]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefa = await _appCont.Clientes.FindAsync(id);
            if (tarefa == null)
            {
                return BadRequest();
            }
            return View(tarefa);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Edit(
            int? id, [Bind("Id, Name, Telefone, Email, Pais, Cidade, Bairro, Rua, Numero, Complemento, Cep, UF")]
            Cliente tarefa)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _appCont.Update(tarefa);
                await _appCont.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tarefa);
        }
        
        [HttpGet]

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefa = await _appCont.Clientes.FirstOrDefaultAsync(t => t.Id == id);

            if ( tarefa == null )
            {
                return BadRequest();
            }
            return View(tarefa);
        }

        [HttpGet]

        public async Task<IActionResult> Delete (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefa = await _appCont.Clientes.FirstOrDefaultAsync(x => x.Id == id);

            if (tarefa == null)
            {
                return NotFound();
            }
            return View(tarefa);
        }

        [HttpPost, ActionName("Delete")]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tarefa = await _appCont.Clientes.FindAsync(id);
            _appCont.Clientes.Remove(tarefa); 
            await _appCont.SaveChangesAsync();
            return RedirectToAction(nameof(Index));   
        }


    }    
}
