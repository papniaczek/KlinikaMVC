using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KlinikaMVC.Models;

namespace KlinikaMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Rejestracja wszystkich twoich tabel
        public DbSet<TypUzaleznienia> TypyUzaleznien { get; set; }
        public DbSet<StatusWizyty> StatusyWizyt { get; set; }
        public DbSet<TypDanych> TypyDanych { get; set; }
        public DbSet<Administrator> Administratorzy { get; set; }
        public DbSet<Pacjent> Pacjenci { get; set; }
        public DbSet<Terapeuta> Terapeuci { get; set; }
        public DbSet<Wizyta> Wizyty { get; set; }
        public DbSet<NotatkaZWizyty> NotatkiZWizyt { get; set; }
        public DbSet<GrupaWsparcia> GrupyWsparcia { get; set; }
        public DbSet<PacjentGrupa> PacjenciGrupy { get; set; }
        public DbSet<PrzypisanieUzaleznienia> PrzypisaniaUzaleznien { get; set; }
        public DbSet<Wiadomosc> Wiadomosci { get; set; }
        public DbSet<WiadomoscOdbiorca> WiadomosciOdbiorcy { get; set; }
        public DbSet<Zalacznik> Zalaczniki { get; set; }
        public DbSet<Zadanie> Zadania { get; set; }
        public DbSet<KrokZadania> KrokiZadania { get; set; }
        public DbSet<OpcjaOdpowiedzi> OpcjeOdpowiedzi { get; set; }
        public DbSet<UdostepnienieZadania> UdostepnieniaZadan { get; set; }
        public DbSet<PodejscieDoZadania> PodejsciaDoZadania { get; set; }
        public DbSet<OdpowiedzPacjenta> OdpowiedziPacjentow { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Klucze kompozytowe dla tabel pośrednich
            builder.Entity<PacjentGrupa>()
                .HasKey(pg => new { pg.PacjentId, pg.GrupaId });

            builder.Entity<PrzypisanieUzaleznienia>()
                .HasKey(pu => new { pu.PacjentId, pu.UzaleznienieId });

            builder.Entity<WiadomoscOdbiorca>()
                .HasKey(wo => new { wo.WiadomoscId, wo.OdbiorcaId });

            // Wizyta - Notatka
            builder.Entity<Wizyta>()
                .HasOne(w => w.Notatka)
                .WithOne(n => n.Wizyta)
                .HasForeignKey<NotatkaZWizyty>(n => n.WizytaId);

            // Blokada kaskadowego usuwania dla wiadomości
            builder.Entity<WiadomoscOdbiorca>()
                .HasOne(wo => wo.Wiadomosc)
                .WithMany(w => w.Odbiorcy)
                .HasForeignKey(wo => wo.WiadomoscId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Wizyta>()
                .HasOne(w => w.Terapeuta)
                .WithMany(t => t.Wizyty)
                .HasForeignKey(w => w.TerapeutaId)
                .OnDelete(DeleteBehavior.Restrict);
            
            // Blokada kaskady dla grup wsparcia
            builder.Entity<PacjentGrupa>()
                .HasOne(pg => pg.Pacjent)
                .WithMany(p => p.PacjenciGrupy)
                .HasForeignKey(pg => pg.PacjentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PacjentGrupa>()
                .HasOne(pg => pg.GrupaWsparcia)
                .WithMany(g => g.PacjenciGrupy)
                .HasForeignKey(pg => pg.GrupaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Blokada kaskady dla uzależnień żeby nie rzucało błędem
            builder.Entity<PrzypisanieUzaleznienia>()
                .HasOne(pu => pu.Pacjent)
                .WithMany(p => p.PrzypisaniaUzaleznien)
                .HasForeignKey(pu => pu.PacjentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Blokada kaskady dla przypisywania zadań pacjentom
            builder.Entity<UdostepnienieZadania>()
                .HasOne(uz => uz.Pacjent)
                .WithMany(p => p.UdostepnieniaZadan)
                .HasForeignKey(uz => uz.PacjentId)
                .OnDelete(DeleteBehavior.Restrict);
            
            // Blokada kaskady dla modułu zadań (żeby uniknąć cykli przy usuwaniu odpowiedzi)
            builder.Entity<OdpowiedzPacjenta>()
                .HasOne(op => op.WybranaOpcja)
                .WithMany(o => o.WybraneW)
                .HasForeignKey(op => op.WybranaOpcjaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<OdpowiedzPacjenta>()
                .HasOne(op => op.Krok)
                .WithMany(k => k.OdpowiedziPacjentow)
                .HasForeignKey(op => op.KrokId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<OdpowiedzPacjenta>()
                .HasOne(op => op.Podejscie)
                .WithMany(p => p.UdzieloneOdpowiedzi)
                .HasForeignKey(op => op.PodejscieId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}