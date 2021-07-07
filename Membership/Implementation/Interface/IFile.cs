using Membership.Models;
using System.Collections.Generic;

namespace Membership.Implementation.Interface
{
    public interface IFile
    {
        string Read(string path);

        List<BaseEntityModel> GetFiles(string path);

        BaseEntityModel FileOnly(string path);

    }
}
