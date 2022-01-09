using NajotTalimOshxona.Moduls;
using NajotTalimOshxona.Consists;
using NajotTalimOshxona.Repositories;
using NajotTalimOshxona.IRepositories;
using NajotTalimOshxona.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Diagnostics;
using Octokit;
using System.Threading;

namespace NajotTalimOshxona
{
    internal class Program
    {
        //private const string PathToServiceAccountKeyFile = @"C:\Youtube\dev\ServiceAccountCred.json";
        //private const string ServiceAccountEmail = "driveuploadtest@testapikey-305109.iam.gserviceaccount.com";
        //private const string UploadFileName = "Test hello.txt";
        //private const string DirectoryId = "10krlloIS2i_2u_ewkdv3_1NqcpmWSL1w";

        static void Main(string[] args)
        {
            //AdminEnterance.Enterance();

            //var proc = new Process();
            //proc.StartInfo.WorkingDirectory = Consists.Paths.PushBatPath;
            //proc.StartInfo.FileName = "testbat.bat
            //proc.StartInfo.CreateNoWindow = false;
            //proc.Start();
            //proc.WaitForExit();
            Process process;
            String command = @"C:\Users\User\Desktop\push.bat";
            ProcessStartInfo processInfo;
            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            // *** Redirect the output ***
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            process = Process.Start(processInfo);
            Thread.Sleep(5000);
            process.WaitForExit();
        }
    }
}