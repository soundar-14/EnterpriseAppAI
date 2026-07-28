using EnterpriseAppAI.Application.Common.Exceptions;
using EnterpriseAppAI.Application.Features.LeaveRequests.DTOs;
using EnterpriseAppAI.Application.Features.LeaveRequests.Mappings;
using EnterpriseAppAI.Application.Interfaces.Persistence;
using EnterpriseAppAI.Domain.Entities;
using MediatR;

namespace EnterpriseAppAI.Application.Features.LeaveRequests.Queries.GetLeaveRequestById;

public sealed class GetLeaveRequestByIdQueryHandler
    : IRequestHandler<GetLeaveRequestByIdQuery, LeaveRequestDto>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    public GetLeaveRequestByIdQueryHandler(
     ILeaveRequestRepository leaveRequestRepository)
    {
        _leaveRequestRepository = leaveRequestRepository;
    }

    public async Task<LeaveRequestDto> Handle(
        GetLeaveRequestByIdQuery request,
        CancellationToken cancellationToken)
    {
        var leave = await _leaveRequestRepository.GetByIdAsync(
        request.Id,
        cancellationToken);

        return leave?.ToDto()
            ?? throw new NotFoundException(
                nameof(LeaveRequest),
                request.Id);
    }
}