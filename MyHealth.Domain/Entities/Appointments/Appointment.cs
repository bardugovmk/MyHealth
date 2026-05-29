using MyHealth.Domain.Entities.Common;
using MyHealth.Domain.Entities.People;
using MyHealth.Domain.Entities.Scheduling;
using MyHealth.Domain.Entities.Medical;

namespace MyHealth.Domain.Entities.Appointments;

public class Appointment : AuditableEntity
{
    public int PatientId { get; set; }

    public int EmployeeId { get; set; }

    public int TimeSlotId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public string Complaint { get; set; } = string.Empty;

    public string? Notes { get; set; }

    // Navigation
    public Patient Patient { get; set; } = null!;

    public Employee Employee { get; set; } = null!;

    public DoctorTimeSlot TimeSlot { get; set; } = null!;

    public ICollection<AppointmentService> AppointmentServices { get; set; }
    = new List<AppointmentService>();
}