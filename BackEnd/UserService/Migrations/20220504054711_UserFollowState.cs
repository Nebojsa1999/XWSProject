using Microsoft.EntityFrameworkCore.Migrations;

namespace UserService.Migrations
{
    public partial class UserFollowState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFollows_Users_userWhichId",
                table: "UserFollows");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFollows_Users_userWhomId",
                table: "UserFollows");

            migrationBuilder.RenameColumn(
                name: "userWhomId",
                table: "UserFollows",
                newName: "UserWhomId");

            migrationBuilder.RenameColumn(
                name: "userWhichId",
                table: "UserFollows",
                newName: "UserWhichId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFollows_userWhomId",
                table: "UserFollows",
                newName: "IX_UserFollows_UserWhomId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFollows_userWhichId",
                table: "UserFollows",
                newName: "IX_UserFollows_UserWhichId");

            migrationBuilder.AddColumn<int>(
                name: "StateOfFollow",
                table: "UserFollows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollows_Users_UserWhichId",
                table: "UserFollows",
                column: "UserWhichId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollows_Users_UserWhomId",
                table: "UserFollows",
                column: "UserWhomId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFollows_Users_UserWhichId",
                table: "UserFollows");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFollows_Users_UserWhomId",
                table: "UserFollows");

            migrationBuilder.DropColumn(
                name: "StateOfFollow",
                table: "UserFollows");

            migrationBuilder.RenameColumn(
                name: "UserWhomId",
                table: "UserFollows",
                newName: "userWhomId");

            migrationBuilder.RenameColumn(
                name: "UserWhichId",
                table: "UserFollows",
                newName: "userWhichId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFollows_UserWhomId",
                table: "UserFollows",
                newName: "IX_UserFollows_userWhomId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFollows_UserWhichId",
                table: "UserFollows",
                newName: "IX_UserFollows_userWhichId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollows_Users_userWhichId",
                table: "UserFollows",
                column: "userWhichId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollows_Users_userWhomId",
                table: "UserFollows",
                column: "userWhomId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
