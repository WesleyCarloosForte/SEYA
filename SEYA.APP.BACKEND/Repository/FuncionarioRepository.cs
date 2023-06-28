using SEYA.APP.BACKEND.Data;
using SEYA.APP.Shared.Interface;
using SEYA.APP.Shared.Models;

namespace SEYA.APP.BACKEND.Repository
{
    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository
    {
        private readonly ServerContex _context;
        public FuncionarioRepository(ServerContex context) : base(context)
        {
            _context = context;
        }
    }
}
