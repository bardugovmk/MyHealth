using Microsoft.EntityFrameworkCore;
using MyHealth.Application.Abstractions.Persistence;
using MyHealth.Domain.Entities.Identity;
using MyHealth.Domain.Entities.People;
using MyHealth.Domain.Entities.Scheduling;
using MyHealth.Domain.Entities.Appointments;
using MyHealth.Domain.Entities.Medical;

namespace MyHealth.Persistence.Contexts;

public class MyHealthDbContext : DbContext, IPersistenceContext
{
    public MyHealthDbContext(DbContextOptions<MyHealthDbContext> options)
        : base(options)
    {
    }

    // Identity
    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<UserRole> UserRoles { get; set; }

    // People
    public DbSet<Patient> Patients { get; set; }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<Doctor> Doctors { get; set; }

    public DbSet<Specialization> Specializations { get; set; }

    // Scheduling
    public DbSet<Cabinet> Cabinets { get; set; }

    public DbSet<DoctorSchedule> DoctorSchedules { get; set; }

    public DbSet<DoctorTimeSlot> DoctorTimeSlots { get; set; }

    // Appointments
    public DbSet<Appointment> Appointments { get; set; }

    public DbSet<AppointmentService> AppointmentServices { get; set; }

    // Medical
    public DbSet<MedicalRecord> MedicalRecords { get; set; }

    public DbSet<Prescription> Prescriptions { get; set; }

    public DbSet<MedicalRecordAttachment> MedicalRecordAttachments { get; set; }

    public DbSet<MedicalService> MedicalServices { get; set; }

    public DbSet<ServiceComponent> ServiceComponents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyHealthDbContext).Assembly);
    }
}