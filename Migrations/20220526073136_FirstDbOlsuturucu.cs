using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crud.Migrations
{
    public partial class FirstDbOlsuturucu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Islemler",
                columns: table => new
                {
                    islemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HesapNumarasi = table.Column<string>(type: "nvarchar(12)", nullable: false),
                    AliciIsim = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    BankaIsim = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    SwiftCode = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    Miktar = table.Column<int>(type: "int", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Islemler", x => x.islemId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Islemler");
        }
    }
}
