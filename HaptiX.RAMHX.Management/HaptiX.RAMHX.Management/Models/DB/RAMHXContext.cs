using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HaptiX.RAMHX.Management.Models.DB
{
    public partial class RAMHXContext : DbContext
    {
        public virtual DbSet<AppAcademicYear> AppAcademicYear { get; set; }
        public virtual DbSet<AppAttendance> AppAttendance { get; set; }
        public virtual DbSet<AppAttendanceType> AppAttendanceType { get; set; }
        public virtual DbSet<AppClass> AppClass { get; set; }
        public virtual DbSet<AppClassDivision> AppClassDivision { get; set; }
        public virtual DbSet<AppClassFeesStructure> AppClassFeesStructure { get; set; }
        public virtual DbSet<AppClassSubject> AppClassSubject { get; set; }
        public virtual DbSet<AppFeesPayment> AppFeesPayment { get; set; }
        public virtual DbSet<AppFeesType> AppFeesType { get; set; }
        public virtual DbSet<AppHolidayCalendar> AppHolidayCalendar { get; set; }
        public virtual DbSet<AppHostel> AppHostel { get; set; }
        public virtual DbSet<AppHostelRoom> AppHostelRoom { get; set; }
        public virtual DbSet<AppHostelType> AppHostelType { get; set; }
        public virtual DbSet<AppLeaveApplication> AppLeaveApplication { get; set; }
        public virtual DbSet<AppLeaveApplicationDay> AppLeaveApplicationDay { get; set; }
        public virtual DbSet<AppOrganization> AppOrganization { get; set; }
        public virtual DbSet<AppOrganizationDepartment> AppOrganizationDepartment { get; set; }
        public virtual DbSet<AppOrganizationSubscription> AppOrganizationSubscription { get; set; }
        public virtual DbSet<AppStudentClass> AppStudentClass { get; set; }
        public virtual DbSet<AppStudentExam> AppStudentExam { get; set; }
        public virtual DbSet<AppStudentExamType> AppStudentExamType { get; set; }
        public virtual DbSet<AppStudentFeesStructure> AppStudentFeesStructure { get; set; }
        public virtual DbSet<AppStudentResult> AppStudentResult { get; set; }
        public virtual DbSet<AppSubject> AppSubject { get; set; }
        public virtual DbSet<AppTimeTable> AppTimeTable { get; set; }
        public virtual DbSet<AppTimeTableType> AppTimeTableType { get; set; }
        public virtual DbSet<AppUserPermission> AppUserPermission { get; set; }
        public virtual DbSet<AppUserTask> AppUserTask { get; set; }
        public virtual DbSet<AppUserType> AppUserType { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<MstCity> MstCity { get; set; }
        public virtual DbSet<MstCountry> MstCountry { get; set; }
        public virtual DbSet<MstPermission> MstPermission { get; set; }
        public virtual DbSet<MstPermissionsGroup> MstPermissionsGroup { get; set; }
        public virtual DbSet<MstState> MstState { get; set; }
        public virtual DbSet<MstSubscription> MstSubscription { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=SOURCEVED01\MSSQL2016;Database=RAMHX; User ID=sa; Password=123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppAcademicYear>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.EndMonth).HasColumnType("date");

                entity.Property(e => e.EndYear).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartMonth).HasColumnType("date");

                entity.Property(e => e.StartYear).HasColumnType("date");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.AppAcademicYear)
                    .HasForeignKey(d => d.OrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppAcadem__OrgId__7B5B524B");
            });

            modelBuilder.Entity<AppAttendance>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.AcademicYid).HasColumnName("AcademicYId");

                entity.Property(e => e.AttendenceDate).HasColumnType("datetime");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.TakenByUserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.AcademicY)
                    .WithMany(p => p.AppAttendance)
                    .HasForeignKey(d => d.AcademicYid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppAttend__Acade__47A6A41B");

                entity.HasOne(d => d.AttType)
                    .WithMany(p => p.AppAttendance)
                    .HasForeignKey(d => d.AttTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppAttend__AttTy__43D61337");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.AppAttendance)
                    .HasForeignKey(d => d.OrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppAttend__OrgId__46B27FE2");

                entity.HasOne(d => d.TakenByUser)
                    .WithMany(p => p.AppAttendanceTakenByUser)
                    .HasForeignKey(d => d.TakenByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppAttend__Taken__45BE5BA9");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AppAttendanceUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppAttend__UserI__44CA3770");
            });

            modelBuilder.Entity<AppAttendanceType>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.AcademicYid).HasColumnName("AcademicYId");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.AcademicY)
                    .WithMany(p => p.AppAttendanceType)
                    .HasForeignKey(d => d.AcademicYid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppAttend__Acade__40058253");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.AppAttendanceType)
                    .HasForeignKey(d => d.OrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppAttend__OrgId__3F115E1A");
            });

            modelBuilder.Entity<AppClass>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.AcademicYid).HasColumnName("AcademicYId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.AcademicY)
                    .WithMany(p => p.AppClass)
                    .HasForeignKey(d => d.AcademicYid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppClass__Academ__04E4BC85");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.AppClass)
                    .HasForeignKey(d => d.OrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppClass__OrgId__03F0984C");
            });

            modelBuilder.Entity<AppClassDivision>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.AcademicYid).HasColumnName("AcademicYId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.AcademicY)
                    .WithMany(p => p.AppClassDivision)
                    .HasForeignKey(d => d.AcademicYid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppClassD__Acade__0A9D95DB");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.AppClassDivision)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppClassD__Class__08B54D69");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.AppClassDivision)
                    .HasForeignKey(d => d.OrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppClassD__OrgId__09A971A2");
            });

            modelBuilder.Entity<AppClassFeesStructure>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.AcademicYid).HasColumnName("AcademicYId");

                entity.Property(e => e.Amount).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Remark).HasMaxLength(100);

                entity.HasOne(d => d.AcademicY)
                    .WithMany(p => p.AppClassFeesStructure)
                    .HasForeignKey(d => d.AcademicYid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppClassF__Acade__2B0A656D");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.AppClassFeesStructure)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppClassF__Class__282DF8C2");

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.AppClassFeesStructure)
                    .HasForeignKey(d => d.DivisionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppClassF__Divis__29221CFB");

                entity.HasOne(d => d.FeesType)
                    .WithMany(p => p.AppClassFeesStructure)
                    .HasForeignKey(d => d.FeesTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppClassF__FeesT__2739D489");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.AppClassFeesStructure)
                    .HasForeignKey(d => d.OrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppClassF__OrgId__2A164134");
            });

            modelBuilder.Entity<AppClassSubject>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.AcademicYid).HasColumnName("AcademicYId");

                entity.HasOne(d => d.AcademicY)
                    .WithMany(p => p.AppClassSubject)
                    .HasForeignKey(d => d.AcademicYid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppClassS__Acade__1EA48E88");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.AppClassSubject)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppClassS__Class__1AD3FDA4");

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.AppClassSubject)
                    .HasForeignKey(d => d.DivisionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppClassS__Divis__1BC821DD");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.AppClassSubject)
                    .HasForeignKey(d => d.OrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppClassS__OrgId__1DB06A4F");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.AppClassSubject)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppClassS__Subje__1CBC4616");
            });

            modelBuilder.Entity<AppFeesPayment>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.AcademicYid).HasColumnName("AcademicYId");

                entity.Property(e => e.Amount).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.PaymentDate).HasColumnType("date");

                entity.Property(e => e.Remark).HasMaxLength(100);

                entity.Property(e => e.StudentId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.AcademicY)
                    .WithMany(p => p.AppFeesPayment)
                    .HasForeignKey(d => d.AcademicYid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppFeesPa__Acade__3B40CD36");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.AppFeesPayment)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppFeesPa__Class__37703C52");

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.AppFeesPayment)
                    .HasForeignKey(d => d.DivisionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppFeesPa__Divis__395884C4");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.AppFeesPayment)
                    .HasForeignKey(d => d.OrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppFeesPa__OrgId__3A4CA8FD");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.AppFeesPayment)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppFeesPa__Stude__3864608B");
            });

            modelBuilder.Entity<AppFeesType>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.AcademicYid).HasColumnName("AcademicYId");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.AcademicY)
                    .WithMany(p => p.AppFeesType)
                    .HasForeignKey(d => d.AcademicYid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppFeesTy__Acade__236943A5");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.AppFeesType)
                    .HasForeignKey(d => d.OrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppFeesTy__OrgId__22751F6C");
            });

            modelBuilder.Entity<AppHolidayCalendar>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.AcademicYid).HasColumnName("AcademicYId");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.AcademicY)
                    .WithMany(p => p.AppHolidayCalendar)
                    .HasForeignKey(d => d.AcademicYid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppHolida__Acade__00200768");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.AppHolidayCalendar)
                    .HasForeignKey(d => d.OrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppHolida__OrgId__7F2BE32F");
            });

            modelBuilder.Entity<AppHostel>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Contactno).HasMaxLength(10);

                entity.Property(e => e.HostelAddress).HasMaxLength(1500);

                entity.Property(e => e.HostelName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.HtypeId).HasColumnName("HTypeId");

                entity.Property(e => e.WardenContactno).HasMaxLength(10);

                entity.Property(e => e.WardenName).HasMaxLength(101);

                entity.HasOne(d => d.Htype)
                    .WithMany(p => p.AppHostel)
                    .HasForeignKey(d => d.HtypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppHostel__HType__6383C8BA");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.AppHostel)
                    .HasForeignKey(d => d.OrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppHostel__OrgId__6477ECF3");
            });

            modelBuilder.Entity<AppHostelRoom>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Cost).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.FloorName).HasMaxLength(100);

                entity.Property(e => e.RoomNo)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Hostel)
                    .WithMany(p => p.AppHostelRoom)
                    .HasForeignKey(d => d.HostelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppHostel__Hoste__68487DD7");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.AppHostelRoom)
                    .HasForeignKey(d => d.OrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppHostel__OrgId__693CA210");
            });

            modelBuilder.Entity<AppHostelType>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.AppHostelType)
                    .HasForeignKey(d => d.OrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppHostel__OrgId__5FB337D6");
            });

            modelBuilder.Entity<AppLeaveApplication>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.AcademicYid).HasColumnName("AcademicYId");

                entity.Property(e => e.ApprovedByUserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Remark).HasMaxLength(100);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TaskDescription)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.AcademicY)
                    .WithMany(p => p.AppLeaveApplication)
                    .HasForeignKey(d => d.AcademicYid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppLeaveA__Acade__56E8E7AB");

                entity.HasOne(d => d.ApprovedByUser)
                    .WithMany(p => p.AppLeaveApplicationApprovedByUser)
                    .HasForeignKey(d => d.ApprovedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppLeaveA__Appro__55009F39");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.AppLeaveApplication)
                    .HasForeignKey(d => d.OrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppLeaveA__OrgId__55F4C372");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AppLeaveApplicationUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppLeaveA__UserI__540C7B00");
            });

            modelBuilder.Entity<AppLeaveApplicationDay>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.AcademicYid).HasColumnName("AcademicYId");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.HalfPeriod)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.AcademicY)
                    .WithMany(p => p.AppLeaveApplicationDay)
                    .HasForeignKey(d => d.AcademicYid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppLeaveA__Acade__5CA1C101");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.AppLeaveApplicationDay)
                    .HasForeignKey(d => d.OrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppLeaveA__OrgId__5BAD9CC8");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AppLeaveApplicationDay)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppLeaveA__UserI__5AB9788F");
            });

            modelBuilder.Entity<AppOrganization>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.BackgroundImagePath).HasMaxLength(1500);

                entity.Property(e => e.Code).HasColumnType("char(3)");

                entity.Property(e => e.DomainName).HasMaxLength(500);

                entity.Property(e => e.Logo).HasMaxLength(3000);

                entity.Property(e => e.OrganizationAddress).HasMaxLength(1500);

                entity.Property(e => e.OrganizationName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Website).HasMaxLength(100);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.AppOrganization)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK__AppOrgani__CityI__4CA06362");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.AppOrganization)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__AppOrgani__Count__4E88ABD4");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.AppOrganization)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK__AppOrgani__State__4D94879B");
            });

            modelBuilder.Entity<AppOrganizationDepartment>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.AppOrganizationDepartment)
                    .HasForeignKey(d => d.OrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppOrgani__OrgId__52593CB8");
            });

            modelBuilder.Entity<AppOrganizationSubscription>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Cost).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.PlanName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.AppOrganizationSubscription)
                    .HasForeignKey(d => d.OrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppOrgani__OrgId__76969D2E");

                entity.HasOne(d => d.Subscribe)
                    .WithMany(p => p.AppOrganizationSubscription)
                    .HasForeignKey(d => d.SubscribeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppOrgani__Subsc__778AC167");
            });

            modelBuilder.Entity<AppStudentClass>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.AcademicYid).HasColumnName("AcademicYId");

                entity.Property(e => e.RollNo).HasMaxLength(50);

                entity.Property(e => e.StudentId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.AcademicY)
                    .WithMany(p => p.AppStudentClass)
                    .HasForeignKey(d => d.AcademicYid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppStuden__Acade__123EB7A3");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.AppStudentClass)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppStuden__Class__0E6E26BF");

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.AppStudentClass)
                    .HasForeignKey(d => d.DivisionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppStuden__Divis__0F624AF8");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.AppStudentClass)
                    .HasForeignKey(d => d.OrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppStuden__OrgId__114A936A");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.AppStudentClass)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppStuden__Stude__10566F31");
            });

            modelBuilder.Entity<AppStudentExam>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.AcademicYid).HasColumnName("AcademicYId");

                entity.Property(e => e.ExamDate).HasColumnType("datetime");

                entity.Property(e => e.PaperFile).HasMaxLength(2500);

                entity.HasOne(d => d.AcademicY)
                    .WithMany(p => p.AppStudentExam)
                    .HasForeignKey(d => d.AcademicYid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppStuden__Acade__7755B73D");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.AppStudentExam)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppStuden__Class__756D6ECB");

                entity.HasOne(d => d.ExamType)
                    .WithMany(p => p.AppStudentExam)
                    .HasForeignKey(d => d.ExamTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppStuden__ExamT__73852659");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.AppStudentExam)
                    .HasForeignKey(d => d.OrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppStuden__OrgId__76619304");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.AppStudentExam)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppStuden__Subje__74794A92");
            });

            modelBuilder.Entity<AppStudentExamType>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.AcademicYid).HasColumnName("AcademicYId");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.AcademicY)
                    .WithMany(p => p.AppStudentExamType)
                    .HasForeignKey(d => d.AcademicYid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppStuden__Acade__6FB49575");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.AppStudentExamType)
                    .HasForeignKey(d => d.OrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppStuden__OrgId__6EC0713C");
            });

            modelBuilder.Entity<AppStudentFeesStructure>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.AcademicYid).HasColumnName("AcademicYId");

                entity.Property(e => e.Amount).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Remark).HasMaxLength(100);

                entity.Property(e => e.StudentId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.AcademicY)
                    .WithMany(p => p.AppStudentFeesStructure)
                    .HasForeignKey(d => d.AcademicYid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppStuden__Acade__339FAB6E");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.AppStudentFeesStructure)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppStuden__Class__2FCF1A8A");

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.AppStudentFeesStructure)
                    .HasForeignKey(d => d.DivisionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppStuden__Divis__31B762FC");

                entity.HasOne(d => d.FeesType)
                    .WithMany(p => p.AppStudentFeesStructure)
                    .HasForeignKey(d => d.FeesTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppStuden__FeesT__2EDAF651");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.AppStudentFeesStructure)
                    .HasForeignKey(d => d.OrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppStuden__OrgId__32AB8735");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.AppStudentFeesStructure)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppStuden__Stude__30C33EC3");
            });

            modelBuilder.Entity<AppStudentResult>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.AcademicYid).HasColumnName("AcademicYId");

                entity.Property(e => e.InspectorId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.PaperFile).HasMaxLength(2500);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.AcademicY)
                    .WithMany(p => p.AppStudentResult)
                    .HasForeignKey(d => d.AcademicYid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppStuden__Acade__00DF2177");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.AppStudentResult)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppStuden__Class__7EF6D905");

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.AppStudentResult)
                    .HasForeignKey(d => d.DivisionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppStuden__Divis__7E02B4CC");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.AppStudentResult)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppStuden__ExamI__01D345B0");

                entity.HasOne(d => d.Inspector)
                    .WithMany(p => p.AppStudentResultInspector)
                    .HasForeignKey(d => d.InspectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppStuden__Inspe__7C1A6C5A");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.AppStudentResult)
                    .HasForeignKey(d => d.OrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppStuden__OrgId__7FEAFD3E");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.AppStudentResult)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppStuden__Subje__7D0E9093");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AppStudentResultUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppStuden__UserI__7B264821");
            });

            modelBuilder.Entity<AppSubject>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.AcademicYid).HasColumnName("AcademicYId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SubjectCode)
                    .IsRequired()
                    .HasColumnType("char(5)");

                entity.HasOne(d => d.AcademicY)
                    .WithMany(p => p.AppSubject)
                    .HasForeignKey(d => d.AcademicYid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppSubjec__Acade__17036CC0");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.AppSubject)
                    .HasForeignKey(d => d.OrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppSubjec__OrgId__160F4887");
            });

            modelBuilder.Entity<AppTimeTable>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.AcademicYid).HasColumnName("AcademicYId");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.TeacherUserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.AcademicY)
                    .WithMany(p => p.AppTimeTable)
                    .HasForeignKey(d => d.AcademicYid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppTimeTa__Acade__6AEFE058");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.AppTimeTable)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppTimeTa__Class__671F4F74");

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.AppTimeTable)
                    .HasForeignKey(d => d.DivisionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppTimeTa__Divis__681373AD");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.AppTimeTable)
                    .HasForeignKey(d => d.OrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppTimeTa__OrgId__69FBBC1F");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.AppTimeTable)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppTimeTa__Subje__662B2B3B");

                entity.HasOne(d => d.TeacherUser)
                    .WithMany(p => p.AppTimeTable)
                    .HasForeignKey(d => d.TeacherUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppTimeTa__Teach__690797E6");

                entity.HasOne(d => d.Timetbl)
                    .WithMany(p => p.AppTimeTable)
                    .HasForeignKey(d => d.TimetblId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppTimeTa__Timet__65370702");
            });

            modelBuilder.Entity<AppTimeTableType>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.AcademicYid).HasColumnName("AcademicYId");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.AcademicY)
                    .WithMany(p => p.AppTimeTableType)
                    .HasForeignKey(d => d.AcademicYid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppTimeTa__Acade__6166761E");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.AppTimeTableType)
                    .HasForeignKey(d => d.OrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppTimeTa__OrgId__607251E5");
            });

            modelBuilder.Entity<AppUserPermission>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.AppUserPermission)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppUserPe__Permi__5AEE82B9");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.AppUserPermission)
                    .HasForeignKey(d => d.UserTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppUserPe__UserT__5BE2A6F2");
            });

            modelBuilder.Entity<AppUserTask>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.AcademicYid).HasColumnName("AcademicYId");

                entity.Property(e => e.GivenByByUserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Remark).HasMaxLength(100);

                entity.Property(e => e.TaskDate).HasColumnType("datetime");

                entity.Property(e => e.TaskDescription).HasMaxLength(4000);

                entity.Property(e => e.TaskFile).HasMaxLength(2500);

                entity.Property(e => e.TaskName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TaskSubmissionDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.HasOne(d => d.AcademicY)
                    .WithMany(p => p.AppUserTask)
                    .HasForeignKey(d => d.AcademicYid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppUserTa__Acade__503BEA1C");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.AppUserTask)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__AppUserTa__Class__4B7734FF");

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.AppUserTask)
                    .HasForeignKey(d => d.DivisionId)
                    .HasConstraintName("FK__AppUserTa__Divis__4C6B5938");

                entity.HasOne(d => d.GivenByByUser)
                    .WithMany(p => p.AppUserTaskGivenByByUser)
                    .HasForeignKey(d => d.GivenByByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppUserTa__Given__4E53A1AA");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.AppUserTask)
                    .HasForeignKey(d => d.OrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppUserTa__OrgId__4F47C5E3");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AppUserTaskUser)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__AppUserTa__UserI__4D5F7D71");
            });

            modelBuilder.Entity<AppUserType>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Depart)
                    .WithMany(p => p.AppUserType)
                    .HasForeignKey(d => d.DepartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppUserTy__Depar__5629CD9C");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.AppUserType)
                    .HasForeignKey(d => d.OrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppUserTy__OrgId__571DF1D5");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AspNetRol__RoleI__0880433F");
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AspNetUse__UserI__0B5CAFEA");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AspNetUse__UserI__0E391C95");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AspNetUse__RoleI__1209AD79");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AspNetUse__UserI__11158940");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.DateOfJoin).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FatherMobile).HasMaxLength(20);

                entity.Property(e => e.FatherName).HasMaxLength(150);

                entity.Property(e => e.FirstName).HasMaxLength(150);

                entity.Property(e => e.HfatherName)
                    .HasColumnName("HFatherName")
                    .HasMaxLength(150);

                entity.Property(e => e.HfirstName)
                    .HasColumnName("HFirstName")
                    .HasMaxLength(150);

                entity.Property(e => e.HlastName)
                    .HasColumnName("HLastName")
                    .HasMaxLength(150);

                entity.Property(e => e.HmiddleName)
                    .HasColumnName("HMiddleName")
                    .HasMaxLength(150);

                entity.Property(e => e.HmotherName)
                    .HasColumnName("HMotherName")
                    .HasMaxLength(150);

                entity.Property(e => e.LastName).HasMaxLength(150);

                entity.Property(e => e.MiddleName).HasMaxLength(150);

                entity.Property(e => e.Mobile).HasMaxLength(20);

                entity.Property(e => e.MotherMobile).HasMaxLength(20);

                entity.Property(e => e.MotherName).HasMaxLength(150);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PinCode).HasColumnType("char(6)");

                entity.Property(e => e.ProfileImagePath).HasMaxLength(1500);

                entity.Property(e => e.UserAddress).HasMaxLength(1500);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.Property(e => e.WhatsApp).HasMaxLength(20);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK__AspNetUse__CityI__6E01572D");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__AspNetUse__Count__6FE99F9F");

                entity.HasOne(d => d.Hostel)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.HostelId)
                    .HasConstraintName("FK__AspNetUse__Hoste__71D1E811");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.OrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AspNetUse__OrgId__6D0D32F4");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK__AspNetUse__RoomI__70DDC3D8");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK__AspNetUse__State__6EF57B66");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.UserTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AspNetUse__UserT__72C60C4A");
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });

            modelBuilder.Entity<MstCity>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.State)
                    .WithMany(p => p.MstCity)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MstCity__StateId__3F466844");
            });

            modelBuilder.Entity<MstCountry>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<MstPermission>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.MenuCode)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.MenuTitle)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PageUrl)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.MstPermission)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MstPermis__Group__48CFD27E");
            });

            modelBuilder.Entity<MstPermissionsGroup>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<MstState>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.MstState)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MstState__Countr__3B75D760");
            });

            modelBuilder.Entity<MstSubscription>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Cost).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.PlanName)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
