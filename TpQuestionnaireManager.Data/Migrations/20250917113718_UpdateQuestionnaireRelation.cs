using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TpQuestionnaireManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateQuestionnaireRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "QuestionnaireId",
                table: "Questions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuestionnaireId",
                table: "Questions",
                column: "QuestionnaireId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Questionnaires_QuestionnaireId",
                table: "Questions",
                column: "QuestionnaireId",
                principalTable: "Questionnaires",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Questionnaires_QuestionnaireId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_QuestionnaireId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionnaireId",
                table: "Questions");
        }
    }
}
