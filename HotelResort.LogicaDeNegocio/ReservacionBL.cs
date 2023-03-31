using HotelResort.AccesoADatos;
using HotelResort.EntidadDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelResort.LogicaDeNegocio
{
    public class ReservacionBL
    {
        public async Task<int> CrearAsync(Reservacion pReservacion)
        {
            return await ReservacionDAL.CrearAsync(pReservacion);
        }
        public async Task<int> ModificarAsync(Reservacion pReservacion)
        {
            return await ReservacionDAL.ModificarAsync(pReservacion);
        }
        public async Task<int> EliminarAsync(Reservacion pReservacion)
        {
            return await ReservacionDAL.EliminarAsync(pReservacion);
        }
        public async Task<Reservacion> ObtenerPorIdAsync(Reservacion pReservacion)
        {
            return await ReservacionDAL.ObtenerPorIdAsync(pReservacion);
        }
        public async Task<List<Reservacion>> ObtenerTodosAsync()
        {
            return await ReservacionDAL.ObtenerTodosAsync();
        }
        public async Task<List<Reservacion>> BuscarAsync(Reservacion pReservacion)
        {
            return await ReservacionDAL.BuscarAsync(pReservacion);
        }
    }
}
