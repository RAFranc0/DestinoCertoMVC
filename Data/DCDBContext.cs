using Microsoft.EntityFrameworkCore;
using DestinoCertoMVC.Models;
using MySql.Data;

namespace DestinoCertoMVC.Data
{
    public class DCDBContext : DbContext
{
    public DCDBContext(DbContextOptions<DCDBContext> options) : base(options)
    {
    }

    public DbSet<UsuarioViewModel> Usuarios { get; set; }
    public DbSet<PacoteViewModel> Pacotes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=destinocerto_db;User=root;Password=yourpassword");
        }
    }
}
}