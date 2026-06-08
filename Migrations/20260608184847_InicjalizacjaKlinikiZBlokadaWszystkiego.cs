using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KlinikaMVC.Migrations
{
    /// <inheritdoc />
    public partial class InicjalizacjaKlinikiZBlokadaWszystkiego : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusyWizyt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusyWizyt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypyDanych",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rozszerzenie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypyDanych", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypyUzaleznien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypyUzaleznien", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Administratorzy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administratorzy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administratorzy_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pacjenci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dlug = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacjenci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacjenci_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Terapeuci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specjalizacja = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terapeuci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Terapeuci_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wiadomosci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tresc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataWyslania = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NadawcaId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wiadomosci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wiadomosci_AspNetUsers_NadawcaId",
                        column: x => x.NadawcaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrzypisaniaUzaleznien",
                columns: table => new
                {
                    PacjentId = table.Column<int>(type: "int", nullable: false),
                    UzaleznienieId = table.Column<int>(type: "int", nullable: false),
                    TypUzaleznieniaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrzypisaniaUzaleznien", x => new { x.PacjentId, x.UzaleznienieId });
                    table.ForeignKey(
                        name: "FK_PrzypisaniaUzaleznien_Pacjenci_PacjentId",
                        column: x => x.PacjentId,
                        principalTable: "Pacjenci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrzypisaniaUzaleznien_TypyUzaleznien_TypUzaleznieniaId",
                        column: x => x.TypUzaleznieniaId,
                        principalTable: "TypyUzaleznien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GrupyWsparcia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TerapeutaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupyWsparcia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrupyWsparcia_Terapeuci_TerapeutaId",
                        column: x => x.TerapeutaId,
                        principalTable: "Terapeuci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wizyty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataWizyty = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PacjentId = table.Column<int>(type: "int", nullable: false),
                    TerapeutaId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wizyty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wizyty_Pacjenci_PacjentId",
                        column: x => x.PacjentId,
                        principalTable: "Pacjenci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wizyty_StatusyWizyt_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StatusyWizyt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wizyty_Terapeuci_TerapeutaId",
                        column: x => x.TerapeutaId,
                        principalTable: "Terapeuci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zadania",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytul = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TerapeutaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zadania", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zadania_Terapeuci_TerapeutaId",
                        column: x => x.TerapeutaId,
                        principalTable: "Terapeuci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WiadomosciOdbiorcy",
                columns: table => new
                {
                    WiadomoscId = table.Column<int>(type: "int", nullable: false),
                    OdbiorcaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CzyPrzeczytana = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WiadomosciOdbiorcy", x => new { x.WiadomoscId, x.OdbiorcaId });
                    table.ForeignKey(
                        name: "FK_WiadomosciOdbiorcy_AspNetUsers_OdbiorcaId",
                        column: x => x.OdbiorcaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WiadomosciOdbiorcy_Wiadomosci_WiadomoscId",
                        column: x => x.WiadomoscId,
                        principalTable: "Wiadomosci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zalaczniki",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sciezka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WiadomoscId = table.Column<int>(type: "int", nullable: false),
                    TypDanychId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zalaczniki", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zalaczniki_TypyDanych_TypDanychId",
                        column: x => x.TypDanychId,
                        principalTable: "TypyDanych",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zalaczniki_Wiadomosci_WiadomoscId",
                        column: x => x.WiadomoscId,
                        principalTable: "Wiadomosci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PacjenciGrupy",
                columns: table => new
                {
                    PacjentId = table.Column<int>(type: "int", nullable: false),
                    GrupaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacjenciGrupy", x => new { x.PacjentId, x.GrupaId });
                    table.ForeignKey(
                        name: "FK_PacjenciGrupy_GrupyWsparcia_GrupaId",
                        column: x => x.GrupaId,
                        principalTable: "GrupyWsparcia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PacjenciGrupy_Pacjenci_PacjentId",
                        column: x => x.PacjentId,
                        principalTable: "Pacjenci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NotatkiZWizyt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tresc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WizytaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotatkiZWizyt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotatkiZWizyt_Wizyty_WizytaId",
                        column: x => x.WizytaId,
                        principalTable: "Wizyty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KrokiZadania",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrescKroku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZadanieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KrokiZadania", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KrokiZadania_Zadania_ZadanieId",
                        column: x => x.ZadanieId,
                        principalTable: "Zadania",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UdostepnieniaZadan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZadanieId = table.Column<int>(type: "int", nullable: false),
                    PacjentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UdostepnieniaZadan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UdostepnieniaZadan_Pacjenci_PacjentId",
                        column: x => x.PacjentId,
                        principalTable: "Pacjenci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UdostepnieniaZadan_Zadania_ZadanieId",
                        column: x => x.ZadanieId,
                        principalTable: "Zadania",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpcjeOdpowiedzi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrescOpcji = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KrokId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpcjeOdpowiedzi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpcjeOdpowiedzi_KrokiZadania_KrokId",
                        column: x => x.KrokId,
                        principalTable: "KrokiZadania",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PodejsciaDoZadania",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataRozpoczecia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UdostepnienieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodejsciaDoZadania", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PodejsciaDoZadania_UdostepnieniaZadan_UdostepnienieId",
                        column: x => x.UdostepnienieId,
                        principalTable: "UdostepnieniaZadan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OdpowiedziPacjentow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PodejscieId = table.Column<int>(type: "int", nullable: false),
                    KrokId = table.Column<int>(type: "int", nullable: false),
                    WybranaOpcjaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdpowiedziPacjentow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OdpowiedziPacjentow_KrokiZadania_KrokId",
                        column: x => x.KrokId,
                        principalTable: "KrokiZadania",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OdpowiedziPacjentow_OpcjeOdpowiedzi_WybranaOpcjaId",
                        column: x => x.WybranaOpcjaId,
                        principalTable: "OpcjeOdpowiedzi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OdpowiedziPacjentow_PodejsciaDoZadania_PodejscieId",
                        column: x => x.PodejscieId,
                        principalTable: "PodejsciaDoZadania",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administratorzy_IdentityUserId",
                table: "Administratorzy",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GrupyWsparcia_TerapeutaId",
                table: "GrupyWsparcia",
                column: "TerapeutaId");

            migrationBuilder.CreateIndex(
                name: "IX_KrokiZadania_ZadanieId",
                table: "KrokiZadania",
                column: "ZadanieId");

            migrationBuilder.CreateIndex(
                name: "IX_NotatkiZWizyt_WizytaId",
                table: "NotatkiZWizyt",
                column: "WizytaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OdpowiedziPacjentow_KrokId",
                table: "OdpowiedziPacjentow",
                column: "KrokId");

            migrationBuilder.CreateIndex(
                name: "IX_OdpowiedziPacjentow_PodejscieId",
                table: "OdpowiedziPacjentow",
                column: "PodejscieId");

            migrationBuilder.CreateIndex(
                name: "IX_OdpowiedziPacjentow_WybranaOpcjaId",
                table: "OdpowiedziPacjentow",
                column: "WybranaOpcjaId");

            migrationBuilder.CreateIndex(
                name: "IX_OpcjeOdpowiedzi_KrokId",
                table: "OpcjeOdpowiedzi",
                column: "KrokId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacjenci_IdentityUserId",
                table: "Pacjenci",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PacjenciGrupy_GrupaId",
                table: "PacjenciGrupy",
                column: "GrupaId");

            migrationBuilder.CreateIndex(
                name: "IX_PodejsciaDoZadania_UdostepnienieId",
                table: "PodejsciaDoZadania",
                column: "UdostepnienieId");

            migrationBuilder.CreateIndex(
                name: "IX_PrzypisaniaUzaleznien_TypUzaleznieniaId",
                table: "PrzypisaniaUzaleznien",
                column: "TypUzaleznieniaId");

            migrationBuilder.CreateIndex(
                name: "IX_Terapeuci_IdentityUserId",
                table: "Terapeuci",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UdostepnieniaZadan_PacjentId",
                table: "UdostepnieniaZadan",
                column: "PacjentId");

            migrationBuilder.CreateIndex(
                name: "IX_UdostepnieniaZadan_ZadanieId",
                table: "UdostepnieniaZadan",
                column: "ZadanieId");

            migrationBuilder.CreateIndex(
                name: "IX_Wiadomosci_NadawcaId",
                table: "Wiadomosci",
                column: "NadawcaId");

            migrationBuilder.CreateIndex(
                name: "IX_WiadomosciOdbiorcy_OdbiorcaId",
                table: "WiadomosciOdbiorcy",
                column: "OdbiorcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Wizyty_PacjentId",
                table: "Wizyty",
                column: "PacjentId");

            migrationBuilder.CreateIndex(
                name: "IX_Wizyty_StatusId",
                table: "Wizyty",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Wizyty_TerapeutaId",
                table: "Wizyty",
                column: "TerapeutaId");

            migrationBuilder.CreateIndex(
                name: "IX_Zadania_TerapeutaId",
                table: "Zadania",
                column: "TerapeutaId");

            migrationBuilder.CreateIndex(
                name: "IX_Zalaczniki_TypDanychId",
                table: "Zalaczniki",
                column: "TypDanychId");

            migrationBuilder.CreateIndex(
                name: "IX_Zalaczniki_WiadomoscId",
                table: "Zalaczniki",
                column: "WiadomoscId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administratorzy");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "NotatkiZWizyt");

            migrationBuilder.DropTable(
                name: "OdpowiedziPacjentow");

            migrationBuilder.DropTable(
                name: "PacjenciGrupy");

            migrationBuilder.DropTable(
                name: "PrzypisaniaUzaleznien");

            migrationBuilder.DropTable(
                name: "WiadomosciOdbiorcy");

            migrationBuilder.DropTable(
                name: "Zalaczniki");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Wizyty");

            migrationBuilder.DropTable(
                name: "OpcjeOdpowiedzi");

            migrationBuilder.DropTable(
                name: "PodejsciaDoZadania");

            migrationBuilder.DropTable(
                name: "GrupyWsparcia");

            migrationBuilder.DropTable(
                name: "TypyUzaleznien");

            migrationBuilder.DropTable(
                name: "TypyDanych");

            migrationBuilder.DropTable(
                name: "Wiadomosci");

            migrationBuilder.DropTable(
                name: "StatusyWizyt");

            migrationBuilder.DropTable(
                name: "KrokiZadania");

            migrationBuilder.DropTable(
                name: "UdostepnieniaZadan");

            migrationBuilder.DropTable(
                name: "Pacjenci");

            migrationBuilder.DropTable(
                name: "Zadania");

            migrationBuilder.DropTable(
                name: "Terapeuci");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
