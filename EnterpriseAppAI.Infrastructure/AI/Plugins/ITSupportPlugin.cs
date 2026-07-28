using EnterpriseAppAI.Infrastructure.AI.Abstractions;
using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace EnterpriseAppAI.Infrastructure.AI.Plugins;

/// <summary>
/// IT Support related AI capabilities.
/// </summary>
public sealed class ITSupportPlugin : IAIPlugin
{
    [KernelFunction]
    [Description("Creates a password reset request.")]
    public string ResetPassword(
        [Description("Employee Number")] string employeeNumber)
    {
        return $"Password reset request has been created for employee {employeeNumber}. IT Support will contact you shortly.";
    }

    [KernelFunction]
    [Description("Creates a laptop request.")]
    public string RequestLaptop(
        [Description("Employee Number")] string employeeNumber)
    {
        return $"Laptop request has been submitted for employee {employeeNumber}. Approval from the reporting manager is required.";
    }

    [KernelFunction]
    [Description("Creates a software installation request.")]
    public string RequestSoftware(
        [Description("Software Name")] string softwareName)
    {
        return $"Software installation request for '{softwareName}' has been created and forwarded to the IT team.";
    }

    [KernelFunction]
    [Description("Returns VPN setup instructions.")]
    public string GetVPNGuide()
    {
        return """
            VPN Setup

            1. Install Enterprise VPN Client.
            2. Enter your company email.
            3. Authenticate using MFA.
            4. Connect to Enterprise VPN.

            Contact IT Support if connection fails.
            """;
    }

    [KernelFunction]
    [Description("Returns IT Helpdesk contact information.")]
    public string GetITSupportContact()
    {
        return """
            IT Helpdesk

            Email : itsupport@enterpriseappai.com
            Phone : +91-9123456789

            Working Hours

            Monday-Friday
            9:00 AM - 6:00 PM
            """;
    }

    [KernelFunction]
    [Description("Creates a generic IT support ticket.")]
    public string RaiseSupportTicket(
        [Description("Issue Description")] string issue)
    {
        return $"IT Support ticket has been created successfully.\n\nIssue: {issue}\n\nOur support team will contact you soon.";
    }
}