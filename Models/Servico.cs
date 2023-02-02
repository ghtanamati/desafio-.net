using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Dto;

namespace SistemaVendas.Models
{
    public class Servico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Servico()
        {
        }
        public Servico(CadastrarServicoDTO dto)
        {
            Nome = dto.Nome;
            Descricao = dto.Descricao;
        }
        public void MapearAtualizarServico(AtualizarServicoDTO dto)
        {
            Nome = dto.Nome;
            Descricao = dto.Descricao;
        }
    }
}