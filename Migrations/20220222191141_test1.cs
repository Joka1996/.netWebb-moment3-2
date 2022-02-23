using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace moment3_2.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cd_User_UserId",
                table: "Cd");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Cd",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Cd_User_UserId",
                table: "Cd",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cd_User_UserId",
                table: "Cd");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Cd",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cd_User_UserId",
                table: "Cd",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
