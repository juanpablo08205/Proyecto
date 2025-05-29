using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto.Migrations
{
    /// <inheritdoc />
    public partial class Muchos_Muchos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Clases_ClaseId",
                table: "Usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "ClaseId",
                table: "Usuarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Clases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "EstilosVida",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstilosVida", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstiloVidaUsuario",
                columns: table => new
                {
                    EstilosVidaId = table.Column<int>(type: "int", nullable: false),
                    UsuariosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstiloVidaUsuario", x => new { x.EstilosVidaId, x.UsuariosId });
                    table.ForeignKey(
                        name: "FK_EstiloVidaUsuario_EstilosVida_EstilosVidaId",
                        column: x => x.EstilosVidaId,
                        principalTable: "EstilosVida",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstiloVidaUsuario_Usuarios_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstiloVidaUsuario_UsuariosId",
                table: "EstiloVidaUsuario",
                column: "UsuariosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Clases_ClaseId",
                table: "Usuarios",
                column: "ClaseId",
                principalTable: "Clases",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Clases_ClaseId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "EstiloVidaUsuario");

            migrationBuilder.DropTable(
                name: "EstilosVida");

            migrationBuilder.AlterColumn<int>(
                name: "ClaseId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Clases",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Clases_ClaseId",
                table: "Usuarios",
                column: "ClaseId",
                principalTable: "Clases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
