using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClinicAppointments.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctors", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    document = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    date_born = table.Column<DateOnly>(type: "date", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "specialties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specialties", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    doctor_id = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_doctors_doctor_id",
                        column: x => x.doctor_id,
                        principalTable: "doctors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_users_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    reason = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    notes = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    patient_id = table.Column<int>(type: "int", nullable: false),
                    doctor_id = table.Column<int>(type: "int", nullable: false),
                    specialty_id = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_appointments_doctors_doctor_id",
                        column: x => x.doctor_id,
                        principalTable: "doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointments_patients_patient_id",
                        column: x => x.patient_id,
                        principalTable: "patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointments_specialties_specialty_id",
                        column: x => x.specialty_id,
                        principalTable: "specialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "doctor_specialties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    doctor_id = table.Column<int>(type: "int", nullable: false),
                    specialty_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctor_specialties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_doctor_specialties_doctors_doctor_id",
                        column: x => x.doctor_id,
                        principalTable: "doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_doctor_specialties_specialties_specialty_id",
                        column: x => x.specialty_id,
                        principalTable: "specialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "appointment_histories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    appointment_id = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    action = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    remarks = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointment_histories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_appointment_histories_appointments_appointment_id",
                        column: x => x.appointment_id,
                        principalTable: "appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "doctors",
                columns: new[] { "Id", "created_at", "email", "name", "phone" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2024, 11, 15, 17, 30, 49, 38, DateTimeKind.Unspecified).AddTicks(8076), new TimeSpan(0, 0, 0, 0, 0)), "johndoe@gmail.com", "Dr. John Doe", "123456789" },
                    { 2, new DateTimeOffset(new DateTime(2024, 11, 15, 17, 30, 49, 38, DateTimeKind.Unspecified).AddTicks(8080), new TimeSpan(0, 0, 0, 0, 0)), "janedoe@gmail.com", "Dr. Jane Doe", "987654321" },
                    { 3, new DateTimeOffset(new DateTime(2024, 11, 15, 17, 30, 49, 38, DateTimeKind.Unspecified).AddTicks(8081), new TimeSpan(0, 0, 0, 0, 0)), "marydoe@gmail.com", "Dr. Mary Doe", "876543210" },
                    { 4, new DateTimeOffset(new DateTime(2024, 11, 15, 17, 30, 49, 38, DateTimeKind.Unspecified).AddTicks(8082), new TimeSpan(0, 0, 0, 0, 0)), "peterdoe@gmail.com", "Dr. Peter Doe", "765432198" }
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "Id", "address", "created_at", "date_born", "document", "name", "phone" },
                values: new object[,]
                {
                    { 1, "123 Main St", new DateTimeOffset(new DateTime(2024, 11, 15, 17, 30, 49, 38, DateTimeKind.Unspecified).AddTicks(8149), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(1985, 5, 20), "123456789", "John Doe", "987654321" },
                    { 2, "456 Main St", new DateTimeOffset(new DateTime(2024, 11, 15, 17, 30, 49, 38, DateTimeKind.Unspecified).AddTicks(8159), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(1990, 8, 15), "876543210", "Jane Doe", "765432198" },
                    { 3, "789 Main St", new DateTimeOffset(new DateTime(2024, 11, 15, 17, 30, 49, 38, DateTimeKind.Unspecified).AddTicks(8161), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(1982, 3, 10), "654321987", "Mary Doe", "543219876" },
                    { 4, "1011 Main St", new DateTimeOffset(new DateTime(2024, 11, 15, 17, 30, 49, 38, DateTimeKind.Unspecified).AddTicks(8162), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(1975, 11, 30), "543219876", "Peter Doe", "432198765" },
                    { 5, "123 Main St", new DateTimeOffset(new DateTime(2024, 11, 15, 17, 30, 49, 38, DateTimeKind.Unspecified).AddTicks(8163), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(1985, 5, 20), "123456789", "John Doe", "987654321" }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "description", "name" },
                values: new object[,]
                {
                    { 1, "Admin Role", "Admin" },
                    { 2, "Employee Role", "Employee" },
                    { 3, "User Role", "User" }
                });

            migrationBuilder.InsertData(
                table: "specialties",
                columns: new[] { "Id", "description", "name" },
                values: new object[,]
                {
                    { 1, "Cardiology", "Cardiology" },
                    { 2, "Dermatology", "Dermatology" },
                    { 3, "Gastroenterology", "Gastroenterology" },
                    { 4, "General Surgery", "General Surgery" },
                    { 5, "Neurology", "Neurology" },
                    { 6, "Pediatrics", "Pediatrics" },
                    { 7, "Plastic Surgery", "Plastic Surgery" },
                    { 8, "Psychiatry", "Psychiatry" },
                    { 9, "Urology", "Urology" }
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "Id", "created_at", "date", "doctor_id", "notes", "patient_id", "reason", "specialty_id", "status" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2024, 11, 15, 17, 30, 49, 38, DateTimeKind.Unspecified).AddTicks(8193), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2024, 11, 10), 1, "Chequeo inicial", 1, "Consulta de Oncología", 1, "Pendiente" },
                    { 2, new DateTimeOffset(new DateTime(2024, 11, 15, 17, 30, 49, 38, DateTimeKind.Unspecified).AddTicks(8199), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2024, 11, 12), 2, "Prevención", 2, "Consulta Cardiológica", 2, "Confirmada" },
                    { 3, new DateTimeOffset(new DateTime(2024, 11, 15, 17, 30, 49, 38, DateTimeKind.Unspecified).AddTicks(8201), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2024, 11, 15), 3, "Dolor de cabeza recurrente", 3, "Consulta Neurológica", 3, "Pendiente" },
                    { 4, new DateTimeOffset(new DateTime(2024, 11, 15, 17, 30, 49, 38, DateTimeKind.Unspecified).AddTicks(8202), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2024, 11, 5), 4, "Revisión general", 4, "Consulta Pediátrica", 4, "Cancelada" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "created_at", "doctor_id", "email", "name", "password", "role_id" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2024, 11, 15, 17, 30, 49, 38, DateTimeKind.Unspecified).AddTicks(8308), new TimeSpan(0, 0, 0, 0, 0)), 1, "admin@admin.com", "Admin", "$2a$11$bNC51utE3yB.x8PR.rwC4O6i2pr4DBlhFJINEfqPLeWFt1HiJVNnO", 1 },
                    { 2, new DateTimeOffset(new DateTime(2024, 11, 15, 17, 30, 49, 142, DateTimeKind.Unspecified).AddTicks(6011), new TimeSpan(0, 0, 0, 0, 0)), null, "receptionistNicolas@receptionist.com", "Receptionist Nicolas", "$2a$11$dHwu6YYyMmStZglnCNwUzuf4gnhjyfR3K88kj.OL4WLQolRvKtn4W", 2 },
                    { 3, new DateTimeOffset(new DateTime(2024, 11, 15, 17, 30, 49, 249, DateTimeKind.Unspecified).AddTicks(4350), new TimeSpan(0, 0, 0, 0, 0)), null, "receptionistJavier@receptionist.com", "Receptionist Javier", "$2a$11$Ax5HIFDl7fL87nskwcJw0ufXLQ5K/UyhLfIsdwIF6bOvCnweMUcxi", 2 },
                    { 4, new DateTimeOffset(new DateTime(2024, 11, 15, 17, 30, 49, 357, DateTimeKind.Unspecified).AddTicks(1159), new TimeSpan(0, 0, 0, 0, 0)), null, "receptionistMariana@receptionist.com", "Receptionist Mariana", "$2a$11$V0smBi8CrW31sxS8F8/HW.MXcPdm2lEImwWVZOLjh.2lsLiMdEmpm", 2 },
                    { 5, new DateTimeOffset(new DateTime(2024, 11, 15, 17, 30, 49, 461, DateTimeKind.Unspecified).AddTicks(8529), new TimeSpan(0, 0, 0, 0, 0)), null, "receptionistJhon@receptionist.com", "Receptionist Jhon", "$2a$11$NT2tLoGyTijt4Otro.aMC.psC2e2TkyhIhbA1KEw6M6YrI0KcrRwO", 2 }
                });

            migrationBuilder.InsertData(
                table: "appointment_histories",
                columns: new[] { "Id", "action", "appointment_id", "created_at", "date", "remarks" },
                values: new object[,]
                {
                    { 1, "Consulta", 1, new DateTimeOffset(new DateTime(2024, 11, 15, 17, 30, 49, 38, DateTimeKind.Unspecified).AddTicks(8246), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2024, 11, 14), "Estoy muy enfermo" },
                    { 2, "Consulta", 1, new DateTimeOffset(new DateTime(2024, 11, 15, 17, 30, 49, 38, DateTimeKind.Unspecified).AddTicks(8250), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2024, 11, 13), "Estoy muy enfermo" },
                    { 3, "Consulta", 1, new DateTimeOffset(new DateTime(2024, 11, 15, 17, 30, 49, 38, DateTimeKind.Unspecified).AddTicks(8252), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2024, 11, 18), "Dolor constante de cabeza" },
                    { 4, "Consulta", 1, new DateTimeOffset(new DateTime(2024, 11, 15, 17, 30, 49, 38, DateTimeKind.Unspecified).AddTicks(8257), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2024, 11, 25), "Chequeo general" },
                    { 5, "Consulta", 2, new DateTimeOffset(new DateTime(2024, 11, 15, 17, 30, 49, 38, DateTimeKind.Unspecified).AddTicks(8259), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2024, 11, 11), "Problemas respiratorios" },
                    { 6, "Consulta", 2, new DateTimeOffset(new DateTime(2024, 11, 15, 17, 30, 49, 38, DateTimeKind.Unspecified).AddTicks(8261), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2024, 11, 20), "Prevención" },
                    { 7, "Consulta", 2, new DateTimeOffset(new DateTime(2024, 11, 15, 17, 30, 49, 38, DateTimeKind.Unspecified).AddTicks(8265), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2024, 11, 22), "Visión borrosa" },
                    { 8, "Consulta", 3, new DateTimeOffset(new DateTime(2024, 11, 15, 17, 30, 49, 38, DateTimeKind.Unspecified).AddTicks(8266), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2024, 11, 12), "Sin complicaciones" },
                    { 9, "Consulta", 3, new DateTimeOffset(new DateTime(2024, 11, 15, 17, 30, 49, 38, DateTimeKind.Unspecified).AddTicks(8268), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2024, 11, 23), "Dolor en los oídos" },
                    { 10, "Consulta", 3, new DateTimeOffset(new DateTime(2024, 11, 15, 17, 30, 49, 38, DateTimeKind.Unspecified).AddTicks(8270), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2024, 11, 30), "Sarpullido en la piel" },
                    { 11, "Consulta", 4, new DateTimeOffset(new DateTime(2024, 11, 15, 17, 30, 49, 38, DateTimeKind.Unspecified).AddTicks(8271), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2024, 11, 16), "Chequeo general" },
                    { 12, "Consulta", 4, new DateTimeOffset(new DateTime(2024, 11, 15, 17, 30, 49, 38, DateTimeKind.Unspecified).AddTicks(8273), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2024, 11, 21), "Revisión rutinaria" },
                    { 13, "Consulta", 4, new DateTimeOffset(new DateTime(2024, 11, 15, 17, 30, 49, 38, DateTimeKind.Unspecified).AddTicks(8275), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2024, 11, 24), "Control de diabetes" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointment_histories_appointment_id",
                table: "appointment_histories",
                column: "appointment_id");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_doctor_id",
                table: "appointments",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_patient_id",
                table: "appointments",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_specialty_id",
                table: "appointments",
                column: "specialty_id");

            migrationBuilder.CreateIndex(
                name: "IX_doctor_specialties_doctor_id",
                table: "doctor_specialties",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_doctor_specialties_specialty_id",
                table: "doctor_specialties",
                column: "specialty_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_doctor_id",
                table: "users",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_role_id",
                table: "users",
                column: "role_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointment_histories");

            migrationBuilder.DropTable(
                name: "doctor_specialties");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "appointments");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.DropTable(
                name: "patients");

            migrationBuilder.DropTable(
                name: "specialties");
        }
    }
}
