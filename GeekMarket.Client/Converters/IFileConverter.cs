using Microsoft.AspNetCore.Components.Forms;

namespace GeekMarket.Client.Converters
{
    public interface IFileConverter
    {
        Task<string> ToBase64(IBrowserFile file);
        (string FileName, string FileExtension, string Base64) GetPropertiesFromBase64(string base64);
    }
}
