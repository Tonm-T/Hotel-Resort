using HotelResort.EntidadDeNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HotelResort.AccesoADatos
{
    public class EmpleadoDAL
    {
        private static void EncriptarMD5(Empleado pEmpleado)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(pEmpleado.ClaveEmpleado));
                var strEncriptar = "";
                for (int i = 0; i < result.Length; i++)
                    strEncriptar += result[i].ToString("x2").ToLower();
                pEmpleado.ClaveEmpleado = strEncriptar;
            }
        }
        private static async Task<bool> ExisteDui(Empleado pEmpleado, BDContexto pDbContext)
        {
            bool result = false;
            var DuiEmpleadoExiste = await pDbContext.Empleados.FirstOrDefaultAsync(s => s.Dui == pEmpleado.Dui && s.Id != pEmpleado.Id);
            if (DuiEmpleadoExiste != null && DuiEmpleadoExiste.Id > 0 && DuiEmpleadoExiste.Dui == pEmpleado.Dui)
                result = true;
            return result;
        }
        public static async Task<int> CrearAsync(Empleado pEmpleado)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bool existeDui = await ExisteDui(pEmpleado, bdContexto);
                if (existeDui == false)
                {
                    pEmpleado.FechaRegistro = DateTime.Now;
                    EncriptarMD5(pEmpleado);
                    bdContexto.Add(pEmpleado);
                    result = await bdContexto.SaveChangesAsync();
                }
                else
                    throw new Exception("El Numero de identidad de ya existe");
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Empleado pEmpleado)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bool existeLogin = await ExisteDui(pEmpleado, bdContexto);
                if (existeLogin == false)
                {
                    
                var empleado = await bdContexto.Empleados.FirstOrDefaultAsync(e => e.Id == pEmpleado.Id);
                empleado.Nombre = pEmpleado.Nombre;
                empleado.Apellido = pEmpleado.Apellido;
                empleado.Email = pEmpleado.Email;
                empleado.Movil = pEmpleado.Movil;
                empleado.Direccion = pEmpleado.Direccion;
                empleado.Dui = pEmpleado.Dui;
                empleado.TipoCargoId = pEmpleado.TipoCargoId;

                bdContexto.Update(empleado);
                result = await bdContexto.SaveChangesAsync();
                }
                else
                    throw new Exception("El numero de identidad ya existe");
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Empleado pEmpleado)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var empleados = await bdContexto.Empleados.FirstOrDefaultAsync(e => e.Id == pEmpleado.Id);
                bdContexto.Empleados.Remove(empleados);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Empleado> ObtenerPorIdAsync(Empleado pEmpleado)
        {
            var empleados = new Empleado();
            using (var bdContexto = new BDContexto())
            {
                empleados = await bdContexto.Empleados.FirstOrDefaultAsync(e => e.Id == pEmpleado.Id);
            }
            return empleados;
        }
        public static async Task<List<Empleado>> ObtenerTodosAsync()
        {
            var empleados = new List<Empleado>();
            using (var bdContexto = new BDContexto())
            {
                empleados = await bdContexto.Empleados.ToListAsync();
            }
            return empleados;
        }
        internal static IQueryable<Empleado> QuerySelect(IQueryable<Empleado> pQuery, Empleado pEmpleado)
        {
            if (pEmpleado.Id > 0)
                pQuery = pQuery.Where(e => e.Id == pEmpleado.Id);
            if (pEmpleado.TipoCargoId > 0)
                pQuery = pQuery.Where(e => e.TipoCargoId == pEmpleado.TipoCargoId);
            if (!string.IsNullOrWhiteSpace(pEmpleado.Nombre))
                pQuery = pQuery.Where(e => e.Nombre.Contains(pEmpleado.Nombre));
            if (!string.IsNullOrWhiteSpace(pEmpleado.Apellido))
                pQuery = pQuery.Where(e => e.Apellido.Contains(pEmpleado.Apellido));
            if (!string.IsNullOrWhiteSpace(pEmpleado.Email))
                pQuery = pQuery.Where(e => e.Email.Contains(pEmpleado.Email));
            if (!string.IsNullOrWhiteSpace(pEmpleado.Movil))
                pQuery = pQuery.Where(e => e.Movil.Contains(pEmpleado.Movil));
            if (!string.IsNullOrWhiteSpace(pEmpleado.Direccion))
                pQuery = pQuery.Where(e => e.Direccion.Contains(pEmpleado.Direccion));
            if (!string.IsNullOrWhiteSpace(pEmpleado.Dui))
                pQuery = pQuery.Where(e => e.Dui.Contains(pEmpleado.Dui));

            if (!string.IsNullOrWhiteSpace(pEmpleado.ClaveEmpleado))
                pQuery = pQuery.Where(e => e.ClaveEmpleado.Contains(pEmpleado.ClaveEmpleado));
            if (pEmpleado.FechaRegistro.Year > 1000)
            {
                DateTime fechaInicial = new DateTime(pEmpleado.FechaRegistro.Year, pEmpleado.FechaRegistro.Month, pEmpleado.FechaRegistro.Day, 0, 0, 0);
                DateTime fechaFinal = fechaInicial.AddDays(1).AddMilliseconds(-1);
                pQuery = pQuery.Where(s => s.FechaRegistro >= fechaInicial && s.FechaRegistro <= fechaFinal);
            }

            pQuery = pQuery.OrderByDescending(e => e.Id).AsQueryable();
            if (pEmpleado.top_aux > 0)
                pQuery = pQuery.Take(pEmpleado.top_aux).AsQueryable();
            return pQuery;
        }
        public static async Task<List<Empleado>> BuscarAsync(Empleado pEmpleado)
        {
            var empleados = new List<Empleado>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Empleados.AsQueryable();
                select = QuerySelect(select, pEmpleado);
                empleados = await select.ToListAsync();
            }
            return empleados;
        }
        public static async Task<List<Empleado>> BuscarIncluirTipoCargoAsync(Empleado pEmpleado)
        {
            var empleado = new List<Empleado>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Empleados.AsQueryable();
                select = QuerySelect(select, pEmpleado).Include(e => e.TipoCargo).AsQueryable();
                empleado = await select.ToListAsync();
            }
            return empleado;
        }

       public static async Task<Empleado> LoginAsync(Empleado pEmpleado)
        {
            var empleado = new Empleado();
            using (var bdContexto = new BDContexto())
            {
                EncriptarMD5(pEmpleado);
                empleado = await bdContexto.Empleados.FirstOrDefaultAsync(s => s.Dui == pEmpleado.Dui &&
                s.ClaveEmpleado == pEmpleado.ClaveEmpleado);
            }
            return empleado;
        }

        public static async Task<int> CambiarPasswordAsync(Empleado pEmpleado, string pPasswordAnt)
        {
            int result = 0;
            var EmpleadoPassAnt = new Empleado { ClaveEmpleado = pPasswordAnt };
            EncriptarMD5(EmpleadoPassAnt);
            using (var bdContexto = new BDContexto())
            {
                var empleado = await bdContexto.Empleados.FirstOrDefaultAsync(s => s.Id == pEmpleado.Id);
                if (EmpleadoPassAnt.ClaveEmpleado == empleado.ClaveEmpleado)
                {
                    EncriptarMD5(pEmpleado);
                    empleado.ClaveEmpleado = pEmpleado.ClaveEmpleado;
                    bdContexto.Update(empleado);
                    result = await bdContexto.SaveChangesAsync();
                }
                else
                    throw new Exception("El password actual es incorrecto");
            }
            return result;
        }
    }
}

