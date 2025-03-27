using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BovIQ.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DropOwnerIdFromHerdTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Herd_AspNetUsers_OwnerId",
                table: "Herd");

            migrationBuilder.DropIndex(
                name: "IX_Herd_OwnerId",
                table: "Herd");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Herd");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Herd",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Herd_ApplicationUserId",
                table: "Herd",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Herd_AspNetUsers_ApplicationUserId",
                table: "Herd",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Herd_AspNetUsers_ApplicationUserId",
                table: "Herd");

            migrationBuilder.DropIndex(
                name: "IX_Herd_ApplicationUserId",
                table: "Herd");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Herd");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Herd",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Herd_OwnerId",
                table: "Herd",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Herd_AspNetUsers_OwnerId",
                table: "Herd",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
