using Azure.Storage.Blobs;

namespace WebApplicationECOM.Helper
{
    public static class FileHelper
    {
        public static async Task<string> UploadImage(IFormFile file)
        {
            string filename = Guid.NewGuid().ToString();
            string connectionString = @"DefaultEndpointsProtocol=https;AccountName=shoppingcartaccount;AccountKey=g0Tjm+xJyUtex/Bbj6dQfq7SbHt4f+mMR03hlPjfi7agrvUUMB6fm/Fmyb+bxNlBcVlOXz5iHM2c+AStkvpw/Q==;EndpointSuffix=core.windows.net";
            string containerName = "book-photos";
            BlobContainerClient containerClient = new BlobContainerClient(connectionString, containerName);
            BlobClient blobClient = containerClient.GetBlobClient(filename + file.FileName);
            MemoryStream ms = new MemoryStream();
            await file.CopyToAsync(ms);
            ms.Position = 0;
            await blobClient.UploadAsync(ms);
            return blobClient.Uri.AbsoluteUri;
        }

        public static async Task<string> UploadUrl(IFormFile file)
        {
            string connectionString = @"DefaultEndpointsProtocol=https;AccountName=shoppingcartaccount;AccountKey=g0Tjm+xJyUtex/Bbj6dQfq7SbHt4f+mMR03hlPjfi7agrvUUMB6fm/Fmyb+bxNlBcVlOXz5iHM2c+AStkvpw/Q==;EndpointSuffix=core.windows.net";
            string containerName = "book-url";
            BlobContainerClient containerClient = new BlobContainerClient(connectionString, containerName);
            BlobClient blobClient = containerClient.GetBlobClient(file.FileName);
            MemoryStream ms = new MemoryStream();
            await file.CopyToAsync(ms);
            ms.Position = 0;
            await blobClient.UploadAsync(ms);
            return blobClient.Uri.AbsoluteUri;
        }
    }
}
