namespace AutoUpdate
{
    public static class SFTPGlobal
    {
        public static string ReleaseConfigFileName = "ReleaseList.xml";
        public static string Host = "123.57.11.15";
        public static string User = "root";
        public static string Pass = "CYADMIN@99012df&dfADMin!!$";
        public static string FtpPath = "/www/cytxprint/update/stand-alone-version/";
        public static string IdentityFile = "";

        public static ReleaseList localRelease;
        public static ReleaseList remoteRelease;
        public static string tempPath= "";
    }
}
