using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands
{
    public record CrearProductoCommand(string Nombre, decimal Precio) : IRequest<CrearProductoCommandResponse>;

    public class CrearProductoCommandResponse
    {
        public bool success { get; set; }
    }
}
