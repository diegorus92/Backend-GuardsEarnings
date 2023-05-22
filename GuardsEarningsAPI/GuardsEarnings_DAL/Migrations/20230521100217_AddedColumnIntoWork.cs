using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuardsEarnings_DAL.Migrations
{
    public partial class AddedColumnIntoWork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Payment",
                table: "Works",
                type: "real",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Payment",
                table: "Works");
        }
    }
}
