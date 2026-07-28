using EnterpriseAppAI.Domain.Entities;

namespace EnterpriseAppAI.Application.Interfaces.Persistence;

/// <summary>
/// Specialized repository for LeaveRequest.
/// Used whenever LeaveRequest navigation properties
/// (Employee, Department, etc.) must be loaded.
/// </summary>
public interface ILeaveRequestRepository
{
    Task<LeaveRequest?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<LeaveRequest>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<LeaveRequest>> GetByEmployeeIdAsync(
        Guid employeeId,
        CancellationToken cancellationToken = default);

    Task AddAsync(
        LeaveRequest leaveRequest,
        CancellationToken cancellationToken = default);

    void Update(LeaveRequest leaveRequest);

    void Delete(LeaveRequest leaveRequest);
}