using HotelResort.EntidadDeNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelResort.AccesoADatos
{
    public class CatalogoHotelDAL
    {
            public static async Task<int> CrearAsync(CatalogoHotel pCatalogoH)
            {
                int result = 0;
                using (var bdContexto = new BDContexto())
                {
                    bdContexto.Add(pCatalogoH);
                    result = await bdContexto.SaveChangesAsync();
                }
                return result;
            }
            public static async Task<int> ModificarAsync(CatalogoHotel pCatalogoH)
            {
                int resut = 0;
                using (var bdContexto = new BDContexto())
                {
                    var catalogo = await bdContexto.CatalogoHotel.FirstOrDefaultAsync(c => c.Id == pCatalogoH.Id);
                    catalogo.ClaseHabitacion = pCatalogoH.ClaseHabitacion;
                    catalogo.Detalles = pCatalogoH.Detalles;
                    catalogo.Precio = pCatalogoH.Precio;
                    catalogo.NumHabitacion = pCatalogoH.NumHabitacion;

                    bdContexto.Update(catalogo);
                    resut = await bdContexto.SaveChangesAsync();
                }
                return resut;
            }
            public static async Task<int> EliminarAsync(CatalogoHotel pCatalogoH)
            {
                var resut = 0;
                using (var bdContexto = new BDContexto())
                {
                    var catalogo = await bdContexto.CatalogoHotel.FirstOrDefaultAsync(c => c.Id == pCatalogoH.Id);
                    bdContexto.CatalogoHotel.Remove(catalogo);
                    resut = await bdContexto.SaveChangesAsync();
                }
                return resut;
            }

            public static async Task<CatalogoHotel> ObtenerPorIdAsync(CatalogoHotel pCatalogoH)
            {
                var catalogo = new CatalogoHotel();
                using (var bdContexto = new BDContexto())
                {
                    catalogo = await bdContexto.CatalogoHotel.FirstOrDefaultAsync(c => c.Id == pCatalogoH.Id);
                }
                return catalogo;
            }

            public static async Task<List<CatalogoHotel>> ObtenerTodosAsync()
            {
                var catalogo = new List<CatalogoHotel>();
                using (var bdContexto = new BDContexto())
                {
                    catalogo = await bdContexto.CatalogoHotel.ToListAsync();
                }
                return catalogo;
            }
            internal static IQueryable<CatalogoHotel> QuerySelect(IQueryable<CatalogoHotel> pQuery, CatalogoHotel pCatalogoH)
            {
            if (pCatalogoH.Id > 0)
                pQuery = pQuery.Where(c => c.Id == pCatalogoH.Id);
            if (!string.IsNullOrWhiteSpace(pCatalogoH.ClaseHabitacion))
                    pQuery = pQuery.Where(c => c.ClaseHabitacion.Contains(pCatalogoH.ClaseHabitacion));
            if (!string.IsNullOrWhiteSpace(pCatalogoH.Detalles))
                pQuery = pQuery.Where(c => c.Detalles.Contains(pCatalogoH.Detalles));
            if (!string.IsNullOrWhiteSpace(pCatalogoH.NumHabitacion))
                pQuery = pQuery.Where(c => c.NumHabitacion.Contains(pCatalogoH.NumHabitacion));
            if (pCatalogoH.Precio > 0)
                pQuery = pQuery.Where(s => s.Precio == pCatalogoH.Precio);

            pQuery = pQuery.OrderByDescending(c => c.Id).AsQueryable();
            if (pCatalogoH.top_aux > 0)

                pQuery = pQuery.Take(pCatalogoH.top_aux).AsQueryable();
            return pQuery;
        }

            public static async Task<List<CatalogoHotel>> BuscarAsync(CatalogoHotel pCatalogoH)
            {
                var catalogo = new List<CatalogoHotel>();
                using (var bdContexto = new BDContexto())
                {
                    var select = bdContexto.CatalogoHotel.AsQueryable();
                    select = QuerySelect(select, pCatalogoH);
                    catalogo = await select.ToListAsync();
                }
                return catalogo;
            }
        }
}
