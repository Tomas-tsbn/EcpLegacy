using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace EcpLegacy.API
{
    public partial class EcpLegacyContext : DbContext
    {
        public EcpLegacyContext()
        {
        }
        public EcpLegacyContext(DbContextOptions<EcpLegacyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<ActivityAssociate> ActivityAssociate { get; set; }
        public virtual DbSet<ActivityStatus> ActivityStatus { get; set; }
        public virtual DbSet<Associate> Associate { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<ProjectPhase> ProjectPhase { get; set; }
        public virtual DbSet<ProjectState> ProjectState { get; set; }
        public virtual DbSet<ProjectStateHistory> ProjectStateHistory { get; set; }

        // Unable to generate entity type for table 'dbo.Planering'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Table_1'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.testTable'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer(Configuration.GetConnectionString("EcpDatabase"));
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-B6UNSD2\SQLEXPRESS;Database=EcpLegacy;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Activity>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdbyid).HasColumnName("createdbyid");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Datemodified)
                    .HasColumnName("datemodified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifiedbyid).HasColumnName("modifiedbyid");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Plannedhours).HasColumnName("plannedhours");

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.Projectphaseid).HasColumnName("projectphaseid");

                entity.Property(e => e.Remarks).HasColumnName("remarks");

                entity.Property(e => e.Responsible).HasColumnName("responsible");

                entity.Property(e => e.Statusid).HasColumnName("statusid");

                entity.Property(e => e.Week)
                    .HasColumnName("week")
                    .HasMaxLength(7);

                entity.Property(e => e.Year)
                    .HasColumnName("year")
                    .HasMaxLength(4);

                entity.HasOne(d => d.Projectphase)
                    .WithMany(p => p.Activity)
                    .HasForeignKey(d => d.Projectphaseid)
                    .HasConstraintName("FK_Activity_ProjectPhase");

                entity.HasOne(d => d.ResponsibleNavigation)
                    .WithMany(p => p.Activity)
                    .HasForeignKey(d => d.Responsible)
                    .HasConstraintName("FK_Activity_Associate");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Activity)
                    .HasForeignKey(d => d.Statusid)
                    .HasConstraintName("FK_Activity_ActivityStatus");
            });

            modelBuilder.Entity<ActivityAssociate>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activityid).HasColumnName("activityid");

                entity.Property(e => e.Associateid).HasColumnName("associateid");

                entity.Property(e => e.Createdbyid).HasColumnName("createdbyid");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Datemodified)
                    .HasColumnName("datemodified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifiedbyid).HasColumnName("modifiedbyid");

                entity.Property(e => e.Plannedhours).HasColumnName("plannedhours");

                entity.Property(e => e.Workedhours).HasColumnName("workedhours");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.ActivityAssociate)
                    .HasForeignKey(d => d.Activityid)
                    .HasConstraintName("FK_ActivityAssociate_Activity");

                entity.HasOne(d => d.Associate)
                    .WithMany(p => p.ActivityAssociate)
                    .HasForeignKey(d => d.Associateid)
                    .HasConstraintName("FK_ActivityAssociate_Associate");
            });

            modelBuilder.Entity<ActivityStatus>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdbyid).HasColumnName("createdbyid");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Datemodified)
                    .HasColumnName("datemodified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifiedbyid).HasColumnName("modifiedbyid");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Remarks).HasColumnName("remarks");
            });

            modelBuilder.Entity<Associate>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Accesskey)
                    .HasColumnName("accesskey")
                    .HasMaxLength(50);

                entity.Property(e => e.Createdbyid).HasColumnName("createdbyid");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Datemodified)
                    .HasColumnName("datemodified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Frendlyname)
                    .HasColumnName("frendlyname")
                    .HasMaxLength(50);

                entity.Property(e => e.Modifiedbyid).HasColumnName("modifiedbyid");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(255);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdbyid).HasColumnName("createdbyid");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Datemodified)
                    .HasColumnName("datemodified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifiedbyid).HasColumnName("modifiedbyid");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Clientid).HasColumnName("clientid");

                entity.Property(e => e.Completed).HasColumnName("completed");

                entity.Property(e => e.Createdbyid).HasColumnName("createdbyid");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Datemodified)
                    .HasColumnName("datemodified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifiedbyid).HasColumnName("modifiedbyid");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Pn)
                    .HasColumnName("pn")
                    .HasMaxLength(100);

                entity.Property(e => e.Pnname)
                    .HasColumnName("pnname")
                    .HasMaxLength(255);

                entity.Property(e => e.Remarks).HasColumnName("remarks");

                entity.Property(e => e.Soldhours).HasColumnName("soldhours");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.Clientid)
                    .HasConstraintName("FK_Project_Client");
            });

            modelBuilder.Entity<ProjectPhase>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdbyid).HasColumnName("createdbyid");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Datemodified)
                    .HasColumnName("datemodified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifiedbyid).HasColumnName("modifiedbyid");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Projectid).HasColumnName("projectid");

                entity.Property(e => e.Remarks).HasColumnName("remarks");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectPhase)
                    .HasForeignKey(d => d.Projectid)
                    .HasConstraintName("FK_ProjectPhase_Project");
            });

            modelBuilder.Entity<ProjectState>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Createdbyid).HasColumnName("createdbyid");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Datemodified)
                    .HasColumnName("datemodified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Modifiedbyid).HasColumnName("modifiedbyid");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ProjectStateHistory>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Createdbyid).HasColumnName("createdbyid");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Datemodified)
                    .HasColumnName("datemodified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Decisiondate)
                    .HasColumnName("decisiondate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Documentid).HasColumnName("documentid");

                entity.Property(e => e.Modifiedbyid).HasColumnName("modifiedbyid");

                entity.Property(e => e.Projectid).HasColumnName("projectid");

                entity.Property(e => e.Projectstateid).HasColumnName("projectstateid");

                entity.Property(e => e.Remarks).HasColumnName("remarks");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectStateHistory)
                    .HasForeignKey(d => d.Projectid)
                    .HasConstraintName("FK_ProjectStateHistory_Project");

                entity.HasOne(d => d.Projectstate)
                    .WithMany(p => p.ProjectStateHistory)
                    .HasForeignKey(d => d.Projectstateid)
                    .HasConstraintName("FK_ProjectStateHistory_ProjectState");
            });
        }
    }
}
