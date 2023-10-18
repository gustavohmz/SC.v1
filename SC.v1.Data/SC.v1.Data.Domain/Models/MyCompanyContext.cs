using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SC.v1.Data.Domain.Models;

public partial class MyCompanyContext : DbContext
{
    public MyCompanyContext()
    {
    }

    public MyCompanyContext(DbContextOptions<MyCompanyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<ElectronicInvoice> ElectronicInvoices { get; set; }

    public virtual DbSet<ElectronicInvoiceItem> ElectronicInvoiceItems { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Payroll> Payrolls { get; set; }

    public virtual DbSet<PayrollItem> PayrollItems { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }

    public virtual DbSet<ThirdParty> ThirdParties { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<TransactionLine> TransactionLines { get; set; }

    public virtual DbSet<TransactionType> TransactionTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }


    public virtual DbSet<Company> Companies { get; set; }
    public virtual DbSet<UserRoles> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Database=myCompany;Username=postgres;Password=4535");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("categories_pkey");

            entity.ToTable("categories", tb => tb.HasComment("Tabla para manejar categorías de productos"));

            entity.HasIndex(e => e.CategoryName, "categories_category_name_key").IsUnique();

            entity.HasIndex(e => e.CategoryId, "idx_categories_id");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.ColorId).HasName("colors_pkey");

            entity.ToTable("colors", tb => tb.HasComment("Tabla para manejar colores de productos"));

            entity.HasIndex(e => e.ColorName, "colors_color_name_key").IsUnique();

            entity.HasIndex(e => e.ColorId, "idx_colors_id");

            entity.Property(e => e.ColorId).HasColumnName("color_id");
            entity.Property(e => e.ColorName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("color_name");
        });

        modelBuilder.Entity<ElectronicInvoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("electronic_invoices_pkey");

            entity.ToTable("electronic_invoices", tb => tb.HasComment("Tabla para manejar facturas electrónicas"));

            entity.HasIndex(e => e.InvoiceNumber, "electronic_invoices_invoice_number_key").IsUnique();

            entity.HasIndex(e => e.InvoiceId, "idx_electronic_invoices_id");

            entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");
            entity.Property(e => e.InvoiceNumber)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("invoice_number");
            entity.Property(e => e.IssueDate).HasColumnName("issue_date");
            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");

            entity.HasOne(d => d.Transaction).WithMany(p => p.ElectronicInvoices)
                .HasForeignKey(d => d.TransactionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("electronic_invoices_transaction_id_fkey");
        });

        modelBuilder.Entity<ElectronicInvoiceItem>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("electronic_invoice_items_pkey");

            entity.ToTable("electronic_invoice_items", tb => tb.HasComment("Tabla para manejar ítems de factura electrónica"));

            entity.HasIndex(e => e.ItemId, "idx_electronic_invoice_items_id");

            entity.Property(e => e.ItemId).HasColumnName("item_id");
            entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UnitPrice)
                .HasPrecision(10, 2)
                .HasColumnName("unit_price");

            entity.HasOne(d => d.Invoice).WithMany(p => p.ElectronicInvoiceItems)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("electronic_invoice_items_invoice_id_fkey");

            entity.HasOne(d => d.Product).WithMany(p => p.ElectronicInvoiceItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("electronic_invoice_items_product_id_fkey");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("inventory_pkey");

            entity.ToTable("inventory", tb => tb.HasComment("Tabla para manejar el inventario"));

            entity.HasIndex(e => e.ProductId, "idx_inventory_id");

            entity.HasIndex(e => e.ProductName, "inventory_product_name_key").IsUnique();

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.ColorId).HasColumnName("color_id");
            entity.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("product_name");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.SizeId).HasColumnName("size_id");

            entity.HasOne(d => d.Category).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("inventory_category_id_fkey");

            entity.HasOne(d => d.Color).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.ColorId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("inventory_color_id_fkey");

            entity.HasOne(d => d.Size).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.SizeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("inventory_size_id_fkey");
        });

        modelBuilder.Entity<Payroll>(entity =>
        {
            entity.HasKey(e => e.PayrollId).HasName("payroll_pkey");

            entity.ToTable("payroll", tb => tb.HasComment("Tabla para manejar nómina"));

            entity.HasIndex(e => e.PayrollId, "idx_payroll_id");

            entity.Property(e => e.PayrollId).HasColumnName("payroll_id");
            entity.Property(e => e.PayrollDate).HasColumnName("payroll_date");
            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");

            entity.HasOne(d => d.Transaction).WithMany(p => p.Payrolls)
                .HasForeignKey(d => d.TransactionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("payroll_transaction_id_fkey");
        });

        modelBuilder.Entity<PayrollItem>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("payroll_items_pkey");

            entity.ToTable("payroll_items", tb => tb.HasComment("Tabla para manejar ítems de nómina"));

            entity.HasIndex(e => e.ItemId, "idx_payroll_items_id");

            entity.Property(e => e.ItemId).HasColumnName("item_id");
            entity.Property(e => e.Amount)
                .HasPrecision(10, 2)
                .HasColumnName("amount");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.PayrollId).HasColumnName("payroll_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.PayrollItems)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("payroll_items_employee_id_fkey");

            entity.HasOne(d => d.Payroll).WithMany(p => p.PayrollItems)
                .HasForeignKey(d => d.PayrollId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("payroll_items_payroll_id_fkey");
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.HasKey(e => e.SizeId).HasName("sizes_pkey");

            entity.ToTable("sizes", tb => tb.HasComment("Tabla para manejar tallas de productos"));

            entity.HasIndex(e => e.SizeId, "idx_sizes_id");

            entity.HasIndex(e => e.SizeName, "sizes_size_name_key").IsUnique();

            entity.Property(e => e.SizeId).HasColumnName("size_id");
            entity.Property(e => e.SizeName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("size_name");
        });

        modelBuilder.Entity<ThirdParty>(entity =>
        {
            entity.HasKey(e => e.ThirdPartyId).HasName("third_parties_pkey");

            entity.ToTable("third_parties", tb => tb.HasComment("Tabla para manejar terceros como clientes, proveedores y asesores"));

            entity.HasIndex(e => e.ThirdPartyId, "idx_third_parties_id");

            entity.HasIndex(e => e.IdNumber, "third_parties_id_number_key").IsUnique();

            entity.Property(e => e.ThirdPartyId).HasColumnName("third_party_id");
            entity.Property(e => e.IdNumber)
                .HasMaxLength(100)
                .HasColumnName("id_number");
            entity.Property(e => e.IdType)
                .HasMaxLength(50)
                .HasColumnName("id_type");
            entity.Property(e => e.ThirdPartyName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("third_party_name");
            entity.Property(e => e.ThirdPartyType)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("third_party_type");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("transactions_pkey");

            entity.ToTable("transactions", tb => tb.HasComment("Tabla para manejar las transacciones"));

            entity.HasIndex(e => e.TransactionId, "idx_transactions_id");

            entity.HasIndex(e => e.TypeId, "idx_transactions_type_id");

            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            entity.Property(e => e.TotalAmount)
                .HasPrecision(10, 2)
                .HasColumnName("total_amount");
            entity.Property(e => e.TransactionDate).HasColumnName("transaction_date");
            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Type).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("transactions_type_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("transactions_user_id_fkey");
        });

        modelBuilder.Entity<TransactionLine>(entity =>
        {
            entity.HasKey(e => e.LineId).HasName("transaction_lines_pkey");

            entity.ToTable("transaction_lines", tb => tb.HasComment("Tabla para manejar las líneas de las transacciones"));

            entity.HasIndex(e => e.LineId, "idx_transaction_lines_id");

            entity.HasIndex(e => e.TransactionId, "idx_transaction_lines_transaction_id");

            entity.Property(e => e.LineId).HasColumnName("line_id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Amount)
                .HasPrecision(10, 2)
                .HasColumnName("amount");
            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");

            entity.HasOne(d => d.Transaction).WithMany(p => p.TransactionLines)
                .HasForeignKey(d => d.TransactionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("transaction_lines_transaction_id_fkey");
        });

        modelBuilder.Entity<TransactionType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("transaction_types_pkey");

            entity.ToTable("transaction_types", tb => tb.HasComment("Tabla para manejar los diferentes tipos de transacciones"));

            entity.HasIndex(e => e.TypeId, "idx_transaction_types_id");

            entity.HasIndex(e => e.TypeName, "transaction_types_type_name_key").IsUnique();

            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.TypeName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("type_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users", tb => tb.HasComment("Tabla para manejar usuarios y autenticación"));

            entity.HasIndex(e => e.UserId, "idx_users_id");

            entity.HasIndex(e => e.UserName, "users_user_name_key").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.PasswordHash)
                .IsRequired()
                .HasMaxLength(64)
                .IsFixedLength()
                .HasColumnName("password_hash");
            entity.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("user_name");
            entity.Property(e => e.RoleId).HasColumnName("user_role_id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");

            entity.HasOne(d => d.UserRole)
                  .WithMany(p => p.Users)
                  .HasForeignKey(d => d.RoleId)
                  .OnDelete(DeleteBehavior.Restrict)
                  .HasConstraintName("users_user_role_id_fkey");

            entity.HasOne(d => d.Company)
                  .WithMany(p => p.Users)
                  .HasForeignKey(d => d.CompanyId)
                  .OnDelete(DeleteBehavior.Restrict)
                  .HasConstraintName("users_company_id_fkey");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("company_pkey");

            entity.ToTable("company", tb => tb.HasComment("Tabla para manejar empresas"));

            entity.HasIndex(e => e.CompanyName, "company_company_name_key").IsUnique();

            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("company_name");
            entity.Property(e => e.CompanyAddress)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("company_address");
            entity.Property(e => e.CompanyPhone)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("company_phone");
            entity.Property(e => e.CompanyEmail)
                .HasMaxLength(100)
                .HasColumnName("company_email");
            entity.Property(e => e.CompanyWebsite)
                .HasMaxLength(100)
                .HasColumnName("company_website");
            entity.Property(e => e.ContactPersonName)
                .HasMaxLength(100)
                .HasColumnName("contact_person_name");
            entity.Property(e => e.ContactPersonEmail)
                .HasMaxLength(100)
                .HasColumnName("contact_person_email");
            entity.Property(e => e.ContactPersonPhone)
                .HasMaxLength(20)
                .HasColumnName("contact_person_phone");
            entity.Property(e => e.RegistrationNumber)
                .HasMaxLength(50)
                .HasColumnName("registration_number");
            entity.Property(e => e.TaxId)
                .HasMaxLength(50)
                .HasColumnName("tax_id");
        });

        modelBuilder.Entity<UserRoles>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("user_roles_pkey");

            entity.ToTable("user_roles", tb => tb.HasComment("Tabla para manejar los roles de usuario"));

            entity.HasIndex(e => e.RoleName, "user_roles_role_name_key").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<UserRoles>(entity =>
        {
            entity.HasData(
                new UserRoles { RoleId = 1, RoleName = "Admin" },
                new UserRoles { RoleId = 2, RoleName = "Cliente" },
                new UserRoles { RoleId = 3, RoleName = "Contador" },
                new UserRoles { RoleId = 4, RoleName = "Proveedor" },
                new UserRoles { RoleId = 5, RoleName = "Gerente" },
                new UserRoles { RoleId = 6, RoleName = "Auditor" },
                new UserRoles { RoleId = 7, RoleName = "Asesor" }
            );
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
