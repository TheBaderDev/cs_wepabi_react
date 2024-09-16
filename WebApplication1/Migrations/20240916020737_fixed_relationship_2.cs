using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class fixed_relationship_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_B_A_ObjectAId",
                table: "B");

            migrationBuilder.AlterColumn<int>(
                name: "ObjectAId",
                table: "B",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_B_A_ObjectAId",
                table: "B",
                column: "ObjectAId",
                principalTable: "A",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_B_A_ObjectAId",
                table: "B");

            migrationBuilder.AlterColumn<int>(
                name: "ObjectAId",
                table: "B",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_B_A_ObjectAId",
                table: "B",
                column: "ObjectAId",
                principalTable: "A",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
