using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace basic.Migrations
{
    /// <inheritdoc />
    public partial class RemoveNavigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Groups_groupId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_groupId",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_groupId",
                table: "Users",
                column: "groupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Groups_groupId",
                table: "Users",
                column: "groupId",
                principalTable: "Groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
