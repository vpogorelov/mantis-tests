﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Net.FtpClient;

namespace mantis_tests
{
    public class FtpHelper : HelperBase
    {
        private FtpClient client;
        public FtpHelper(ApplicationManager manager) : base(manager)
        {
            client = new FtpClient();
            client.Host = "localhost";
            client.Credentials = new System.Net.NetworkCredential("mantis", "mantis");
            client.Connect();
        }

        public void BackupFile(string path)
        {
            String backupPath = path + ".bak";
            if (!client.FileExists(backupPath))
            {
                client.Rename(path, backupPath);
            }
        }

        public void RestoreBackupFile(string path)
        {
            String backupPath = path + ".bak";
            if (client.FileExists(backupPath))
            {
                if (client.FileExists(path))
                    client.DeleteFile(path);
                client.Rename(backupPath, path);
            }
        }

        public void Upload(String path, Stream localFile)   // 'File': static types cannot be used as parameters
        {
            if (client.FileExists(path))
                client.DeleteFile(path);
            using (Stream ftpStream = client.OpenWrite(path))
            {
                byte[] buffer = new byte[8*1024];
                int count = localFile.Read(buffer, 0, buffer.Length);
                while (count > 0)
                {
                    ftpStream.Write(buffer, 0, count);
                    count = localFile.Read(buffer, 0, buffer.Length);
                }
            }
        } 
    }
}
