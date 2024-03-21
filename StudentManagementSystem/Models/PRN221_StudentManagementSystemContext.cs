using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StudentManagementSystem.Models
{
    public partial class PRN221_StudentManagementSystemContext : DbContext
    {
        public PRN221_StudentManagementSystemContext()
        {
        }

        public PRN221_StudentManagementSystemContext(DbContextOptions<PRN221_StudentManagementSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<ClassSubject> ClassSubjects { get; set; } = null!;
        public virtual DbSet<ExamSchedule> ExamSchedules { get; set; } = null!;
        public virtual DbSet<Excercy> Excercies { get; set; } = null!;
        public virtual DbSet<Lecture> Lectures { get; set; } = null!;
        public virtual DbSet<Major> Majors { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<Semester> Semesters { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentsExcercy> StudentsExcercies { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DbConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__Admin__F3DBC573716CDCEA");

                entity.ToTable("Admin");

                entity.HasIndex(e => e.Phone, "UQ__Admin__B43B145F895A80E4")
                    .IsUnique();

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.AdminName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("admin_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.RoleId).HasColumnName("role_id");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.ClassClassName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("class_className");
            });

            modelBuilder.Entity<ClassSubject>(entity =>
            {
                entity.HasKey(e => new { e.ClassSubjectId, e.Slot, e.Date, e.Room, e.LectureId, e.SubjectId })
                    .HasName("PK__Class_Su__DAA4A24DED7050B1");

                entity.ToTable("Class_Subject");

                entity.Property(e => e.ClassSubjectId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("class_subject_id");

                entity.Property(e => e.Slot).HasColumnName("slot");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.Room)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("room");

                entity.Property(e => e.LectureId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("lecture_id");

                entity.Property(e => e.SubjectId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("subject_id");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.NumberOfStudents).HasColumnName("number_of_students");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.ClassSubjects)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_Class_Subject_Classes");

                entity.HasOne(d => d.Lecture)
                    .WithMany(p => p.ClassSubjects)
                    .HasForeignKey(d => d.LectureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKClass_Subj109304");

                entity.HasOne(d => d.RoomNavigation)
                    .WithMany(p => p.ClassSubjects)
                    .HasForeignKey(d => d.Room)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKClass_Subj765984");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.ClassSubjects)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKClass_Subj688945");
            });

            modelBuilder.Entity<ExamSchedule>(entity =>
            {
                entity.ToTable("Exam_Schedule");

                entity.Property(e => e.ExamScheduleId).HasColumnName("exam_schedule_id");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.DateOfPublic)
                    .HasColumnType("date")
                    .HasColumnName("date_of_public");

                entity.Property(e => e.DateOfPublicResit)
                    .HasColumnType("date")
                    .HasColumnName("date_of_public_resit");

                entity.Property(e => e.DateOfResit)
                    .HasColumnType("date")
                    .HasColumnName("date_of_resit");

                entity.Property(e => e.LectureId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("lecture_id");

                entity.Property(e => e.Room)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("room");

                entity.Property(e => e.SemesterId).HasColumnName("semester_id");

                entity.Property(e => e.SubjectId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("subject_id");

                entity.Property(e => e.TimeFrom)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("time_from");

                entity.Property(e => e.TimeFromResit)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("time_from_resit");

                entity.Property(e => e.TimeTo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("time_to");

                entity.Property(e => e.TimeToResit)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("time_to_resit");

                entity.Property(e => e.TypeOfExam)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("type_of_exam");

                entity.HasOne(d => d.Lecture)
                    .WithMany(p => p.ExamSchedules)
                    .HasForeignKey(d => d.LectureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKExam_Sched511942");

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.ExamSchedules)
                    .HasForeignKey(d => d.SemesterId)
                    .HasConstraintName("FK_Exam_Schedule_Semester");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.ExamSchedules)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKExam_Sched39290");
            });

            modelBuilder.Entity<Excercy>(entity =>
            {
                entity.HasKey(e => e.ExerciseName)
                    .HasName("PK__Excercie__44AB11D9D8E394E5");

                entity.Property(e => e.ExerciseName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("exercise_name");

                entity.Property(e => e.Dateline)
                    .HasColumnType("datetime")
                    .HasColumnName("dateline");

                entity.Property(e => e.Percentage).HasColumnName("percentage");

                entity.Property(e => e.SubjectId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("subject_id");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Excercies)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKExcercies435330");
            });

            modelBuilder.Entity<Lecture>(entity =>
            {
                entity.HasIndex(e => e.Phone, "UQ__Lectures__B43B145FB2719904")
                    .IsUnique();

                entity.HasIndex(e => e.LectureEmail, "UQ__Lectures__DADF7035E460882C")
                    .IsUnique();

                entity.Property(e => e.LectureId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("lecture_id");

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("dob");

                entity.Property(e => e.LectureEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("lecture_email");

                entity.Property(e => e.LectureName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("lecture_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.RoleId).HasColumnName("role_id");
            });

            modelBuilder.Entity<Major>(entity =>
            {
                entity.HasIndex(e => e.MajorName, "UQ__Majors__B2815F7A6E93E39A")
                    .IsUnique();

                entity.Property(e => e.MajorId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("major_id");

                entity.Property(e => e.MajorName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("major_name");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.RoomId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("room_id");
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.ToTable("Semester");

                entity.Property(e => e.SemesterId).HasColumnName("semester_id");

                entity.Property(e => e.ClassSemesterName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("class_semester_name");

                entity.Property(e => e.Year).HasColumnName("year");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasIndex(e => e.StudentEmail, "UQ__Students__820A8F3E1144F201")
                    .IsUnique();

                entity.HasIndex(e => e.Phone, "UQ__Students__B43B145FB1EA2B2E")
                    .IsUnique();

                entity.Property(e => e.StudentId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("student_id");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("dob");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.MajorId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("major_id");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Semester).HasColumnName("semester");

                entity.Property(e => e.StudentEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("student_email");

                entity.Property(e => e.StudentName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("student_name");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_Students_Classes");

                entity.HasOne(d => d.Major)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.MajorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKStudents8281");

                entity.HasMany(d => d.ExamSchedules)
                    .WithMany(p => p.Students)
                    .UsingEntity<Dictionary<string, object>>(
                        "StudentsExamSchedule",
                        l => l.HasOne<ExamSchedule>().WithMany().HasForeignKey("ExamScheduleId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FKStudents_E449250"),
                        r => r.HasOne<Student>().WithMany().HasForeignKey("StudentId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FKStudents_E743912"),
                        j =>
                        {
                            j.HasKey("StudentId", "ExamScheduleId").HasName("PK__Students__2CD42807F985A91A");

                            j.ToTable("Students_Exam_Schedule");

                            j.IndexerProperty<string>("StudentId").HasMaxLength(255).IsUnicode(false).HasColumnName("student_id");

                            j.IndexerProperty<int>("ExamScheduleId").HasColumnName("exam_schedule_id");
                        });
            });

            modelBuilder.Entity<StudentsExcercy>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.ExerciseName })
                    .HasName("PK__Students__AE79B7878D9E5CDE");

                entity.ToTable("Students_Excercies");

                entity.Property(e => e.StudentId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("student_id");

                entity.Property(e => e.ExerciseName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("exercise_name");

                entity.Property(e => e.Mark).HasColumnName("mark");

                entity.HasOne(d => d.ExerciseNameNavigation)
                    .WithMany(p => p.StudentsExcercies)
                    .HasForeignKey(d => d.ExerciseName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKStudents_E930074");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentsExcercies)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKStudents_E938209");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasIndex(e => e.SubjectName, "UQ__Subjects__40817661D499C7D5")
                    .IsUnique();

                entity.Property(e => e.SubjectId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("subject_id");

                entity.Property(e => e.Credit).HasColumnName("credit");

                entity.Property(e => e.SubjectName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("subject_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
