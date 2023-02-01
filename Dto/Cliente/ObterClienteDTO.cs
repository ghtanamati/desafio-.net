using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Models;

namespace SistemaVendas.Controllers
{
    public class ObterClienteDTO
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public ObterClienteDTO(Cliente cliente)
        {
            Nome = cliente.Nome;
            Login = cliente.Login;
            Senha = cliente.Senha;
        }
    }
}