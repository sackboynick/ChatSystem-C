using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class UpdateToFriendshipEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Friendships");

            migrationBuilder.AddColumn<int>(
                name: "FriendUserId",
                table: "Friendships",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FriendUserId",
                table: "Friendships");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Friendships",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
