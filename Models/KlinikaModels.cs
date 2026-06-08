using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace KlinikaMVC.Models
{
    // SŁOWNIKI
    public class TypUzaleznienia
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public ICollection<PrzypisanieUzaleznienia> PrzypisaniaUzaleznien { get; set; }
    }

    public class StatusWizyty
    {
        public int Id { get; set; }
        public string Nazwa { get; set; } // Oczekująca, Odbyta, Anulowana
        public ICollection<Wizyta> Wizyty { get; set; }
    }

    public class TypDanych
    {
        public int Id { get; set; }
        public string Rozszerzenie { get; set; } // np. .pdf, .jpg
        public ICollection<Zalacznik> Zalaczniki { get; set; }
    }
    
    // KONTA I PROFILE
    
    public class Administrator
    {
        public int Id { get; set; }
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
        public string Imie { get; set; }
    }

    public class Pacjent
    {
        public int Id { get; set; }
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
        
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Dlug { get; set; }

        public ICollection<Wizyta> Wizyty { get; set; }
        public ICollection<PacjentGrupa> PacjenciGrupy { get; set; }
        public ICollection<PrzypisanieUzaleznienia> PrzypisaniaUzaleznien { get; set; }
        public ICollection<UdostepnienieZadania> UdostepnieniaZadan { get; set; }
    }

    public class Terapeuta
    {
        public int Id { get; set; }
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
        
        public string Imie { get; set; }
        public string Specjalizacja { get; set; }

        public ICollection<Wizyta> Wizyty { get; set; }
        public ICollection<GrupaWsparcia> GrupyWsparcia { get; set; }
        public ICollection<Zadanie> Zadania { get; set; }
    }

    // WIZYTY I GRUPY
    public class Wizyta
    {
        public int Id { get; set; }
        public DateTime DataWizyty { get; set; }

        public int PacjentId { get; set; }
        public Pacjent Pacjent { get; set; }

        public int TerapeutaId { get; set; }
        public Terapeuta Terapeuta { get; set; }

        public int StatusId { get; set; }
        public StatusWizyty Status { get; set; }

        public NotatkaZWizyty Notatka { get; set; } // Relacja 1:1
    }

    public class NotatkaZWizyty
    {
        public int Id { get; set; }
        public string Tresc { get; set; }

        public int WizytaId { get; set; }
        public Wizyta Wizyta { get; set; }
    }

    public class GrupaWsparcia
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }

        public int TerapeutaId { get; set; }
        public Terapeuta Terapeuta { get; set; }

        public ICollection<PacjentGrupa> PacjenciGrupy { get; set; }
    }

    // Tabele pośrednie
    public class PacjentGrupa
    {
        public int PacjentId { get; set; }
        public Pacjent Pacjent { get; set; }

        public int GrupaId { get; set; }
        public GrupaWsparcia GrupaWsparcia { get; set; }
    }

    public class PrzypisanieUzaleznienia
    {
        public int PacjentId { get; set; }
        public Pacjent Pacjent { get; set; }

        public int UzaleznienieId { get; set; }
        public TypUzaleznienia TypUzaleznienia { get; set; }
    }

    // WIADOMOŚCI
    public class Wiadomosc
    {
        public int Id { get; set; }
        public string Tresc { get; set; }
        public DateTime DataWyslania { get; set; }

        public string NadawcaId { get; set; } // Klucz do IdentityUser
        public IdentityUser Nadawca { get; set; }

        public ICollection<WiadomoscOdbiorca> Odbiorcy { get; set; }
        public ICollection<Zalacznik> Zalaczniki { get; set; }
    }

    public class WiadomoscOdbiorca
    {
        public int WiadomoscId { get; set; }
        public Wiadomosc Wiadomosc { get; set; }

        public string OdbiorcaId { get; set; } // Klucz do IdentityUser
        public IdentityUser Odbiorca { get; set; }

        public bool CzyPrzeczytana { get; set; }
    }

    public class Zalacznik
    {
        public int Id { get; set; }
        public string Sciezka { get; set; }

        public int WiadomoscId { get; set; }
        public Wiadomosc Wiadomosc { get; set; }

        public int TypDanychId { get; set; }
        public TypDanych TypDanych { get; set; }
    }

    // ZADANIA
    public class Zadanie
    {
        public int Id { get; set; }
        public string Tytul { get; set; }

        public int TerapeutaId { get; set; }
        public Terapeuta Terapeuta { get; set; }

        public ICollection<KrokZadania> Kroki { get; set; }
        public ICollection<UdostepnienieZadania> Udostepnienia { get; set; }
    }

    public class KrokZadania
    {
        public int Id { get; set; }
        public string TrescKroku { get; set; }

        public int ZadanieId { get; set; }
        public Zadanie Zadanie { get; set; }

        public ICollection<OpcjaOdpowiedzi> Opcje { get; set; }
        public ICollection<OdpowiedzPacjenta> OdpowiedziPacjentow { get; set; }
    }

    public class OpcjaOdpowiedzi
    {
        public int Id { get; set; }
        public string TrescOpcji { get; set; }

        public int KrokId { get; set; }
        public KrokZadania Krok { get; set; }

        public ICollection<OdpowiedzPacjenta> WybraneW { get; set; }
    }

    public class UdostepnienieZadania
    {
        public int Id { get; set; }
        
        public int ZadanieId { get; set; }
        public Zadanie Zadanie { get; set; }

        public int PacjentId { get; set; }
        public Pacjent Pacjent { get; set; }

        public ICollection<PodejscieDoZadania> Podejscia { get; set; }
    }

    public class PodejscieDoZadania
    {
        public int Id { get; set; }
        public DateTime DataRozpoczecia { get; set; }

        public int UdostepnienieId { get; set; }
        public UdostepnienieZadania Udostepnienie { get; set; }

        public ICollection<OdpowiedzPacjenta> UdzieloneOdpowiedzi { get; set; }
    }

    public class OdpowiedzPacjenta
    {
        public int Id { get; set; }

        public int PodejscieId { get; set; }
        public PodejscieDoZadania Podejscie { get; set; }

        public int KrokId { get; set; }
        public KrokZadania Krok { get; set; }

        public int WybranaOpcjaId { get; set; }
        public OpcjaOdpowiedzi WybranaOpcja { get; set; }
    }
}