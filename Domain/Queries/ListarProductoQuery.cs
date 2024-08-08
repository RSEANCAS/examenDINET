using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Queries
{
    public record ListarProductoQuery(int? id, string? nombre) : IRequest<List<ListarProductoQueryResponse>>;
    public class ListarProductoQueryResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
    }
}
