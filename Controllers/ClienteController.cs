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
    public class ClienteController : ControllerBase
    {
        private readonly ClienteRepository _repository;
        public ClienteController(ClienteRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public IActionResult Cadastrar(CadastrarClienteDTO dto)
        {
            var cliente = new Cliente(dto);
            _repository.Cadastrar(cliente);
            return Ok(cliente);
        }
        [HttpGet("ObterPorID/{id}")]
        public IActionResult ObterPorId(int id)
        {
            var cliente = _repository.ObterPorId(id);
            if (cliente is not null)
            {
                var clienteDTO = new ObterClienteDTO(cliente);
                return Ok(clienteDTO);
            }    
            else
            {
                return NotFound(new { Mensagem = "Não foi encontrado um cliente com este ID"});
            }
        }
        [HttpGet("ObterPorNome/{nome}")]
        public IActionResult ObterPorCliente(string nome)
        {
            var cliente = _repository.ObterPorNome(nome);
            if (cliente is not null)
            {
                return Ok(cliente);
            }    
            else
            {
                return NotFound(new { Mensagem = "Não foram encontrados clientes com este nome"});
            }
        }
        [HttpPut("AtualizarCliente/{id}")]
        public IActionResult AtualizarCliente(int id, AtualizarClienteDTO dto)
        {
            var cliente = _repository.ObterPorId(id);

            if (cliente is not null)
            {
                cliente.MapearAtualizarCliente(dto);
                _repository.AtualizarCliente(cliente);
                return Ok(cliente);
            }
            else
            {
                return NotFound (new {Mensagem = "Não foi encontrado um cliente com este ID"});
            }
        }
        [HttpPatch("AtualizarSenha/{id}")]
        public IActionResult AtualizarSenha(int id, AtualizarSenhaClienteDTO dto)
        {
            var cliente = _repository.ObterPorId(id);
            if (cliente is not null)
            {
                _repository.AtualizarSenha(cliente, dto);
                return Ok(cliente);
            }
            else
            {
                return NotFound(new { Mensagem = "Não foi encontrado um cliente com este ID"});
            }
        }
        [HttpDelete("DeletarCliente/{id}")]
        public IActionResult Deletar(int id)
        {
            var cliente = _repository.ObterPorId(id);
            if (cliente is not null)
            {
                _repository.DeletarPedido(cliente);
                return Ok("Cliente deletado com sucesso");
            }
            else
            {
                return NotFound (new {Mensagem = "Não foi encontrado um cliente com este ID"});
            }
        }
    }
}