using Membership.Helper;
using System;
using System.Collections.Generic;

namespace Membership.Implementation.Interface
{
    public interface IHouseKeeper
    {
        string SaveStatement(int housekeeperOid, string housekeeperName, DateTime statementDate);
    }

    public interface IEmail
    {
        void EmailFile(string emailAddress, string emailBody, string filename, string subject);
    }
}
