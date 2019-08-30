using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Data.Mirgrations
{
    public partial class firstmigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crusts",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crusts", x => x.Name);
                    table.UniqueConstraint("AK_Crusts_Id", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Crusts");
        }
    }
}
