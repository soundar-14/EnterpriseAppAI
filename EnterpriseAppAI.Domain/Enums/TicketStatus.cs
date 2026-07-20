namespace EnterpriseAppAI.Domain.Enums;

/// <summary>
/// Lifecycle status of a service ticket (used starting in a later milestone).
/// </summary>
public enum TicketStatus
{
    Open = 0,
    InProgress = 1,
    OnHold = 2,
    Resolved = 3,
    Closed = 4
}
