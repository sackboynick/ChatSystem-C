using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class MessagePropertiesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ForwardedMessageId",
                table: "Messages",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PinnedMessage",
                table: "Messages",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RepliedMessageId",
                table: "Messages",
                type: "INTEGER",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForwardedMessageId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "PinnedMessage",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "RepliedMessageId",
                table: "Messages");
        }
    }
}
