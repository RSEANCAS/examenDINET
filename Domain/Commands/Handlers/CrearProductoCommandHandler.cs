using Domain.Data;
using Domain.Models;
using Domain.Queries;
using Domain.Util;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.Handlers
{
    public class CrearProductoCommandHandler : IRequestHandler<CrearProductoCommand, CrearProductoCommandResponse>
    {
        private DbExamenDINETContext _context;
        public CrearProductoCommandHandler(
            DbExamenDINETContext context
            )
        {
            _context = context;
        }

        public async Task<CrearProductoCommandResponse> Handle(CrearProductoCommand request, CancellationToken cancellationToken)
        {
            var item = request.Map<CrearProductoCommand, Producto>();
            _context.Producto.Add(item);
            int filasAfectadas = _context.SaveChanges();

            CrearProductoCommandResponse response = new();
            response.success = filasAfectadas > 0;

            return response;
        }
    }
}
