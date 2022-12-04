using Persistence.Helpers;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class SP_Add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddSqlFile();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
