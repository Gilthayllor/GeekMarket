namespace GeekMarket.Client.Components.Toast
{
    public record ToastItem
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Title { get; set; }
        public ToastTypeEnum ToastType { get; set; }
        public string? Content { get; set; }
        public bool IsVisible { get; set; } = true;

        public ToastItem(ToastTypeEnum type, string title, string? content)
        {
            Title = title;
            ToastType = type;
            Content = content;
        }

        public ToastItem(ToastTypeEnum type, string title) : this(type, title, null) { }

    }
}
