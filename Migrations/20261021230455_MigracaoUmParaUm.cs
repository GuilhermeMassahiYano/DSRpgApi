using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoUmParaUm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Derrotas",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Disputas",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vitorias",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonagemId",
                table: "TB_ARMAS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 1,
                column: "PersonagemId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 2,
                column: "PersonagemId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 3,
                column: "PersonagemId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 4,
                column: "PersonagemId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 5,
                column: "PersonagemId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 6,
                column: "PersonagemId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 7,
                column: "PersonagemId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 151, 170, 34, 173, 176, 70, 245, 66, 88, 190, 180, 106, 127, 137, 47, 124, 125, 165, 73, 118, 175, 45, 119, 7, 62, 157, 134, 127, 142, 108, 45, 230, 199, 43, 165, 131, 28, 94, 124, 23, 151, 3, 68, 54, 87, 116, 57, 227, 30, 155, 97, 135, 138, 43, 123, 110, 122, 132, 1, 26, 245, 222, 241, 33 }, new byte[] { 218, 75, 203, 16, 2, 94, 201, 99, 74, 199, 235, 77, 134, 103, 44, 166, 198, 228, 43, 45, 32, 105, 148, 71, 244, 204, 20, 198, 27, 32, 246, 243, 1, 158, 233, 149, 43, 20, 8, 30, 158, 148, 112, 48, 91, 243, 234, 235, 187, 36, 26, 126, 204, 230, 211, 21, 7, 162, 104, 87, 125, 253, 1, 149, 118, 69, 254, 152, 110, 193, 62, 212, 48, 59, 137, 76, 250, 13, 248, 200, 10, 68, 45, 204, 0, 200, 108, 60, 93, 16, 200, 48, 172, 248, 210, 126, 236, 3, 120, 74, 218, 113, 128, 104, 49, 104, 209, 240, 153, 136, 102, 181, 7, 9, 177, 165, 58, 38, 72, 66, 67, 142, 233, 141, 253, 202, 159, 128 } });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                principalTable: "TB_PERSONAGENS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.DropIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.DropColumn(
                name: "Derrotas",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "Disputas",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "Vitorias",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 93, 248, 68, 245, 116, 162, 90, 0, 137, 152, 10, 226, 102, 237, 241, 229, 201, 229, 75, 164, 86, 223, 134, 191, 147, 195, 22, 21, 75, 167, 241, 250, 134, 7, 183, 45, 48, 98, 235, 34, 83, 194, 85, 44, 12, 65, 6, 48, 82, 135, 18, 73, 98, 179, 151, 118, 180, 55, 165, 225, 77, 7, 7, 165 }, new byte[] { 7, 180, 89, 64, 218, 0, 227, 78, 203, 13, 254, 141, 129, 54, 85, 130, 11, 111, 231, 77, 112, 228, 238, 232, 17, 233, 198, 168, 133, 11, 252, 83, 81, 108, 85, 165, 204, 20, 58, 191, 219, 56, 91, 153, 246, 118, 139, 12, 115, 56, 187, 76, 143, 252, 25, 110, 149, 49, 123, 252, 44, 69, 136, 170, 68, 10, 245, 44, 140, 217, 59, 12, 210, 131, 192, 45, 202, 95, 20, 163, 30, 28, 77, 187, 152, 207, 104, 32, 33, 127, 98, 249, 209, 85, 92, 152, 2, 75, 7, 209, 128, 4, 73, 102, 145, 16, 5, 182, 142, 175, 161, 17, 84, 17, 226, 77, 64, 221, 127, 12, 50, 233, 209, 100, 138, 190, 56, 151 } });
        }
    }
}
