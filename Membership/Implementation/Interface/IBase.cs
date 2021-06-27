using System.Collections.Generic;
using System.Threading.Tasks;

namespace Membership.Implementation.Interface
{
    interface IBase<Class>
        where Class : class
    {

        Task<List<Class>> GetList();
        Task<Class> Get();
        Task<bool> Delete();
        Task<bool> Update();
        Task<bool> Add();
    }
}
