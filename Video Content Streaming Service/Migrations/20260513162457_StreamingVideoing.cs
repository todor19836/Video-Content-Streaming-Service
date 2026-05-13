using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Video_Content_Streaming_Service.Migrations
{
    /// <inheritdoc />
    public partial class StreamingVideoing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "Videos");

            migrationBuilder.RenameColumn(
                name: "VideoId",
                table: "Videos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CommentDate",
                table: "Comments",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "Comments",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Videos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Videos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Videos");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Videos",
                newName: "VideoId");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Comments",
                newName: "CommentDate");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comments",
                newName: "CommentId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Videos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "Videos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
