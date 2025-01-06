using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class bb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarquePneu");

            migrationBuilder.AddColumn<string>(
                name: "marqueNom",
                table: "Pneu",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Pneu_marqueNom",
                table: "Pneu",
                column: "marqueNom");

            migrationBuilder.AddForeignKey(
                name: "FK_Pneu_Marque_marqueNom",
                table: "Pneu",
                column: "marqueNom",
                principalTable: "Marque",
                principalColumn: "Nom",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pneu_Marque_marqueNom",
                table: "Pneu");

            migrationBuilder.DropIndex(
                name: "IX_Pneu_marqueNom",
                table: "Pneu");

            migrationBuilder.DropColumn(
                name: "marqueNom",
                table: "Pneu");

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
                name: "IX_MarquePneu_marquesNom",
                table: "MarquePneu",
                column: "marquesNom");
        }
    }
}
