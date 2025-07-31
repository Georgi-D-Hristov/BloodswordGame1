using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodswordGame.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddToParagraphNumberandDescriptiontoChoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Choices_Paragraphs_ToParagraphId",
                table: "Choices");

            migrationBuilder.DropIndex(
                name: "IX_Choices_ToParagraphId",
                table: "Choices");

            migrationBuilder.RenameColumn(
                name: "ToParagraphId",
                table: "Choices",
                newName: "ToParagraphNumber");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Choices",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Choices");

            migrationBuilder.RenameColumn(
                name: "ToParagraphNumber",
                table: "Choices",
                newName: "ToParagraphId");

            migrationBuilder.CreateIndex(
                name: "IX_Choices_ToParagraphId",
                table: "Choices",
                column: "ToParagraphId");

            migrationBuilder.AddForeignKey(
                name: "FK_Choices_Paragraphs_ToParagraphId",
                table: "Choices",
                column: "ToParagraphId",
                principalTable: "Paragraphs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
