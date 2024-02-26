using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codeislife.crm.web.app.Migrations
{
    /// <inheritdoc />
    public partial class addCommentOnLead : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Lead",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Lead");
        }
    }
}
