using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroEstudantesIEL.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarIndexUnicoCPF : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Estudantes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Estudantes_CPF",
                table: "Estudantes",
                column: "CPF",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Estudantes_CPF",
                table: "Estudantes");

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Estudantes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
