using Membership.Implementation.Interface;

namespace Membership.Implementation.DataManager
{
    public class DownloadManager
    {
        IDownload _download;
        public DownloadManager(IDownload download)
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