using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessConfigs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: false),
                    ConfigKey = table.Column<string>(type: "NVARCHAR(255)", nullable: true),
                    ConfigValue = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(64)", nullable: false),
                    IsEntrance = table.Column<bool>(type: "BIT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardFormats",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    Token = table.Column<string>(type: "VARCHAR(64)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(64)", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(64)", nullable: false),
                    BitLength = table.Column<int>(type: "int", nullable: false),
                    IsEnable = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardFormats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Controllers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    Token = table.Column<string>(type: "VARCHAR(64)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(64)", nullable: false),
                    UserName = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    MACAddress = table.Column<string>(type: "VARCHAR(17)", nullable: false),
                    OAK = table.Column<string>(type: "VARCHAR(75)", nullable: false),
                    IsOneDoor = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    IsDoor1Added = table.Column<bool>(type: "bit", nullable: false),
                    IsDoor2Added = table.Column<bool>(type: "bit", nullable: false),
                    Model = table.Column<string>(type: "VARCHAR(15)", nullable: false),
                    State = table.Column<string>(type: "VARCHAR(25)", nullable: false),
                    UUID = table.Column<string>(type: "VARCHAR(60)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Controllers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoorGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(64)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoorGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Priorities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(64)", nullable: true),
                    ColorCode = table.Column<string>(type: "NVARCHAR(10)", nullable: true),
                    PriortyLevel = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priorities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QUser",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    Token = table.Column<string>(type: "NVARCHAR(64)", nullable: false),
                    EmployeeId = table.Column<string>(type: "NVARCHAR(40)", nullable: true),
                    FirstName = table.Column<string>(type: "NVARCHAR(64)", nullable: false),
                    LastName = table.Column<string>(type: "NVARCHAR(64)", nullable: false),
                    MiddleName = table.Column<string>(type: "NVARCHAR(64)", nullable: true),
                    Email = table.Column<string>(type: "NVARCHAR(254)", nullable: true),
                    DepartmentName = table.Column<string>(type: "VARCHAR(64)", nullable: true),
                    CompanyName = table.Column<string>(type: "NVARCHAR(100)", nullable: true),
                    Gender = table.Column<string>(type: "VARCHAR(6)", nullable: true),
                    QUserType = table.Column<string>(type: "VARCHAR(64)", nullable: true),
                    Phone = table.Column<string>(type: "NVARCHAR(16)", nullable: true),
                    LastArea = table.Column<string>(type: "NVARCHAR(64)", nullable: true),
                    LastUse = table.Column<DateTime>(type: "DateTime", nullable: true),
                    Nationality = table.Column<string>(type: "NVARCHAR(100)", nullable: true),
                    LastLocation = table.Column<string>(type: "NVARCHAR(64)", nullable: true),
                    IsUnlockExtensionADA = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(64)", nullable: false),
                    Token = table.Column<string>(type: "NVARCHAR(64)", nullable: false),
                    IsSubtraction = table.Column<bool>(type: "BIT", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(128)", nullable: true),
                    Definition = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardFormatsItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardFormatId = table.Column<long>(type: "bigint", nullable: false),
                    CardFormatItemName = table.Column<string>(type: "NVARCHAR(64)", nullable: false),
                    EncodingRange = table.Column<string>(type: "VARCHAR(21)", nullable: false),
                    Encoding = table.Column<string>(type: "VARCHAR(13)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardFormatsItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardFormatsItems_CardFormats_CardFormatId",
                        column: x => x.CardFormatId,
                        principalTable: "CardFormats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ControllerDateTime",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    ControllerId = table.Column<long>(type: "bigint", nullable: false),
                    TimeZoneValue = table.Column<string>(type: "NVARCHAR(60)", nullable: false),
                    DayLightSaving = table.Column<bool>(type: "bit", nullable: false),
                    SetMode = table.Column<string>(type: "NVARCHAR(6)", nullable: false),
                    DHCP = table.Column<string>(type: "NVARCHAR(39)", nullable: true),
                    IPAddress = table.Column<string>(type: "NVARCHAR(39)", nullable: true),
                    Date = table.Column<string>(type: "NVARCHAR(12)", nullable: true),
                    Time = table.Column<string>(type: "NVARCHAR(10)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControllerDateTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControllerDateTime_Controllers_ControllerId",
                        column: x => x.ControllerId,
                        principalTable: "Controllers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ControllerIOPorts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    ControllerId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(64)", nullable: false),
                    PortType = table.Column<string>(type: "NVARCHAR(7)", nullable: false),
                    State = table.Column<string>(type: "NVARCHAR(18)", nullable: false),
                    Status = table.Column<string>(type: "NVARCHAR(64)", nullable: true),
                    IONumber = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControllerIOPorts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControllerIOPorts_Controllers_ControllerId",
                        column: x => x.ControllerId,
                        principalTable: "Controllers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    Token = table.Column<string>(type: "NVARCHAR(64)", nullable: false),
                    ControllerId = table.Column<long>(type: "bigint", nullable: false),
                    Lock = table.Column<string>(type: "NVARCHAR(15)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(64)", nullable: false),
                    DoorState = table.Column<string>(type: "NVARCHAR(15)", nullable: false),
                    DoorType = table.Column<string>(type: "NVARCHAR(15)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doors_Controllers_ControllerId",
                        column: x => x.ControllerId,
                        principalTable: "Controllers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    Token = table.Column<string>(type: "NVARCHAR(64)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(255)", nullable: true),
                    IsEnable = table.Column<bool>(type: "bit", nullable: true),
                    IsAntiPassBack = table.Column<bool>(type: "bit", nullable: true),
                    CardNumber = table.Column<string>(type: "NVARCHAR(255)", nullable: true),
                    CardRaw = table.Column<string>(type: "NVARCHAR(255)", nullable: true),
                    Pin = table.Column<string>(type: "NVARCHAR(10)", nullable: true),
                    FacilityCode = table.Column<int>(type: "int ", nullable: true),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QUserId = table.Column<long>(type: "bigint", nullable: false),
                    LastAccessDoorId = table.Column<long>(type: "bigint", nullable: true),
                    LastAccessAreaId = table.Column<long>(type: "bigint", nullable: true),
                    DoNotExpire = table.Column<bool>(type: "bit", nullable: true),
                    CardStatus = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    IsCard = table.Column<bool>(type: "bit", nullable: true),
                    LpnNumber = table.Column<string>(type: "NVARCHAR(255)", nullable: true),
                    IsAdOverride = table.Column<bool>(type: "bit", nullable: false),
                    IsFacial = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_QUser_QUserId",
                        column: x => x.QUserId,
                        principalTable: "QUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QUserFiles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    QUserId = table.Column<long>(type: "bigint", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ImageData = table.Column<byte[]>(type: "VARBINARY(MAX)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QUserFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QUserFiles_QUser_QUserId",
                        column: x => x.QUserId,
                        principalTable: "QUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessLevels",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    DuringScheduleId = table.Column<long>(type: "bigint", nullable: false),
                    ExceptScheduleId = table.Column<long>(type: "bigint", nullable: true),
                    Token = table.Column<string>(type: "NVARCHAR(64)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(64)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessLevels_Schedules_DuringScheduleId",
                        column: x => x.DuringScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccessLevels_Schedules_ExceptScheduleId",
                        column: x => x.ExceptScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ScheduleItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleId = table.Column<long>(type: "BIGINT", nullable: false),
                    Summary = table.Column<string>(type: "NVARCHAR(64)", nullable: false),
                    ItemDefinition = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    StartTime = table.Column<string>(type: "NVARCHAR(5)", nullable: true),
                    EndTime = table.Column<string>(type: "NVARCHAR(5)", nullable: true),
                    RecurrenceDays = table.Column<string>(type: "NVARCHAR(40)", nullable: true),
                    IsAllDay = table.Column<bool>(type: "BIT", nullable: false),
                    IsWeekly = table.Column<bool>(type: "BIT", nullable: false),
                    IsRecurrence = table.Column<bool>(type: "BIT", nullable: false),
                    IsEndBy = table.Column<bool>(type: "BIT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    EndDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    EndBy = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleItems_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoorAdvanceConfigurations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoorId = table.Column<long>(type: "bigint", nullable: false),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    DuringScheduleId = table.Column<long>(type: "bigint", nullable: true),
                    UnlockScheduleId = table.Column<long>(type: "bigint", nullable: true),
                    IsDoorMonitor = table.Column<bool>(type: "bit", nullable: false),
                    IsLockMonitor = table.Column<bool>(type: "bit", nullable: false),
                    AccessTime = table.Column<int>(type: "int", nullable: false),
                    LongAccessTime = table.Column<int>(type: "int", nullable: false),
                    LockWhenLocked = table.Column<string>(type: "VARCHAR(5)", nullable: false),
                    LockWhenUnlocked = table.Column<string>(type: "VARCHAR(5)", nullable: false),
                    RelayStateLocked = table.Column<string>(type: "VARCHAR(8)", nullable: false),
                    BoltInTime = table.Column<int>(type: "int", nullable: false),
                    BoltOutTime = table.Column<int>(type: "int", nullable: false),
                    IsAntiPassback = table.Column<bool>(type: "bit", nullable: false),
                    AntipassbackMode = table.Column<string>(type: "VARCHAR(15)", nullable: true),
                    AntiPassbackEnforcementMode = table.Column<string>(type: "VARCHAR(10)", nullable: true),
                    AntiPassbackTimeout = table.Column<int>(type: "int", nullable: true),
                    LockMonitor = table.Column<int>(type: "int", nullable: true),
                    LockType = table.Column<int>(type: "int", nullable: true),
                    DoorMonitor = table.Column<string>(type: "NVARCHAR(30)", nullable: true),
                    CancelAccessTimeOnceDoorIsOpened = table.Column<bool>(type: "bit", nullable: true),
                    EnableSupervisedInputs = table.Column<bool>(type: "bit", nullable: true),
                    OpenTooLongTime = table.Column<int>(type: "int", nullable: true),
                    PreAlarmTime = table.Column<int>(type: "int", nullable: true),
                    RelockTime = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoorAdvanceConfigurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoorAdvanceConfigurations_Doors_DoorId",
                        column: x => x.DoorId,
                        principalTable: "Doors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoorAdvanceConfigurations_Schedules_DuringScheduleId",
                        column: x => x.DuringScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DoorAdvanceConfigurations_Schedules_UnlockScheduleId",
                        column: x => x.UnlockScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DoorGroupDoors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    DoorId = table.Column<long>(type: "BIGINT", nullable: false),
                    DoorGroupId = table.Column<long>(type: "BIGINT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoorGroupDoors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoorGroupDoors_DoorGroups_DoorGroupId",
                        column: x => x.DoorGroupId,
                        principalTable: "DoorGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoorGroupDoors_Doors_DoorId",
                        column: x => x.DoorId,
                        principalTable: "Doors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Readers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    Token = table.Column<string>(type: "NVARCHAR(64)", nullable: false),
                    DoorId = table.Column<long>(type: "bigint", nullable: false),
                    ControllerId = table.Column<long>(type: "bigint", nullable: false),
                    ReaderType = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(45)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(60)", nullable: false),
                    Protocol = table.Column<string>(type: "VARCHAR(15)", nullable: false),
                    LEDType = table.Column<string>(type: "VARCHAR(15)", nullable: true),
                    AreaInId = table.Column<long>(type: "bigint", nullable: true),
                    AreaOutId = table.Column<long>(type: "bigint", nullable: true),
                    Location = table.Column<string>(type: "NVARCHAR(60)", nullable: false),
                    HeartbeatInterval = table.Column<int>(type: "int", nullable: false),
                    Timeout = table.Column<int>(type: "int", nullable: false),
                    LPNCameraSN = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    IsTimeAttendance = table.Column<bool>(type: "bit", nullable: false),
                    IsEnrollmentReader = table.Column<bool>(type: "bit", nullable: false),
                    LEDActiveLevel = table.Column<int>(type: "int", nullable: false),
                    TamperingType = table.Column<int>(type: "int", nullable: false),
                    BeeperType = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Readers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Readers_Areas_AreaInId",
                        column: x => x.AreaInId,
                        principalTable: "Areas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Readers_Areas_AreaOutId",
                        column: x => x.AreaOutId,
                        principalTable: "Areas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Readers_Doors_DoorId",
                        column: x => x.DoorId,
                        principalTable: "Doors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rexes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RexConnection = table.Column<string>(type: "VARCHAR(15)", nullable: false),
                    IsRexNotUnlockDoor = table.Column<bool>(type: "bit", nullable: false),
                    RexType = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    RexDuringScheduleId = table.Column<long>(type: "bigint", nullable: false),
                    RexExceptScheduleId = table.Column<long>(type: "bigint", nullable: true),
                    DoorId = table.Column<long>(type: "bigint", nullable: false),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rexes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rexes_Doors_DoorId",
                        column: x => x.DoorId,
                        principalTable: "Doors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rexes_Schedules_RexDuringScheduleId",
                        column: x => x.RexDuringScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rexes_Schedules_RexExceptScheduleId",
                        column: x => x.RexExceptScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccessLevelDoors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    AccessLevelId = table.Column<long>(type: "bigint", nullable: false),
                    DoorId = table.Column<long>(type: "bigint", nullable: false),
                    DuringScheduleId = table.Column<long>(type: "bigint", nullable: false),
                    ExceptScheduleId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessLevelDoors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessLevelDoors_AccessLevels_AccessLevelId",
                        column: x => x.AccessLevelId,
                        principalTable: "AccessLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessLevelDoors_Doors_DoorId",
                        column: x => x.DoorId,
                        principalTable: "Doors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessLevelDoors_Schedules_DuringScheduleId",
                        column: x => x.DuringScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccessLevelDoors_Schedules_ExceptScheduleId",
                        column: x => x.ExceptScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QUserAccessLevels",
                columns: table => new
                {
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessLevelId = table.Column<long>(type: "bigint", nullable: false),
                    QUserId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QUserAccessLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QUserAccessLevels_AccessLevels_AccessLevelId",
                        column: x => x.AccessLevelId,
                        principalTable: "AccessLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QUserAccessLevels_QUser_QUserId",
                        column: x => x.QUserId,
                        principalTable: "QUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReaderIdentificationTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ControllerId = table.Column<long>(type: "bigint", nullable: false),
                    ReaderId = table.Column<long>(type: "bigint", nullable: false),
                    IdentificationType = table.Column<string>(type: "VARCHAR(25)", nullable: false),
                    DuringScheduleId = table.Column<long>(type: "bigint", nullable: true),
                    ExceptScheduleId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReaderIdentificationTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReaderIdentificationTypes_Readers_ReaderId",
                        column: x => x.ReaderId,
                        principalTable: "Readers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReaderIdentificationTypes_Schedules_DuringScheduleId",
                        column: x => x.DuringScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReaderIdentificationTypes_Schedules_ExceptScheduleId",
                        column: x => x.ExceptScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AccessConfigs",
                columns: new[] { "Id", "ConfigKey", "ConfigValue", "CreatedDate", "LastModifiedDate", "OrganizationId", "ParentId" },
                values: new object[,]
                {
                    { 1L, "03C_SETTINGS", "O3C Settings", null, null, 1L, 0L },
                    { 2L, "O3C_USERNAME", "", null, null, 1L, 1L },
                    { 3L, "O3C_PASSWORD", "", null, null, 1L, 1L },
                    { 4L, "O3C_DISPATCHER_URL", "", null, null, 1L, 1L },
                    { 5L, "O3C_PROTOCOL_TYPE", "", null, null, 1L, 1L },
                    { 6L, "O3C_SERVER", "", null, null, 1L, 1L }
                });

            migrationBuilder.InsertData(
                table: "CardFormats",
                columns: new[] { "Id", "BitLength", "CreatedDate", "Description", "IsEnable", "LastModifiedDate", "Name", "OrganizationId", "Token" },
                values: new object[,]
                {
                    { 1L, 26, null, "Standard 26-bit Wiegand (H10301)", true, null, "Wiegand 26-bit (H10301)", 1L, "iddataconf_wiegand_26bit_h10301" },
                    { 2L, 32, null, "32-bit raw card data", true, null, "32-bit Card Data", 1L, "iddataconf_32bit_card_data" },
                    { 3L, 34, null, "Standard 34-bit Wiegand", true, null, "Wiegand 34-bit", 1L, "iddataconf_wiegand_34bit" },
                    { 4L, 37, null, "Standard 37-bit Wiegand (H10302)", true, null, "Wiegand 37-bit (H10302)", 1L, "iddataconf_wiegand_37bit_h10302" },
                    { 5L, 37, null, "Standard 37-bit Wiegand with facility code (H10304)", true, null, "Wiegand 37-bit with facility code (H10304)", 1L, "iddataconf_wiegand_37bit_h10304" },
                    { 6L, 80, null, "80-bit SmartIntego Card Data", true, null, "80-bit SmartIntego", 1L, "iddataconf_smartintego_80bit" },
                    { 7L, 56, null, "56-bit raw card data", true, null, "56-bit Card Data", 1L, "iddataconf_56bit_card_data" }
                });

            migrationBuilder.InsertData(
                table: "Priorities",
                columns: new[] { "Id", "ColorCode", "CreatedDate", "LastModifiedDate", "Name", "OrganizationId", "PriortyLevel" },
                values: new object[,]
                {
                    { 1L, "#FF0000", null, null, "High", -1L, null },
                    { 2L, "#FFFF00", null, null, "Medium", -1L, null },
                    { 3L, "#00FF00", null, null, "Low", -1L, null },
                    { 4L, "#000000", null, null, "None", -1L, null }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "CreatedDate", "Definition", "Description", "IsSubtraction", "LastModifiedDate", "Name", "OrganizationId", "Token" },
                values: new object[,]
                {
                    { 1L, null, null, "Always active (standard schedule)", false, null, "Always", -1L, "standard_always" },
                    { 2L, null, null, "Example office hours (9AM to 5PM)", false, null, "Office Hours", -1L, "standard_office_hours" },
                    { 3L, null, null, "Example weekend time incl. friday evening", false, null, "Weekends", -1L, "standard_weekends" },
                    { 4L, null, null, "Example after hours (5PM to 9AM) incl. weekends", false, null, "After Hours", -1L, "standard_after_hours" }
                });

            migrationBuilder.InsertData(
                table: "CardFormatsItems",
                columns: new[] { "Id", "CardFormatId", "CreatedDate", "Encoding", "EncodingRange", "LastModifiedDate", "CardFormatItemName" },
                values: new object[,]
                {
                    { 1L, 1L, null, "BinLE2Int", "1", null, "EvenParity" },
                    { 2L, 1L, null, "BinLE2Int", "2-9", null, "FacilityCode" },
                    { 3L, 1L, null, "BinLE2Int", "10-25", null, "CardNr" },
                    { 4L, 1L, null, "BinLE2hex", "10-25", null, "CardNrHex" },
                    { 5L, 1L, null, "BinLE2Int", "26", null, "OddParity" },
                    { 6L, 2L, null, "BinLE2Int", "1-32", null, "CardNr" },
                    { 7L, 2L, null, "BinLE2hex", "1-32", null, "CardNrHex" },
                    { 8L, 3L, null, "BinLE2Int", "1", null, "EvenParity" },
                    { 9L, 3L, null, "BinLE2Int", "2-17", null, "FacilityCode" },
                    { 10L, 3L, null, "BinLE2Int", "18-33", null, "CardNr" },
                    { 11L, 3L, null, "BinLE2hex", "18-33", null, "CardNrHex" },
                    { 12L, 3L, null, "BinLE2Int", "34", null, "OddParity" },
                    { 13L, 4L, null, "BinLE2Int", "1", null, "EvenParity" },
                    { 14L, 4L, null, "BinLE2Int", "2-36", null, "CardNr" },
                    { 15L, 4L, null, "BinLE2hex", "2-36", null, "CardNrHex" },
                    { 16L, 4L, null, "BinLE2Int", "37", null, "OddParity" },
                    { 17L, 5L, null, "BinLE2Int", "1", null, "EvenParity" },
                    { 18L, 5L, null, "BinLE2Int", "2-17", null, "FacilityCode" },
                    { 19L, 5L, null, "BinLE2Int", "18-36", null, "CardNr" },
                    { 20L, 5L, null, "BinLE2hex", "18-36", null, "CardNrHex" },
                    { 21L, 5L, null, "BinLE2Int", "37", null, "OddParity" },
                    { 22L, 6L, null, "BinLE2Int", "17-80", null, "CardNr" },
                    { 23L, 6L, null, "BinLE2hex", "17-80", null, "CardNrHex" },
                    { 24L, 7L, null, "BinLE2Int", "1-56", null, "CardNr" },
                    { 25L, 7L, null, "BinLE2hex", "1-56", null, "CardNrHex" },
                    { 26L, 1L, null, "BinLE2Int", "1", null, "OddParity" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessLevelDoors_AccessLevelId",
                table: "AccessLevelDoors",
                column: "AccessLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessLevelDoors_DoorId",
                table: "AccessLevelDoors",
                column: "DoorId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessLevelDoors_DuringScheduleId",
                table: "AccessLevelDoors",
                column: "DuringScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessLevelDoors_ExceptScheduleId",
                table: "AccessLevelDoors",
                column: "ExceptScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessLevels_DuringScheduleId",
                table: "AccessLevels",
                column: "DuringScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessLevels_ExceptScheduleId",
                table: "AccessLevels",
                column: "ExceptScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_CardFormats_OrganizationId_Name",
                table: "CardFormats",
                columns: new[] { "OrganizationId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CardFormatsItems_CardFormatId",
                table: "CardFormatsItems",
                column: "CardFormatId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_QUserId",
                table: "Cards",
                column: "QUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ControllerDateTime_ControllerId",
                table: "ControllerDateTime",
                column: "ControllerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ControllerDateTime_OrganizationId",
                table: "ControllerDateTime",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ControllerIOPorts_ControllerId",
                table: "ControllerIOPorts",
                column: "ControllerId");

            migrationBuilder.CreateIndex(
                name: "IX_Controllers_OrganizationId_Name",
                table: "Controllers",
                columns: new[] { "OrganizationId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DoorAdvanceConfigurations_DoorId",
                table: "DoorAdvanceConfigurations",
                column: "DoorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DoorAdvanceConfigurations_DuringScheduleId",
                table: "DoorAdvanceConfigurations",
                column: "DuringScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_DoorAdvanceConfigurations_Id",
                table: "DoorAdvanceConfigurations",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DoorAdvanceConfigurations_UnlockScheduleId",
                table: "DoorAdvanceConfigurations",
                column: "UnlockScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_DoorGroupDoors_DoorGroupId",
                table: "DoorGroupDoors",
                column: "DoorGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_DoorGroupDoors_DoorId",
                table: "DoorGroupDoors",
                column: "DoorId");

            migrationBuilder.CreateIndex(
                name: "IX_Doors_ControllerId",
                table: "Doors",
                column: "ControllerId");

            migrationBuilder.CreateIndex(
                name: "IX_QUserAccessLevels_AccessLevelId",
                table: "QUserAccessLevels",
                column: "AccessLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_QUserAccessLevels_QUserId",
                table: "QUserAccessLevels",
                column: "QUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QUserFiles_QUserId",
                table: "QUserFiles",
                column: "QUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReaderIdentificationTypes_DuringScheduleId",
                table: "ReaderIdentificationTypes",
                column: "DuringScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ReaderIdentificationTypes_ExceptScheduleId",
                table: "ReaderIdentificationTypes",
                column: "ExceptScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ReaderIdentificationTypes_ReaderId",
                table: "ReaderIdentificationTypes",
                column: "ReaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Readers_AreaInId",
                table: "Readers",
                column: "AreaInId",
                unique: true,
                filter: "[AreaInId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Readers_AreaOutId",
                table: "Readers",
                column: "AreaOutId",
                unique: true,
                filter: "[AreaOutId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Readers_DoorId",
                table: "Readers",
                column: "DoorId");

            migrationBuilder.CreateIndex(
                name: "IX_Rexes_DoorId",
                table: "Rexes",
                column: "DoorId");

            migrationBuilder.CreateIndex(
                name: "IX_Rexes_RexDuringScheduleId",
                table: "Rexes",
                column: "RexDuringScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Rexes_RexExceptScheduleId",
                table: "Rexes",
                column: "RexExceptScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleItems_ScheduleId",
                table: "ScheduleItems",
                column: "ScheduleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessConfigs");

            migrationBuilder.DropTable(
                name: "AccessLevelDoors");

            migrationBuilder.DropTable(
                name: "CardFormatsItems");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "ControllerDateTime");

            migrationBuilder.DropTable(
                name: "ControllerIOPorts");

            migrationBuilder.DropTable(
                name: "DoorAdvanceConfigurations");

            migrationBuilder.DropTable(
                name: "DoorGroupDoors");

            migrationBuilder.DropTable(
                name: "Priorities");

            migrationBuilder.DropTable(
                name: "QUserAccessLevels");

            migrationBuilder.DropTable(
                name: "QUserFiles");

            migrationBuilder.DropTable(
                name: "ReaderIdentificationTypes");

            migrationBuilder.DropTable(
                name: "Rexes");

            migrationBuilder.DropTable(
                name: "ScheduleItems");

            migrationBuilder.DropTable(
                name: "CardFormats");

            migrationBuilder.DropTable(
                name: "DoorGroups");

            migrationBuilder.DropTable(
                name: "AccessLevels");

            migrationBuilder.DropTable(
                name: "QUser");

            migrationBuilder.DropTable(
                name: "Readers");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Doors");

            migrationBuilder.DropTable(
                name: "Controllers");
        }
    }
}
