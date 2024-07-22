using System.Linq;
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

    public async Task<IActionResult> EditarPacotes()
    {
        var pacotes = await _context.Pacotes.ToListAsync();
        return View(pacotes);
    }

    public async Task<IActionResult> ListarPacotes()
    {
        var pacotes = await _context.Pacotes.ToListAsync();
        return View(pacotes);
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

    public async Task<IActionResult> TelaEdicao(int id)
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

    [HttpPost]
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

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(int id, [Bind("Id,Nome,Origem,Destino,Saida,Retorno,Atrativos")] PacoteViewModel pacote)
    {
        if (id != pacote.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(pacote);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacoteExists(pacote.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("PainelUsuario", "Home");
        }
        return View(pacote);
    }

    private bool PacoteExists(int id)
    {
        return _context.Pacotes.Any(e => e.Id == id);
    }
}
