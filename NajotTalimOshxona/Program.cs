using NajotTalimOshxona.Moduls;
using NajotTalimOshxona.Consists;
using NajotTalimOshxona.Repositories;
using NajotTalimOshxona.IRepositories;
using NajotTalimOshxona.Extensions;
using System;
using System.Net;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using System.Threading;
using Google.Apis.Upload;

namespace NajotTalimOshxona
{
    internal class Program
    {
        private const string PathToServiceAccountKeyFile = @"C:\Youtube\dev\ServiceAccountCred.json";
        private const string ServiceAccountEmail = "driveuploadtest@testapikey-305109.iam.gserviceaccount.com";
        private const string UploadFileName = "Test hello.txt";
        private const string DirectoryId = "10krlloIS2i_2u_ewkdv3_1NqcpmWSL1w";

        static void Main(string[] args)
        {
            //AdminEnterance.Enterance();
        }
    }
}