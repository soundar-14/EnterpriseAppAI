using EnterpriseAppAI.Application.Features.LeaveRequests.DTOs;
using EnterpriseAppAI.Application.Features.LeaveRequests.Mappings;
using EnterpriseAppAI.Application.Interfaces.Persistence;
using MediatR;

namespace EnterpriseAppAI.Application.Features.LeaveRequests.Queries.GetEmployeeLeaveHistory;

public sealed class GetEmployeeLeaveHistoryQueryHandler
    : IRequestHandler<GetEmployeeLeaveHistoryQuery, IReadOnlyList<LeaveRequestDto>>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;

    public GetEmployeeLeaveHistoryQueryHandler(
    ILeaveRequestRepository leaveRequestRepository)
    {
        _leaveRequestRepository = leaveRequestRepository;
    }

    public async Task<IReadOnlyList<LeaveRequestDto>> Handle(
        GetEmployeeLeaveHistoryQuery request,
        CancellationToken cancellationToken)
    {
        var leaves = await _leaveRequestRepository
    .GetByEmployeeIdAsync(
        request.EmployeeId,
        cancellationToken);

        return leaves
            .Select(x => x.ToDto())
            .ToList();
    }
}