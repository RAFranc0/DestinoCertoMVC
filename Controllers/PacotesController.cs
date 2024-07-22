using System.Threading.Tasks;
using DestinoCertoMVC.Data;
using DestinoCertoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class PacotesController : Controller
{
    private readonly DCDBContext _context;

    public PacotesController(DCDBContext context)
    {
        _context = context;
    }

    public IActionResult AdicionarPacotes()
    {
        return View();
    }

    public async Task<IActionResult> ExcluirPacotes()
    {
        var pacotes = await _context.Pacotes.ToListAsync();
        return View(pacotes);
    }

    public IActionResult EditarPacotes()
    {
        return View();
    }

    public IActionResult ListarPacotes()
    {
        return View();
    }

    public async Task<IActionResult> ConfirmarExclusao(int id)
    {
        var pacote = await _context.Pacotes.FindAsync(id);
        if (pacote == null)
        {
            return NotFound();
        }
        return View(pacote);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Adicionar(PacoteViewModel pacote)
    {
        if (ModelState.IsValid)
        {
            _context.Pacotes.Add(pacote);
            await _context.SaveChangesAsync();
            return RedirectToAction("PainelUsuario", "Home");
        }

        return View(pacote);
    }

    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Excluir(int id)
    {
        var pacote = await _context.Pacotes.FindAsync(id);
        if (pacote == null)
        {
            return NotFound();
        }

        _context.Pacotes.Remove(pacote);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(ExcluirPacotes));
    }
}
