namespace Membership.Models
{
    public class PagerModel
    {
        public PagerModel()
        {
            CurrentPage = 1;
            RecordPerPage = 10;
        }

        public PagerModel(int size)
        {
            CurrentPage = 1;
            RecordPerPage = size;
        }
        public int CurrentPage { get; set; }
        public int RecordPerPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
    }
}