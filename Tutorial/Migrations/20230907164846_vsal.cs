using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tutorial.Migrations
{
    /// <inheritdoc />
    public partial class vsal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "Builds",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Builds_CharacterId",
                table: "Builds",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Builds_Characters_CharacterId",
                table: "Builds",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "CharacterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Builds_Characters_CharacterId",
                table: "Builds");

            migrationBuilder.DropIndex(
                name: "IX_Builds_CharacterId",
                table: "Builds");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Builds");
        }
    }
}
