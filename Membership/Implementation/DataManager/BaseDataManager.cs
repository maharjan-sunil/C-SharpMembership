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

    public class BaseDataManager<Converter> : BaseDataManager
       where Converter : class, new()
    {
        protected readonly Converter converter;

        public BaseDataManager() : base()
        {
            converter = new Converter();
        }

    }
}