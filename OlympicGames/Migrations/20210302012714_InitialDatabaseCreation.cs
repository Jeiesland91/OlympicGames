using Microsoft.EntityFrameworkCore.Migrations;

namespace OlympicGames.Migrations
{
    public partial class InitialDatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    SportId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.SportId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    GameId = table.Column<string>(nullable: true),
                    SportId = table.Column<string>(nullable: true),
                    CategoryId = table.Column<string>(nullable: true),
                    FlagImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                    table.ForeignKey(
                        name: "FK_Countries_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Countries_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Countries_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "SportId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { "I", "Indoor" },
                    { "O", "Outdoor" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "Name" },
                values: new object[,]
                {
                    { "P", "Paralympics" },
                    { "SO", "Summer Olympics" },
                    { "WO", "Winter Olympics" },
                    { "YSO", "Youth Olympic Games" }
                });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "SportId", "Name" },
                values: new object[,]
                {
                    { "Cur", "Curling" },
                    { "Bob", "Bobsleigh" },
                    { "Div", "Diving" },
                    { "RCyc", "Road Cycling" },
                    { "Arc", "Archery" },
                    { "CanSpr", "Canoe Sprint" },
                    { "BreDan", "Breakdancing" },
                    { "SkaBoa", "Skateboarding" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CategoryId", "FlagImage", "GameId", "Name", "SportId" },
                values: new object[,]
                {
                    { "CAN", "I", "CAN.png", "WO", "Canada", "Cur" },
                    { "FIN", "O", "FIN.png", "YSO", "Finland", "SkaBoa" },
                    { "RUS", "I", "RUS.png", "YSO", "Russia", "BreDan" },
                    { "CYP", "I", "CYP.png", "YSO", "Cyprus", "BreDan" },
                    { "FRA", "I", "FRA.png", "YSO", "France", "BreDan" },
                    { "ZIM", "O", "ZIM.png", "P", "Zimbabwe", "CanSpr" },
                    { "PAK", "O", "PAK.png", "P", "Pakistan", "CanSpr" },
                    { "AUS", "O", "AUS.png", "P", "Austria", "CanSpr" },
                    { "UKR", "I", "UKR.png", "P", "Ukraine", "Arc" },
                    { "URU", "I", "URU.png", "P", "Uruguay", "Arc" },
                    { "THA", "I", "THA.png", "P", "Thailand", "Arc" },
                    { "USA", "O", "USA.png", "SO", "USA", "RCyc" },
                    { "NET", "O", "NET.png", "SO", "Netherlands", "RCyc" },
                    { "BRA", "O", "BRA.png", "SO", "Brazil", "RCyc" },
                    { "MEX", "I", "MEX.png", "SO", "Mexico", "Div" },
                    { "CHI", "I", "CHI.png", "SO", "China", "Div" },
                    { "GER", "I", "GER.png", "SO", "Germany", "Div" },
                    { "JAP", "O", "JAP.png", "WO", "Japan", "Bob" },
                    { "ITA", "O", "ITA.png", "WO", "Italy", "Bob" },
                    { "JAM", "O", "JAM.png", "WO", "Jamaica", "Bob" },
                    { "GB", "I", "GB.png", "WO", "Great Britain", "Cur" },
                    { "SWE", "I", "SWE.png", "WO", "Sweden", "Cur" },
                    { "SLO", "O", "SLO.png", "YSO", "Slovakia", "SkaBoa" },
                    { "POR", "O", "POR.png", "YSO", "Portugal", "SkaBoa" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CategoryId",
                table: "Countries",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_GameId",
                table: "Countries",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_SportId",
                table: "Countries",
                column: "SportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Sports");
        }
    }
}
