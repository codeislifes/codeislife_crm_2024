using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codeislife.crm.data.Migrations
{
    /// <inheritdoc />
    public partial class addstage_state_0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OnLeadStateId",
                table: "DashboardStage",
                newName: "OnLeadState");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OnLeadState",
                table: "DashboardStage",
                newName: "OnLeadStateId");
        }
    }
}
