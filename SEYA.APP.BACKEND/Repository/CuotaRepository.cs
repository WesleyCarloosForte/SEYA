using Microsoft.EntityFrameworkCore;
using SEYA.APP.BACKEND.Data;
using SEYA.APP.Shared.Interface;
using SEYA.APP.Shared.Models;

namespace SEYA.APP.BACKEND.Repository
{
    public class CuotaRepository:Repository<Cuota>,ICuotaRepository
    {
        public CuotaRepository(ServerContex context):base(context) 
        {
            this.context=context;
        }
        public async Task<Cuota> Get(int id)
        {
            return await context.Cuotas.Include(x => x.Deuda).ThenInclude(x => x.Cliente).Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task PagarCuota(int id,int UserId)
        {
           
                var cuota = context.Cuotas.Find(id);
                if (cuota != null)
                {

                    var comprobante = context.Comprobantes.Find(1);

                    cuota.Pendiente = false;
                    context.Pagos.Add(new Pago() 
                    { 
                        Comprobante=$"{comprobante.Sucursal}-{comprobante.PuntoExpedicion}-{comprobante.NumeroActual.ToString("D7")}" , 
                        CuotaId = id, 
                        Fecha = DateTime.Now.Date, 
                        UsuarioId = UserId,
                        InicioVigencia=comprobante.InicioVigencia,
                        FinVigencia=comprobante.FinVigencia,
                        Timbrado=comprobante.Timbrado,
                    });

                    comprobante.NumeroActual += 1;

                    context.Entry(cuota).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.Entry(comprobante).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    await context.SaveChangesAsync();
                }
            
            
        }
        private readonly ServerContex context;

    }
}
