namespace MVCVendasWeb.Models.ViewModels
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }
        public string Message { get; set; } = null!;

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
