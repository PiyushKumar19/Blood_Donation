using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodDonation.Migrations
{
    public partial class datainsert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "BGroup",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "BGroup",
                columns: new[] { "ID", "Address", "Age", "BloodGroup", "City", "Email", "FirstName", "Gender", "LastName" },
                values: new object[,]
                {
                    { 1, "Bihari Colony", 18, 2, null, "PiyushKumar@gmail.com", "Piyush", 0, "Kumar" },
                    { 2, "Kaushambi", 18, 0, null, "HarshKumar@gmail.com", "Harsh", 0, "Kumar" },
                    { 3, "Bhola Nath Nagar", 18, 1, null, "AdityaArora@gmail.com", "Aditya", 0, "Arora" },
                    { 4, "GokulPuri", 18, 4, null, "HimanshuYadav@gmail.com", "Himanshu", 0, "Yadav" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BGroup",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BGroup",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BGroup",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BGroup",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "BGroup",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
