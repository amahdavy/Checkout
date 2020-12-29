using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Checkout.Core.Migrations
{
    public partial class Checkout_InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Merchant",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Website = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LastLoging = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Merchant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_PaymentMethod",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_PaymentMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_MerchantProfile",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mode = table.Column<int>(type: "int", nullable: false),
                    APIKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MerchantId = table.Column<long>(type: "bigint", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_MerchantProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_MerchantProfile_tbl_Merchant_MerchantId",
                        column: x => x.MerchantId,
                        principalTable: "tbl_Merchant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_MerchantProfilesPaymentMethods",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentMethodId = table.Column<long>(type: "bigint", nullable: true),
                    MerchantProfileId = table.Column<long>(type: "bigint", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_MerchantProfilesPaymentMethods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_MerchantProfilesPaymentMethods_tbl_MerchantProfile_MerchantProfileId",
                        column: x => x.MerchantProfileId,
                        principalTable: "tbl_MerchantProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_MerchantProfilesPaymentMethods_tbl_PaymentMethod_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "tbl_PaymentMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_TemporaryTransaction",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount_Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RedirectUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebhookUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Locale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Metadata = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SequenceType = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MandateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MerchantProfileId = table.Column<long>(type: "bigint", nullable: true),
                    TestMode = table.Column<bool>(type: "bit", nullable: true),
                    TransctionCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_TemporaryTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_TemporaryTransaction_tbl_MerchantProfile_MerchantProfileId",
                        column: x => x.MerchantProfileId,
                        principalTable: "tbl_MerchantProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_TransactionBase",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransctionCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MerchantProfileId = table.Column<long>(type: "bigint", nullable: true),
                    Amount_Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemporaryTransactionId = table.Column<long>(type: "bigint", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_TransactionBase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_TransactionBase_tbl_MerchantProfile_MerchantProfileId",
                        column: x => x.MerchantProfileId,
                        principalTable: "tbl_MerchantProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_TransactionBase_tbl_TemporaryTransaction_TemporaryTransactionId",
                        column: x => x.TemporaryTransactionId,
                        principalTable: "tbl_TemporaryTransaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_CardTransaction",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    HolderName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BillingAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(19)", maxLength: 19, nullable: false),
                    CCV = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    ExpYear = table.Column<int>(type: "int", nullable: false),
                    ExpMonth = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_CardTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_CardTransaction_tbl_TransactionBase_Id",
                        column: x => x.Id,
                        principalTable: "tbl_TransactionBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "tbl_Merchant",
                columns: new[] { "Id", "Email", "InsertDate", "LastLoging", "ModifyDate", "Name", "Password", "Phone", "Website" },
                values: new object[] { 1L, "abolfazl.mahdavi@gmail.com", new DateTime(2020, 12, 29, 13, 19, 18, 985, DateTimeKind.Local).AddTicks(1753), null, null, "Mahdavy.com", "123", "969696", "http://www.mahdavy.com" });

            migrationBuilder.InsertData(
                table: "tbl_PaymentMethod",
                columns: new[] { "Id", "InsertDate", "Logo", "ModifyDate", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 12, 29, 13, 19, 18, 991, DateTimeKind.Local).AddTicks(9453), "fab fa-apple-pay fa-lg", null, "ApplePay" },
                    { 2L, new DateTime(2020, 12, 29, 13, 19, 18, 992, DateTimeKind.Local).AddTicks(1412), "fa fa-credit-card fa-lg", null, "CreditCard" },
                    { 3L, new DateTime(2020, 12, 29, 13, 19, 18, 992, DateTimeKind.Local).AddTicks(1481), "fa fa-credit-card fa-lg", null, "DirectDebit" },
                    { 4L, new DateTime(2020, 12, 29, 13, 19, 18, 992, DateTimeKind.Local).AddTicks(1489), "fa fa-university fa-lg", null, "BankTransfer" }
                });

            migrationBuilder.InsertData(
                table: "tbl_MerchantProfile",
                columns: new[] { "Id", "APIKey", "InsertDate", "Logo", "MerchantId", "Mode", "ModifyDate", "Name", "Website" },
                values: new object[] { 1L, "test_a02f7e6a-7768-4244-8032-8979f25d9581", new DateTime(2020, 12, 29, 13, 19, 18, 992, DateTimeKind.Local).AddTicks(7784), "https://acropaq.com/image/data/logo.png", 1L, 1, null, "Mahdavi Shop 1", "shop.mahdavy.com" });

            migrationBuilder.InsertData(
                table: "tbl_MerchantProfile",
                columns: new[] { "Id", "APIKey", "InsertDate", "Logo", "MerchantId", "Mode", "ModifyDate", "Name", "Website" },
                values: new object[] { 2L, "live_974281d1-0e8d-4279-a4fa-4e37cd002b74", new DateTime(2020, 12, 29, 13, 19, 18, 993, DateTimeKind.Local).AddTicks(1918), "https://acropaq.com/image/data/logo.png", 1L, 0, null, "Mahdavi Shop", "shop.mahdavy.com" });

            migrationBuilder.InsertData(
                table: "tbl_MerchantProfilesPaymentMethods",
                columns: new[] { "Id", "InsertDate", "MerchantProfileId", "ModifyDate", "PaymentMethodId" },
                values: new object[] { 1L, new DateTime(2020, 12, 29, 13, 19, 18, 993, DateTimeKind.Local).AddTicks(2388), 1L, null, 1L });

            migrationBuilder.InsertData(
                table: "tbl_MerchantProfilesPaymentMethods",
                columns: new[] { "Id", "InsertDate", "MerchantProfileId", "ModifyDate", "PaymentMethodId" },
                values: new object[] { 2L, new DateTime(2020, 12, 29, 13, 19, 18, 993, DateTimeKind.Local).AddTicks(3665), 1L, null, 2L });

            migrationBuilder.InsertData(
                table: "tbl_MerchantProfilesPaymentMethods",
                columns: new[] { "Id", "InsertDate", "MerchantProfileId", "ModifyDate", "PaymentMethodId" },
                values: new object[] { 3L, new DateTime(2020, 12, 29, 13, 19, 18, 993, DateTimeKind.Local).AddTicks(3728), 1L, null, 4L });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_MerchantProfile_MerchantId",
                table: "tbl_MerchantProfile",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_MerchantProfilesPaymentMethods_MerchantProfileId",
                table: "tbl_MerchantProfilesPaymentMethods",
                column: "MerchantProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_MerchantProfilesPaymentMethods_PaymentMethodId",
                table: "tbl_MerchantProfilesPaymentMethods",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_TemporaryTransaction_MerchantProfileId",
                table: "tbl_TemporaryTransaction",
                column: "MerchantProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_TransactionBase_MerchantProfileId",
                table: "tbl_TransactionBase",
                column: "MerchantProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_TransactionBase_TemporaryTransactionId",
                table: "tbl_TransactionBase",
                column: "TemporaryTransactionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_CardTransaction");

            migrationBuilder.DropTable(
                name: "tbl_MerchantProfilesPaymentMethods");

            migrationBuilder.DropTable(
                name: "tbl_TransactionBase");

            migrationBuilder.DropTable(
                name: "tbl_PaymentMethod");

            migrationBuilder.DropTable(
                name: "tbl_TemporaryTransaction");

            migrationBuilder.DropTable(
                name: "tbl_MerchantProfile");

            migrationBuilder.DropTable(
                name: "tbl_Merchant");
        }
    }
}
