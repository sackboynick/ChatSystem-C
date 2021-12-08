using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class CreateAdditionalTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_GroupChats_GroupChatId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_PrivateChats_PrivateChatId",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                table: "Message");

            migrationBuilder.RenameTable(
                name: "Message",
                newName: "Messages");

            migrationBuilder.RenameIndex(
                name: "IX_Message_PrivateChatId",
                table: "Messages",
                newName: "IX_Messages_PrivateChatId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_GroupChatId",
                table: "Messages",
                newName: "IX_Messages_GroupChatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_GroupChats_GroupChatId",
                table: "Messages",
                column: "GroupChatId",
                principalTable: "GroupChats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_PrivateChats_PrivateChatId",
                table: "Messages",
                column: "PrivateChatId",
                principalTable: "PrivateChats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_GroupChats_GroupChatId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_PrivateChats_PrivateChatId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "Message");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_PrivateChatId",
                table: "Message",
                newName: "IX_Message_PrivateChatId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_GroupChatId",
                table: "Message",
                newName: "IX_Message_GroupChatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_GroupChats_GroupChatId",
                table: "Message",
                column: "GroupChatId",
                principalTable: "GroupChats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_PrivateChats_PrivateChatId",
                table: "Message",
                column: "PrivateChatId",
                principalTable: "PrivateChats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
