using Microsoft.EntityFrameworkCore;
using zadanie4.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace zadanie4.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Pytanie> Pytania { get; set; }
        public DbSet<Odpowiedz> Odpowiedzi { get; set; }
        public DbSet<ProfilUzytkownika> Profile { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pytanie>().HasData(
           
                new Pytanie { Id = 1, Tresc = "Co najczęściej robisz, kiedy masz wolną godzinę tylko dla siebie?", Typ = "choice" },
                new Pytanie { Id = 2, Tresc = "Na ile lubisz wyzwania fizyczne? (sport, trening, aktywność)", Typ = "scale" },
                new Pytanie { Id = 3, Tresc = "Czy często wpadają Ci do głowy nowe pomysły albo projekty?", Typ = "scale" },
                new Pytanie { Id = 4, Tresc = "Co bardziej Cię napędza?", Typ = "choice" },
                new Pytanie { Id = 5, Tresc = "Jak bardzo lubisz działać w grupie?", Typ = "scale" },
                new Pytanie { Id = 6, Tresc = "Gdy masz problem, co robisz jako pierwsze?", Typ = "choice" },
                new Pytanie { Id = 7, Tresc = "Czy dbasz o swoje zdrowie i energię? (sen, ruch, jedzenie)", Typ = "scale" },
                new Pytanie { Id = 8, Tresc = "Jak ważny jest dla Ciebie rozwój osobisty?", Typ = "scale" },
                new Pytanie { Id = 9, Tresc = "Kiedy poznajesz nowych ludzi, jesteś raczej:", Typ = "choice" },
                new Pytanie { Id = 10, Tresc = "Gdybyś miał wybrać jedną rzecz, w której chcesz się najbardziej rozwijać?", Typ = "choice" }
            );

            modelBuilder.Entity<Odpowiedz>().HasData(
                new Odpowiedz { Id = 1, PytanieId = 1, Tresc = "Czytam / uczę się czegoś", PunktyUmysl = 10 },
                new Odpowiedz { Id = 2, PytanieId = 1, Tresc = "Oglądam coś", PunktyUmysl = 5 },
                new Odpowiedz { Id = 3, PytanieId = 1, Tresc = "Tworzę coś (rysunek, pisanie itp.)", PunktyUmysl = 7, PunktyDuchowosc = 3 },
                new Odpowiedz { Id = 4, PytanieId = 1, Tresc = "Spotykam się z kimś", PunktyRelacje = 10 },
                new Odpowiedz { Id = 5, PytanieId = 1, Tresc = "Sport / ruch", PunktyCialo = 10 },


                new Odpowiedz { Id = 6, PytanieId = 2, Tresc = "1", PunktyCialo = 2 },
                new Odpowiedz { Id = 7, PytanieId = 2, Tresc = "2", PunktyCialo = 4 },
                new Odpowiedz { Id = 8, PytanieId = 2, Tresc = "3", PunktyCialo = 6 },
                new Odpowiedz { Id = 9, PytanieId = 2, Tresc = "4", PunktyCialo = 8 },
                new Odpowiedz { Id = 10, PytanieId = 2, Tresc = "5", PunktyCialo = 10 },


                new Odpowiedz { Id = 11, PytanieId = 3, Tresc = "1", PunktyUmysl = 2 },
                new Odpowiedz { Id = 12, PytanieId = 3, Tresc = "2", PunktyUmysl = 4 },
                new Odpowiedz { Id = 13, PytanieId = 3, Tresc = "3", PunktyUmysl = 6 },
                new Odpowiedz { Id = 14, PytanieId = 3, Tresc = "4", PunktyUmysl = 8 },
                new Odpowiedz { Id = 15, PytanieId = 3, Tresc = "5", PunktyUmysl = 10 },


                new Odpowiedz { Id = 16, PytanieId = 4, Tresc = "Osiąganie celów", PunktyPraca = 10 },
                new Odpowiedz { Id = 17, PytanieId = 4, Tresc = "Kreatywność", PunktyUmysl = 7, PunktyDuchowosc = 3 },
                new Odpowiedz { Id = 18, PytanieId = 4, Tresc = "Pomaganie innym", PunktyRelacje = 10 },
                new Odpowiedz { Id = 19, PytanieId = 4, Tresc = "Przygoda i nowe doświadczenia", PunktyCialo = 5, PunktyUmysl = 5 },
                new Odpowiedz { Id = 20, PytanieId = 4, Tresc = "Spokój i stabilność", PunktyDuchowosc = 10 },


                new Odpowiedz { Id = 21, PytanieId = 5, Tresc = "1", PunktyRelacje = 2 },
                new Odpowiedz { Id = 22, PytanieId = 5, Tresc = "2", PunktyRelacje = 4 },
                new Odpowiedz { Id = 23, PytanieId = 5, Tresc = "3", PunktyRelacje = 6 },
                new Odpowiedz { Id = 24, PytanieId = 5, Tresc = "4", PunktyRelacje = 8 },
                new Odpowiedz { Id = 25, PytanieId = 5, Tresc = "5", PunktyRelacje = 10 },


                new Odpowiedz { Id = 26, PytanieId = 6, Tresc = "Analizuję i szukam rozwiązania", PunktyUmysl = 10 },
                new Odpowiedz { Id = 27, PytanieId = 6, Tresc = "Pytam kogoś o radę", PunktyRelacje = 8 },
                new Odpowiedz { Id = 28, PytanieId = 6, Tresc = "Działam od razu i testuję", PunktyCialo = 5, PunktyPraca = 5 },
                new Odpowiedz { Id = 29, PytanieId = 6, Tresc = "Robię przerwę i wracam później", PunktyDuchowosc = 8 },


                new Odpowiedz { Id = 30, PytanieId = 7, Tresc = "1", PunktyCialo = 2 },
                new Odpowiedz { Id = 31, PytanieId = 7, Tresc = "2", PunktyCialo = 4 },
                new Odpowiedz { Id = 32, PytanieId = 7, Tresc = "3", PunktyCialo = 6 },
                new Odpowiedz { Id = 33, PytanieId = 7, Tresc = "4", PunktyCialo = 8 },
                new Odpowiedz { Id = 34, PytanieId = 7, Tresc = "5", PunktyCialo = 10 },


                new Odpowiedz { Id = 35, PytanieId = 8, Tresc = "1", PunktyDuchowosc = 2 },
                new Odpowiedz { Id = 36, PytanieId = 8, Tresc = "2", PunktyDuchowosc = 4 },
                new Odpowiedz { Id = 37, PytanieId = 8, Tresc = "3", PunktyDuchowosc = 6 },
                new Odpowiedz { Id = 38, PytanieId = 8, Tresc = "4", PunktyDuchowosc = 8 },
                new Odpowiedz { Id = 39, PytanieId = 8, Tresc = "5", PunktyDuchowosc = 10 },


                new Odpowiedz { Id = 40, PytanieId = 9, Tresc = "Duszą towarzystwa", PunktyRelacje = 10 },
                new Odpowiedz { Id = 41, PytanieId = 9, Tresc = "Otwarty, ale spokojny", PunktyRelacje = 8 },
                new Odpowiedz { Id = 42, PytanieId = 9, Tresc = "Raczej obserwatorem", PunktyUmysl = 5 },
                new Odpowiedz { Id = 43, PytanieId = 9, Tresc = "Potrzebuję czasu żeby się otworzyć", PunktyDuchowosc = 5 },


                new Odpowiedz { Id = 44, PytanieId = 10, Tresc = "Sport / zdrowie", PunktyCialo = 10 },
                new Odpowiedz { Id = 45, PytanieId = 10, Tresc = "Wiedza / nauka", PunktyUmysl = 10 },
                new Odpowiedz { Id = 46, PytanieId = 10, Tresc = "Relacje z ludźmi", PunktyRelacje = 10 },
                new Odpowiedz { Id = 47, PytanieId = 10, Tresc = "Kariera / umiejętności", PunktyPraca = 10 },
                new Odpowiedz { Id = 48, PytanieId = 10, Tresc = "Rozwój wewnętrzny / spokój", PunktyDuchowosc = 10 }
            );
        }
    }
}