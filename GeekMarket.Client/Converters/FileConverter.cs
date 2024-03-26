using Microsoft.AspNetCore.Components.Forms;

namespace GeekMarket.Client.Converters
{
    public class FileConverter : IFileConverter
    {
        private const string _separator = "|";

        public async Task<string> ToBase64(IBrowserFile file)
        {
            using var memoryStream = new MemoryStream();
            
            await file.OpenReadStream(5242880).CopyToAsync(memoryStream);
            
            byte[] fileBytes = memoryStream.ToArray();

            string fileName = file.Name;

            string base64 = $"{fileName}{_separator}{Convert.ToBase64String(fileBytes)}";
            
            return base64;
        }

        public (string FileName, string FileExtension, string Base64) GetPropertiesFromBase64(string base64)
        {
            var splited = base64.Split(_separator);

            string fileName = string.Empty;
            string fileExtension = string.Empty;
            string formatedBase64 = string.Empty;

            if (splited.Length > 1)
            {
                fileName = splited[0];
                fileExtension = Path.GetExtension(fileName);
                formatedBase64 = splited[1];
            }

            return (fileName, fileExtension, formatedBase64);
        }
    }
}
