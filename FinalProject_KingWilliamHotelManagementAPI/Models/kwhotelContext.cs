using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KingWilliamHotelManagementAPI.Models
{
    public partial class kwhotelContext : DbContext
    {
        public kwhotelContext()
        {
        }

        public kwhotelContext(DbContextOptions<kwhotelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<JncMenuIngredients> JncMenuIngredients { get; set; }
        public virtual DbSet<LkpCreditCard> LkpCreditCard { get; set; }
        public virtual DbSet<LkpItems> LkpItems { get; set; }
        public virtual DbSet<LkpPositionTypes> LkpPositionTypes { get; set; }
        public virtual DbSet<TblChargeableItems> TblChargeableItems { get; set; }
        public virtual DbSet<TblCustomer> TblCustomer { get; set; }
        public virtual DbSet<TblEmployee> TblEmployee { get; set; }
        public virtual DbSet<TblGuestInvoice> TblGuestInvoice { get; set; }
        public virtual DbSet<TblGuestLineItems> TblGuestLineItems { get; set; }
        public virtual DbSet<TblGuestStay> TblGuestStay { get; set; }
        public virtual DbSet<TblMenu> TblMenu { get; set; }
        public virtual DbSet<TblOrder> TblOrder { get; set; }
        public virtual DbSet<TblPerson> TblPerson { get; set; }
        public virtual DbSet<TblPosition> TblPosition { get; set; }
        public virtual DbSet<TblReservation> TblReservation { get; set; }
        public virtual DbSet<TblRoomHouseKeeping> TblRoomHouseKeeping { get; set; }
        public virtual DbSet<TblRoomItems> TblRoomItems { get; set; }
        public virtual DbSet<TblRoomMaintenance> TblRoomMaintenance { get; set; }
        public virtual DbSet<TblRooms> TblRooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=198.71.226.6;Initial Catalog=kwhotel;Persist Security Info=True;User ID=rathorfarhan;Password=Hl5wr64@");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:DefaultSchema", "rathorfarhan");

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<JncMenuIngredients>(entity =>
            {
                entity.HasKey(e => new { e.MenuOptionId, e.ItemId });

                entity.ToTable("jncMenuIngredients", "dbo");

                entity.Property(e => e.MenuOptionId).HasColumnName("menuOptionID");

                entity.Property(e => e.ItemId).HasColumnName("itemID");

                entity.Property(e => e.QuantityNeeded).HasColumnName("quantityNeeded");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.JncMenuIngredients)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_jncMenuIngredients_lkpItems");

                entity.HasOne(d => d.MenuOption)
                    .WithMany(p => p.JncMenuIngredients)
                    .HasForeignKey(d => d.MenuOptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_jncMenuIngredients_tblMenu");
            });

            modelBuilder.Entity<LkpCreditCard>(entity =>
            {
                entity.HasKey(e => e.CreditCardNumber);

                entity.ToTable("lkpCreditCard", "dbo");

                entity.Property(e => e.CreditCardNumber)
                    .HasColumnName("creditCardNumber")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreditCardExpiryDate)
                    .HasColumnName("creditCardExpiryDate")
                    .HasColumnType("date");

                entity.Property(e => e.CreditCardName)
                    .IsRequired()
                    .HasColumnName("creditCardName");
            });

            modelBuilder.Entity<LkpItems>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.ToTable("lkpItems", "dbo");

                entity.Property(e => e.ItemId).HasColumnName("itemID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasColumnName("itemName");

                entity.Property(e => e.QuantityOnHand).HasColumnName("quantityOnHand");
            });

            modelBuilder.Entity<LkpPositionTypes>(entity =>
            {
                entity.HasKey(e => e.PositionId);

                entity.ToTable("lkpPositionTypes", "dbo");

                entity.Property(e => e.PositionId).HasColumnName("positionID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.IsActive).HasColumnName("isActive");
            });

            modelBuilder.Entity<TblChargeableItems>(entity =>
            {
                entity.HasKey(e => e.ChargeableItemId);

                entity.ToTable("tblChargeableItems", "dbo");

                entity.Property(e => e.ChargeableItemId).HasColumnName("chargeableItemID");

                entity.Property(e => e.ItemId).HasColumnName("itemID");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("money");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TblChargeableItems)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblChargeableItems_lkpItems");
            });

            modelBuilder.Entity<TblCustomer>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.ToTable("tblCustomer", "dbo");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customerID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreditCardNumber).HasColumnName("creditCardNumber");

                entity.HasOne(d => d.CreditCardNumberNavigation)
                    .WithMany(p => p.TblCustomer)
                    .HasForeignKey(d => d.CreditCardNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCustomer_lkpCreditCard");

                entity.HasOne(d => d.Customer)
                    .WithOne(p => p.TblCustomer)
                    .HasForeignKey<TblCustomer>(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCustomer_tblPerson");
            });

            modelBuilder.Entity<TblEmployee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.ToTable("tblEmployee", "dbo");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.EmergencyContactName)
                    .IsRequired()
                    .HasColumnName("emergencyContactName");

                entity.Property(e => e.EmergencyContactNumber)
                    .IsRequired()
                    .HasColumnName("emergencyContactNumber");

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.TblEmployee)
                    .HasForeignKey<TblEmployee>(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmployee_tblPerson");
            });

            modelBuilder.Entity<TblGuestInvoice>(entity =>
            {
                entity.HasKey(e => e.InvoiceId);

                entity.ToTable("tblGuestInvoice", "dbo");

                entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");

                entity.Property(e => e.GuestStayId).HasColumnName("guestStayID");

                entity.Property(e => e.InvoiceDateTime)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.GuestStay)
                    .WithMany(p => p.TblGuestInvoice)
                    .HasForeignKey(d => d.GuestStayId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblGuestInvoice_tblGuestStay");
            });

            modelBuilder.Entity<TblGuestLineItems>(entity =>
            {
                entity.HasKey(e => e.GuestLineItemId);

                entity.ToTable("tblGuestLineItems", "dbo");

                entity.Property(e => e.GuestLineItemId).HasColumnName("guestLineItemID");

                entity.Property(e => e.DateTime)
                    .HasColumnName("dateTime")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.GuestStayId).HasColumnName("guestStayID");

                entity.Property(e => e.ItemId).HasColumnName("itemID");

                entity.Property(e => e.ItemPrice)
                    .HasColumnName("itemPrice")
                    .HasColumnType("money");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.GuestStay)
                    .WithMany(p => p.TblGuestLineItems)
                    .HasForeignKey(d => d.GuestStayId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblGuestLineItems_tblGuestStay");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TblGuestLineItems)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblGuestLineItems_lkpItems");
            });

            modelBuilder.Entity<TblGuestStay>(entity =>
            {
                entity.HasKey(e => e.GuestStayId);

                entity.ToTable("tblGuestStay", "dbo");

                entity.Property(e => e.GuestStayId).HasColumnName("guestStayID");

                entity.Property(e => e.CustomerId).HasColumnName("customerID");

                entity.Property(e => e.EndDatetime)
                    .HasColumnName("endDatetime")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.RoomNumber).HasColumnName("roomNumber");

                entity.Property(e => e.StartDatetime)
                    .HasColumnName("startDatetime")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TblGuestStay)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblGuestStay_tblCustomer");

                entity.HasOne(d => d.RoomNumberNavigation)
                    .WithMany(p => p.TblGuestStay)
                    .HasForeignKey(d => d.RoomNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblGuestStay_tblRooms");
            });

            modelBuilder.Entity<TblMenu>(entity =>
            {
                entity.HasKey(e => e.MenuOptionId);

                entity.ToTable("tblMenu", "dbo");

                entity.Property(e => e.MenuOptionId).HasColumnName("menuOptionID");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasColumnName("category");

                entity.Property(e => e.ChargeableItemId).HasColumnName("chargeableItemID");

                entity.Property(e => e.IsAvailable).HasColumnName("isAvailable");

                entity.HasOne(d => d.ChargeableItem)
                    .WithMany(p => p.TblMenu)
                    .HasForeignKey(d => d.ChargeableItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblMenu_tblChargeableItems");
            });

            modelBuilder.Entity<TblOrder>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ItemId });

                entity.ToTable("tblOrder", "dbo");

                entity.Property(e => e.OrderId)
                    .HasColumnName("orderID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ItemId).HasColumnName("itemID");

                entity.Property(e => e.OrderDateTime)
                    .HasColumnName("orderDateTime")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.QuantityOrdered).HasColumnName("quantityOrdered");

                entity.Property(e => e.QuantityReceived).HasColumnName("quantityReceived");

                entity.Property(e => e.ReceivedDateTime)
                    .HasColumnName("receivedDateTime")
                    .HasColumnType("smalldatetime");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TblOrder)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblOrder_lkpItems");
            });

            modelBuilder.Entity<TblPerson>(entity =>
            {
                entity.HasKey(e => e.PersonId);

                entity.ToTable("tblPerson", "dbo");

                entity.Property(e => e.PersonId).HasColumnName("personID");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country");

                entity.Property(e => e.EmailAddress).HasColumnName("emailAddress");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasColumnName("postalCode")
                    .HasMaxLength(6);

                entity.Property(e => e.StreetName)
                    .IsRequired()
                    .HasColumnName("streetName");

                entity.Property(e => e.StreetNumber).HasColumnName("streetNumber");
            });

            modelBuilder.Entity<TblPosition>(entity =>
            {
                entity.ToTable("tblPosition", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmployeeId).HasColumnName("employeeID");

                entity.Property(e => e.EndDate)
                    .HasColumnName("endDate")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.PositionId).HasColumnName("positionID");

                entity.Property(e => e.StartDate)
                    .HasColumnName("startDate")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TblPosition)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPosition_tblEmployee");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.TblPosition)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPosition_lkpPositionTypes");
            });

            modelBuilder.Entity<TblReservation>(entity =>
            {
                entity.HasKey(e => e.ReservationId);

                entity.ToTable("tblReservation", "dbo");

                entity.Property(e => e.ReservationId).HasColumnName("reservationID");

                entity.Property(e => e.ExpectedArriveDate)
                    .HasColumnName("expectedArriveDate")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.ExpectedLeaveDate)
                    .HasColumnName("expectedLeaveDate")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.PersonId).HasColumnName("personID");

                entity.Property(e => e.ReservationNotes).HasColumnName("reservationNotes");

                entity.Property(e => e.RoomNumber).HasColumnName("roomNumber");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.TblReservation)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblReservation_tblPerson");

                entity.HasOne(d => d.RoomNumberNavigation)
                    .WithMany(p => p.TblReservation)
                    .HasForeignKey(d => d.RoomNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblReservation_tblRooms");
            });

            modelBuilder.Entity<TblRoomHouseKeeping>(entity =>
            {
                entity.HasKey(e => e.RoomHouseKeepingId);

                entity.ToTable("tblRoomHouseKeeping", "dbo");

                entity.Property(e => e.RoomHouseKeepingId).HasColumnName("roomHouseKeepingID");

                entity.Property(e => e.EmployeeId).HasColumnName("employeeID");

                entity.Property(e => e.RoomHouseKeepingDatetime)
                    .HasColumnName("roomHouseKeepingDatetime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RoomNumber).HasColumnName("roomNumber");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TblRoomHouseKeeping)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRoomHouseKeeping_tblEmployee");

                entity.HasOne(d => d.RoomNumberNavigation)
                    .WithMany(p => p.TblRoomHouseKeeping)
                    .HasForeignKey(d => d.RoomNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRoomHouseKeeping_tblRooms");
            });

            modelBuilder.Entity<TblRoomItems>(entity =>
            {
                entity.HasKey(e => e.RoomItemId);

                entity.ToTable("tblRoomItems", "dbo");

                entity.Property(e => e.RoomItemId).HasColumnName("roomItemID");

                entity.Property(e => e.ItemId).HasColumnName("itemID");

                entity.Property(e => e.RoomItemDatetime)
                    .HasColumnName("roomItemDatetime")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RoomNumber).HasColumnName("roomNumber");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TblRoomItems)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRoomItems_lkpItems");

                entity.HasOne(d => d.RoomNumberNavigation)
                    .WithMany(p => p.TblRoomItems)
                    .HasForeignKey(d => d.RoomNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRoomItems_tblRooms");
            });

            modelBuilder.Entity<TblRoomMaintenance>(entity =>
            {
                entity.HasKey(e => e.RoomMaintenanceId);

                entity.ToTable("tblRoomMaintenance", "dbo");

                entity.Property(e => e.RoomMaintenanceId).HasColumnName("roomMaintenanceID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50);

                entity.Property(e => e.EmployeeId).HasColumnName("employeeID");

                entity.Property(e => e.EndDatetime)
                    .HasColumnName("endDatetime")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.MaintenanceCode).HasColumnName("maintenanceCode");

                entity.Property(e => e.RoomNumber).HasColumnName("roomNumber");

                entity.Property(e => e.StartDatetime)
                    .HasColumnName("startDatetime")
                    .HasColumnType("smalldatetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TblRoomMaintenance)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRoomMaintenance_tblEmployee");

                entity.HasOne(d => d.RoomNumberNavigation)
                    .WithMany(p => p.TblRoomMaintenance)
                    .HasForeignKey(d => d.RoomNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRoomMaintenance_tblRooms");
            });

            modelBuilder.Entity<TblRooms>(entity =>
            {
                entity.HasKey(e => e.RoomNumber);

                entity.ToTable("tblRooms", "dbo");

                entity.Property(e => e.RoomNumber)
                    .HasColumnName("roomNumber")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("money");

                entity.Property(e => e.RoomStatus).HasColumnName("roomStatus");

                entity.Property(e => e.RoomType)
                    .IsRequired()
                    .HasColumnName("roomType")
                    .HasMaxLength(10);

                entity.Property(e => e.RoomView)
                    .IsRequired()
                    .HasColumnName("roomView")
                    .HasMaxLength(10);
            });
        }
    }
}
