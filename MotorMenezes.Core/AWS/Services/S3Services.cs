using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using MotorMenezes.Core.AWS.Interfaces;
using MotorMenezes.Core.Helpers;
using System.Net;

namespace MotorMenezes.Core.AWS.Services
{
    public class S3Services : IS3Services
    {

        public readonly GlobalVariables _globalVariables;

        public S3Services(GlobalVariables globalVariables)
        {
            _globalVariables = globalVariables;
        }

        private async Task<AmazonS3Client> GetS3Client()
        {
            var credentials = new Amazon.Runtime.BasicAWSCredentials(_globalVariables.S3AccessKeyId, _globalVariables.S3AccessKeySecret);
            var region = Amazon.RegionEndpoint.SAEast1;
            var s3Client = new AmazonS3Client(credentials, region);
            return await Task.FromResult(s3Client);
        }

        public async Task<PutObjectResponse> Upload(string bucketName, string S3PathWithFilename, MemoryStream objectToSend)
        {
            try
            {
                using (var s3Client = await GetS3Client())
                {
                    var objectRequest = new PutObjectRequest()
                    {
                        BucketName = bucketName,
                        Key = S3PathWithFilename,
                        InputStream = objectToSend
                    };

                    var response = await s3Client.PutObjectAsync(objectRequest);

                    return response;
                }
            }
            catch (AmazonS3Exception ex)
            {
                throw new Exception($"Erro ao realizar upload para o container S3. Mensagem: {ex.Message}.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro não previsto ao realizar upload para o container S3. Mensagem:{ex.Message}", ex);
            }
        }

        public async Task<bool> FileExists(string bucketName, string S3PathWithFilename)
        {
            try
            {
                using (var client = await GetS3Client())
                {
                    var obj = new GetObjectMetadataRequest()
                    {
                        BucketName = bucketName,
                        Key = S3PathWithFilename
                    };

                    var response = await client.GetObjectMetadataAsync(obj);

                    if (response.HttpStatusCode == HttpStatusCode.OK)
                        return true;

                    return false;
                }
            }
            catch (AmazonS3Exception ex)
            {
                if (ex.StatusCode == HttpStatusCode.NotFound)
                    return false;

                throw;
            }
        }

        public async Task<MemoryStream> Download(string bucketName, string S3PathWithFilename)
        {
            MemoryStream resposta = new();

            GetObjectRequest request = new()
            {
                BucketName = bucketName,
                Key = S3PathWithFilename
            };

            using (AmazonS3Client s3Client = await GetS3Client())
            {
                await (await new TransferUtility(s3Client).S3Client.GetObjectAsync(request)).ResponseStream.CopyToAsync(resposta);
            }

            return resposta;
        }

        public async Task Deletar(string bucketName, string S3PathWithFilename)
        {
            using (var client = await GetS3Client())
            {
                var deleteObjectRequest = new DeleteObjectRequest
                {
                    BucketName = bucketName,
                    Key = S3PathWithFilename
                };

                await client.DeleteObjectAsync(deleteObjectRequest);
            }
        }

        public string MontarUrlImagem(string bucketName, string regionEndpoint, string S3PathWithFilename)
            => "https://" + bucketName + ".s3." + regionEndpoint + ".amazonaws.com/" + S3PathWithFilename;
    }
}
