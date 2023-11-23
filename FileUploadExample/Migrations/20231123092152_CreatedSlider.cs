using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileUploadExample.Migrations
{
    /// <inheritdoc />
    public partial class CreatedSlider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Slider",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TextUpper = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TextBelow = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TextButton = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slider", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Slider");
        }
    }
}
