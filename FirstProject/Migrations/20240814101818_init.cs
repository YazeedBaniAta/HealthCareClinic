using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstProject.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ADMINS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIRST_NAME = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    LAST_NAME = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    PHONE = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    IMAGE_PATH = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMINS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BANNER_SECTION",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TITLE = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    DESCRIPTION = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    IMAGE_PATH = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BANNER_SECTION", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CONTACT",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FULL_NAME = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    EMAIL = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    TOPIC = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    PHONE = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    MESSAGE = table.Column<string>(unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTACT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "COUNTER_SECTION",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HAPPY_PEOPEL = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    SURGERY_COMEPLET = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    EXPERT_DOCTOR = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    WORDWIDE_BRANCH = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COUNTER_SECTION", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DEPARTMENTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(unicode: false, maxLength: 60, nullable: false),
                    DESCRIPTION = table.Column<string>(unicode: false, maxLength: 250, nullable: false),
                    IMAGE_PATH = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPARTMENTS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FEATURES_SECTION",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TIMESUN_WED = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    TIMETHU_FRI = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    TIMESAT_SUN = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    EMAEGENCY_CASE = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FEATURES_SECTION", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FOOTER_SECTION",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COLUMN1 = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    IMAGE_PATH = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FOOTER_SECTION", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HEAD_SECTION",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CLINIC_NAME = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CLINIC_ADDRESS = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CLINIC_EMAIL = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    IMAGE_PATH = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HEAD_SECTION", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PARTNERS_SECTION",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPTION = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    IMAGE_PATH = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PARTNERS_SECTION", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PATIENTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIRST_NAME = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    LAST_NAME = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    EMAIL = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    GENDER = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    ADDRESS = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    PHONE = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    IMAGE_PATH = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    BOD = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PATIENTS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ROLES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ROLENAME = table.Column<string>(unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SERVICE_PAGE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TITLE = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    DESCRIPTION = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    IMAGE_PATH = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SERVICE_PAGE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SERVICE_SECTION",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TITLE = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    DESCRIPTION = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    IMAGE_PATH = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SERVICE_SECTION", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SPECIALIZATION",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPECIALIZATION", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SUBSCRIP",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMAIL = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUBSCRIP", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PATIENTS_VESA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BALANCE = table.Column<decimal>(type: "DECIMAL(8,2)", nullable: true, defaultValueSql: "1000 "),
                    PATIENT_ID = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PATIENTS_VESA", x => x.ID);
                    table.ForeignKey(
                        name: "PATIENTS_VESA_FK1",
                        column: x => x.PATIENT_ID,
                        principalTable: "PATIENTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TESTIMONIAL_SECTION",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SUBJECT = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    DESCRIPTION = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    PATIENT_ID = table.Column<int>(type: "INT", nullable: true),
                    STATUS = table.Column<string>(unicode: false, maxLength: 20, nullable: true, defaultValueSql: @"0 
")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TESTIMONIAL_SECTION", x => x.ID);
                    table.ForeignKey(
                        name: "TESTIMONIAL_SECTION_FK1",
                        column: x => x.PATIENT_ID,
                        principalTable: "PATIENTS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "DOCTORS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIRST_NAME = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    LAST_NAME = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    EMAIL = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    PHONE = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    ADDRESS = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    BOD = table.Column<string>(unicode: false, maxLength: 80, nullable: false),
                    IS_AVAILABLE = table.Column<string>(unicode: false, maxLength: 50, nullable: true, defaultValueSql: "1 "),
                    AVAILABLE_TIME = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    AVAILABLE_DAY = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    SALARY = table.Column<string>(unicode: false, maxLength: 80, nullable: false),
                    DEPARTMENT_ID = table.Column<int>(type: "INT", nullable: false),
                    SPECIALIZATION_ID = table.Column<int>(type: "INT", nullable: false),
                    IMAGE_PATH = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOCTORS", x => x.ID);
                    table.ForeignKey(
                        name: "DOCTOR_FK1",
                        column: x => x.DEPARTMENT_ID,
                        principalTable: "DEPARTMENTS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "DOCTOR_FK2",
                        column: x => x.SPECIALIZATION_ID,
                        principalTable: "SPECIALIZATION",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "APPOINTMENTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    APPOINTMENT_DATE = table.Column<DateTime>(type: "DATE", nullable: false),
                    APPOINTMENT_TIME = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    MESSAGE = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    DEPARTMENT_ID = table.Column<int>(type: "INT", nullable: false),
                    DOCTOR_ID = table.Column<int>(type: "INT", nullable: false),
                    PATIENT_ID = table.Column<int>(type: "INT", nullable: true),
                    STATUS = table.Column<string>(unicode: false, maxLength: 20, nullable: true, defaultValueSql: @"0 
")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APPOINTMENTS", x => x.ID);
                    table.ForeignKey(
                        name: "APPOINTMENT_FK1",
                        column: x => x.DEPARTMENT_ID,
                        principalTable: "DEPARTMENTS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "APPOINTMENT_FK2",
                        column: x => x.DOCTOR_ID,
                        principalTable: "DOCTORS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "APPOINTMENT_FK3",
                        column: x => x.PATIENT_ID,
                        principalTable: "PATIENTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ATTENDANCES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DOCTOR_ID = table.Column<int>(type: "INT", nullable: true),
                    STATUS = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    ATTENDANCE_DATE = table.Column<string>(unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATTENDANCES", x => x.ID);
                    table.ForeignKey(
                        name: "ATTENDANCE_FK1",
                        column: x => x.DOCTOR_ID,
                        principalTable: "DOCTORS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "INVOICES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CARD_NUMBER = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    BOOKING_AMOUNT = table.Column<decimal>(type: "DECIMAL(8,2)", nullable: true, defaultValueSql: @"10 
"),
                    BOOKING_DATE = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    PATIENT_ID = table.Column<int>(type: "INT", nullable: true),
                    DOCTOR_ID = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVOICES", x => x.ID);
                    table.ForeignKey(
                        name: "INVOICES_FK2",
                        column: x => x.DOCTOR_ID,
                        principalTable: "DOCTORS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "INVOICES_FK1",
                        column: x => x.PATIENT_ID,
                        principalTable: "PATIENTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_NAME = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    PASSWORD = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    ROLE_ID = table.Column<int>(type: "INT", nullable: true),
                    ADMIN_ID = table.Column<int>(type: "INT", nullable: true),
                    DOCTOR_ID = table.Column<int>(type: "INT", nullable: true),
                    PATIENT_ID = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.ID);
                    table.ForeignKey(
                        name: "USERS_FK2",
                        column: x => x.ADMIN_ID,
                        principalTable: "ADMINS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "USERS_FK3",
                        column: x => x.DOCTOR_ID,
                        principalTable: "DOCTORS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "USERS_FK4",
                        column: x => x.PATIENT_ID,
                        principalTable: "PATIENTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "USERS_FK1",
                        column: x => x.ROLE_ID,
                        principalTable: "ROLES",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_APPOINTMENTS_DEPARTMENT_ID",
                table: "APPOINTMENTS",
                column: "DEPARTMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_APPOINTMENTS_DOCTOR_ID",
                table: "APPOINTMENTS",
                column: "DOCTOR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_APPOINTMENTS_PATIENT_ID",
                table: "APPOINTMENTS",
                column: "PATIENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ATTENDANCES_DOCTOR_ID",
                table: "ATTENDANCES",
                column: "DOCTOR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_DOCTORS_DEPARTMENT_ID",
                table: "DOCTORS",
                column: "DEPARTMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_DOCTORS_SPECIALIZATION_ID",
                table: "DOCTORS",
                column: "SPECIALIZATION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INVOICES_DOCTOR_ID",
                table: "INVOICES",
                column: "DOCTOR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INVOICES_PATIENT_ID",
                table: "INVOICES",
                column: "PATIENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PATIENTS_VESA_PATIENT_ID",
                table: "PATIENTS_VESA",
                column: "PATIENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TESTIMONIAL_SECTION_PATIENT_ID",
                table: "TESTIMONIAL_SECTION",
                column: "PATIENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_ADMIN_ID",
                table: "USERS",
                column: "ADMIN_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_DOCTOR_ID",
                table: "USERS",
                column: "DOCTOR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_PATIENT_ID",
                table: "USERS",
                column: "PATIENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_ROLE_ID",
                table: "USERS",
                column: "ROLE_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APPOINTMENTS");

            migrationBuilder.DropTable(
                name: "ATTENDANCES");

            migrationBuilder.DropTable(
                name: "BANNER_SECTION");

            migrationBuilder.DropTable(
                name: "CONTACT");

            migrationBuilder.DropTable(
                name: "COUNTER_SECTION");

            migrationBuilder.DropTable(
                name: "FEATURES_SECTION");

            migrationBuilder.DropTable(
                name: "FOOTER_SECTION");

            migrationBuilder.DropTable(
                name: "HEAD_SECTION");

            migrationBuilder.DropTable(
                name: "INVOICES");

            migrationBuilder.DropTable(
                name: "PARTNERS_SECTION");

            migrationBuilder.DropTable(
                name: "PATIENTS_VESA");

            migrationBuilder.DropTable(
                name: "SERVICE_PAGE");

            migrationBuilder.DropTable(
                name: "SERVICE_SECTION");

            migrationBuilder.DropTable(
                name: "SUBSCRIP");

            migrationBuilder.DropTable(
                name: "TESTIMONIAL_SECTION");

            migrationBuilder.DropTable(
                name: "USERS");

            migrationBuilder.DropTable(
                name: "ADMINS");

            migrationBuilder.DropTable(
                name: "DOCTORS");

            migrationBuilder.DropTable(
                name: "PATIENTS");

            migrationBuilder.DropTable(
                name: "ROLES");

            migrationBuilder.DropTable(
                name: "DEPARTMENTS");

            migrationBuilder.DropTable(
                name: "SPECIALIZATION");
        }
    }
}
