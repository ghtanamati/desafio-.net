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
    public class PedidoController : ControllerBase
    {
        //Injeção de Dependência (Start)
        private readonly PedidoRepository _repository;
        public PedidoController(PedidoRepository repository)
        {
            _repository = repository;
        }
        //Injeção de Dependência (End)
        [HttpPost]
        public IActionResult Cadastrar(CadastrarPedidoDTO dto)
        {
            var pedido = new Pedido(dto);
            _repository.Cadastrar(pedido);
            return Ok(pedido);
        }
        [HttpGet("ObterPorID/{id}")]
        public IActionResult ObterPorId(int id)
        {
            var pedido = _repository.ObterPorId(id);
            var pedidoFront = new ObterPedidoDTO(pedido);
            if (pedidoFront is not null)
            {
                return Ok(pedidoFront);
            }    
            else
            {
                return NotFound(new { Mensagem = "Não foi encontrado um pedido com este ID"});
            }
        }
        [HttpGet("ObterPorCliente/{idCliente}")]
        public IActionResult ObterPorCliente(int idCliente)
        {
            var pedido = _repository.ObterPorCliente(idCliente);
            var pedidoFront = new ObterPedidoDTO(pedido);
            if (pedidoFront is not null)
            {
                return Ok(pedidoFront);
            }    
            else
            {
                return NotFound(new { Mensagem = "Não foram encontrados pedidos deste cliente"});
            }
        }
        [HttpGet("ObterPorVendedor/{idVendedor}")]
        public IActionResult ObterPorVendedor(int idVendedor)
        {
            var pedido = _repository.ObterPorVendedor(idVendedor);   
            var pedidoFront = new ObterPedidoDTO(pedido);
            if (pedidoFront is not null)
            {
                return Ok(pedidoFront);
            }    
            else
            {
                return NotFound(new { Mensagem = "Não foram encontrados pedidos deste vendedor"});
            }
        }
        [HttpPut("AtualizarPedido/{id}")]
        public IActionResult AtualizarPedido(int id, AtualizarPedidoDTO dto)
        {
            var pedido = _repository.ObterPorId(id);
            if (pedido is not null)
            {
                pedido.MapearAtualizarPedido(dto);
                _repository.AtualizarPedido(pedido);
                return Ok(pedido);
            }
            else
            {
                return NotFound (new {Mensagem = "Não foi encontrado um pedido com este ID"});
            }
        }
        [HttpPatch("AtualizarVendedor/{id}")]
        public IActionResult AtualizarVendedor(int id, AtualizarVendedorDoPedidoDTO dto)
        {
            var pedido = _repository.ObterPorId(id);
            if (pedido is not null)
            {
                _repository.AtualizarVendedor(pedido, dto);
                return Ok(pedido);
            }
            else
            {
                return NotFound(new { Mensagem = "Não foi encontrado um pedido com este ID"});
            }
        }
        [HttpDelete("DeletarPedido/{id}")]
        public IActionResult Deletar(int id)
        {
            var pedido = _repository.ObterPorId(id);            
            if (pedido is not null)
            {
                _repository.DeletarPedido(pedido);
                return Ok("Pedido deletado com sucesso");
            }
            else
            {
                return NotFound (new {Mensagem = "Não foi encontrado um pedido com este ID"});
            }
        }
    }
}