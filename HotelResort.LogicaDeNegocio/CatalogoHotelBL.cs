using HotelResort.AccesoADatos;
using HotelResort.EntidadDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelResort.LogicaDeNegocio
{
    public class CatalogoHotelBL
    {
        public async Task<int> CrearAsync(CatalogoHotel pCatalogoH)
        {
            return await CatalogoHotelDAL.CrearAsync(pCatalogoH);
        }
        public async Task<int> ModificarAsync(CatalogoHotel pCatalogoH)
        {
            return await CatalogoHotelDAL.ModificarAsync(pCatalogoH);
        }
        public async Task<int> EliminarAsync(CatalogoHotel pCatalogoH)
        {
            return await CatalogoHotelDAL.EliminarAsync(pCatalogoH);
        }
        public async Task<CatalogoHotel> ObtenerPorIdAsync(CatalogoHotel pCatalogoH)
        {
            return await CatalogoHotelDAL.ObtenerPorIdAsync(pCatalogoH);
        }
        public async Task<List<CatalogoHotel>> ObtenerTodosAsync()
        {
            return await CatalogoHotelDAL.ObtenerTodosAsync();
        }
        public async Task<List<CatalogoHotel>> BuscarAsync(CatalogoHotel pCatalogoH)
        {
            return await CatalogoHotelDAL.BuscarAsync(pCatalogoH);
        }
    }
}
