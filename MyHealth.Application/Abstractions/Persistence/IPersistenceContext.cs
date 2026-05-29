using Microsoft.EntityFrameworkCore;
using MyHealth.Domain.Entities.Identity;
using MyHealth.Domain.Entities.People;
using MyHealth.Domain.Entities.Scheduling;
using MyHealth.Domain.Entities.Appointments;
using MyHealth.Domain.Entities.Medical;

namespace MyHealth.Application.Abstractions.Persistence;

public interface IPersistenceContext
{
    // Identity
    DbSet<User> Users { get; }
    DbSet<Role> Roles { get; }
    DbSet<UserRole> UserRoles { get; }

    // People
    DbSet<Patient> Patients { get; }
    DbSet<Employee> Employees { get; }
    DbSet<Doctor> Doctors { get; }
    DbSet<Specialization> Specializations { get; }

    // Scheduling
    DbSet<Cabinet> Cabinets { get; }
    DbSet<DoctorSchedule> DoctorSchedules { get; }
    DbSet<DoctorTimeSlot> DoctorTimeSlots { get; }

    // Appointments
    DbSet<Appointment> Appointments { get; }
    DbSet<AppointmentService> AppointmentServices { get; }

    // Medical
    DbSet<MedicalRecord> MedicalRecords { get; }
    DbSet<Prescription> Prescriptions { get; }
    DbSet<MedicalRecordAttachment> MedicalRecordAttachments { get; }

    DbSet<MedicalService> MedicalServices { get; }
    DbSet<ServiceComponent> ServiceComponents { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}