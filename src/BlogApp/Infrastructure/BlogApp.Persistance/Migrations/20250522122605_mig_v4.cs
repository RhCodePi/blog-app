using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApp.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Articles",
                type: "jsonb USING \"Content\"::jsonb",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Articles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserID",
                table: "Articles",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AspNetUsers_UserID",
                table: "Articles",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AspNetUsers_UserID",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_UserID",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Articles");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Articles",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "jsonb");
        }
    }
}
