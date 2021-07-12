using Membership.Implementation.Interface;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Membership.Implementation.Service
{
    public class HouseKeeperService : IHouseKeeper
    {
        public class HousekeeperStatementReport
        {
            public HousekeeperStatementReport(int housekeeperOid, DateTime statementDate)
            {
            }

            public bool HasData { get; set; }

            public void CreateDocument()
            {
            }

            public void ExportToPdf(string filename)
            {
            }
        }

        public string SaveStatement(int housekeeperOid, string housekeeperName, DateTime statementDate)
        {
            var report = new HousekeeperStatementReport(housekeeperOid, statementDate);

            if (!report.HasData)
                return string.Empty;

            report.CreateDocument();

            var filename = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                string.Format("Sandpiper Statement {0:yyyy-MM} {1}.pdf", statementDate, housekeeperName));

            report.ExportToPdf(filename);

            return filename;
        }

    }

    public class EmailService : IEmail
    {
        public class SystemSettingsHelper
        {
            public static string EmailSmtpHost { get; set; }
            public static int EmailPort { get; set; }
            public static string EmailUsername { get; set; }
            public static string EmailPassword { get; set; }
            public static string EmailFromEmail { get; set; }
            public static string EmailFromName { get; set; }
        }

        public void EmailFile(string emailAddress, string emailBody, string filename, string subject)
        {
            var client = new SmtpClient(SystemSettingsHelper.EmailSmtpHost)
            {
                Port = SystemSettingsHelper.EmailPort,
                Credentials =
                   new NetworkCredential(
                       SystemSettingsHelper.EmailUsername,
                       SystemSettingsHelper.EmailPassword)
            };

            var from = new MailAddress(SystemSettingsHelper.EmailFromEmail, SystemSettingsHelper.EmailFromName,
                Encoding.UTF8);
            var to = new MailAddress(emailAddress);

            var message = new MailMessage(from, to)
            {
                Subject = subject,
                SubjectEncoding = Encoding.UTF8,
                Body = emailBody,
                BodyEncoding = Encoding.UTF8
            };

            message.Attachments.Add(new Attachment(filename));
            client.Send(message);
            message.Dispose();

            File.Delete(filename);
        }
    }
}