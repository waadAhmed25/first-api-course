using AutoMapper;
using DNAAnalysis.Domain.Contracts;
using DNAAnalysis.Services.Abstraction;
using DNAAnalysis.Shared.DrugDtos;
using DNAAnalysis.Domain.Entities.DrugModule;

namespace DNAAnalysis.Services;

public class DrugService : IDrugService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IDrugInteractionClient _drugClient;

    public DrugService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IDrugInteractionClient drugClient)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _drugClient = drugClient;
    }

    // ================= GET ALL =================
    public async Task<IEnumerable<DrugInteractionDto>> GetAllAsync()
    {
        var repo = _unitOfWork.GetRepository<DrugInteraction, int>();
        var drugs = await repo.GetAllAsync();
        return _mapper.Map<IEnumerable<DrugInteractionDto>>(drugs);
    }

    // ================= GET BY ID =================
    public async Task<DrugInteractionDto?> GetByIdAsync(int id)
    {
        var repo = _unitOfWork.GetRepository<DrugInteraction, int>();
        var drug = await repo.GetByIdAsync(id);

        if (drug is null)
            return null;

        return _mapper.Map<DrugInteractionDto>(drug);
    }

    // ================= ADD =================
    public async Task AddAsync(DrugInteractionDto dto)
    {
        var repo = _unitOfWork.GetRepository<DrugInteraction, int>();
        var entity = _mapper.Map<DrugInteraction>(dto);

        await repo.AddAsync(entity);
        await _unitOfWork.SaveChangeAsync();
    }

    // ================= GET USER HISTORY (SQL Filtered) =================
    public async Task<IEnumerable<DrugInteractionDto>> GetUserDrugInteractionsAsync(string userId)
    {
        var repo = _unitOfWork.GetRepository<DrugInteraction, int>();

        var userInteractions =
            await repo.GetAllAsync(d => d.UserId == userId);

        return _mapper.Map<IEnumerable<DrugInteractionDto>>(userInteractions);
    }

    // ================= DELETE =================
    public async Task<bool> DeleteInteractionAsync(int id, string userId)
    {
        var repo = _unitOfWork.GetRepository<DrugInteraction, int>();

        var interaction = await repo.GetByIdAsync(id);

        if (interaction is null)
            return false;

        if (interaction.UserId != userId)
            return false;

        repo.Remove(interaction);

        await _unitOfWork.SaveChangeAsync();

        return true;
    }

    // ================= CHECK INTERACTION (AI) =================
    public async Task<DrugInteractionDto> CheckInteractionAsync(
        CheckDrugInteractionRequest request,
        string userId)
    {
        // 1️⃣ Call AI Client
        var aiResult = await _drugClient.CheckInteractionAsync(request);

        // 2️⃣ Attach UserId
        aiResult.UserId = userId;

        // 3️⃣ Save to Database
        var repo = _unitOfWork.GetRepository<DrugInteraction, int>();
        var entity = _mapper.Map<DrugInteraction>(aiResult);

        await repo.AddAsync(entity);
        await _unitOfWork.SaveChangeAsync();

        return aiResult;
    }
}