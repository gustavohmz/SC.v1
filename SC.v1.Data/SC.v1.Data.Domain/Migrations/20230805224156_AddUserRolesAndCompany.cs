using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SC.v1.Data.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddUserRolesAndCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    category_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("categories_pkey", x => x.category_id);
                },
                comment: "Tabla para manejar categorías de productos");

            migrationBuilder.CreateTable(
                name: "colors",
                columns: table => new
                {
                    color_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    color_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("colors_pkey", x => x.color_id);
                },
                comment: "Tabla para manejar colores de productos");

            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    company_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    company_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    company_address = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    company_phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    company_email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    company_website = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    contact_person_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    contact_person_email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    contact_person_phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    registration_number = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    tax_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("company_pkey", x => x.company_id);
                },
                comment: "Tabla para manejar empresas");

            migrationBuilder.CreateTable(
                name: "sizes",
                columns: table => new
                {
                    size_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    size_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("sizes_pkey", x => x.size_id);
                },
                comment: "Tabla para manejar tallas de productos");

            migrationBuilder.CreateTable(
                name: "third_parties",
                columns: table => new
                {
                    third_party_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    third_party_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    third_party_type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    id_type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    id_number = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("third_parties_pkey", x => x.third_party_id);
                },
                comment: "Tabla para manejar terceros como clientes, proveedores y asesores");

            migrationBuilder.CreateTable(
                name: "transaction_types",
                columns: table => new
                {
                    type_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("transaction_types_pkey", x => x.type_id);
                },
                comment: "Tabla para manejar los diferentes tipos de transacciones");

            migrationBuilder.CreateTable(
                name: "user_roles",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_roles_pkey", x => x.role_id);
                },
                comment: "Tabla para manejar los roles de usuario");

            migrationBuilder.CreateTable(
                name: "inventory",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: true),
                    color_id = table.Column<int>(type: "integer", nullable: true),
                    size_id = table.Column<int>(type: "integer", nullable: true),
                    quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("inventory_pkey", x => x.product_id);
                    table.ForeignKey(
                        name: "inventory_category_id_fkey",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "inventory_color_id_fkey",
                        column: x => x.color_id,
                        principalTable: "colors",
                        principalColumn: "color_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "inventory_size_id_fkey",
                        column: x => x.size_id,
                        principalTable: "sizes",
                        principalColumn: "size_id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Tabla para manejar el inventario");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    password_hash = table.Column<string>(type: "character(64)", fixedLength: true, maxLength: 64, nullable: false),
                    password_salt = table.Column<string>(type: "character(64)", fixedLength: true, maxLength: 64, nullable: false),
                    user_role_id = table.Column<int>(type: "integer", nullable: false),
                    company_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("users_pkey", x => x.user_id);
                    table.ForeignKey(
                        name: "users_company_id_fkey",
                        column: x => x.company_id,
                        principalTable: "company",
                        principalColumn: "company_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "users_user_role_id_fkey",
                        column: x => x.user_role_id,
                        principalTable: "user_roles",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Tabla para manejar usuarios y autenticación");

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    transaction_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type_id = table.Column<int>(type: "integer", nullable: true),
                    transaction_date = table.Column<DateOnly>(type: "date", nullable: false),
                    total_amount = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("transactions_pkey", x => x.transaction_id);
                    table.ForeignKey(
                        name: "transactions_type_id_fkey",
                        column: x => x.type_id,
                        principalTable: "transaction_types",
                        principalColumn: "type_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "transactions_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Tabla para manejar las transacciones");

            migrationBuilder.CreateTable(
                name: "electronic_invoices",
                columns: table => new
                {
                    invoice_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    transaction_id = table.Column<int>(type: "integer", nullable: true),
                    invoice_number = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    issue_date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("electronic_invoices_pkey", x => x.invoice_id);
                    table.ForeignKey(
                        name: "electronic_invoices_transaction_id_fkey",
                        column: x => x.transaction_id,
                        principalTable: "transactions",
                        principalColumn: "transaction_id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Tabla para manejar facturas electrónicas");

            migrationBuilder.CreateTable(
                name: "payroll",
                columns: table => new
                {
                    payroll_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    transaction_id = table.Column<int>(type: "integer", nullable: true),
                    payroll_date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("payroll_pkey", x => x.payroll_id);
                    table.ForeignKey(
                        name: "payroll_transaction_id_fkey",
                        column: x => x.transaction_id,
                        principalTable: "transactions",
                        principalColumn: "transaction_id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Tabla para manejar nómina");

            migrationBuilder.CreateTable(
                name: "transaction_lines",
                columns: table => new
                {
                    line_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    transaction_id = table.Column<int>(type: "integer", nullable: true),
                    account_id = table.Column<int>(type: "integer", nullable: true),
                    amount = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("transaction_lines_pkey", x => x.line_id);
                    table.ForeignKey(
                        name: "transaction_lines_transaction_id_fkey",
                        column: x => x.transaction_id,
                        principalTable: "transactions",
                        principalColumn: "transaction_id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Tabla para manejar las líneas de las transacciones");

            migrationBuilder.CreateTable(
                name: "electronic_invoice_items",
                columns: table => new
                {
                    item_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    invoice_id = table.Column<int>(type: "integer", nullable: true),
                    product_id = table.Column<int>(type: "integer", nullable: true),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    unit_price = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("electronic_invoice_items_pkey", x => x.item_id);
                    table.ForeignKey(
                        name: "electronic_invoice_items_invoice_id_fkey",
                        column: x => x.invoice_id,
                        principalTable: "electronic_invoices",
                        principalColumn: "invoice_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "electronic_invoice_items_product_id_fkey",
                        column: x => x.product_id,
                        principalTable: "inventory",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Tabla para manejar ítems de factura electrónica");

            migrationBuilder.CreateTable(
                name: "payroll_items",
                columns: table => new
                {
                    item_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    payroll_id = table.Column<int>(type: "integer", nullable: true),
                    employee_id = table.Column<int>(type: "integer", nullable: true),
                    amount = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("payroll_items_pkey", x => x.item_id);
                    table.ForeignKey(
                        name: "payroll_items_employee_id_fkey",
                        column: x => x.employee_id,
                        principalTable: "third_parties",
                        principalColumn: "third_party_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "payroll_items_payroll_id_fkey",
                        column: x => x.payroll_id,
                        principalTable: "payroll",
                        principalColumn: "payroll_id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Tabla para manejar ítems de nómina");

            migrationBuilder.CreateIndex(
                name: "categories_category_name_key",
                table: "categories",
                column: "category_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_categories_id",
                table: "categories",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "colors_color_name_key",
                table: "colors",
                column: "color_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_colors_id",
                table: "colors",
                column: "color_id");

            migrationBuilder.CreateIndex(
                name: "company_company_name_key",
                table: "company",
                column: "company_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_electronic_invoice_items_id",
                table: "electronic_invoice_items",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_electronic_invoice_items_invoice_id",
                table: "electronic_invoice_items",
                column: "invoice_id");

            migrationBuilder.CreateIndex(
                name: "IX_electronic_invoice_items_product_id",
                table: "electronic_invoice_items",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "electronic_invoices_invoice_number_key",
                table: "electronic_invoices",
                column: "invoice_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_electronic_invoices_id",
                table: "electronic_invoices",
                column: "invoice_id");

            migrationBuilder.CreateIndex(
                name: "IX_electronic_invoices_transaction_id",
                table: "electronic_invoices",
                column: "transaction_id");

            migrationBuilder.CreateIndex(
                name: "idx_inventory_id",
                table: "inventory",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "inventory_product_name_key",
                table: "inventory",
                column: "product_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_inventory_category_id",
                table: "inventory",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_color_id",
                table: "inventory",
                column: "color_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_size_id",
                table: "inventory",
                column: "size_id");

            migrationBuilder.CreateIndex(
                name: "idx_payroll_id",
                table: "payroll",
                column: "payroll_id");

            migrationBuilder.CreateIndex(
                name: "IX_payroll_transaction_id",
                table: "payroll",
                column: "transaction_id");

            migrationBuilder.CreateIndex(
                name: "idx_payroll_items_id",
                table: "payroll_items",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_payroll_items_employee_id",
                table: "payroll_items",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_payroll_items_payroll_id",
                table: "payroll_items",
                column: "payroll_id");

            migrationBuilder.CreateIndex(
                name: "idx_sizes_id",
                table: "sizes",
                column: "size_id");

            migrationBuilder.CreateIndex(
                name: "sizes_size_name_key",
                table: "sizes",
                column: "size_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_third_parties_id",
                table: "third_parties",
                column: "third_party_id");

            migrationBuilder.CreateIndex(
                name: "third_parties_id_number_key",
                table: "third_parties",
                column: "id_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_transaction_lines_id",
                table: "transaction_lines",
                column: "line_id");

            migrationBuilder.CreateIndex(
                name: "idx_transaction_lines_transaction_id",
                table: "transaction_lines",
                column: "transaction_id");

            migrationBuilder.CreateIndex(
                name: "idx_transaction_types_id",
                table: "transaction_types",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "transaction_types_type_name_key",
                table: "transaction_types",
                column: "type_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_transactions_id",
                table: "transactions",
                column: "transaction_id");

            migrationBuilder.CreateIndex(
                name: "idx_transactions_type_id",
                table: "transactions",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_user_id",
                table: "transactions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "user_roles_role_name_key",
                table: "user_roles",
                column: "role_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_users_id",
                table: "users",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_company_id",
                table: "users",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_user_role_id",
                table: "users",
                column: "user_role_id");

            migrationBuilder.CreateIndex(
                name: "users_user_name_key",
                table: "users",
                column: "user_name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "electronic_invoice_items");

            migrationBuilder.DropTable(
                name: "payroll_items");

            migrationBuilder.DropTable(
                name: "transaction_lines");

            migrationBuilder.DropTable(
                name: "electronic_invoices");

            migrationBuilder.DropTable(
                name: "inventory");

            migrationBuilder.DropTable(
                name: "third_parties");

            migrationBuilder.DropTable(
                name: "payroll");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "colors");

            migrationBuilder.DropTable(
                name: "sizes");

            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "transaction_types");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "company");

            migrationBuilder.DropTable(
                name: "user_roles");
        }
    }
}
