using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friendship_Users_UserId",
                table: "Friendship");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_GroupChats_GroupChatId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_PrivateChats_PrivateChatId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Participant_GroupChats_GroupChatId",
                table: "Participant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participant",
                table: "Participant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Friendship",
                table: "Friendship");

            migrationBuilder.RenameTable(
                name: "Participant",
                newName: "Participants");

            migrationBuilder.RenameTable(
                name: "Message",
                newName: "Messages");

            migrationBuilder.RenameTable(
                name: "Friendship",
                newName: "Friendships");

            migrationBuilder.RenameIndex(
                name: "IX_Participant_GroupChatId",
                table: "Participants",
                newName: "IX_Participants_GroupChatId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_PrivateChatId",
                table: "Messages",
                newName: "IX_Messages_PrivateChatId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_GroupChatId",
                table: "Messages",
                newName: "IX_Messages_GroupChatId");

            migrationBuilder.RenameIndex(
                name: "IX_Friendship_UserId",
                table: "Friendships",
                newName: "IX_Friendships_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participants",
                table: "Participants",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friendships",
                table: "Friendships",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Friendships_Users_UserId",
                table: "Friendships",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_GroupChats_GroupChatId",
                table: "Participants",
                column: "GroupChatId",
                principalTable: "GroupChats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friendships_Users_UserId",
                table: "Friendships");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_GroupChats_GroupChatId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_PrivateChats_PrivateChatId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Participants_GroupChats_GroupChatId",
                table: "Participants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participants",
                table: "Participants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Friendships",
                table: "Friendships");

            migrationBuilder.RenameTable(
                name: "Participants",
                newName: "Participant");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "Message");

            migrationBuilder.RenameTable(
                name: "Friendships",
                newName: "Friendship");

            migrationBuilder.RenameIndex(
                name: "IX_Participants_GroupChatId",
                table: "Participant",
                newName: "IX_Participant_GroupChatId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_PrivateChatId",
                table: "Message",
                newName: "IX_Message_PrivateChatId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_GroupChatId",
                table: "Message",
                newName: "IX_Message_GroupChatId");

            migrationBuilder.RenameIndex(
                name: "IX_Friendships_UserId",
                table: "Friendship",
                newName: "IX_Friendship_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participant",
                table: "Participant",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friendship",
                table: "Friendship",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Friendship_Users_UserId",
                table: "Friendship",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Participant_GroupChats_GroupChatId",
                table: "Participant",
                column: "GroupChatId",
                principalTable: "GroupChats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
