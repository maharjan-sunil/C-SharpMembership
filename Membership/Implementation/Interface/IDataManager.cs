using System.Collections.Generic;

namespace Membership.Implementation.Interface
{
    public interface IDataManager<Class>
        where Class: class
    {
        List<Class> GetList();
        //List<Class> GetList(string query);
        Class GetDetail(int id);
        bool Delete(int id);
        bool Edit(Class model);
        bool Add(Class model );
    }
}