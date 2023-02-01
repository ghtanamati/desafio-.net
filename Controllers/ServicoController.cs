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
    public class ServicoController : ControllerBase
    {
        private readonly ServicoRepository _repository;
        public ServicoController(ServicoRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public IActionResult Cadastrar(CadastrarServicoDTO dto)
        {
            var servico = new Servico(dto);
            _repository.Cadastrar(servico);
            return Ok(servico);
        }

        [HttpGet("ObterPorID/{id}")]
        public IActionResult ObterPorId(int id)
        {
            var servico = _repository.ObterPorId(id);
            if (servico is not null)
            {
                return Ok(servico);
            }    
            else
            {
                return NotFound(new { Mensagem = "Não foi encontrado um serviço com este ID"});
            }
        }

        [HttpGet("ObterPorNome/{nome}")]
        public IActionResult ObterPorNome(string nome)
        {
            var servicos = _repository.ObterPorNome(nome);
            if(servicos is not null)
            {
                return Ok(servicos);
            }
            else
            {
                return NotFound(new { Mensagem = "Não foram encontrados serviços com este nome"});
            }
        }

        [HttpPut("AtualizarServico/{id}")]
        public IActionResult AtualizarServico(int id, AtualizarServicoDTO dto)
        {
            var servico = _repository.ObterPorId(id);
            if (servico is not null)
            {
                servico.MapearAtualizarServico(dto);
                _repository.AtualizarServico(servico);
                return Ok(servico);
            }
            else
            {
                return NotFound (new {Mensagem = "Não foi encontrado um serviço com este ID"});
            }
        }

        [HttpPatch("AtualizarNome/{id}")]
        public IActionResult AtualizarNome(int id, AtualizarNomeServicoDTO dto)
        {
            var servico = _repository.ObterPorId(id);
            if (servico is not null)
            {
                _repository.AtualizarNome(servico, dto);
                return Ok(servico);
            }
            else
            {
                return NotFound(new { Mensagem = "Não foi encontrado um serviço com este ID"});
            }
        }

        [HttpPatch("AtualizarDescricao/{id}")]
        public IActionResult AtualizarDescricao(int id, AtualizarDescricaoServicoDTO dto)
        {
            var servico = _repository.ObterPorId(id);
            if (servico is not null)
            {
                _repository.AtualizarDescricao(servico, dto);
                return Ok(servico);
            }
            else
            {
                return NotFound(new { Mensagem = "Não foi encontrado um serviço com este ID"});
            }
        }

        [HttpDelete("DeletarServico/{id}")]
        public IActionResult Deletar(int id)
        {
            var servico = _repository.ObterPorId(id);  
            if (servico is not null)
            {
                _repository.DeletarServico(servico);
                return Ok("Serviço deletado com sucesso");
            }
            else
            {
                return NotFound (new {Mensagem = "Não foi encontrado um serviço com este ID"});
            }
        }
    }
}