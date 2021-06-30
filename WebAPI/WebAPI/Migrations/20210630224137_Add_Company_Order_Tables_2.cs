using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class Add_Company_Order_Tables_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Orders",
                newName: "TransferAmount");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Orders",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Orders",
                newName: "Product");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "Orders",
                newName: "Amount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransferAmount",
                table: "Orders",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Orders",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "Product",
                table: "Orders",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Orders",
                newName: "CompanyName");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Orders",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }
    }
}
