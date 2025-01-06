using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fournisseur",
                columns: table => new
                {
                    FournisseurId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fournisseur", x => x.FournisseurId);
                });

            migrationBuilder.CreateTable(
                name: "Marque",
                columns: table => new
                {
                    Nom = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Reputation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marque", x => x.Nom);
                });

            migrationBuilder.CreateTable(
                name: "Ouvrier",
                columns: table => new
                {
                    OuvrierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false),
                    Qualifie = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ouvrier", x => x.OuvrierId);
                });

            migrationBuilder.CreateTable(
                name: "Pneu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diametre = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fabrication = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pneu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarqueFournTable",
                columns: table => new
                {
                    FournisseursFournisseurId = table.Column<int>(type: "int", nullable: false),
                    MarquesNom = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarqueFournTable", x => new { x.FournisseursFournisseurId, x.MarquesNom });
                    table.ForeignKey(
                        name: "FK_MarqueFournTable_Fournisseur_FournisseursFournisseurId",
                        column: x => x.FournisseursFournisseurId,
                        principalTable: "Fournisseur",
                        principalColumn: "FournisseurId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarqueFournTable_Marque_MarquesNom",
                        column: x => x.MarquesNom,
                        principalTable: "Marque",
                        principalColumn: "Nom",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Intervention",
                columns: table => new
                {
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OuvrierKey = table.Column<int>(type: "int", nullable: false),
                    PneuKey = table.Column<int>(type: "int", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cout = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intervention", x => new { x.PneuKey, x.OuvrierKey, x.DateDebut });
                    table.ForeignKey(
                        name: "FK_Intervention_Ouvrier_OuvrierKey",
                        column: x => x.OuvrierKey,
                        principalTable: "Ouvrier",
                        principalColumn: "OuvrierId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Intervention_Pneu_PneuKey",
                        column: x => x.PneuKey,
                        principalTable: "Pneu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarquePneu",
                columns: table => new
                {
                    PneusId = table.Column<int>(type: "int", nullable: false),
                    marquesNom = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarquePneu", x => new { x.PneusId, x.marquesNom });
                    table.ForeignKey(
                        name: "FK_MarquePneu_Marque_marquesNom",
                        column: x => x.marquesNom,
                        principalTable: "Marque",
                        principalColumn: "Nom",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarquePneu_Pneu_PneusId",
                        column: x => x.PneusId,
                        principalTable: "Pneu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Intervention_OuvrierKey",
                table: "Intervention",
                column: "OuvrierKey");

            migrationBuilder.CreateIndex(
                name: "IX_MarqueFournTable_MarquesNom",
                table: "MarqueFournTable",
                column: "MarquesNom");

            migrationBuilder.CreateIndex(
                name: "IX_MarquePneu_marquesNom",
                table: "MarquePneu",
                column: "marquesNom");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Intervention");

            migrationBuilder.DropTable(
                name: "MarqueFournTable");

            migrationBuilder.DropTable(
                name: "MarquePneu");

            migrationBuilder.DropTable(
                name: "Ouvrier");

            migrationBuilder.DropTable(
                name: "Fournisseur");

            migrationBuilder.DropTable(
                name: "Marque");

            migrationBuilder.DropTable(
                name: "Pneu");
        }
    }
}
