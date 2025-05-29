using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto.Migrations
{
    /// <inheritdoc />
    public partial class Uno_muchos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClaseId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Clases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clases", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ClaseId",
                table: "Usuarios",
                column: "ClaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Clases_ClaseId",
                table: "Usuarios",
                column: "ClaseId",
                principalTable: "Clases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Clases_ClaseId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Clases");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_ClaseId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ClaseId",
                table: "Usuarios");
        }
    }
}
