using AutoMapper;
using HospitalBackend.AppServices.Contexts.Analyzes.Repositories;
using HospitalBackend.AppServices.Contexts.Appointments.Services;
using HospitalBackend.AppServices.Exceptions;
using HospitalBackend.Contracts.Analyzes;

namespace HospitalBackend.AppServices.Contexts.Analyzes.Services;

/// <inheritdoc cref="IAnalysisService"/>
public class AnalysisService(IAnalysisRepository repository, IMapper mapper, TimeProvider timeProvider, IAppointmentService appointmentService) : IAnalysisService
{
    ///<inheritdoc/>
    public async Task<Guid> AddAnalysisAsync(Guid appointmentId, AddAnalysisRequest request, CancellationToken cancellationToken)
    {
        if (!(await appointmentService.IsAppointmentExistsAsync(appointmentId, cancellationToken)))
            throw new ConflictException("Такого назначения не существует.");
        var analysis = mapper.Map<AnalysisDto>(request);
        analysis.AppointmentId = appointmentId;
        analysis.Id = Guid.NewGuid();
        analysis.Date = DateOnly.FromDateTime(timeProvider.GetUtcNow().UtcDateTime);
        analysis.HistoryId = await appointmentService.GetHistoryIdByAppointmentIdAsync(appointmentId, cancellationToken);
        return await repository.AddAsync(analysis, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task<ICollection<AnalysisDto>> GetAnalysesByHistoryIdAsync(Guid historyId, CancellationToken cancellationToken)
    {
        return await repository.GetByHistoryIdAsync(historyId, cancellationToken);
    }
    
    ///<inheritdoc/>
    public async Task<AnalysisDto> GetByIdAsync(Guid analysisId, CancellationToken cancellationToken)
    {
        return await repository.GetByIdAsync(analysisId, cancellationToken);
    }
}