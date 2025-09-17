using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TpQuestionnaireManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questionnaires",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionnaires", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intitule = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ReponseCorrecteId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reponse",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    QuestionId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reponse_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ReponseCorrecteId",
                table: "Questions",
                column: "ReponseCorrecteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reponse_QuestionId",
                table: "Reponse",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Reponse_ReponseCorrecteId",
                table: "Questions",
                column: "ReponseCorrecteId",
                principalTable: "Reponse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Reponse_ReponseCorrecteId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "Questionnaires");

            migrationBuilder.DropTable(
                name: "Reponse");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
