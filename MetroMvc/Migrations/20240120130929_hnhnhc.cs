using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetroMvc.Migrations
{
    public partial class hnhnhc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "OfficePhone",
                table: "Settings");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://www.google.com/imgres?imgurl=https%3A%2F%2Fh5p.org%2Fsites%2Fdefault%2Ffiles%2Fh5p%2Fcontent%2F1209180%2Fimages%2Ffile-6113d5f8845dc.jpeg&tbnid=7QZBd9RaYaUYjM&vet=12ahUKEwjHwcHshOyDAxVcPhAIHTHHAhgQMygpegUIARClAQ..i&imgrefurl=https%3A%2F%2Fh5p.org%2Fcontent-types%2Fimage-choice&docid=Ju-2V_Fzujza9M&w=2292&h=1500&q=image&ved=2ahUKEwjHwcHshOyDAxVcPhAIHTHHAhgQMygpegUIARClAQ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Settings");

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OfficePhone",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Adress", "City", "Email", "Mobile", "OfficePhone" },
                values: new object[] { "Baki,Azerbaijan", "Abhseron", "Fuad@gmai.com", "34556", "01256578" });
        }
    }
}
