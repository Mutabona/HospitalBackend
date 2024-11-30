using AutoMapper;
using HospitalBackend.AppServices.Contexts.Appointments.Repositories;
using HospitalBackend.Contracts.Appointments;

namespace HospitalBackend.AppServices.Contexts.Appointments.Services;

/// <inheritdoc cref="IAppointmentService"/>
public class AppointmentService(IAppointmentRepository repository, IMapper mapper, TimeProvider timeProvider) : IAppointmentService
{
    ///<inheritdoc/>
    public async Task<Guid> AddAsync(Guid examinationId, AddAppointmentRequest request, CancellationToken cancellationToken)
    {
        var appointment = mapper.Map<AppointmentDto>(request);
        appointment.ExaminationId = examinationId;
        appointment.Id = Guid.NewGuid();
        appointment.Date = DateOnly.FromDateTime(timeProvider.GetUtcNow().UtcDateTime);
        
        return await repository.AddAppointmentAsync(appointment, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task<AppointmentDto> GetByIdAsync(Guid appointmentId, CancellationToken cancellationToken)
    {
        return await repository.GetByIdAsync(appointmentId, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task<ICollection<AppointmentDto>> GetByHistoryIdAsync(Guid historyId, CancellationToken cancellationToken)
    {
        return await repository.GetAppointmentsByHistoryIdAsync(historyId, cancellationToken);
    }
}