using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolverClientComunication.Migrations
{
    /// <inheritdoc />
    public partial class RenameTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbPassagensOnFlightReport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DbGeneralParametersDefault",
                table: "DbGeneralParametersDefault");

            migrationBuilder.RenameTable(
                name: "DbGeneralParametersDefault",
                newName: "DbDefaultParameters");

            migrationBuilder.RenameTable(
                name: "DbFuelPrice",
                newName: "DbFuelPrices");

            migrationBuilder.RenameTable(
                name: "DbFlightsReport",
                newName: "DbFlightsReports");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DbDefaultParameters",
                table: "DbDefaultParameters",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DbPassengersOnFlight",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightId = table.Column<long>(type: "bigint", nullable: false),
                    PassengerId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbPassengersOnFlight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbPassengersOnFlight_DbFlightsReports_FlightId",
                        column: x => x.FlightId,
                        principalTable: "DbFlightsReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DbPassengersOnFlight_DbRequests_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "DbRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbPassengersOnFlight_FlightId",
                table: "DbPassengersOnFlight",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_DbPassengersOnFlight_PassengerId",
                table: "DbPassengersOnFlight",
                column: "PassengerId");

            migrationBuilder.AddForeignKey(
                name: "FK_DbAirplanes_DbInstances_InstanceId",
                table: "DbAirplanes",
                column: "InstanceId",
                principalTable: "DbInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_DbAirports_DbInstances_InstanceId",
                table: "DbAirports",
                column: "InstanceId",
                principalTable: "DbInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_DbExchangeRates_DbInstances_InstanceId",
                table: "DbExchangeRates",
                column: "InstanceId",
                principalTable: "DbInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_DbFlightsReports_DbAirplanes_AirplanesId",
                table: "DbFlightsReports",
                column: "AirplanesId",
                principalTable: "DbAirplanes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_DbFlightsReports_DbAirports_DestinationId",
                table: "DbFlightsReports",
                column: "DestinationId",
                principalTable: "DbAirports",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_DbFlightsReports_DbAirports_OriginId",
                table: "DbFlightsReports",
                column: "OriginId",
                principalTable: "DbAirports",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_DbFlightsReports_DbInstances_InstanceId",
                table: "DbFlightsReports",
                column: "InstanceId",
                principalTable: "DbInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_DbFuelPrices_DbAirports_AirportId",
                table: "DbFuelPrices",
                column: "AirportId",
                principalTable: "DbAirports",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_DbFuelPrices_DbInstances_InstanceId",
                table: "DbFuelPrices",
                column: "InstanceId",
                principalTable: "DbInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_DbImportErrors_DbInstances_InstanceId",
                table: "DbImportErrors",
                column: "InstanceId",
                principalTable: "DbInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_DbOptimizationAlerts_DbInstances_InstanceId",
                table: "DbOptimizationAlerts",
                column: "InstanceId",
                principalTable: "DbInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_DbParameters_DbInstances_InstanceId",
                table: "DbParameters",
                column: "InstanceId",
                principalTable: "DbInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_DbRefuelsReport_DbInstances_InstanceId",
                table: "DbRefuelsReport",
                column: "InstanceId",
                principalTable: "DbInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_DbRequests_DbInstances_InstanceId",
                table: "DbRequests",
                column: "InstanceId",
                principalTable: "DbInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbAirplanes_DbInstances_InstanceId",
                table: "DbAirplanes");

            migrationBuilder.DropForeignKey(
                name: "FK_DbAirports_DbInstances_InstanceId",
                table: "DbAirports");

            migrationBuilder.DropForeignKey(
                name: "FK_DbExchangeRates_DbInstances_InstanceId",
                table: "DbExchangeRates");

            migrationBuilder.DropForeignKey(
                name: "FK_DbFlightsReports_DbAirplanes_AirplanesId",
                table: "DbFlightsReports");

            migrationBuilder.DropForeignKey(
                name: "FK_DbFlightsReports_DbAirports_DestinationId",
                table: "DbFlightsReports");

            migrationBuilder.DropForeignKey(
                name: "FK_DbFlightsReports_DbAirports_OriginId",
                table: "DbFlightsReports");

            migrationBuilder.DropForeignKey(
                name: "FK_DbFlightsReports_DbInstances_InstanceId",
                table: "DbFlightsReports");

            migrationBuilder.DropForeignKey(
                name: "FK_DbFuelPrices_DbAirports_AirportId",
                table: "DbFuelPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_DbFuelPrices_DbInstances_InstanceId",
                table: "DbFuelPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_DbImportErrors_DbInstances_InstanceId",
                table: "DbImportErrors");

            migrationBuilder.DropForeignKey(
                name: "FK_DbOptimizationAlerts_DbInstances_InstanceId",
                table: "DbOptimizationAlerts");

            migrationBuilder.DropForeignKey(
                name: "FK_DbParameters_DbInstances_InstanceId",
                table: "DbParameters");

            migrationBuilder.DropForeignKey(
                name: "FK_DbRefuelsReport_DbInstances_InstanceId",
                table: "DbRefuelsReport");

            migrationBuilder.DropForeignKey(
                name: "FK_DbRequests_DbInstances_InstanceId",
                table: "DbRequests");

            migrationBuilder.DropTable(
                name: "DbPassengersOnFlight");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DbInstances",
                table: "DbInstances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DbFuelPrices",
                table: "DbFuelPrices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DbFlightsReports",
                table: "DbFlightsReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DbDefaultParameters",
                table: "DbDefaultParameters");

            migrationBuilder.RenameTable(
                name: "DbInstances",
                newName: "DbInstance");

            migrationBuilder.RenameTable(
                name: "DbFuelPrices",
                newName: "DbFuelPrice");

            migrationBuilder.RenameTable(
                name: "DbFlightsReports",
                newName: "DbFlightsReport");

            migrationBuilder.RenameTable(
                name: "DbDefaultParameters",
                newName: "DbGeneralParametersDefault");

            migrationBuilder.RenameIndex(
                name: "IX_DbFuelPrices_InstanceId",
                table: "DbFuelPrice",
                newName: "IX_DbFuelPrice_InstanceId");

            migrationBuilder.RenameIndex(
                name: "IX_DbFuelPrices_AirportId",
                table: "DbFuelPrice",
                newName: "IX_DbFuelPrice_AirportId");

            migrationBuilder.RenameIndex(
                name: "IX_DbFlightsReports_OriginId",
                table: "DbFlightsReport",
                newName: "IX_DbFlightsReport_OriginId");

            migrationBuilder.RenameIndex(
                name: "IX_DbFlightsReports_InstanceId",
                table: "DbFlightsReport",
                newName: "IX_DbFlightsReport_InstanceId");

            migrationBuilder.RenameIndex(
                name: "IX_DbFlightsReports_DestinationId",
                table: "DbFlightsReport",
                newName: "IX_DbFlightsReport_DestinationId");

            migrationBuilder.RenameIndex(
                name: "IX_DbFlightsReports_AirplanesId",
                table: "DbFlightsReport",
                newName: "IX_DbFlightsReport_AirplanesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DbInstance",
                table: "DbInstance",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DbFuelPrice",
                table: "DbFuelPrice",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DbFlightsReport",
                table: "DbFlightsReport",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DbGeneralParametersDefault",
                table: "DbGeneralParametersDefault",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DbPassagensOnFlightReport",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightId = table.Column<long>(type: "bigint", nullable: false),
                    PassengerId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbPassagensOnFlightReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbPassagensOnFlightReport_DbFlightsReport_FlightId",
                        column: x => x.FlightId,
                        principalTable: "DbFlightsReport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DbPassagensOnFlightReport_DbRequests_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "DbRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbPassagensOnFlightReport_FlightId",
                table: "DbPassagensOnFlightReport",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_DbPassagensOnFlightReport_PassengerId",
                table: "DbPassagensOnFlightReport",
                column: "PassengerId");

            migrationBuilder.AddForeignKey(
                name: "FK_DbAirplanes_DbInstance_InstanceId",
                table: "DbAirplanes",
                column: "InstanceId",
                principalTable: "DbInstance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DbAirports_DbInstance_InstanceId",
                table: "DbAirports",
                column: "InstanceId",
                principalTable: "DbInstance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DbExchangeRates_DbInstance_InstanceId",
                table: "DbExchangeRates",
                column: "InstanceId",
                principalTable: "DbInstance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DbFlightsReport_DbAirplanes_AirplanesId",
                table: "DbFlightsReport",
                column: "AirplanesId",
                principalTable: "DbAirplanes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DbFlightsReport_DbAirports_DestinationId",
                table: "DbFlightsReport",
                column: "DestinationId",
                principalTable: "DbAirports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DbFlightsReport_DbAirports_OriginId",
                table: "DbFlightsReport",
                column: "OriginId",
                principalTable: "DbAirports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DbFlightsReport_DbInstance_InstanceId",
                table: "DbFlightsReport",
                column: "InstanceId",
                principalTable: "DbInstance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DbFuelPrice_DbAirports_AirportId",
                table: "DbFuelPrice",
                column: "AirportId",
                principalTable: "DbAirports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DbFuelPrice_DbInstance_InstanceId",
                table: "DbFuelPrice",
                column: "InstanceId",
                principalTable: "DbInstance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DbImportErrors_DbInstance_InstanceId",
                table: "DbImportErrors",
                column: "InstanceId",
                principalTable: "DbInstance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DbOptimizationAlerts_DbInstance_InstanceId",
                table: "DbOptimizationAlerts",
                column: "InstanceId",
                principalTable: "DbInstance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DbParameters_DbInstance_InstanceId",
                table: "DbParameters",
                column: "InstanceId",
                principalTable: "DbInstance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DbRefuelsReport_DbInstance_InstanceId",
                table: "DbRefuelsReport",
                column: "InstanceId",
                principalTable: "DbInstance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DbRequests_DbInstance_InstanceId",
                table: "DbRequests",
                column: "InstanceId",
                principalTable: "DbInstance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
