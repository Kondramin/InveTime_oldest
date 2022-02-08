using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InveTime.Database.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Market",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Market", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passwords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passwords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessLevel = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategorySearchWords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorySearchWords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategorySearchWords_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OpenToModifi = table.Column<bool>(type: "bit", nullable: false),
                    MarketId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventories_Market_MarketId",
                        column: x => x.MarketId,
                        principalTable: "Market",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarketId = table.Column<int>(type: "int", nullable: true),
                    PositionId = table.Column<int>(type: "int", nullable: true),
                    PasswordId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Market_MarketId",
                        column: x => x.MarketId,
                        principalTable: "Market",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Passwords_PasswordId",
                        column: x => x.PasswordId,
                        principalTable: "Passwords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductsInventeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountData = table.Column<int>(type: "int", nullable: false),
                    AmountFact = table.Column<int>(type: "int", nullable: false),
                    Re_Grading = table.Column<bool>(type: "bit", nullable: false),
                    ProductInfoId = table.Column<int>(type: "int", nullable: true),
                    InventoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsInventeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsInventeds_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductsInventeds_Products_ProductInfoId",
                        column: x => x.ProductInfoId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeInventory",
                columns: table => new
                {
                    EventStaffId = table.Column<int>(type: "int", nullable: false),
                    InventoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeInventory", x => new { x.EventStaffId, x.InventoriesId });
                    table.ForeignKey(
                        name: "FK_EmployeeInventory_Employees_EventStaffId",
                        column: x => x.EventStaffId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeInventory_Inventories_InventoriesId",
                        column: x => x.InventoriesId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Внешние аккумуляторы" },
                    { 24, "Прочее" },
                    { 23, "Кабели" },
                    { 22, "Освещение" },
                    { 21, "Транспорт" },
                    { 20, "Техника для уборки" },
                    { 19, "Умный дом" },
                    { 18, "Медиаплееры" },
                    { 17, "Телевизоры" },
                    { 15, "Гарнитуры" },
                    { 14, "Портативная акустика" },
                    { 13, "Мыши компьютерные" },
                    { 16, "Сетевое оборудование" },
                    { 11, "Батарейки" },
                    { 2, "Ноутбуки" },
                    { 12, "IP-камеры" },
                    { 4, "Мобильные телефоны" },
                    { 5, "Чехлы/бампера/книги для телефона" },
                    { 6, "Защитные стёкла/плёнки" },
                    { 3, "Рюкзаки/сумки/чемоданы" },
                    { 8, "Ремешки для часов/браслетов" },
                    { 9, "Видеорегистраторы" },
                    { 10, "Карты памяти" },
                    { 7, "Умные часы/браслеты" }
                });

            migrationBuilder.InsertData(
                table: "Market",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, null, "Mi_Minsk_Galereya" },
                    { 2, null, "Mi_Minsk_Expobel" },
                    { 3, null, "Mi_Minsk_E-City" },
                    { 4, null, "Mi_Minsk_Skala" }
                });

            migrationBuilder.InsertData(
                table: "Passwords",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "AccessLevel", "Name" },
                values: new object[,]
                {
                    { 2, 5, "Менеджер магазина" },
                    { 1, 10, "Администратор" },
                    { 3, 1, "Продавец" }
                });

            migrationBuilder.InsertData(
                table: "CategorySearchWords",
                columns: new[] { "Id", "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "внешний" },
                    { 20, 14, "колонка" },
                    { 21, 15, "гарнитура" },
                    { 22, 16, "Wi-Fi" },
                    { 23, 17, "телевизор" },
                    { 24, 18, "TV" },
                    { 25, 19, "блок" },
                    { 19, 13, "мышь" },
                    { 26, 19, "кнопка" },
                    { 28, 20, "пылесос" },
                    { 29, 20, "швабра" },
                    { 30, 21, "самокат" },
                    { 31, 21, "велосипед" },
                    { 32, 21, "гироскутер" },
                    { 33, 22, "лампа" },
                    { 27, 19, "датчик" },
                    { 34, 23, "кабель" },
                    { 18, 12, "IP" },
                    { 16, 10, "памяти" },
                    { 2, 2, "ноутбук" },
                    { 3, 3, "рюкзак" },
                    { 4, 3, "сумка" },
                    { 5, 3, "чемодан" },
                    { 6, 4, "телефон" },
                    { 7, 5, "чехол" },
                    { 17, 11, "батар" },
                    { 8, 5, "бампер" },
                    { 10, 6, "стекло" },
                    { 11, 6, "пленка" },
                    { 12, 7, "браслет" },
                    { 13, 7, "часы" },
                    { 14, 8, "ремешок" },
                    { 15, 9, "видеорегистратор" },
                    { 9, 5, "книга" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "Location", "MarketId", "Name", "PasswordId", "Patronymic", "Phone", "PositionId", "SecondName" },
                values: new object[] { 1, "Admin@mail.com", null, null, "Admin", null, null, null, 1, null });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CategorySearchWords_CategoryId",
                table: "CategorySearchWords",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInventory_InventoriesId",
                table: "EmployeeInventory",
                column: "InventoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_MarketId",
                table: "Employees",
                column: "MarketId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PasswordId",
                table: "Employees",
                column: "PasswordId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionId",
                table: "Employees",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_MarketId",
                table: "Inventories",
                column: "MarketId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsInventeds_InventoryId",
                table: "ProductsInventeds",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsInventeds_ProductInfoId",
                table: "ProductsInventeds",
                column: "ProductInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategorySearchWords");

            migrationBuilder.DropTable(
                name: "EmployeeInventory");

            migrationBuilder.DropTable(
                name: "ProductsInventeds");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Passwords");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Market");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
