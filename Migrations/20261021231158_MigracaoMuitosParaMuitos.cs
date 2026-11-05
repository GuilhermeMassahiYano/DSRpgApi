using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoMuitosParaMuitos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_HABILIDADES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Dano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_HABILIDADES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PERSONAGENS_HABILIDADES",
                columns: table => new
                {
                    PersonagemId = table.Column<int>(type: "int", nullable: false),
                    HabilidadeId = table.Column<int>(type: "int", nullable: false),
                    PersonagemHabilidadeHabilidadeId = table.Column<int>(type: "int", nullable: true),
                    PersonagemHabilidadePersonagemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PERSONAGENS_HABILIDADES", x => new { x.PersonagemId, x.HabilidadeId });
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_HABILIDADES_TB_HABILIDADES_HabilidadeId",
                        column: x => x.HabilidadeId,
                        principalTable: "TB_HABILIDADES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_HABILIDADES_TB_PERSONAGENS_HABILIDADES_PersonagemHabilidadePersonagemId_PersonagemHabilidadeHabilidadeId",
                        columns: x => new { x.PersonagemHabilidadePersonagemId, x.PersonagemHabilidadeHabilidadeId },
                        principalTable: "TB_PERSONAGENS_HABILIDADES",
                        principalColumns: new[] { "PersonagemId", "HabilidadeId" });
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_HABILIDADES_TB_PERSONAGENS_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "TB_PERSONAGENS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TB_HABILIDADES",
                columns: new[] { "Id", "Dano", "Nome" },
                values: new object[,]
                {
                    { 1, 39, "Adormecer" },
                    { 2, 41, "Congelar" },
                    { 3, 37, "Hipnotizar" }
                });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 39, 96, 75, 37, 191, 131, 180, 133, 38, 20, 137, 103, 250, 51, 218, 94, 32, 146, 123, 151, 105, 137, 154, 93, 119, 52, 12, 252, 100, 2, 64, 11, 206, 52, 104, 180, 127, 43, 87, 60, 233, 241, 224, 95, 193, 60, 208, 93, 9, 22, 29, 192, 40, 110, 9, 14, 89, 97, 85, 219, 133, 129, 252, 198 }, new byte[] { 129, 215, 199, 157, 227, 30, 61, 117, 207, 233, 180, 110, 156, 166, 10, 130, 201, 64, 45, 191, 82, 194, 248, 147, 154, 211, 152, 79, 251, 179, 248, 99, 228, 232, 126, 222, 227, 196, 229, 47, 123, 236, 78, 150, 166, 248, 100, 143, 254, 120, 181, 104, 181, 57, 209, 219, 254, 199, 192, 152, 65, 66, 134, 53, 86, 72, 127, 181, 22, 147, 225, 23, 22, 34, 252, 58, 186, 177, 184, 140, 103, 166, 102, 231, 15, 22, 254, 209, 39, 236, 74, 16, 25, 85, 30, 42, 162, 46, 99, 240, 178, 93, 161, 93, 176, 249, 217, 71, 87, 26, 185, 186, 55, 15, 23, 239, 76, 5, 105, 65, 221, 66, 109, 142, 85, 213, 28, 1 } });

            migrationBuilder.InsertData(
                table: "TB_PERSONAGENS_HABILIDADES",
                columns: new[] { "HabilidadeId", "PersonagemId", "PersonagemHabilidadeHabilidadeId", "PersonagemHabilidadePersonagemId" },
                values: new object[,]
                {
                    { 1, 1, null, null },
                    { 2, 1, null, null },
                    { 2, 2, null, null },
                    { 2, 3, null, null },
                    { 3, 3, null, null },
                    { 3, 4, null, null },
                    { 1, 5, null, null },
                    { 2, 6, null, null },
                    { 3, 7, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERSONAGENS_HABILIDADES_HabilidadeId",
                table: "TB_PERSONAGENS_HABILIDADES",
                column: "HabilidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERSONAGENS_HABILIDADES_PersonagemHabilidadePersonagemId_PersonagemHabilidadeHabilidadeId",
                table: "TB_PERSONAGENS_HABILIDADES",
                columns: new[] { "PersonagemHabilidadePersonagemId", "PersonagemHabilidadeHabilidadeId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PERSONAGENS_HABILIDADES");

            migrationBuilder.DropTable(
                name: "TB_HABILIDADES");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 151, 170, 34, 173, 176, 70, 245, 66, 88, 190, 180, 106, 127, 137, 47, 124, 125, 165, 73, 118, 175, 45, 119, 7, 62, 157, 134, 127, 142, 108, 45, 230, 199, 43, 165, 131, 28, 94, 124, 23, 151, 3, 68, 54, 87, 116, 57, 227, 30, 155, 97, 135, 138, 43, 123, 110, 122, 132, 1, 26, 245, 222, 241, 33 }, new byte[] { 218, 75, 203, 16, 2, 94, 201, 99, 74, 199, 235, 77, 134, 103, 44, 166, 198, 228, 43, 45, 32, 105, 148, 71, 244, 204, 20, 198, 27, 32, 246, 243, 1, 158, 233, 149, 43, 20, 8, 30, 158, 148, 112, 48, 91, 243, 234, 235, 187, 36, 26, 126, 204, 230, 211, 21, 7, 162, 104, 87, 125, 253, 1, 149, 118, 69, 254, 152, 110, 193, 62, 212, 48, 59, 137, 76, 250, 13, 248, 200, 10, 68, 45, 204, 0, 200, 108, 60, 93, 16, 200, 48, 172, 248, 210, 126, 236, 3, 120, 74, 218, 113, 128, 104, 49, 104, 209, 240, 153, 136, 102, 181, 7, 9, 177, 165, 58, 38, 72, 66, 67, 142, 233, 141, 253, 202, 159, 128 } });
        }
    }
}
