using Microsoft.AspNetCore.Components;
using PrintConnect.Domain.Entities;

namespace PrintConnect.Client.Pages;

public partial class PrinterNavBar : ComponentBase
{
    private Printer? Printer { get; set; } = Printer.Create("http://192.168.178.158/", "maker", "WpZhQTj86AKwX4z",
        "ger-de-printer", "je moeder", "prusa mk4s");

    private void SetPrinterReady()
    {
        throw new NotImplementedException();
    }
}