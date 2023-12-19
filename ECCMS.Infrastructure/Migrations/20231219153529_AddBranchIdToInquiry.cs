using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECCMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBranchIdToInquiry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "Inquiries",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Inquiries");
        }
    }
}
