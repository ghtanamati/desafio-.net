using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVendas.Context;
using SistemaVendas.Controllers;
using SistemaVendas.Dto;
using SistemaVendas.Models;

namespace SistemaVendas.Repository
{
    public class PedidoRepository
    {
        private readonly VendasContext _context;
        public PedidoRepository(VendasContext context)
        {
            _context = context;
        }
        public void Cadastrar(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
        }
        public Pedido ObterPorId(int id)
        {
            var pedido = _context.Pedidos.Include(x => x.Cliente)
                                         .Include(x => x.Vendedor)
                                         .FirstOrDefault(x => x.Id == id);      
            return pedido;
        }
        public Pedido ObterPorCliente(int idCliente)
        {
            var pedido = _context.Pedidos.Include(x => x.Cliente)
                                         .Include(x => x.Vendedor)
                                         .FirstOrDefault(x => x.Id == idCliente);
            return pedido;
        }
        public Pedido ObterPorVendedor(int idVendedor)
        {
            var pedido = _context.Pedidos.Include(x => x.Cliente)
                                          .Include(x => x.Vendedor)
                                          .FirstOrDefault(x => x.Id == idVendedor);
            return pedido;
        }
        public Pedido AtualizarPedido(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
            _context.SaveChanges();
            return pedido;
        }
        public void AtualizarVendedor(Pedido pedido, AtualizarVendedorDoPedidoDTO dto)
        {
            pedido.VendedorId = dto.VendedorId;
            AtualizarPedido(pedido);
        }
        public void DeletarPedido(Pedido pedido)
        {
            _context.Pedidos.Remove(pedido);
            _context.SaveChanges();
        }
    }
}