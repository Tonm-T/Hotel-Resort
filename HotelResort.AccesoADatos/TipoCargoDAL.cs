using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelResort.EntidadDeNegocio;
using Microsoft.EntityFrameworkCore;

namespace HotelResort.AccesoADatos
{
    public class TipoCargoDAL
    {
        public static async Task<int> CrearAsync(TipoCargo pTipoCargo)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pTipoCargo);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(TipoCargo pTipoCargo)
        {
            int resut = 0;
            using (var bdContexto = new BDContexto())
            {
                var tipocargo = await bdContexto.TipoCargo.FirstOrDefaultAsync(c => c.Id == pTipoCargo.Id);
                tipocargo.Cargo = pTipoCargo.Cargo;
               

                bdContexto.Update(tipocargo);
                resut = await bdContexto.SaveChangesAsync();
            }
            return resut;
        }
        public static async Task<int> EliminarAsync(TipoCargo pTipoCargo)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var tipocargo = await bdContexto.TipoCargo.FirstOrDefaultAsync(c => c.Id == pTipoCargo.Id);
                bdContexto.TipoCargo.Remove(tipocargo);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<TipoCargo> ObtenerPorIdAsync(TipoCargo pTipoCargo)
        {
            var tipocargo = new TipoCargo();
            using (var bdContexto = new BDContexto())
            {
                tipocargo = await bdContexto.TipoCargo.FirstOrDefaultAsync(c => c.Id == pTipoCargo.Id);
            }
            return tipocargo;
        }

        public static async Task<List<TipoCargo>> ObtenerTodosAsync()
        {
            var tipocargo = new List<TipoCargo>();
            using (var bdContexto = new BDContexto())
            {
                tipocargo = await bdContexto.TipoCargo.ToListAsync();
            }
            return tipocargo;
        }
        internal static IQueryable<TipoCargo> QuerySelect(IQueryable<TipoCargo> pQuery, TipoCargo pTipoCargo)
        {
            if (pTipoCargo.Id > 0)
                pQuery = pQuery.Where(c => c.Id == pTipoCargo.Id);
            if (!string.IsNullOrWhiteSpace(pTipoCargo.Cargo))
                pQuery = pQuery.Where(c => c.Cargo == pTipoCargo.Cargo);
            


            pQuery = pQuery.OrderByDescending(c => c.Id).AsQueryable();
            if (pTipoCargo.top_aux > 0)

                pQuery = pQuery.Take(pTipoCargo.top_aux).AsQueryable();
            return pQuery;
        }

        public static async Task<List<TipoCargo>> BuscarAsync(TipoCargo pTipoCargo)
        {
            var tipocargo = new List<TipoCargo>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.TipoCargo.AsQueryable();
                select = QuerySelect(select, pTipoCargo);
                tipocargo = await select.ToListAsync();
            }
            return tipocargo;
        }
    }
}
