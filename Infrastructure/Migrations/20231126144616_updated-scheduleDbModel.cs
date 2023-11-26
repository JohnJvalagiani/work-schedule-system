using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatedscheduleDbModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Schedules");

            migrationBuilder.AlterColumn<int>(
                name: "JobId",
                table: "Schedules",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Employee",
                table: "Schedules",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_JobId",
                table: "Schedules",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Jobs_JobId",
                table: "Schedules",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Jobs_JobId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_JobId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "Employee",
                table: "Schedules");

            migrationBuilder.AlterColumn<int>(
                name: "JobId",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
