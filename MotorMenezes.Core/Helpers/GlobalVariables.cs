using Microsoft.Extensions.Configuration;

namespace MotorMenezes.Core.Helpers
{
    public class GlobalVariables
    {
        public readonly IConfigurationSection _sectionAWS;
        public readonly IConfigurationSection _sectionRabbitMQ;

        public GlobalVariables(IConfiguration configuration)
        {
            _sectionAWS = configuration.GetSection("AWS");
            _sectionRabbitMQ = configuration.GetSection("RabbitMQ");
        }

        public string S3AccessKeyId => _sectionAWS["S3AccessKeyId"]!;
        public string S3AccessKeySecret => _sectionAWS["S3AccessKeySecret"]!;
        public string S3BucketRegionEndpoint => _sectionAWS["S3BucketRegionEndpoint"]!;
        public string S3BucketExterno => _sectionAWS["S3BucketExterno"]!;
        public string S3UploadPahCNH => _sectionAWS["S3UploadPahCNH"]!;
        public string LocalStackURL => _sectionAWS["LocalStackURL"]!;
        public string RabbitMQHostName => _sectionRabbitMQ["HostName"]!;
        public int RabbitMQPort => Convert.ToInt32(_sectionRabbitMQ["Port"]!);
        public string RabbitMQUserName => _sectionRabbitMQ["UserName"]!;
        public string RabbitMQPassword => _sectionRabbitMQ["Password"]!;
    }
}
