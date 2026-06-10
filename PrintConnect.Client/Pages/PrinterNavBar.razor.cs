using Microsoft.AspNetCore.Components;
using PrintConnect.Domain.Entities;

namespace PrintConnect.Client.Pages;

public partial class PrinterNavBar : ComponentBase
{
    [Parameter]
    public Printer? Printer { get; set; }
}