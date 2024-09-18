using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class fixing_relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_B_A_ObjectAId",
                table: "B");

            migrationBuilder.AddForeignKey(
                name: "FK_B_A_ObjectAId",
                table: "B",
                column: "ObjectAId",
                principalTable: "A",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_B_A_ObjectAId",
                table: "B");

            migrationBuilder.AddForeignKey(
                name: "FK_B_A_ObjectAId",
                table: "B",
                column: "ObjectAId",
                principalTable: "A",
                principalColumn: "id");
        }
    }
}
