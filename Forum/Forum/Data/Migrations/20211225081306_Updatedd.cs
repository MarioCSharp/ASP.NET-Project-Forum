namespace Forum.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;
    public partial class Updatedd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreaterEmail",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreaterEmail",
                table: "Comments");
        }
    }
}
