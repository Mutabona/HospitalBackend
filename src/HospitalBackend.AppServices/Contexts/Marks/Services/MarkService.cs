using HospitalBackend.AppServices.Contexts.Appointments.Services;
using HospitalBackend.AppServices.Contexts.Marks.Repositories;
using HospitalBackend.AppServices.Exceptions;
using HospitalBackend.Contracts.Marks;

namespace HospitalBackend.AppServices.Contexts.Marks.Services;

/// <inheritdoc cref="IMarkService"/>
public class MarkService(IMarkRepository repository, TimeProvider timeProvider, IAppointmentService appointmentService) : IMarkService
{
    ///<inheritdoc/>
    public async Task<Guid> AddAsync(Guid userId, Guid appointmentId, CancellationToken cancellationToken)
    {
        if (!(await appointmentService.IsAppointmentExistsAsync(appointmentId, cancellationToken)))
            throw new ConflictException("Такого назначения не существует.");
        
        var mark = new MarkDto
        {
            AppointmentId = appointmentId,
            UserId = userId,
            IsDone = true,
            Date = DateOnly.FromDateTime(timeProvider.GetUtcNow().UtcDateTime)
        };
        
        return await repository.AddAsync(mark, cancellationToken);
    }
}