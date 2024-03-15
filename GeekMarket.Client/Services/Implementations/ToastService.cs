using GeekMarket.Client.Components.Toast;
using GeekMarket.Client.Services.Interfaces;

namespace GeekMarket.Client.Services.Implementations
{
    public class ToastService : IToastService
    {
        public IReadOnlyList<ToastItem> Toasts => _toasts;

        public event EventHandler? OnToastListChanged;

        private List<ToastItem> _toasts = new List<ToastItem>();

        public void RemoveToast(ToastItem? toast)
        {
            if (toast != null)
            {
                _toasts.Remove(toast);
                OnToastUpdated();
            }
        }

        public void AddToast(ToastItem toast)
        {
            _toasts.Add(toast);
            OnToastUpdated();
        }

        private void OnToastUpdated()
        {
            OnToastListChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
