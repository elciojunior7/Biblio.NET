using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjBiblio.Infrastructure.Data.Migrations
{
    public partial class AlterTableMkt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "startDate",
                table: "MarketingCampaign",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "endDate",
                table: "MarketingCampaign",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "discountPercentage",
                table: "MarketingCampaign",
                newName: "DiscountPercentage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "MarketingCampaign",
                newName: "startDate");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "MarketingCampaign",
                newName: "endDate");

            migrationBuilder.RenameColumn(
                name: "DiscountPercentage",
                table: "MarketingCampaign",
                newName: "discountPercentage");
        }
    }
}
