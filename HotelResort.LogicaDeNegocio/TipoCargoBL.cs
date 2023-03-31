using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelResort.AccesoADatos;
using HotelResort.EntidadDeNegocio;

namespace HotelResort.LogicaDeNegocio
{
    public class TipoCargoBL
    {
        public async Task<int> CrearAsync(TipoCargo pTipoCargo)
        {
            return await TipoCargoDAL.CrearAsync(pTipoCargo);
        }
        public async Task<int> ModificarAsync(TipoCargo pTipoCargo)
        {
            return await TipoCargoDAL.ModificarAsync(pTipoCargo);
        }
        public async Task<int> EliminarAsync(TipoCargo pTipoCargo)
        {
            return await TipoCargoDAL.EliminarAsync(pTipoCargo);
        }
        public async Task<TipoCargo> ObtenerPorIdAsync(TipoCargo pTipoCargo)
        {
            return await TipoCargoDAL.ObtenerPorIdAsync(pTipoCargo);
        }
        public async Task<List<TipoCargo>> ObtenerTodosAsync()
        {
            return await TipoCargoDAL.ObtenerTodosAsync();
        }
        public async Task<List<TipoCargo>> BuscarAsync(TipoCargo pTipoCargo)
        {
            return await TipoCargoDAL.BuscarAsync(pTipoCargo);
        }
    }
}
