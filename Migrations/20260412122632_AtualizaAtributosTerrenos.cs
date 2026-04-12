using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaAtributosTerrenos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Terrenos",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Terrenos",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "MarcadoComoImportante",
                table: "Terrenos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -26.304400000000001, -48.848700000000001, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -22.9068, -43.172899999999998, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 40.712800000000001, -74.006, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 48.8566, 2.3521999999999998, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 35.689500000000002, 139.6917, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -33.8688, 151.20930000000001, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 51.507399999999997, -0.1278, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 34.052199999999999, -118.2437, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 55.755800000000001, 37.6173, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 41.902799999999999, 12.4964, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 19.432600000000001, -99.133200000000002, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 52.520000000000003, 13.404999999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 59.329300000000003, 18.0686, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 37.774900000000002, -122.4194, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 31.230399999999999, 121.47369999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 28.613900000000001, 77.209000000000003, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 50.110900000000001, 8.6821000000000002, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 45.464199999999998, 9.1899999999999995, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 43.653199999999998, -79.383200000000002, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 1.3521000000000001, 103.8198, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 35.676200000000001, 139.65029999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 60.169899999999998, 24.938400000000001, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -23.5505, -46.633299999999998, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -34.603700000000003, -58.381599999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 25.204799999999999, 55.270800000000001, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 19.076000000000001, 72.877700000000004, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 41.385100000000001, 2.1734, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 64.200800000000001, -149.49369999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -13.1631, -72.545000000000002, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 64.963099999999997, -19.020800000000001, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -22.951899999999998, -43.210500000000003, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 46.227600000000002, 2.2136999999999998, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 35.907800000000002, 127.76690000000001, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -9.1898999999999997, -75.015199999999993, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 56.130400000000002, -106.3468, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 30.0444, 31.235700000000001, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 13.7563, 100.5018, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 59.913899999999998, 10.7522, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -17.8249, 31.049199999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 61.524000000000001, 105.3188, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 7.8731, 80.771799999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 25.761700000000001, -80.191800000000001, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 50.850299999999997, 4.3517000000000001, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -36.848500000000001, 174.76329999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 55.953299999999999, -3.1882999999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 35.2271, -80.843100000000007, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 48.208199999999998, 16.373799999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 66.160499999999999, -153.3691, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -45.031199999999998, 168.6626, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 64.146600000000007, -21.942599999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 35.861699999999999, 104.19540000000001, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -20.348400000000002, 57.552199999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 53.349800000000002, -6.2603, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 36.204799999999999, 138.25290000000001, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -8.7832000000000008, -55.491500000000002, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 56.879600000000003, 24.603200000000001, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 14.599500000000001, 120.9842, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 59.436999999999998, 24.753599999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -1.2921, 36.821899999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 50.075499999999998, 14.437799999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -22.9068, 18.423200000000001, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 61.2181, -149.90029999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 33.684399999999997, 73.047899999999998, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 47.497900000000001, 19.040199999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -15.7942, -47.882199999999997, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 55.676099999999998, 12.568300000000001, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 37.566499999999998, 126.97799999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 64.963099999999997, -19.020800000000001, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -33.924900000000001, 18.424099999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 60.472000000000001, 8.4688999999999997, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 9.0820000000000007, 8.6753, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 56.2639, 9.5017999999999994, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -12.0464, -77.0428, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 35.6892, 51.389000000000003, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 41.008200000000002, 28.978400000000001, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 59.9343, 30.335100000000001, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 13.082700000000001, 80.270700000000005, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 52.367600000000003, 4.9040999999999997, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 25.276, 55.296199999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -6.2088000000000001, 106.8456, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 50.110900000000001, 8.6821000000000002, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 59.329300000000003, 18.0686, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 19.076000000000001, 72.877700000000004, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 55.755800000000001, 37.6173, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 37.774900000000002, -122.4194, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 48.8566, 2.3521999999999998, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 35.676200000000001, 139.65029999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 46.818199999999997, 8.2274999999999991, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -17.7134, 178.065, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 64.135499999999993, -21.895399999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 52.520000000000003, 13.404999999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -22.951899999999998, -43.210500000000003, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 41.385100000000001, 2.1734, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 35.676200000000001, 139.65029999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 55.755800000000001, 37.6173, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 37.774900000000002, -122.4194, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 48.8566, 2.3521999999999998, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -33.8688, 151.20930000000001, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 51.507399999999997, -0.1278, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 40.712800000000001, -74.006, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 34.052199999999999, -118.2437, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 1.3521000000000001, 103.8198, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 35.689500000000002, 139.6917, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 41.902799999999999, 12.4964, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 19.432600000000001, -99.133200000000002, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 52.520000000000003, 13.404999999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 59.329300000000003, 18.0686, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 63.825800000000001, -149.49369999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -54.801900000000003, -68.302999999999997, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 71.706900000000005, -42.604300000000002, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 23.634499999999999, -102.5528, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 64.200800000000001, -51.677999999999997, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 78.223200000000006, 15.6469, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -25.2744, 133.77510000000001, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 60.1282, 18.6435, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 39.904200000000003, 116.4074, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 55.378100000000003, -3.4359999999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -13.254300000000001, 34.301499999999997, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 46.227600000000002, 2.2136999999999998, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 35.861699999999999, 104.19540000000001, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -30.5595, 22.9375, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 61.924100000000003, 25.748200000000001, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 21.161899999999999, -86.851500000000001, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 50.9375, 6.9603000000000002, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 13.4125, 103.86669999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 59.913899999999998, 10.7522, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -22.328499999999998, 24.684899999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 66.503900000000002, 25.729399999999998, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -23.442499999999999, -58.443800000000003, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 64.183499999999995, -51.721600000000002, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 35.179600000000001, 129.07560000000001, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 56.490699999999997, -4.2026000000000003, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -15.387499999999999, 28.322800000000001, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 43.238900000000001, 76.889700000000005, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 61.132199999999997, -149.89400000000001, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 52.229700000000001, 21.0122, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -3.4653, -62.215899999999998, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 55.864199999999997, -4.2518000000000002, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 46.2044, 6.1432000000000002, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 35.907800000000002, 14.512499999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 18.1096, -77.297499999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 50.450099999999999, 30.523399999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 14.716699999999999, -17.467700000000001, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 59.913899999999998, 10.7522, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -26.2041, 28.0473, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 47.376899999999999, 8.5417000000000005, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 25.761700000000001, -80.191800000000001, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 64.837800000000001, -147.71639999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -12.4634, 130.84559999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 64.126499999999993, -21.817399999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 151,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 35.2271, -80.843100000000007, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 152,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 52.367600000000003, 4.9040999999999997, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 153,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -34.9285, 138.60069999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 154,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 43.653199999999998, -79.383200000000002, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 155,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 60.169899999999998, 24.938400000000001, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 156,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -22.9068, 18.423200000000001, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 157,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 41.008200000000002, 28.978400000000001, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 158,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 59.329300000000003, 18.0686, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 159,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 19.432600000000001, -99.133200000000002, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 160,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 55.755800000000001, 37.6173, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 161,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 35.676200000000001, 139.65029999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 162,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 48.8566, 2.3521999999999998, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 163,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 37.774900000000002, -122.4194, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 164,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 1.3521000000000001, 103.8198, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 165,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 51.507399999999997, -0.1278, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 166,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -33.8688, 151.20930000000001, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 167,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 40.712800000000001, -74.006, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 168,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 66.0, 30.0, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 169,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -35.0, -70.0, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 170,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 10.0, 20.0, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 171,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -10.0, 100.0, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 172,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 35.0, -10.0, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 173,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 48.0, 14.0, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 174,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -20.0, 130.0, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 175,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 55.0, -3.0, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 176,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -15.0, -47.0, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 177,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 60.0, 90.0, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 178,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -25.0, 25.0, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 179,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 30.0, 120.0, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 180,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -30.0, -60.0, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 181,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 45.0, 45.0, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 182,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -5.0, -30.0, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 183,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 20.0, -80.0, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 184,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 65.0, 60.0, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 185,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -40.0, 140.0, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 186,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 15.0, -100.0, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 187,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -45.0, 10.0, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 188,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 12.9716, 77.5946, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 189,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -33.448900000000002, -70.669300000000007, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 190,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 64.963099999999997, -19.020800000000001, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 191,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 35.689500000000002, 139.6917, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 192,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 48.208199999999998, 16.373799999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 193,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -26.2041, 28.0473, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 194,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 50.850299999999997, 4.3517000000000001, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 195,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -34.603700000000003, -58.381599999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 196,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 59.913899999999998, 10.7522, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 197,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 13.7563, 100.5018, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 198,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 55.953299999999999, -3.1882999999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 199,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 25.204799999999999, 55.270800000000001, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 200,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 41.008200000000002, 28.978400000000001, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 201,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 60.169899999999998, 24.938400000000001, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 202,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -36.848500000000001, 174.76329999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 203,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 52.520000000000003, 13.404999999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 204,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 19.432600000000001, -99.133200000000002, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 205,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 35.676200000000001, 139.65029999999999, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 206,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { -22.951899999999998, -43.210500000000003, false });

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 207,
                columns: new[] { "Latitude", "Longitude", "MarcadoComoImportante" },
                values: new object[] { 37.774900000000002, -122.4194, false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Terrenos");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Terrenos");

            migrationBuilder.DropColumn(
                name: "MarcadoComoImportante",
                table: "Terrenos");
        }
    }
}
