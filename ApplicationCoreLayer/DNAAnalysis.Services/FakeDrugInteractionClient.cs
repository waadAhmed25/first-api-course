using DNAAnalysis.Services.Abstraction;
using DNAAnalysis.Shared.DrugDtos;

namespace DNAAnalysis.Services;

public class FakeDrugInteractionClient : IDrugInteractionClient
{
    public Task<DrugInteractionDto> CheckInteractionAsync(CheckDrugInteractionRequest request)
    {
        var result = new DrugInteractionDto
        {
            Drug1 = request.Drug1,
            Drug2 = request.Drug2,
            HasInteraction = true,
            Severity = "High",
            Description = "Severe interaction detected between the two drugs."
        };

        return Task.FromResult(result);
    }
}