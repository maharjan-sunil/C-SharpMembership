using Membership.Implementation.Interface;

namespace Membership.Implementation.DataManager
{
    public class DownloadDataManager
    {
        IDownload _download;
        public DownloadDataManager(IDownload download)
        {
            this._download = download;
        }
        public byte[] GetBytesFromString(string data)
        {
            //inject with interface to call CSV Service without creating instance of CSV Service
            return _download.GetBytes(data);
        }
    }
}