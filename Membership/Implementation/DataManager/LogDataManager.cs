using Membership.Database;
using Membership.Implementation.Interface;
using Membership.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Membership.Implementation.DataManager
{
    public class LogDataManager : BaseDataManager, ILog
    {
        private readonly DirectoryManager directoryManager;
        public LogDataManager() : base()
        {
            directoryManager = new DirectoryManager();
        }

        public LogDataManager(int applicationId) : base(applicationId)
        {

        }
        public void Log(LoginModel model)
        {
            //var applicationId = ApplicationId;
            string directoryPath = HttpContext.Current.Server.MapPath("~/SystemFile");
            string logFilePath = directoryPath + "/Log.Log";
            directoryManager.DirectoryExist(directoryPath);

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
                var list = JsonConvert.DeserializeObject<List<LoginModel>>(oldContent);
                list.Add(model);
                var loginModel = JsonConvert.SerializeObject(list, Formatting.Indented);
                File.WriteAllText(logFilePath, loginModel);
            }
            else
            {
                string logString = GetLogData(model);
                File.WriteAllText(logFilePath, logString);
            }
        }

        internal void GetStdLibFromSP()
        {
            string studentName = "Sunil";
            string department = "Comic";
           using (var db = new MembershipEntities())
            {
                var stdLtd = db.Std_Lib(studentName, department).ToList();
            }
        }

        private string GetLogData(LoginModel model)
        {
            model.LogDate = DateTime.Now;
            string loginModel = JsonConvert.SerializeObject(model);
            //StringBuilder strBuilder = new StringBuilder();
            //strBuilder.AppendFormat("Log :\t {0}", DateTime.Now);
            //strBuilder.AppendLine();
            //strBuilder.AppendFormat("UserName :\t {0}", model.Username);
            //strBuilder.AppendLine();
            //strBuilder.AppendFormat("Login :\t {0}", model.Login);
            //strBuilder.AppendLine();
            //return strBuilder.ToString();
            return loginModel;
        }

    }
}