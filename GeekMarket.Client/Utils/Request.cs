namespace GeekMarket.Client.Utils
{
    public class Request
    {
        public MethodTypeEnumeration Method { get; set; } = MethodTypeEnumeration.GET;
        public string Url { get; set; } = null!;
        public Dictionary<string, string>? QueryParameters { get; set; }
        public object? Data { get; set; }

        public enum MethodTypeEnumeration
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
