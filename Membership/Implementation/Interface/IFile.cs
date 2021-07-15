using System.Web;

namespace Membership.Implementation.Interface
{
    public interface IFile
    {
        string ReadFromFile(HttpPostedFileBase file);
        string UploadHttpPostedFileBase(HttpPostedFileBase file, string directory);
        void UploadFileByte(byte[] fileByte, string directory, string fileName);
        byte[] GetBytesFromData(string data);
        byte[] GetBytesFromFile(string filePath);

        //   string Read(string file);
        //  List<BaseEntityModel> GetFiles(string path);
        //BaseEntityModel FileOnly(string path);
    }
}
