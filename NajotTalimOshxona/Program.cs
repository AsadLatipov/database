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

            // Load the Service account credentials and define the scope of its access.
            var credential = GoogleCredential.FromFile(PathToServiceAccountKeyFile)
                            .CreateScoped(DriveService.ScopeConstants.Drive);

            // Create the  Drive service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential
            });

            // Create the  Drive service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential
            });

            string uploadedFileId;
            // Create a new file on Google Drive
            await using (var fsSource = new FileStream(UploadFileName, FileMode.Open, FileAccess.Read))
            {
                // Create a new file, with metadata and stream.
                var request = service.Files.Create(fileMetadata, fsSource, "text/plain");
                request.Fields = "*";
                var results = await request.UploadAsync(CancellationToken.None);

                if (results.Status == UploadStatus.Failed)
                {
                    Console.WriteLine($"Error uploading file: {results.Exception.Message}");
                }

                // the file id of the new file we created
                uploadedFileId = request.ResponseBody?.Id;
            }

            // Let's change the files name.
            // Note: not all fields are writeable watch out, you cant just send uploadedFile back.
            var updateFileBody = new Google.Apis.Drive.v3.Data.File()
            {
                Name = "update.txt"
            };

            // Let's add some text to our file.
            await File.WriteAllTextAsync(UploadFileName, "Text changed in file.");

            // Then upload the file again with a new name and new data.
            await using (var uploadStream = new FileStream(UploadFileName, FileMode.Open, FileAccess.Read))
            {
                // Update the file id, with new metadata and stream.
                var updateRequest = service.Files.Update(updateFileBody, uploadedFile.Id, uploadStream, "text/plain");
                var result = await updateRequest.UploadAsync(CancellationToken.None);

                if (result.Status == UploadStatus.Failed)
                {
                    Console.WriteLine($"Error uploading file: {result.Exception.Message}");
                }
            }
        }
    }
}