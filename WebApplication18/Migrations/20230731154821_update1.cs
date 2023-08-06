using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication18.Migrations
{
    /// <inheritdoc />
    public partial class update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hayvans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    İsim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tür = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cins = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hayvans", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hayvans");
        }
    }
}
