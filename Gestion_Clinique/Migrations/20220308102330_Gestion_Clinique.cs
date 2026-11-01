using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestion_Clinique.Migrations
{
    public partial class Gestion_Clinique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DateDeTravail",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeurFin = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateDeTravail", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Specialite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialite", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotDePasse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialiteId = table.Column<int>(type: "int", nullable: true),
                    DateDeTravailId = table.Column<int>(type: "int", nullable: true),
                    RendezVousId = table.Column<int>(type: "int", nullable: true),
                    Prix_visite = table.Column<int>(type: "int", nullable: true),
                    Activate = table.Column<bool>(type: "bit", nullable: true),
                    CIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CNSS = table.Column<int>(type: "int", nullable: true),
                    Date_Naissance = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateur", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Utilisateur_DateDeTravail_DateDeTravailId",
                        column: x => x.DateDeTravailId,
                        principalTable: "DateDeTravail",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Utilisateur_Specialite_SpecialiteId",
                        column: x => x.SpecialiteId,
                        principalTable: "Specialite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RendezVous",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedecinId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Heure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valider = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RendezVous", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RendezVous_Utilisateur_MedecinId",
                        column: x => x.MedecinId,
                        principalTable: "Utilisateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RendezVous_Utilisateur_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Utilisateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RendezVous_MedecinId",
                table: "RendezVous",
                column: "MedecinId");

            migrationBuilder.CreateIndex(
                name: "IX_RendezVous_PatientId",
                table: "RendezVous",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateur_DateDeTravailId",
                table: "Utilisateur",
                column: "DateDeTravailId");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateur_SpecialiteId",
                table: "Utilisateur",
                column: "SpecialiteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RendezVous");

            migrationBuilder.DropTable(
                name: "Utilisateur");

            migrationBuilder.DropTable(
                name: "DateDeTravail");

            migrationBuilder.DropTable(
                name: "Specialite");
        }
    }
}
