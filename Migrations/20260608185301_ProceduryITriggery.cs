using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KlinikaMVC.Migrations
{
    /// <inheritdoc />
    public partial class ProceduryITriggery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Trigger - Blokuje dodawanie wizyt w przeszłości
            migrationBuilder.Sql(@"
                CREATE TRIGGER trg_BlokadaWizytyWPrzeszlosci
                ON Wizyty
                AFTER INSERT, UPDATE
                AS
                BEGIN
                    IF EXISTS (SELECT 1 FROM inserted WHERE DataWizyty < GETDATE())
                    BEGIN
                        RAISERROR ('Nie mozna zarezerwowac wizyty w przeszlosci!', 16, 1);
                        ROLLBACK TRANSACTION;
                    END
                END;
            ");

            // 2. Procedura składowana - Wyciąga pacjentów z największymi długami
            migrationBuilder.Sql(@"
                CREATE PROCEDURE sp_RaportDlugow
                AS
                BEGIN
                    SELECT Id, Imie, Nazwisko, Dlug 
                    FROM Pacjenci 
                    ORDER BY Dlug DESC;
                END;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_BlokadaWizytyWPrzeszlosci;");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_RaportDlugow;");
        }
    }
}
