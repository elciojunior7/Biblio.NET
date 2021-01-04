using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ProjBiblio.Infrastructure.Data.Migrations
{
    public partial class CreateTableKart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "startDate",
                table: "Loan",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "returnDate",
                table: "Loan",
                newName: "ReturnDate");

            migrationBuilder.RenameColumn(
                name: "endDate",
                table: "Loan",
                newName: "EndDate");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "User",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Kart",
                columns: table => new
                {
                    KartID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    LoanID = table.Column<int>(nullable: true),
                    SessionUserID = table.Column<string>(nullable: true),
                    BookID = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kart", x => x.KartID);
                    table.ForeignKey(
                        name: "FK_Kart_Book_BookID",
                        column: x => x.BookID,
                        principalTable: "Book",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kart_BookID",
                table: "Kart",
                column: "BookID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kart");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Loan",
                newName: "startDate");

            migrationBuilder.RenameColumn(
                name: "ReturnDate",
                table: "Loan",
                newName: "returnDate");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Loan",
                newName: "endDate");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "User",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);
        }
    }
}
