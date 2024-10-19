using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolverClientComunication.Migrations
{
    /// <inheritdoc />
    public partial class ResetAfterEFUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbGeneralParametersDefault",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbGeneralParametersDefault", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbInstance",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastOptimization = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Optimized = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbInstance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbReportList",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportLabel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbReportList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbStretches",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstanceId = table.Column<long>(type: "bigint", nullable: false),
                    Distance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbStretches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbAirports",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirportName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IATA = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Region = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Elevation = table.Column<int>(type: "int", nullable: false),
                    RunwayLength = table.Column<int>(type: "int", nullable: false),
                    MTOW_APE3 = table.Column<int>(type: "int", nullable: false),
                    MTOW_PC12 = table.Column<int>(type: "int", nullable: false),
                    LandingCost = table.Column<int>(type: "int", nullable: false),
                    GroundTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    InstanceId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbAirports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbAirports_DbInstance_InstanceId",
                        column: x => x.InstanceId,
                        principalTable: "DbInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DbExchangeRates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrencySymbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValueInDolar = table.Column<double>(type: "float", nullable: false),
                    InstanceId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbExchangeRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbExchangeRates_DbInstance_InstanceId",
                        column: x => x.InstanceId,
                        principalTable: "DbInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DbImportErrors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sheet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RowLine = table.Column<int>(type: "int", nullable: false),
                    ImportationHour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InstanceId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbImportErrors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbImportErrors_DbInstance_InstanceId",
                        column: x => x.InstanceId,
                        principalTable: "DbInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DbOptimizationAlerts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Table = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstanceId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbOptimizationAlerts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbOptimizationAlerts_DbInstance_InstanceId",
                        column: x => x.InstanceId,
                        principalTable: "DbInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DbParameters",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstanceId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbParameters_DbInstance_InstanceId",
                        column: x => x.InstanceId,
                        principalTable: "DbInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DbAirplanes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prefix = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Range = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    MaxWeight = table.Column<int>(type: "int", nullable: false),
                    FuelConsumptionFirstHour = table.Column<int>(type: "int", nullable: false),
                    FuelConsumptionSecondHour = table.Column<int>(type: "int", nullable: false),
                    CruiseSpeed = table.Column<double>(type: "float", nullable: false),
                    MaxFuel = table.Column<double>(type: "float", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<double>(type: "float", nullable: false),
                    BaseAirportId = table.Column<long>(type: "bigint", nullable: true),
                    InstanceId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbAirplanes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbAirplanes_DbAirports_BaseAirportId",
                        column: x => x.BaseAirportId,
                        principalTable: "DbAirports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DbAirplanes_DbInstance_InstanceId",
                        column: x => x.InstanceId,
                        principalTable: "DbInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DbFuelPrice",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirportId = table.Column<long>(type: "bigint", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstanceId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbFuelPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbFuelPrice_DbAirports_AirportId",
                        column: x => x.AirportId,
                        principalTable: "DbAirports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DbFuelPrice_DbInstance_InstanceId",
                        column: x => x.InstanceId,
                        principalTable: "DbInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbRequests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PNR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsChildren = table.Column<bool>(type: "bit", nullable: false),
                    DepartureTimeWindowBegin = table.Column<TimeSpan>(type: "time", nullable: false),
                    DepartureTimeWindowEnd = table.Column<TimeSpan>(type: "time", nullable: false),
                    ArrivalTimeWindowBegin = table.Column<TimeSpan>(type: "time", nullable: false),
                    ArrivalTimeWindowEnd = table.Column<TimeSpan>(type: "time", nullable: false),
                    OriginId = table.Column<long>(type: "bigint", nullable: false),
                    DestinationId = table.Column<long>(type: "bigint", nullable: false),
                    InstanceId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbRequests_DbAirports_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "DbAirports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbRequests_DbAirports_OriginId",
                        column: x => x.OriginId,
                        principalTable: "DbAirports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbRequests_DbInstance_InstanceId",
                        column: x => x.InstanceId,
                        principalTable: "DbInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbFlightsReport",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginId = table.Column<long>(type: "bigint", nullable: false),
                    DestinationId = table.Column<long>(type: "bigint", nullable: false),
                    FuelOnDeparture = table.Column<double>(type: "float", nullable: false),
                    FuelOnArrival = table.Column<double>(type: "float", nullable: false),
                    DepartureTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ArrivalTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    AirplanesId = table.Column<long>(type: "bigint", nullable: false),
                    InstanceId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbFlightsReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbFlightsReport_DbAirplanes_AirplanesId",
                        column: x => x.AirplanesId,
                        principalTable: "DbAirplanes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DbFlightsReport_DbAirports_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "DbAirports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbFlightsReport_DbAirports_OriginId",
                        column: x => x.OriginId,
                        principalTable: "DbAirports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbFlightsReport_DbInstance_InstanceId",
                        column: x => x.InstanceId,
                        principalTable: "DbInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbRefuelsReport",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstanceId = table.Column<long>(type: "bigint", nullable: false),
                    AirportId = table.Column<long>(type: "bigint", nullable: false),
                    AirplanesId = table.Column<long>(type: "bigint", nullable: false),
                    RefuelTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbRefuelsReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbRefuelsReport_DbAirplanes_AirplanesId",
                        column: x => x.AirplanesId,
                        principalTable: "DbAirplanes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbRefuelsReport_DbAirports_AirportId",
                        column: x => x.AirportId,
                        principalTable: "DbAirports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbRefuelsReport_DbInstance_InstanceId",
                        column: x => x.InstanceId,
                        principalTable: "DbInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbSeats",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirplanesId = table.Column<long>(type: "bigint", nullable: false),
                    seatClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    luggageWeightLimit = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbSeats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbSeats_DbAirplanes_AirplanesId",
                        column: x => x.AirplanesId,
                        principalTable: "DbAirplanes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_DbAirplanes_BaseAirportId",
                table: "DbAirplanes",
                column: "BaseAirportId");

            migrationBuilder.CreateIndex(
                name: "IX_DbAirplanes_InstanceId",
                table: "DbAirplanes",
                column: "InstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_DbAirports_InstanceId",
                table: "DbAirports",
                column: "InstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_DbExchangeRates_InstanceId",
                table: "DbExchangeRates",
                column: "InstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_DbFlightsReport_AirplanesId",
                table: "DbFlightsReport",
                column: "AirplanesId");

            migrationBuilder.CreateIndex(
                name: "IX_DbFlightsReport_DestinationId",
                table: "DbFlightsReport",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_DbFlightsReport_InstanceId",
                table: "DbFlightsReport",
                column: "InstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_DbFlightsReport_OriginId",
                table: "DbFlightsReport",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_DbFuelPrice_AirportId",
                table: "DbFuelPrice",
                column: "AirportId");

            migrationBuilder.CreateIndex(
                name: "IX_DbFuelPrice_InstanceId",
                table: "DbFuelPrice",
                column: "InstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_DbImportErrors_InstanceId",
                table: "DbImportErrors",
                column: "InstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_DbOptimizationAlerts_InstanceId",
                table: "DbOptimizationAlerts",
                column: "InstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_DbParameters_InstanceId",
                table: "DbParameters",
                column: "InstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_DbPassagensOnFlightReport_FlightId",
                table: "DbPassagensOnFlightReport",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_DbPassagensOnFlightReport_PassengerId",
                table: "DbPassagensOnFlightReport",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_DbRefuelsReport_AirplanesId",
                table: "DbRefuelsReport",
                column: "AirplanesId");

            migrationBuilder.CreateIndex(
                name: "IX_DbRefuelsReport_AirportId",
                table: "DbRefuelsReport",
                column: "AirportId");

            migrationBuilder.CreateIndex(
                name: "IX_DbRefuelsReport_InstanceId",
                table: "DbRefuelsReport",
                column: "InstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_DbRequests_DestinationId",
                table: "DbRequests",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_DbRequests_InstanceId",
                table: "DbRequests",
                column: "InstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_DbRequests_OriginId",
                table: "DbRequests",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_DbSeats_AirplanesId",
                table: "DbSeats",
                column: "AirplanesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbExchangeRates");

            migrationBuilder.DropTable(
                name: "DbFuelPrice");

            migrationBuilder.DropTable(
                name: "DbGeneralParametersDefault");

            migrationBuilder.DropTable(
                name: "DbImportErrors");

            migrationBuilder.DropTable(
                name: "DbOptimizationAlerts");

            migrationBuilder.DropTable(
                name: "DbParameters");

            migrationBuilder.DropTable(
                name: "DbPassagensOnFlightReport");

            migrationBuilder.DropTable(
                name: "DbRefuelsReport");

            migrationBuilder.DropTable(
                name: "DbReportList");

            migrationBuilder.DropTable(
                name: "DbSeats");

            migrationBuilder.DropTable(
                name: "DbStretches");

            migrationBuilder.DropTable(
                name: "DbFlightsReport");

            migrationBuilder.DropTable(
                name: "DbRequests");

            migrationBuilder.DropTable(
                name: "DbAirplanes");

            migrationBuilder.DropTable(
                name: "DbAirports");

            migrationBuilder.DropTable(
                name: "DbInstance");
        }
    }
}
