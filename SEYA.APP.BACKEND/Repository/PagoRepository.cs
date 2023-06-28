using SEYA.APP.BACKEND.Data;
using SEYA.APP.Shared.Interface;
using SEYA.APP.Shared.Models;

namespace SEYA.APP.BACKEND.Repository
{
    public class PagoRepository:Repository<Pago>,IPagoRepository
    {
        public PagoRepository(ServerContex context) : base(context)
        {


        }
    }
}
