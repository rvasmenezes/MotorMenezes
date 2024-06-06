using Amazon.S3.Model;

namespace MotorMenezes.Core.AWS.Interfaces
{
    public interface IS3Services
    {
        Task<PutObjectResponse> Upload(string bucketName, string S3PathWithFilename, MemoryStream objectToSend);
        Task<bool> FileExists(string bucketName, string S3PathWithFilename);
        Task<MemoryStream> Download(string bucketName, string S3PathWithFilename);
        Task Deletar(string bucketName, string S3PathWithFilename);
        string MontarUrlImagem(string bucketName, string regionEndpoint, string S3PathWithFilename);
    }
}
