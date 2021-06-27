using Membership.Models;
using System;
using System.IO;
using System.Text;
using System.Web;

namespace Membership.Implementation.DataManager
{
    public class LogManager : BaseDataManager
    {
        public LogManager() : base()
        {

        }

        public LogManager(int applicationId) : base(applicationId)
        {

        }
        public void LogLogin(LoginModel model)
        {
            string logString = GetLogData(model);
            var applicationId = ApplicationId;
            string directoryPath = HttpContext.Current.Server.MapPath("~/SystemFile");
            string logFilePath = directoryPath + "/Log.Log";
            DirectoryExist(directoryPath);

            if (File.Exists(logFilePath))
            {
                //File.AppendText Returns stream

                //using because dynamically dispose the object created within 

                //using (StreamWriter stream = File.AppendText(logFilePath))
                //{
                //    stream.Write(logString);
                //    stream.Flush();
                //}
                string oldContent = File.ReadAllText(logFilePath);
                File.WriteAllText(logFilePath, logString + oldContent);
            }
            else
            {
                File.WriteAllText(logFilePath, logString);
            }
        }

        private string GetLogData(LoginModel model)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.AppendFormat("Log :\t {0}", DateTime.Now);
            strBuilder.AppendLine();
            strBuilder.AppendFormat("UserName :\t {0}", model.Username);
            strBuilder.AppendLine();
            strBuilder.AppendFormat("Login :\t {0}", model.Login);
            strBuilder.AppendLine();
            return strBuilder.ToString();
        }

        public void DirectoryExist(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
        }
    }
}