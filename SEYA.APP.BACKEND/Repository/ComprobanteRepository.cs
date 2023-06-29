using SEYA.APP.BACKEND.Data;
using SEYA.APP.Shared.Interface;
using SEYA.APP.Shared.Models;

namespace SEYA.APP.BACKEND.Repository
{
    public class ComprobanteRepository:Repository<Comprobante>,IComprobanteRepository
    {
        public ComprobanteRepository(ServerContex contex):base(contex)
        {

        }


    }
}
