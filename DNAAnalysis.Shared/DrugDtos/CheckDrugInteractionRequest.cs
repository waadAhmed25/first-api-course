namespace DNAAnalysis.Shared.DrugDtos;

public class CheckDrugInteractionRequest
{
    public string Drug1 { get; set; } = string.Empty;
    public string Drug2 { get; set; } = string.Empty;
}