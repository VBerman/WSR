using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Client.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestProject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IssueDate = table.Column<DateTime>(type: "date", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestProject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FullNameEN = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FullNameRU = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PhotoPath = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    IsStaff = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Country",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestProjectSession",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestProjectId = table.Column<int>(type: "int", nullable: false),
                    FileStorage = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_TestProjectSession_TestProject",
                        column: x => x.TestProjectId,
                        principalTable: "TestProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Catalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: false),
                    EditDate = table.Column<DateTime>(type: "date", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CatalogId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalog_Catalog",
                        column: x => x.CatalogId,
                        principalTable: "Catalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Catalog_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false),
                    InternationalExpertId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Skill_User",
                        column: x => x.InternationalExpertId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserDocument",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DocumentTypeId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScanPath = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDocument_DocumentType",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserDocument_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    Token = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DeviceId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => x.Token);
                    table.ForeignKey(
                        name: "FK_UserToken_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingPlace",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPlace", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingPlace_City",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatalogId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Path = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EditDateTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_Catalog",
                        column: x => x.CatalogId,
                        principalTable: "Catalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WSOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionNumber = table.Column<byte>(type: "tinyint", nullable: false),
                    SectionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SkillCode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WSOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WSOS_Skill",
                        column: x => x.SkillCode,
                        principalTable: "Skill",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Training",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillCode = table.Column<int>(type: "int", nullable: false),
                    TrainingPlaceId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Training_Skill",
                        column: x => x.SkillCode,
                        principalTable: "Skill",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Training_TrainingPlace",
                        column: x => x.TrainingPlaceId,
                        principalTable: "TrainingPlace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubSkill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentSubSkillId = table.Column<int>(type: "int", nullable: true),
                    WSOSId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Theory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Importance = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubSkill_SubSkill",
                        column: x => x.ParentSubSkillId,
                        principalTable: "SubSkill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubSkill_WSOS",
                        column: x => x.WSOSId,
                        principalTable: "WSOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Expense",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseTypeId = table.Column<int>(type: "int", nullable: false),
                    UnitTypeId = table.Column<int>(type: "int", nullable: false),
                    TrainingId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    CostPerUnit = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expense_ExpenseType",
                        column: x => x.ExpenseTypeId,
                        principalTable: "ExpenseType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expense_Training",
                        column: x => x.TrainingId,
                        principalTable: "Training",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expense_UnitType",
                        column: x => x.UnitTypeId,
                        principalTable: "UnitType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Participant",
                columns: table => new
                {
                    TrainingId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => new { x.TrainingId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Participant_Training",
                        column: x => x.TrainingId,
                        principalTable: "Training",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Participant_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    HotelPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EarlyCheckInDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    LateCheckOutDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    CheckInDate = table.Column<DateTime>(type: "date", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "date", nullable: true),
                    UserDocumentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Request_Training",
                        column: x => x.TrainingId,
                        principalTable: "Training",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Request_User",
                        column: x => x.OwnerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Request_UserDocument",
                        column: x => x.UserDocumentId,
                        principalTable: "UserDocument",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingDay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    TrainingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingDay_Training",
                        column: x => x.TrainingId,
                        principalTable: "Training",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubSkillMark",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubSkillId = table.Column<int>(type: "int", nullable: false),
                    CompetitorId = table.Column<int>(type: "int", nullable: false),
                    Mark = table.Column<byte>(type: "tinyint", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubSkillMark", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubSkillMark_SubSkill",
                        column: x => x.SubSkillId,
                        principalTable: "SubSkill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubSkillMark_User",
                        column: x => x.CompetitorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubSkillTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttachmentPath = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SubSkilId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    TestProjectId = table.Column<int>(type: "int", nullable: false),
                    MaxScore = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubSkillTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubSkillTask_SubSkill",
                        column: x => x.SubSkilId,
                        principalTable: "SubSkill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubSkillTask_TestProject",
                        column: x => x.TestProjectId,
                        principalTable: "TestProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubSkillTask_User",
                        column: x => x.AuthorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RequestHotel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestHotel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestHotel_Request",
                        column: x => x.RequestId,
                        principalTable: "Request",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartureCityId = table.Column<int>(type: "int", nullable: false),
                    ArrivalCityId = table.Column<int>(type: "int", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsToTraining = table.Column<bool>(type: "bit", nullable: false),
                    IsRefund = table.Column<bool>(type: "bit", nullable: false),
                    DepartureDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ArrivalDateTim = table.Column<DateTime>(type: "datetime", nullable: false),
                    BaggageInfo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ExpensiveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_City",
                        column: x => x.DepartureCityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_City1",
                        column: x => x.ArrivalCityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_Expense",
                        column: x => x.ExpensiveId,
                        principalTable: "Expense",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_Request",
                        column: x => x.RequestId,
                        principalTable: "Request",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTrainingDay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingDayId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTrainingDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTrainingDay_TrainingDay",
                        column: x => x.TrainingDayId,
                        principalTable: "TrainingDay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserTrainingDay_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubSkillTaskResolving",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubSkillTaskId = table.Column<int>(type: "int", nullable: false),
                    CompetitorId = table.Column<int>(type: "int", nullable: false),
                    ResolvingDuration = table.Column<TimeSpan>(type: "time(0)", nullable: true),
                    Score = table.Column<byte>(type: "tinyint", nullable: true),
                    SolutionPath = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFullResolving = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubSkillTaskResolving", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubSkillTaskResolving_SubSkillTask",
                        column: x => x.SubSkillTaskId,
                        principalTable: "SubSkillTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubSkillTaskResolving_User",
                        column: x => x.CompetitorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_CatalogId",
                table: "Catalog",
                column: "CatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_UserId",
                table: "Catalog",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryId",
                table: "City",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_ExpenseTypeId",
                table: "Expense",
                column: "ExpenseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_TrainingId",
                table: "Expense",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_UnitTypeId",
                table: "Expense",
                column: "UnitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_File_CatalogId",
                table: "File",
                column: "CatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_UserId",
                table: "Participant",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_OwnerId",
                table: "Request",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_TrainingId",
                table: "Request",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_UserDocumentId",
                table: "Request",
                column: "UserDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestHotel_RequestId",
                table: "RequestHotel",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_InternationalExpertId",
                table: "Skill",
                column: "InternationalExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_SubSkill_ParentSubSkillId",
                table: "SubSkill",
                column: "ParentSubSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_SubSkill_WSOSId",
                table: "SubSkill",
                column: "WSOSId");

            migrationBuilder.CreateIndex(
                name: "IX_SubSkillMark_CompetitorId",
                table: "SubSkillMark",
                column: "CompetitorId");

            migrationBuilder.CreateIndex(
                name: "IX_SubSkillMark_SubSkillId",
                table: "SubSkillMark",
                column: "SubSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_SubSkillTask_AuthorId",
                table: "SubSkillTask",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_SubSkillTask_SubSkilId",
                table: "SubSkillTask",
                column: "SubSkilId");

            migrationBuilder.CreateIndex(
                name: "IX_SubSkillTask_TestProjectId",
                table: "SubSkillTask",
                column: "TestProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SubSkillTaskResolving_CompetitorId",
                table: "SubSkillTaskResolving",
                column: "CompetitorId");

            migrationBuilder.CreateIndex(
                name: "IX_SubSkillTaskResolving_SubSkillTaskId",
                table: "SubSkillTaskResolving",
                column: "SubSkillTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TestProjectSession_TestProjectId",
                table: "TestProjectSession",
                column: "TestProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_ArrivalCityId",
                table: "Ticket",
                column: "ArrivalCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_DepartureCityId",
                table: "Ticket",
                column: "DepartureCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_ExpensiveId",
                table: "Ticket",
                column: "ExpensiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_RequestId",
                table: "Ticket",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Training_SkillCode",
                table: "Training",
                column: "SkillCode");

            migrationBuilder.CreateIndex(
                name: "IX_Training_TrainingPlaceId",
                table: "Training",
                column: "TrainingPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingDay_TrainingId",
                table: "TrainingDay",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlace_CityId",
                table: "TrainingPlace",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDocument_DocumentTypeId",
                table: "UserDocument",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDocument_UserId",
                table: "UserDocument",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToken_UserId",
                table: "UserToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTrainingDay_TrainingDayId",
                table: "UserTrainingDay",
                column: "TrainingDayId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTrainingDay_UserId",
                table: "UserTrainingDay",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WSOS_SkillCode",
                table: "WSOS",
                column: "SkillCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "Participant");

            migrationBuilder.DropTable(
                name: "RequestHotel");

            migrationBuilder.DropTable(
                name: "SubSkillMark");

            migrationBuilder.DropTable(
                name: "SubSkillTaskResolving");

            migrationBuilder.DropTable(
                name: "TestProjectSession");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "UserTrainingDay");

            migrationBuilder.DropTable(
                name: "Catalog");

            migrationBuilder.DropTable(
                name: "SubSkillTask");

            migrationBuilder.DropTable(
                name: "Expense");

            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "TrainingDay");

            migrationBuilder.DropTable(
                name: "SubSkill");

            migrationBuilder.DropTable(
                name: "TestProject");

            migrationBuilder.DropTable(
                name: "ExpenseType");

            migrationBuilder.DropTable(
                name: "UnitType");

            migrationBuilder.DropTable(
                name: "UserDocument");

            migrationBuilder.DropTable(
                name: "Training");

            migrationBuilder.DropTable(
                name: "WSOS");

            migrationBuilder.DropTable(
                name: "DocumentType");

            migrationBuilder.DropTable(
                name: "TrainingPlace");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
