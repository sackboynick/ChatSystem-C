using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddParticipantsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participant_GroupChats_GroupChatId",
                table: "Participant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participant",
                table: "Participant");

            migrationBuilder.RenameTable(
                name: "Participant",
                newName: "Participants");

            migrationBuilder.RenameIndex(
                name: "IX_Participant_GroupChatId",
                table: "Participants",
                newName: "IX_Participants_GroupChatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participants",
                table: "Participants",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_GroupChats_GroupChatId",
                table: "Participants",
                column: "GroupChatId",
                principalTable: "GroupChats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_GroupChats_GroupChatId",
                table: "Participants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participants",
                table: "Participants");

            migrationBuilder.RenameTable(
                name: "Participants",
                newName: "Participant");

            migrationBuilder.RenameIndex(
                name: "IX_Participants_GroupChatId",
                table: "Participant",
                newName: "IX_Participant_GroupChatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participant",
                table: "Participant",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Participant_GroupChats_GroupChatId",
                table: "Participant",
                column: "GroupChatId",
                principalTable: "GroupChats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
