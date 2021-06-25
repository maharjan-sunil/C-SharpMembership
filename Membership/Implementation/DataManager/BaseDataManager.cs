namespace Membership.Implementation.DataManager
{
    public class BaseDataManager
    {
        protected int ApplicationId;
        public BaseDataManager()
        {

        }

        public BaseDataManager(int applicationId)
        {
            ApplicationId = applicationId;
        }
    }
}