using Microsoft.EntityFrameworkCore;
using SEYA.APP.BACKEND.Data;
using SEYA.APP.Shared.Interface;
using SEYA.APP.Shared.Models;

namespace SEYA.APP.BACKEND.Repository
{
    public class DeudaRepository:Repository<Deuda>,IDeudaRepository
    {
        public DeudaRepository(ServerContex context) :base(context){
        this.context = context;
        }
        private readonly ServerContex context;
        public async Task<Deuda> Get(int id)
        {
            return await context.Deudas.Include(x => x.Cuotas).Include(x=>x.Cliente).Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task Add(Deuda entity)
        {

                var lasDeuda = context.Deudas.OrderByDescending(x=>x.Id).FirstOrDefault();
                if (lasDeuda != null)
                {
                    entity.NumeroComprobante = (lasDeuda.Id + 1).ToString("D7");
                }
                else
                {
                    entity.NumeroComprobante = 1.ToString("D7");
                }

                entity.Cuotas = new List<Cuota>();



                context.Deudas.Add(entity);
              var a=  context.SaveChanges();

            if (a>0)
            {
            int aux = entity.CantidadCuotas;
            var cuotas = new List<Cuota>();
            while (aux > 0)
            {
                cuotas.Add(new Cuota()
                {
                    FechaVencimiento = DateTime.Now.AddMonths(aux).Date,
                    Numero = aux,
                    Pendiente = true,
                    Valor = entity.ValorTotal / entity.CantidadCuotas,
                    CuentaId=entity.Id

                });
                aux--;
            }
                context.Cuotas.AddRange(cuotas);
              await  context.SaveChangesAsync();
            }




        }


    }
}
