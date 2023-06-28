using SEYA.APP.BACKEND.Data;
using SEYA.APP.Shared.Interface;
using SEYA.APP.Shared.Models;

namespace SEYA.APP.BACKEND.Repository
{
    public class RolRepository : Repository<Rol>, IRolRepository
    {
        private readonly ServerContex _context;
        public RolRepository(ServerContex context) : base(context)
        {
            _context = context;
        }
    }
}
