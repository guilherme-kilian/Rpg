using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rpg.Infra.Migrations
{
    /// <inheritdoc />
    public partial class modelig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArmorType",
                table: "CharacterTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "CanUseMagic",
                table: "CharacterTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "CharacterTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "discriminator",
                table: "CharacterTypes",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Characters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AdventureId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AttributeId",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BackHistory",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BattleId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentHealth",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Experience",
                table: "Characters",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxHealth",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Player_TypeId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "discriminator",
                table: "Characters",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AdventureConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InitialLevel = table.Column<int>(type: "int", nullable: false),
                    AttributePointsPerLevel = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdventureConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharacterAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intelligence = table.Column<int>(type: "int", nullable: false),
                    Charisma = table.Column<int>(type: "int", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Dexterity = table.Column<int>(type: "int", nullable: false),
                    Constitution = table.Column<int>(type: "int", nullable: false),
                    Agility = table.Column<int>(type: "int", nullable: false),
                    Luck = table.Column<int>(type: "int", nullable: false),
                    Critical = table.Column<int>(type: "int", nullable: false),
                    Resistance = table.Column<int>(type: "int", nullable: false),
                    HealthPoints = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    Wisdom = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterAttributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Adventures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MasterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConfigurationId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adventures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adventures_AdventureConfigs_ConfigurationId",
                        column: x => x.ConfigurationId,
                        principalTable: "AdventureConfigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adventures_Users_MasterId",
                        column: x => x.MasterId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Battles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdventureId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Battles_Adventures_AdventureId",
                        column: x => x.AdventureId,
                        principalTable: "Adventures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BattleStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BattleId = table.Column<int>(type: "int", nullable: false),
                    TotalDamage = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BattleStatistics_Battles_BattleId",
                        column: x => x.BattleId,
                        principalTable: "Battles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    BattleStatisticId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterStatistics_BattleStatistics_BattleStatisticId",
                        column: x => x.BattleStatisticId,
                        principalTable: "BattleStatistics",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharacterStatistics_Characters_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_AdventureId",
                table: "Characters",
                column: "AdventureId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_AttributeId",
                table: "Characters",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_BattleId",
                table: "Characters",
                column: "BattleId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_Player_TypeId",
                table: "Characters",
                column: "Player_TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Adventures_ConfigurationId",
                table: "Adventures",
                column: "ConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_Adventures_MasterId",
                table: "Adventures",
                column: "MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Battles_AdventureId",
                table: "Battles",
                column: "AdventureId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleStatistics_BattleId",
                table: "BattleStatistics",
                column: "BattleId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterStatistics_BattleStatisticId",
                table: "CharacterStatistics",
                column: "BattleStatisticId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterStatistics_PlayerId",
                table: "CharacterStatistics",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Adventures_AdventureId",
                table: "Characters",
                column: "AdventureId",
                principalTable: "Adventures",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Battles_BattleId",
                table: "Characters",
                column: "BattleId",
                principalTable: "Battles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_CharacterAttributes_AttributeId",
                table: "Characters",
                column: "AttributeId",
                principalTable: "CharacterAttributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_CharacterTypes_Player_TypeId",
                table: "Characters",
                column: "Player_TypeId",
                principalTable: "CharacterTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Adventures_AdventureId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Battles_BattleId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_CharacterAttributes_AttributeId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_CharacterTypes_Player_TypeId",
                table: "Characters");

            migrationBuilder.DropTable(
                name: "CharacterAttributes");

            migrationBuilder.DropTable(
                name: "CharacterStatistics");

            migrationBuilder.DropTable(
                name: "BattleStatistics");

            migrationBuilder.DropTable(
                name: "Battles");

            migrationBuilder.DropTable(
                name: "Adventures");

            migrationBuilder.DropTable(
                name: "AdventureConfigs");

            migrationBuilder.DropIndex(
                name: "IX_Characters_AdventureId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_AttributeId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_BattleId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_Player_TypeId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "ArmorType",
                table: "CharacterTypes");

            migrationBuilder.DropColumn(
                name: "CanUseMagic",
                table: "CharacterTypes");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "CharacterTypes");

            migrationBuilder.DropColumn(
                name: "discriminator",
                table: "CharacterTypes");

            migrationBuilder.DropColumn(
                name: "AdventureId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "AttributeId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "BackHistory",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "BattleId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "CurrentHealth",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "MaxHealth",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Player_TypeId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "discriminator",
                table: "Characters");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
