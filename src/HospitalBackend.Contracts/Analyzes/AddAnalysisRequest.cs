namespace HospitalBackend.Contracts.Analyzes;

/// <summary>
/// Запрос на добавление анализа.
/// </summary>
public class AddAnalysisRequest
{
    /// <summary>
    /// Тип анализа
    /// </summary>
    public string Type { get; set; }
    
    /// <summary>
    /// Результаты анализа
    /// </summary>
    public string Result { get; set; }
}