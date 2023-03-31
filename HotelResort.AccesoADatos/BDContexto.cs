using HotelResort.EntidadDeNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelResort.AccesoADatos
{
    public class BDContexto  : DbContext
    {
        public DbSet<Reservacion> Reservacion{ get; set; }
        public DbSet<Empleado> Empleados{ get; set; }
        public DbSet<TipoCargo> TipoCargo{ get; set; }
        public DbSet<CatalogoHotel> CatalogoHotel{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=DESKTOP-GDA2PJM;Initial Catalog=CatalogoHotel;Integrated Security=True; trust Server Certificate=True");
            //options.UseSqlServer(@"Data Source=DESKTOP-GDA2PJM;Initial Catalog=CatalogoHotel;Integrated Security=True");
        }
    }
}
