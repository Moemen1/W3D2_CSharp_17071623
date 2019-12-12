using Microsoft.EntityFrameworkCore.Migrations;

namespace W3D2_CSharp_17071623.Migrations
{
    public partial class MadeLeeftijdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Leeftijd",
                table: "Students",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Leeftijd",
                table: "Students",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
