using System;

namespace DestinoCertoMVC.Models
{
    public class PacoteViewModel
    {
        public string Id { get; set;}
        public string Nome { get; set;}
        public string Origem { get; set;}
        public string Destino  { get; set; }
        public DateTime Saida { get; set; }
        public DateTime Retorno { get; set; }
        public int UsuarioId { get; set; }
    }
}