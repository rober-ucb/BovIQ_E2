using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BovIQ.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DropHerdFromHerdTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cow_Herd_HerdId",
                table: "Cow");

            migrationBuilder.DropForeignKey(
                name: "FK_Herd_AspNetUsers_ApplicationUserId",
                table: "Herd");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Herd",
                table: "Herd");

            migrationBuilder.RenameTable(
                name: "Herd",
                newName: "Herds");

            migrationBuilder.RenameIndex(
                name: "IX_Herd_ApplicationUserId",
                table: "Herds",
                newName: "IX_Herds_ApplicationUserId");

            migrationBuilder.AlterColumn<int>(
                name: "HerdId",
                table: "Cow",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Herds",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Herds",
                table: "Herds",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cow_Herds_HerdId",
                table: "Cow",
                column: "HerdId",
                principalTable: "Herds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Herds_AspNetUsers_ApplicationUserId",
                table: "Herds",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cow_Herds_HerdId",
                table: "Cow");

            migrationBuilder.DropForeignKey(
                name: "FK_Herds_AspNetUsers_ApplicationUserId",
                table: "Herds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Herds",
                table: "Herds");

            migrationBuilder.RenameTable(
                name: "Herds",
                newName: "Herd");

            migrationBuilder.RenameIndex(
                name: "IX_Herds_ApplicationUserId",
                table: "Herd",
                newName: "IX_Herd_ApplicationUserId");

            migrationBuilder.AlterColumn<int>(
                name: "HerdId",
                table: "Cow",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Herd",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Herd",
                table: "Herd",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cow_Herd_HerdId",
                table: "Cow",
                column: "HerdId",
                principalTable: "Herd",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Herd_AspNetUsers_ApplicationUserId",
                table: "Herd",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
