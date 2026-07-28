using EnterpriseAppAI.Infrastructure.AI.Abstractions;
using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace EnterpriseAppAI.Infrastructure.AI.Plugins;

/// <summary>
/// HR-related AI capabilities.
/// </summary>
public sealed class HRPlugin : IAIPlugin
{
    [KernelFunction]
    [Description("Returns the company's working hours.")]
    public string GetWorkingHours()
    {
        return """
            Company Working Hours

            • Monday - Friday
            • 9:00 AM - 6:00 PM
            • Lunch Break: 1:00 PM - 2:00 PM
            • Saturday & Sunday are holidays.
            """;
    }

    [KernelFunction]
    [Description("Returns the HR contact information.")]
    public string GetHRContact()
    {
        return """
            HR Contact Information

            Email : hr@enterpriseappai.com
            Phone : +91-9876543210
            Working Hours : Monday-Friday, 9 AM - 6 PM
            """;
    }

    [KernelFunction]
    [Description("Returns the leave policy.")]
    public string GetLeavePolicy()
    {
        return """
            Leave Policy

            • Casual Leave : 12 days/year
            • Sick Leave : 10 days/year
            • Earned Leave : 15 days/year
            • Maternity Leave : As per company policy
            • Paternity Leave : 5 working days

            Leave requests require manager approval.
            """;
    }

    [KernelFunction]
    [Description("Returns company holiday information.")]
    public string GetHolidayCalendar()
    {
        return """
            Company Holidays

            • New Year's Day
            • Republic Day
            • Independence Day
            • Gandhi Jayanti
            • Deepavali
            • Christmas

            Additional regional holidays may apply.
            """;
    }

    [KernelFunction]
    [Description("Returns employee benefits.")]
    public string GetEmployeeBenefits()
    {
        return """
            Employee Benefits

            • Medical Insurance
            • Life Insurance
            • Provident Fund
            • Gratuity
            • Annual Performance Bonus
            • Learning & Certification Support
            """;
    }
}