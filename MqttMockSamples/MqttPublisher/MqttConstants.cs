namespace MqttPublisher
{
    static class MqttConstants
    {
        // client info
        public const string ClientId = "PublisherId";
        public const int Port = 8883;
        public const string Host = "localhost";
        // certificates related info
        public const string CertsDirPath = @"C:\hoge\";
        public const string DeviceCertificateFileName = "xxxx-certificate.pen.crt";
        public const string PrivateKeyFileName = "xxxx-private.pem.crt";
        public const string RootCAFileName = "AmazonRootCA1.pem";
    }
}
