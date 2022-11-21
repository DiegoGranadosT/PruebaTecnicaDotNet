using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnicaDotNet.Server.Migrations
{
    /// <inheritdoc />
    public partial class M1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    cId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cName1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cName2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cLastName1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cLastName2 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.cId);
                });

            migrationBuilder.CreateTable(
                name: "CustomersPhones",
                columns: table => new
                {
                    cpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cId = table.Column<int>(type: "int", nullable: false),
                    cpPhone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersPhones", x => x.cpId);
                    table.ForeignKey(
                        name: "FK_CustomersPhones_Customers_cId",
                        column: x => x.cId,
                        principalTable: "Customers",
                        principalColumn: "cId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomersPhones_cId",
                table: "CustomersPhones",
                column: "cId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomersPhones");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
