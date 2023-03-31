using HotelResort.EntidadDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HotelResort.AccesoADatos
{
    public class ReservacionDAL
    {
        public static async Task<int> CrearAsync(Reservacion pReservacion)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pReservacion);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Reservacion pReservacion)
        {
            int resut = 0;
            using (var bdContexto = new BDContexto())
            {
                var reservacion = await bdContexto.Reservacion.FirstOrDefaultAsync(c => c.Id == pReservacion.Id);
                reservacion.Nombre = reservacion.Nombre;
                reservacion.Apellido = reservacion.Apellido;
                reservacion.Email = reservacion.Email;
                reservacion.NIdentidad = reservacion.NIdentidad;
                reservacion.Movil = reservacion.Movil;
                reservacion.NHabitacion = reservacion.NHabitacion;
                reservacion.PHabitacion = reservacion.PHabitacion;
                reservacion.FyHRegistro = reservacion.FyHRegistro;
                reservacion.FyHEntrada = reservacion.FyHEntrada;
                reservacion.FyHSalida = reservacion.FyHSalida;

                bdContexto.Update(reservacion);
                resut = await bdContexto.SaveChangesAsync();
            }
            return resut;
        }
        public static async Task<int> EliminarAsync(Reservacion pReservacion)
        {
            var resut = 0;
            using (var bdContexto = new BDContexto())
            {
                var reservacion = await bdContexto.Reservacion.FirstOrDefaultAsync(c => c.Id == pReservacion.Id);
                bdContexto.Reservacion.Remove(reservacion);
                resut = await bdContexto.SaveChangesAsync();
            }
            return resut;
        }

        public static async Task<Reservacion> ObtenerPorIdAsync(Reservacion pReservacion)
        {
            var reservacion = new Reservacion();
            using (var bdContexto = new BDContexto())
            {
                reservacion = await bdContexto.Reservacion.FirstOrDefaultAsync(c => c.Id == pReservacion.Id);
            }
            return reservacion;
        }

        public static async Task<List<Reservacion>> ObtenerTodosAsync()
        {
            var reservacion = new List<Reservacion>();
            using (var bdContexto = new BDContexto())
            {
                reservacion = await bdContexto.Reservacion.ToListAsync();
            }
            return reservacion;
        }
        internal static IQueryable<Reservacion> QuerySelect(IQueryable<Reservacion> pQuery, Reservacion pReservacion)
        {
            if (pReservacion.Id > 0)
                pQuery = pQuery.Where(c => c.Id == pReservacion.Id);
            if (!string.IsNullOrWhiteSpace(pReservacion.Nombre))
                pQuery = pQuery.Where(c => c.Nombre == pReservacion.Nombre);
            if (!string.IsNullOrWhiteSpace(pReservacion.Apellido))
                pQuery = pQuery.Where(c => c.Apellido == pReservacion.Apellido);
            if (!string.IsNullOrWhiteSpace(pReservacion.Email))
                pQuery = pQuery.Where(c => c.Email.Contains(pReservacion.Email));
            if (!string.IsNullOrWhiteSpace(pReservacion.NIdentidad))
                pQuery = pQuery.Where(c => c.NIdentidad.Contains(pReservacion.NIdentidad));
            if (!string.IsNullOrWhiteSpace(pReservacion.Movil))
                pQuery = pQuery.Where(c => c.Movil.Contains(pReservacion.Movil));
            if (!string.IsNullOrWhiteSpace(pReservacion.NHabitacion))
                pQuery = pQuery.Where(c => c.NHabitacion.Contains(pReservacion.NHabitacion));
            if (pReservacion.PHabitacion > 0)
                pQuery = pQuery.Where(s => s.PHabitacion == pReservacion.PHabitacion);
            if (pReservacion.FyHRegistro.Year > 1000)
            {
                DateTime fyhRegistroInicial = new DateTime(pReservacion.FyHRegistro.Year, pReservacion.FyHRegistro.Month, pReservacion.FyHRegistro.Day);
                DateTime fyhRegistroFinal = fyhRegistroInicial.AddDays(1).AddMilliseconds(-1);
                pQuery = pQuery.Where(s => s.FyHRegistro >= fyhRegistroInicial && s.FyHRegistro <= fyhRegistroFinal);
            }
            if (pReservacion.FyHEntrada.Year > 1000)
            {
                DateTime fyhEntradaInicial = new DateTime(pReservacion.FyHEntrada.Year, pReservacion.FyHEntrada.Month, pReservacion.FyHEntrada.Day);
                DateTime fyhEntradaFinal = fyhEntradaInicial.AddDays(1).AddMilliseconds(-1);
                pQuery = pQuery.Where(s => s.FyHEntrada >= fyhEntradaInicial && s.FyHEntrada <= fyhEntradaFinal);
            }
            if (pReservacion.FyHSalida.Year > 1000)
            {
                DateTime fechaInicial = new DateTime(pReservacion.FyHSalida.Year, pReservacion.FyHSalida.Month, pReservacion.FyHSalida.Day, 0, 0, 0);
                DateTime fechaFinal = fechaInicial.AddDays(1).AddMilliseconds(-1);
                pQuery = pQuery.Where(s => s.FyHSalida >= fechaInicial && s.FyHSalida <= fechaFinal);
            }

            pQuery = pQuery.OrderByDescending(c => c.Id).AsQueryable();
            if (pReservacion.top_aux > 0)

                pQuery = pQuery.Take(pReservacion.top_aux).AsQueryable();
            return pQuery;
        }

        public static async Task<List<Reservacion>> BuscarAsync(Reservacion pReservacion)
        {
            var reservacion = new List<Reservacion>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Reservacion.AsQueryable();
                select = QuerySelect(select, pReservacion);
                reservacion = await select.ToListAsync();
            }
            return reservacion;
        }
    }
}
