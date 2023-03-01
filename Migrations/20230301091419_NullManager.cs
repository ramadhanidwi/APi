using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APi.Migrations
{
    /// <inheritdoc />
    public partial class NullManager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "manager_id",
                table: "tb_m_employees",
                type: "nchar(5)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar(5)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "manager_id",
                table: "tb_m_employees",
                type: "nchar(5)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nchar(5)",
                oldNullable: true);
        }
    }
}
