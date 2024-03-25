using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codeislife.crm.data.Migrations
{
    /// <inheritdoc />
    public partial class addstage_state : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OnLeadStateId",
                table: "DashboardStage",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OnLeadStateId",
                table: "DashboardStage");
        }
    }
}
