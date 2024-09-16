using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class fixed_relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_B_A_parentid",
                table: "B");

            migrationBuilder.RenameColumn(
                name: "parentid",
                table: "B",
                newName: "ObjectAId");

            migrationBuilder.RenameIndex(
                name: "IX_B_parentid",
                table: "B",
                newName: "IX_B_ObjectAId");

            migrationBuilder.AddForeignKey(
                name: "FK_B_A_ObjectAId",
                table: "B",
                column: "ObjectAId",
                principalTable: "A",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_B_A_ObjectAId",
                table: "B");

            migrationBuilder.RenameColumn(
                name: "ObjectAId",
                table: "B",
                newName: "parentid");

            migrationBuilder.RenameIndex(
                name: "IX_B_ObjectAId",
                table: "B",
                newName: "IX_B_parentid");

            migrationBuilder.AddForeignKey(
                name: "FK_B_A_parentid",
                table: "B",
                column: "parentid",
                principalTable: "A",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
