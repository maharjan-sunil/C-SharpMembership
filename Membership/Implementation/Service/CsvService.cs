using Membership.Constant;
using Membership.Implementation.Interface;
using System.Text;

namespace Membership.Implementation.Service
{
    public class CsvService : IDownload
    {
        public byte[] GetBytes(string data)
        {
            byte[] file = Encoding.GetEncoding(EncodingConstant.ISO).GetBytes(data);
            return file;
        }
    }
}