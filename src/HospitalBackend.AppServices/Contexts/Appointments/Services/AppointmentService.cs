using AutoMapper;
using HospitalBackend.AppServices.Contexts.Appointments.Repositories;
using HospitalBackend.AppServices.Contexts.Examinations.Services;
using HospitalBackend.AppServices.Exceptions;
using HospitalBackend.Contracts.Appointments;

namespace HospitalBackend.AppServices.Contexts.Appointments.Services;

/// <inheritdoc cref="IAppointmentService"/>
public class AppointmentService(IAppointmentRepository repository, IMapper mapper, TimeProvider timeProvider, IExaminationService examinationService) : IAppointmentService
{
    ///<inheritdoc/>
    public async Task<Guid> AddAsync(Guid examinationId, AddAppointmentRequest request, CancellationToken cancellationToken)
    {
        if (!(await examinationService.IsExaminationExistsAsync(examinationId, cancellationToken)))
            throw new ConflictException("Такого осмотра не существует.");
        
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

    ///<inheritdoc/>
    public async Task<Guid> GetHistoryIdByAppointmentIdAsync(Guid appointmentId, CancellationToken cancellationToken)
    {
        return await repository.GetHistoryIdByAppointmentIdAsync(appointmentId, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task<bool> IsAppointmentExistsAsync(Guid appointmentId, CancellationToken cancellationToken)
    {
        try
        {
            await repository.GetByIdAsync(appointmentId, cancellationToken);
        }
        catch (EntityNotFoundException)
        {
            return false;
        }
        return true;
    }
}