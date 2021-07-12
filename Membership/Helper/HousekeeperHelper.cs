using Membership.Implementation.Interface;
using Membership.Implementation.Service;
using System;

namespace Membership.Helper
{
    public class HousekeeperHelper
    {
        private readonly IHouseKeeper _houseKeeper;
        private readonly IEmail _email;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMessage _message;

        public HousekeeperHelper(
            IUnitOfWork unitOfWork,
            IHouseKeeper houseKeeper,
            IEmail email,
            IMessage message
            )
        {
            _unitOfWork = unitOfWork ?? new UnitOfWork();
            _houseKeeper = houseKeeper ?? new HouseKeeperService();
            _email = email ?? new EmailService();
            _message = message ?? new XtraMessageBox();
        }
        public bool SendStatementEmails(DateTime statementDate)
        {
            var housekeepers = _unitOfWork.Query<Housekeeper>();

            foreach (var housekeeper in housekeepers)
            {
                if (housekeeper.Email == null)
                    continue;

                var statementFilename = _houseKeeper.SaveStatement(housekeeper.Oid, housekeeper.FullName, statementDate);

                if (string.IsNullOrWhiteSpace(statementFilename))
                    continue;

                var emailAddress = housekeeper.Email;
                var emailBody = housekeeper.StatementEmailBody;

                try
                {
                    _email.EmailFile(emailAddress, emailBody, statementFilename,
                        string.Format("Sandpiper Statement {0:yyyy-MM} {1}", statementDate, housekeeper.FullName));
                }
                catch (Exception e)
                {
                    _message.Show();
                }
            }

            return true;
        }

        public void TestExceptionCase(string name)
        {
            try
            {
                int count = name.Length;
            }
            catch (Exception ex)
            {
                _message.Show();

                //throw new ArgumentNullException();
            }
        }
    }

    public enum MessageBoxButtons
    {
        OK
    }
     
    public interface IMessage
    {
        void Show();
    }

    public class XtraMessageBox : IMessage
    {
        public void Show()
        {
        }
    }

    public class MainForm
    {
        public bool HousekeeperStatementsSending { get; set; }
    }

    public class DateForm
    {
        public DateForm(string statementDate, object endOfLastMonth)
        {
        }

        public DateTime Date { get; set; }

        public DialogResult ShowDialog()
        {
            return DialogResult.Abort;
        }
    }

    public enum DialogResult
    {
        Abort,
        OK
    }

    

    public class Housekeeper
    {
        public string Email { get; set; }
        public int Oid { get; set; }
        public string FullName { get; set; }
        public string StatementEmailBody { get; set; }
    }

    
}