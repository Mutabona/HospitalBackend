using AutoMapper;
using AutoMapper.QueryableExtensions;
using HospitalBackend.AppServices.Contexts.Appointments.Repositories;
using HospitalBackend.AppServices.Exceptions;
using HospitalBackend.Contracts.Appointments;
using HospitalBackend.Domain.Appointments;
using HospitalBackend.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace HospitalBackend.DataAccess.Appointments;

/// <inheritdoc cref="IAppointmentRepository"/>
public class AppointmentRepository(IRepository<Appointment> repository, IMapper mapper) : IAppointmentRepository
{
    ///<inheritdoc/>
    public async Task<Guid> AddAppointmentAsync(AppointmentDto appointment, CancellationToken cancellationToken)
    {
        return await repository.AddAsync(mapper.Map<Appointment>(appointment), cancellationToken);
    }

    ///<inheritdoc/>
    public async Task<AppointmentDto> GetByIdAsync(Guid appointmentId, CancellationToken cancellationToken)
    {
        var appointment = await repository
            .GetAll()
            .Include(x => x.Examination)
            .Include(x => x.Examination.User)
            .Include(x => x.Examination.History)
            .Include(x => x.Examination.History.Patient)
            .Include(x => x.Mark)
            .Where(x => x.Id == appointmentId)
            .ProjectTo<AppointmentDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
        
        if (appointment == null) throw new EntityNotFoundException();
        
        return appointment;
    }

    ///<inheritdoc/>
    public async Task<ICollection<AppointmentDto>> GetAppointmentsByHistoryIdAsync(Guid historyId, CancellationToken cancellationToken)
    {
        var appointments = await repository
            .GetAll()
            .Include(x => x.Examination)
            .Include(x => x.Examination.User)
            .Include(x => x.Examination.History)
            .Include(x => x.Examination.History.Patient)
            .Include(x => x.Mark)
            .Where(x => x.Examination.HistoryId == historyId)
            .ProjectTo<AppointmentDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        if (appointments.Count == 0) throw new EntityNotFoundException();
        
        return appointments;
    }
}