using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Models;

namespace SistemaVendas.Controllers
{
    public class ObterVendedorDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public ObterVendedorDTO()
        {
        }
        public ObterVendedorDTO(Vendedor vendedor)
        {
            Id = vendedor.Id;
            Nome = vendedor.Nome;
            Login = vendedor.Login;
        }
    }
}