using FluentValidation;

namespace EnterpriseAppAI.Application.Features.LeaveRequests.Commands.UpdateLeaveRequest;

public sealed class UpdateLeaveRequestValidator
    : AbstractValidator<UpdateLeaveRequestCommand>
{
    public UpdateLeaveRequestValidator()
    {
        RuleFor(x => x.Reason)
            .NotEmpty()
            .MaximumLength(1000);

        RuleFor(x => x.StartDate)
            .LessThanOrEqualTo(x => x.EndDate)
            .WithMessage("Start date must be before or equal to End date.");
    }
}