using Business.Entities.Enums;
using System.Diagnostics.CodeAnalysis;

namespace Adapter.Controllers.DTOs;

[ExcludeFromCodeCoverage]
public class PaymentWebhook
{
    public string? OrderId { get; set; }    
    public string? PaymentId { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
}
