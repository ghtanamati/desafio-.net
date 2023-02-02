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
    public class ItemPedidoRepository
    {
        private readonly VendasContext _context;
        public ItemPedidoRepository(VendasContext context)
        {
            _context = context;
        }
        public void Cadastrar(ItemPedido itemPedido)
        {
            _context.ItensPedidos.Add(itemPedido);
            _context.SaveChanges();
        }
        public ItemPedido ObterPorId(int id)
        {
            var itemPedido = _context.ItensPedidos.Find(id);
            return itemPedido;
        }
        public List<ObterItemPedidoDTO> ObterPorServico(int idServico)
        {
            var itensPedido = _context.ItensPedidos.Where(x => x.Servico.Id == idServico)
                                                    .Select(x => new ObterItemPedidoDTO(x))
                                                    .ToList();
            
            return itensPedido;
        }
        public List<ObterItemPedidoDTO> ObterPorPedido(int idPedido)
        {
            var itensPedido = _context.ItensPedidos.Where(x => x.Pedido.Id == idPedido)
                                                    .Select(x => new ObterItemPedidoDTO(x))
                                                    .ToList();
            
            return itensPedido;
        }
        public ItemPedido AtualizarItemPedido(ItemPedido itemPedido)
        {
            _context.ItensPedidos.Update(itemPedido);
            _context.SaveChanges();
            return itemPedido;
        }
        public void AtualizarQuantidade(ItemPedido itemPedido, AtualizarQtdeDTO dto)
        {
            itemPedido.Quantidade = dto.Quantidade;
            AtualizarItemPedido(itemPedido);
        }
        public void AtualizarValor(ItemPedido itemPedido, AtualizarValorDTO dto)
        {
            itemPedido.Valor = dto.Valor;
            AtualizarItemPedido(itemPedido);
        }
        public void DeletarItemPedido(ItemPedido itemPedido)
        {
            _context.ItensPedidos.Remove(itemPedido);
            _context.SaveChanges();
        }
    }
}