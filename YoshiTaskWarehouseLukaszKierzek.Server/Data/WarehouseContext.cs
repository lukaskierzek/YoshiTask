using Microsoft.EntityFrameworkCore;
using YoshiTaskWarehouseLukaszKierzek.Server.Models;
using YoshiTaskWarehouseLukaszKierzek.Server.Models.Enums;

namespace YoshiTaskWarehouseLukaszKierzek.Server.Data
{
    public class WarehouseContext : DbContext
    {
        public DbSet<DokumentPrzyjecia> dokumentPrzyjecia { get; set; }
        public DbSet<Dostawca> dostawca { get; set; }
        public DbSet<Etykieta> etykieta { get; set; }
        public DbSet<Magazyn> magazyn { get; set; }
        public DbSet<Towar> towar { get; set; }
        public DbSet<DokumentPrzyjeciaEtykieta> dokumentPrzyjeciaEtykieta { get; set; }

        public WarehouseContext(DbContextOptions<WarehouseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DokumentPrzyjecia>()
                .HasOne(dokumentPrzyjecia => dokumentPrzyjecia.Dostawca)
                .WithMany(dostawca => dostawca.DokumentyPrzyjecia)
                .HasForeignKey(dokumentPrzyjecia => dokumentPrzyjecia.DostawcaId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);

            modelBuilder.Entity<DokumentPrzyjecia>()
                .HasMany(dokumentPrzyjecia => dokumentPrzyjecia.Etykiety)
                .WithMany(etykieta => etykieta.DokumentyPrzyjecia)
                .UsingEntity<DokumentPrzyjeciaEtykieta>();

            modelBuilder.Entity<DokumentPrzyjecia>()
                .HasOne(dokumentPrzyjecia => dokumentPrzyjecia.MagazynDocelowy)
                .WithMany(magazyn => magazyn.DokumentyPrzyjecia)
                .HasForeignKey(dokumentPrzyjecia => dokumentPrzyjecia.MagazynDocelowyId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);


            modelBuilder.Entity<DokumentPrzyjecia>()
                .HasMany(dokumentPrzyjecia => dokumentPrzyjecia.ListaTowarow)
                .WithOne(towar => towar.DokumentPrzyjecia)
                .HasForeignKey(towar => towar.DokumnetPrzyjeciaId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);

            var dostawcaList = new List<Dostawca>
            {
                new Dostawca { Id = 1, Adres = "adres1", NazwaFirmy = "Firma1" },
                new Dostawca { Id = 2, Adres = "adres2", NazwaFirmy = "Firma2" },
                new Dostawca { Id = 3, Adres = "adres3", NazwaFirmy = "Firma3" },
            };
            modelBuilder.Entity<Dostawca>().HasData(dostawcaList);

            var etykietaList = new List<Etykieta>
            {
                new Etykieta {Id = 1,Nazwa="Etykieta1"},
                new Etykieta {Id = 2,Nazwa="Etykieta2"},
                new Etykieta {Id = 3,Nazwa="Etykieta3"},
            };
            modelBuilder.Entity<Etykieta>().HasData(etykietaList);

            var magazynList = new List<Magazyn>
            {
                new Magazyn {Id=1,Nazwa="Magazyn1", Symbol="Symbol1"},
                new Magazyn {Id=2,Nazwa="Magazyn2", Symbol="Symbol2"},
                new Magazyn {Id=3,Nazwa="Magazyn3", Symbol="Symbol3"},
            };
            modelBuilder.Entity<Magazyn>().HasData(magazynList);

            var dokumentyPrzyjeciaList = new List<DokumentPrzyjecia>
            {
                new DokumentPrzyjecia {Id=1, MagazynDocelowyId=1,DostawcaId=1, Anulowany=(int)IsCancelled.No, Zatwierdzony=(int)IsApproved.No},
                new DokumentPrzyjecia {Id=2, MagazynDocelowyId=1,DostawcaId=1, Anulowany=(int)IsCancelled.No, Zatwierdzony=(int)IsApproved.No},
                new DokumentPrzyjecia {Id=3, MagazynDocelowyId=2,DostawcaId=2, Anulowany=(int)IsCancelled.Yes, Zatwierdzony=(int)IsApproved.No},
            };
            modelBuilder.Entity<DokumentPrzyjecia>().HasData(dokumentyPrzyjeciaList);

            var dokuemntyPrzyjeciaEtykietaList = new List<DokumentPrzyjeciaEtykieta>
            {
                new DokumentPrzyjeciaEtykieta {DokumentPrzyjeciaId=1, EtykietaId=1},
                new DokumentPrzyjeciaEtykieta {DokumentPrzyjeciaId=1, EtykietaId=2},
                new DokumentPrzyjeciaEtykieta {DokumentPrzyjeciaId=2, EtykietaId=3},
            };
            modelBuilder.Entity<DokumentPrzyjeciaEtykieta>().HasData(dokuemntyPrzyjeciaEtykietaList);

            var towarList = new List<Towar>
            {
                new Towar {Id=1, Nazwa="Towar1", Kod="kod1", Cena=20.99m, Ilosc=2, DokumnetPrzyjeciaId=1},
                new Towar {Id=2, Nazwa="Towar2", Kod="kod2", Cena=21.99m, Ilosc=4, DokumnetPrzyjeciaId=1},
                new Towar {Id=3, Nazwa="Towar3", Kod="kod3", Cena=22.99m, Ilosc=5, DokumnetPrzyjeciaId=2},
            };
            modelBuilder.Entity<Towar>().HasData(towarList);

            base.OnModelCreating(modelBuilder);
        }

    }
}
