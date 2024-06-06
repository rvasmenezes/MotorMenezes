using Microsoft.Extensions.Configuration;

namespace MotorMenezes.Core.Helpers
{
    public class GlobalVariables
    {
        public readonly IConfigurationSection _sectionAWS;

        public GlobalVariables(IConfiguration configuration)
        {
            _sectionAWS = configuration.GetSection("AWS");
        }

        public string S3AccessKeyId => _sectionAWS["S3AccessKeyId"]!;
        public string S3AccessKeySecret => _sectionAWS["S3AccessKeySecret"]!;
        public string S3BucketRegionEndpoint => _sectionAWS["S3BucketRegionEndpoint"]!;
        public string S3BucketExterno => _sectionAWS["S3BucketExterno"]!;
        public string S3UploadPahCNH => _sectionAWS["S3UploadPahCNH"]!;
    }
}
