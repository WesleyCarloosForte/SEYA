using SEYA.APP.BACKEND.Data;
using SEYA.APP.Shared.Interface;
using SEYA.APP.Shared.Models;

namespace SEYA.APP.BACKEND.Repository
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
