using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECCMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Inquiries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inquiries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    InstitutionId = table.Column<int>(type: "int", nullable: false),
                    CrimeTypeId = table.Column<int>(type: "int", nullable: false),
                    TicketId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    InquiryEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAttachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewingResponse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignResponse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvestigatingResponse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvestigatingAttachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompleteResponse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSatisfied = table.Column<bool>(type: "bit", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inquiries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inquiries_CrimeTypes_CrimeTypeId",
                        column: x => x.CrimeTypeId,
                        principalTable: "CrimeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inquiries_CrimeTypeId",
                table: "Inquiries",
                column: "CrimeTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inquiries");
        }
    }
}
