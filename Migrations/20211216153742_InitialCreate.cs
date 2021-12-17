using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication3.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vacancy",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    staffing_item_parrent_full_ext_id = table.Column<string>(nullable: false),
                    staffing_item_full_ext_id = table.Column<string>(nullable: false),
                    Fio_vlad = table.Column<string>(nullable: false),
                    Telefon_vlad = table.Column<string>(nullable: false),
                    Fio_rec = table.Column<string>(nullable: false),
                    Telefon_rec = table.Column<string>(nullable: false),
                    Email_rec = table.Column<string>(nullable: false),
                    id_candidate = table.Column<int>(nullable: false),
                    last_name = table.Column<string>(nullable: false),
                    first_name = table.Column<string>(nullable: false),
                    middle_name = table.Column<string>(nullable: true),
                    no_middle_name = table.Column<bool>(nullable: false),
                    dt_birthday = table.Column<DateTime>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    gender = table.Column<bool>(nullable: false),
                    Rec_Active = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancy", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vacancy");
        }
    }
}
