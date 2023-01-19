using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Context;
using SistemaVendas.Controllers;
using SistemaVendas.Models;

namespace SistemaVendas.Repository
{
    public class VendedorRepository
    {
            private readonly VendasContext _context;

            public VendedorRepository(VendasContext context)
            {
                _context = context;
            }

            public void Cadastrar(Vendedor vendedor)
            {
                _context.Vendedores.Add(vendedor);
                _context.SaveChanges();
            }

            public Vendedor ObterPorId(int id)
            {
                var vendedor = _context.Vendedores.Find(id);
                return vendedor;
            }
            public List<ObterVendedorDTO> ObterPorNome(string nome)
            {
                var vendedores = _context.Vendedores.Where(x => x.Nome.Contains(nome))
                                                    .Select(x => new ObterVendedorDTO(x))
                                                    .ToList();
                return vendedores;
            }
    }
}