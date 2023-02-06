using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspnetserver.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LastPostId",
                table: "Categories",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "LastPostId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "LastPostId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "LastPostId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "LastPostId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_LastPostId",
                table: "Categories",
                column: "LastPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Posts_LastPostId",
                table: "Categories",
                column: "LastPostId",
                principalTable: "Posts",
                principalColumn: "PostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Posts_LastPostId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_LastPostId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "LastPostId",
                table: "Categories");
        }
    }
}
