using Microsoft.EntityFrameworkCore.Migrations;

namespace UserService.Migrations
{
    public partial class UserUpdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Privacy",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "UserFollows",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userWhichId = table.Column<long>(type: "bigint", nullable: true),
                    userWhomId = table.Column<long>(type: "bigint", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFollows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFollows_Users_userWhichId",
                        column: x => x.userWhichId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserFollows_Users_userWhomId",
                        column: x => x.userWhomId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFollows_userWhichId",
                table: "UserFollows",
                column: "userWhichId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFollows_userWhomId",
                table: "UserFollows",
                column: "userWhomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFollows");

            migrationBuilder.DropColumn(
                name: "Privacy",
                table: "Users");
        }
    }
}
