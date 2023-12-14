using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECCMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DbChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HasAcceptedTerms",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastContact",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "MobileNo1",
                table: "AspNetUsers",
                newName: "Address");

            migrationBuilder.AddColumn<string>(
                name: "Nic",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nic",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "AspNetUsers",
                newName: "MobileNo1");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasAcceptedTerms",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastContact",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
