using System;
using DestinoCertoMVC.Data;
using DestinoCertoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class CadastroController : Controller
{
    private readonly DCDBContext _context;

    public CadastroController(DCDBContext context)
    {
        _context = context;
    }

        [HttpPost]
    public IActionResult Create(UsuarioViewModel u)
    {
        if (ModelState.IsValid)
        {
            if (u.DataNascimento.HasValue)
            {
                string formattedDate = u.DataNascimento.Value.ToString("dd/MM/yyyy");
                u.DataNascimento = DateTime.ParseExact(formattedDate, "dd/MM/yyyy", null);
            }

            _context.Add(u);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        return View(u);
    }
}