using FluentValidation;
using DNAAnalysis.Shared.GeneticRequestDtos;

namespace DNAAnalysis.Api.Validators
{
    public class UpdateRequestStatusValidator 
        : AbstractValidator<UpdateRequestStatusDto>
    {
        public UpdateRequestStatusValidator()
        {
            RuleFor(x => x.Status)
                .NotEmpty()
                .WithMessage("Status is required.");
        }
    }
}