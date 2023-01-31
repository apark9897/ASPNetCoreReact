using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspnetserver.Migrations
{
    /// <inheritdoc />
    public partial class AddNullableFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Comments_LastCommentId",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "LastCommentId",
                table: "Posts",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Comments_LastCommentId",
                table: "Posts",
                column: "LastCommentId",
                principalTable: "Comments",
                principalColumn: "CommentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Comments_LastCommentId",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "LastCommentId",
                table: "Posts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Comments_LastCommentId",
                table: "Posts",
                column: "LastCommentId",
                principalTable: "Comments",
                principalColumn: "CommentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
