using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Dto;

namespace SistemaVendas.Models
{
    public class ItemPedido
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
        public int ServicoId { get; set; }
        public Servico Servico { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public ItemPedido()
        {
        }
        public ItemPedido(CadastrarItemPedidoDTO dto)
        {
            PedidoId = dto.PedidoId;
            ServicoId = dto.ServicoId;
            Quantidade = dto.Quantidade;
            Valor = dto.Valor;
        }
        public void MapearAtualizarItemPedido(AtualizarItemPedidoDTO dto)
        {
            Quantidade = dto.Quantidade;
            Valor = dto.Valor;
        }
    }
}