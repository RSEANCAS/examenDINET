using Domain.Data;
using Domain.Models;
using Domain.Util;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Queries.Handlers
{
    public class ListarProductoQueryHandler : IRequestHandler<ListarProductoQuery, List<ListarProductoQueryResponse>>
    {
        private readonly DbExamenDINETContext _context;

        public ListarProductoQueryHandler(
            DbExamenDINETContext context
            )
        {
            _context = context;
        }

        public async Task<List<ListarProductoQueryResponse>> Handle(ListarProductoQuery request, CancellationToken cancellationToken)
        {
            var query = (from a in _context.Producto
                         where (!request.id.HasValue || request.id == a.Id)
                         && (string.IsNullOrEmpty(request.nombre) || a.Nombre.Contains(request.nombre))
                         select a);

            var list = await query.ToListAsync(cancellationToken);
            var listDTO = list.Map<Producto, ListarProductoQueryResponse>();
            return listDTO;
        }
    }
}
