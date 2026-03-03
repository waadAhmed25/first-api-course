using FluentValidation;
using DNAAnalysis.Api.Requests;

namespace DNAAnalysis.Api.Validators
{
    public class CreateGeneticRequestFormValidator 
        : AbstractValidator<CreateGeneticRequestFormDto>
    {
        private const long MaxFileSize = 5 * 1024 * 1024; // 5MB
        private readonly string[] AllowedExtensions = { ".txt", ".csv", ".vcf" };

        public CreateGeneticRequestFormValidator()
        {
            RuleFor(x => x)
                .Must(HaveValidFileCombination)
                .WithMessage("You must upload either a combined file OR father and mother files.");

            When(x => x.CombinedFile != null, () =>
            {
                RuleFor(x => x.CombinedFile!)
                    .Must(BeValidFile)
                    .WithMessage("Invalid combined file (type or size).");
            });

            When(x => x.FatherFile != null, () =>
            {
                RuleFor(x => x.FatherFile!)
                    .Must(BeValidFile)
                    .WithMessage("Invalid father file (type or size).");
            });

            When(x => x.MotherFile != null, () =>
            {
                RuleFor(x => x.MotherFile!)
                    .Must(BeValidFile)
                    .WithMessage("Invalid mother file (type or size).");
            });

            When(x => x.ChildFile != null, () =>
            {
                RuleFor(x => x.ChildFile!)
                    .Must(BeValidFile)
                    .WithMessage("Invalid child file (type or size).");
            });
        }

        private bool HaveValidFileCombination(CreateGeneticRequestFormDto dto)
        {
            if (dto.CombinedFile != null)
                return true;

            if (dto.FatherFile != null && dto.MotherFile != null)
                return true;

            return false;
        }

        private bool BeValidFile(IFormFile file)
        {
            if (file.Length == 0 || file.Length > MaxFileSize)
                return false;

            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

            return AllowedExtensions.Contains(extension);
        }
    }
}