using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Models;
using SistemaVendas.Controllers;

namespace SistemaVendas.Dto
{
    public class ObterPedidoDTO
    {
        public int Id {get; set;}
        public DateTime Data {get;set;}
        public ObterClienteDTO Cliente {get;set;}
        public ObterVendedorDTO Vendedor {get;set;}
        public ObterPedidoDTO()
        {
        }
        public ObterPedidoDTO(Pedido pedido)
        {
            Id = pedido.Id;
            Data = pedido.Data;
            Cliente = new ObterClienteDTO(pedido.Cliente);
            Vendedor = new ObterVendedorDTO(pedido.Vendedor);
        }
    }
}