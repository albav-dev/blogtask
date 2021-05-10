using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Migrations
{
    public partial class Category5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Books",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Nature",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "Programming",
                table: "Category",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Category",
                newName: "Programming");

            migrationBuilder.AddColumn<string>(
                name: "Books",
                table: "Category",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nature",
                table: "Category",
                nullable: true);
        }
    }
}
