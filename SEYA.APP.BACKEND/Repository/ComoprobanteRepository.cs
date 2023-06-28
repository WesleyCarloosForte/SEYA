using SEYA.APP.BACKEND.Data;
using SEYA.APP.Shared.Interface;
using SEYA.APP.Shared.Models;

namespace SEYA.APP.BACKEND.Repository
{
    public class ComoprobanteRepository:Repository<Comprobante>,IComprobanteRepository
    {
        public ComoprobanteRepository(ServerContex contex):base(contex)
        {

        }
    }
}
