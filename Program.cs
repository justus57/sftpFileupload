using Chilkat;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCB
{
    class Program
    {
        static void Main(string[] args)
        {
          
        }
        //Parameters for sending Payment File
        public static void SendPaymentFile(string host, string username, string password, string remoteFilePath, string localFilePath, string port)
        {
            try
            {
                using (ScpClient client = new ScpClient(host, password,port))
                {
                    client.Connect();

                    using (System.IO.Stream localFile = File.OpenRead(localFilePath))
                    {
                        client.Upload(localFile, remoteFilePath);
                    }

                }
                Console.WriteLine("Successfully connected to the client");
                Console.ReadLine();
            }
            catch (Exception es)
            {
                WriteLog(es.Message);
            }
        }
        public static void WriteLog(string text)
        {

            try
            {
                //set up a filestream
                string strPath = @"C:\Logs\KCBAPI";
                string fileName = DateTime.Now.ToString("MMddyyyy") + "_logs.txt";
                string filenamePath = strPath + '\\' + fileName;
                Directory.CreateDirectory(strPath);
                FileStream fs = new FileStream(filenamePath, FileMode.OpenOrCreate, System.IO.FileAccess.Write);
                //set up a streamwriter for adding text
                StreamWriter sw = new StreamWriter(fs);
                //find the end of the underlying filestream
                sw.BaseStream.Seek(0, SeekOrigin.End);
                //add the text
                sw.WriteLine(DateTime.Now.ToString() + " : " + text);
                //add the text to the underlying filestream
                sw.Flush();
                //close the writer
                sw.Close();
            }
            catch (Exception ex)
            {
                //throw;
                ex.Data.Clear();
            }
        }
    }  
}




