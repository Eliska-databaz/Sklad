using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity
{
    public class WarehouseContext : DbContext
    {
        public DbSet<Material> Materials { get; set; }
        public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
                options.UseSqlServer(
                    "Data Source=(localdb)\\MSSQLLocalDB;" +
                    "Initial Catalog=Warehouse2026;" +
                    "Integrated Security=True;" +
                    "TrustServerCertificate=True")
                    .UseLazyLoadingProxies();
        }

        public void Seed()
        {
            if (UnitOfMeasures.Any() || Materials.Any())
            {
                return;
            }

            var pcsUnit = new UnitOfMeasure { Description = "ks" };
            var kgUnit = new UnitOfMeasure { Description = "kg" };
            var m3Unit = new UnitOfMeasure { Description = "m3" };

            var screw = new Material
            {
                Name = "Šroub",
                SafetyStock = 1000,
                PalletCapacity = 2000,
                UnitOfMeasure = pcsUnit
            };

            var nail = new Material
            {
                Name = "Hřebík",
                SafetyStock = 1500,
                PalletCapacity = 1000,
                UnitOfMeasure = pcsUnit
            };

            UnitOfMeasures.AddRange(pcsUnit, kgUnit, m3Unit);
            Materials.AddRange(screw, nail);

            SaveChanges();
        }

    }
}