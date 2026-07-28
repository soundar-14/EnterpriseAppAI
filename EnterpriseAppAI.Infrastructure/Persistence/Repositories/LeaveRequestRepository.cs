using EnterpriseAppAI.Application.Interfaces.Persistence;
using EnterpriseAppAI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseAppAI.Infrastructure.Persistence.Repositories;

public sealed class LeaveRequestRepository : ILeaveRequestRepository
{
    private readonly ApplicationDbContext _context;

    public LeaveRequestRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<LeaveRequest?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _context.LeaveRequests
            .Include(x => x.Employee)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<LeaveRequest>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.LeaveRequests
            .Include(x => x.Employee)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<LeaveRequest>> GetByEmployeeIdAsync(
        Guid employeeId,
        CancellationToken cancellationToken = default)
    {
        return await _context.LeaveRequests
            .Include(x => x.Employee)
            .Where(x => x.EmployeeId == employeeId)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(
        LeaveRequest leaveRequest,
        CancellationToken cancellationToken = default)
    {
        await _context.LeaveRequests.AddAsync(leaveRequest, cancellationToken);
    }

    public void Update(LeaveRequest leaveRequest)
    {
        _context.LeaveRequests.Update(leaveRequest);
    }

    public void Delete(LeaveRequest leaveRequest)
    {
        _context.LeaveRequests.Remove(leaveRequest);
    }
}