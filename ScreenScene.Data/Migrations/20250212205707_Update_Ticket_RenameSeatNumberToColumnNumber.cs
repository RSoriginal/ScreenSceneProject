using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenScene.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update_Ticket_RenameSeatNumberToColumnNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SeatNumber",
                table: "Tickets",
                newName: "ColumnNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ColumnNumber",
                table: "Tickets",
                newName: "SeatNumber");
        }
    }
}
