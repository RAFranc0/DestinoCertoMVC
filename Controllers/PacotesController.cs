using DestinoCertoMVC.Data;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult ExcluirPacotes()
    {
        return View();
    }
    public IActionResult EditarPacotes()
    {
        return View();
    }
    public IActionResult ListarPacotes()
    {
        return View();
    }

}