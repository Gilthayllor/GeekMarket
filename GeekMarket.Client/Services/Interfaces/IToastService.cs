using GeekMarket.Client.Components.Toast;

namespace GeekMarket.Client.Services.Interfaces
{
    public interface IToastService
    {
        IReadOnlyList<ToastItem> Toasts { get; }

        event EventHandler OnToastListChanged;

        void AddToast(ToastItem toast);

        void RemoveToast(ToastItem toast);
    }
}
