using SEYA.APP.Server.Data;
using SEYA.APP.Shared.Interface;
using SEYA.APP.Shared.Models;

namespace SEYA.APP.Server.Repository
{
    public class ClienteRepository:Repository<Cliente>,IClienteRepository
    {
        private readonly ServerContex _context;
        public ClienteRepository(ServerContex context) :base(context)
        {
        _context = context;
        }

    }
}
