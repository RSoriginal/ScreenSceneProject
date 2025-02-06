using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenScene.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update_Hall_RemoveCapacity_RenameSeatCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Halls");

            migrationBuilder.RenameColumn(
                name: "SeatCount",
                table: "Halls",
                newName: "ColumnCount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ColumnCount",
                table: "Halls",
                newName: "SeatCount");

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Halls",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
