using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace zadanie4.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cialo = table.Column<int>(type: "int", nullable: false),
                    Umysl = table.Column<int>(type: "int", nullable: false),
                    Relacje = table.Column<int>(type: "int", nullable: false),
                    Praca = table.Column<int>(type: "int", nullable: false),
                    Duchowosc = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pytania",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tresc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Typ = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pytania", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Odpowiedzi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tresc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PytanieId = table.Column<int>(type: "int", nullable: false),
                    PunktyCialo = table.Column<int>(type: "int", nullable: false),
                    PunktyUmysl = table.Column<int>(type: "int", nullable: false),
                    PunktyRelacje = table.Column<int>(type: "int", nullable: false),
                    PunktyPraca = table.Column<int>(type: "int", nullable: false),
                    PunktyDuchowosc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odpowiedzi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Odpowiedzi_Pytania_PytanieId",
                        column: x => x.PytanieId,
                        principalTable: "Pytania",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pytania",
                columns: new[] { "Id", "Tresc", "Typ" },
                values: new object[,]
                {
                    { 1, "Co najczęściej robisz, kiedy masz wolną godzinę tylko dla siebie?", "choice" },
                    { 2, "Na ile lubisz wyzwania fizyczne? (sport, trening, aktywność)", "scale" },
                    { 3, "Czy często wpadają Ci do głowy nowe pomysły albo projekty?", "scale" },
                    { 4, "Co bardziej Cię napędza?", "choice" },
                    { 5, "Jak bardzo lubisz działać w grupie?", "scale" },
                    { 6, "Gdy masz problem, co robisz jako pierwsze?", "choice" },
                    { 7, "Czy dbasz o swoje zdrowie i energię? (sen, ruch, jedzenie)", "scale" },
                    { 8, "Jak ważny jest dla Ciebie rozwój osobisty?", "scale" },
                    { 9, "Kiedy poznajesz nowych ludzi, jesteś raczej:", "choice" },
                    { 10, "Gdybyś miał wybrać jedną rzecz, w której chcesz się najbardziej rozwijać?", "choice" }
                });

            migrationBuilder.InsertData(
                table: "Odpowiedzi",
                columns: new[] { "Id", "PunktyCialo", "PunktyDuchowosc", "PunktyPraca", "PunktyRelacje", "PunktyUmysl", "PytanieId", "Tresc" },
                values: new object[,]
                {
                    { 1, 0, 0, 0, 0, 10, 1, "Czytam / uczę się czegoś" },
                    { 2, 0, 0, 0, 0, 5, 1, "Oglądam coś" },
                    { 3, 0, 3, 0, 0, 7, 1, "Tworzę coś (rysunek, pisanie itp.)" },
                    { 4, 0, 0, 0, 10, 0, 1, "Spotykam się z kimś" },
                    { 5, 10, 0, 0, 0, 0, 1, "Sport / ruch" },
                    { 6, 2, 0, 0, 0, 0, 2, "1" },
                    { 7, 4, 0, 0, 0, 0, 2, "2" },
                    { 8, 6, 0, 0, 0, 0, 2, "3" },
                    { 9, 8, 0, 0, 0, 0, 2, "4" },
                    { 10, 10, 0, 0, 0, 0, 2, "5" },
                    { 11, 0, 0, 0, 0, 2, 3, "1" },
                    { 12, 0, 0, 0, 0, 4, 3, "2" },
                    { 13, 0, 0, 0, 0, 6, 3, "3" },
                    { 14, 0, 0, 0, 0, 8, 3, "4" },
                    { 15, 0, 0, 0, 0, 10, 3, "5" },
                    { 16, 0, 0, 10, 0, 0, 4, "Osiąganie celów" },
                    { 17, 0, 3, 0, 0, 7, 4, "Kreatywność" },
                    { 18, 0, 0, 0, 10, 0, 4, "Pomaganie innym" },
                    { 19, 5, 0, 0, 0, 5, 4, "Przygoda i nowe doświadczenia" },
                    { 20, 0, 10, 0, 0, 0, 4, "Spokój i stabilność" },
                    { 21, 0, 0, 0, 2, 0, 5, "1" },
                    { 22, 0, 0, 0, 4, 0, 5, "2" },
                    { 23, 0, 0, 0, 6, 0, 5, "3" },
                    { 24, 0, 0, 0, 8, 0, 5, "4" },
                    { 25, 0, 0, 0, 10, 0, 5, "5" },
                    { 26, 0, 0, 0, 0, 10, 6, "Analizuję i szukam rozwiązania" },
                    { 27, 0, 0, 0, 8, 0, 6, "Pytam kogoś o radę" },
                    { 28, 5, 0, 5, 0, 0, 6, "Działam od razu i testuję" },
                    { 29, 0, 8, 0, 0, 0, 6, "Robię przerwę i wracam później" },
                    { 30, 2, 0, 0, 0, 0, 7, "1" },
                    { 31, 4, 0, 0, 0, 0, 7, "2" },
                    { 32, 6, 0, 0, 0, 0, 7, "3" },
                    { 33, 8, 0, 0, 0, 0, 7, "4" },
                    { 34, 10, 0, 0, 0, 0, 7, "5" },
                    { 35, 0, 2, 0, 0, 0, 8, "1" },
                    { 36, 0, 4, 0, 0, 0, 8, "2" },
                    { 37, 0, 6, 0, 0, 0, 8, "3" },
                    { 38, 0, 8, 0, 0, 0, 8, "4" },
                    { 39, 0, 10, 0, 0, 0, 8, "5" },
                    { 40, 0, 0, 0, 10, 0, 9, "Duszą towarzystwa" },
                    { 41, 0, 0, 0, 8, 0, 9, "Otwarty, ale spokojny" },
                    { 42, 0, 0, 0, 0, 5, 9, "Raczej obserwatorem" },
                    { 43, 0, 5, 0, 0, 0, 9, "Potrzebuję czasu żeby się otworzyć" },
                    { 44, 10, 0, 0, 0, 0, 10, "Sport / zdrowie" },
                    { 45, 0, 0, 0, 0, 10, 10, "Wiedza / nauka" },
                    { 46, 0, 0, 0, 10, 0, 10, "Relacje z ludźmi" },
                    { 47, 0, 0, 10, 0, 0, 10, "Kariera / umiejętności" },
                    { 48, 0, 10, 0, 0, 0, 10, "Rozwój wewnętrzny / spokój" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Odpowiedzi_PytanieId",
                table: "Odpowiedzi",
                column: "PytanieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Odpowiedzi");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "Pytania");
        }
    }
}
