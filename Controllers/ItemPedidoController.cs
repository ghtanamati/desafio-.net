using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Dto;
using SistemaVendas.Models;
using SistemaVendas.Repository;

namespace SistemaVendas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemPedidoController : ControllerBase
    {
        private readonly ItemPedidoRepository _repository;
        public ItemPedidoController(ItemPedidoRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public IActionResult Cadastrar(CadastrarItemPedidoDTO dto)
        {
            var itemPedido = new ItemPedido(dto);
            _repository.Cadastrar(itemPedido);
            return Ok(itemPedido);
        }
        [HttpGet("ObterPorServico/{idServico}")]
        public IActionResult ObterPorServico(int idServico)
        {
            var itemPedido = _repository.ObterPorServico(idServico);
            if (itemPedido is not null)
            {
                return Ok(itemPedido);
            }    
            else
            {
                return NotFound(new { Mensagem = "Não foram encontrados itens pedidos com este serviço"});
            }
        }
        [HttpGet("ObterPorIDPedido/{idPedido}")]
        public IActionResult ObterPorPedido(int idPedido)
        {
            var itemPedido = _repository.ObterPorPedido(idPedido);
            if (itemPedido is not null)
            {
                return Ok(itemPedido);
            }    
            else
            {
                return NotFound(new { Mensagem = "Não foram encontrados itens pedidos com este serviço"});
            }
        }
        [HttpPut("AtualizarItemPedido/{id}")]
        public IActionResult AtualizarItemPedido(int id, AtualizarItemPedidoDTO dto)
        {
            var itemPedido = _repository.ObterPorId(id);
            if (itemPedido is not null)
            {
                itemPedido.MapearAtualizarItemPedido(dto);
                _repository.AtualizarItemPedido(itemPedido);
                return Ok(itemPedido);
            }
            else
            {
                return NotFound (new {Mensagem = "Não foi encontrado um cliente com este ID"});
            }
        }
        [HttpPatch("AtualizarValor/{id}")]
        public IActionResult AtualizarValor(int id, AtualizarValorDTO dto)
        {
            var itemPedido = _repository.ObterPorId(id);
            if (itemPedido is not null)
            {
                _repository.AtualizarValor(itemPedido, dto);
                return Ok(itemPedido);
            }
            else
            {
                return NotFound(new { Mensagem = "Não foi encontrado um item pedido com este ID"});
            }
        }
        [HttpDelete("DeletarItemPedido/{id}")]
        public IActionResult DeletarItemPedido(int id)
        {
            var itemPedido = _repository.ObterPorId(id);
            if (itemPedido is not null)
            {
                _repository.DeletarItemPedido(itemPedido);
                return Ok("Item Pedido deletado com sucesso");
            }
            else
            {
                return NotFound (new {Mensagem = "Não foi encontrado um item pedido com este ID"});
            }
        }
    }
}