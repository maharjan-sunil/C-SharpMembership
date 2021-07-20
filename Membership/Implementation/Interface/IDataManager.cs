using System.Collections.Generic;

namespace Membership.Implementation.Interface
{
    public interface IDataManager<Model, ViewModel>
         where Model : class
        where ViewModel : class
    {
        ViewModel GetList(ViewModel model);
        Model GetDetail(int id);
        bool Delete(int id);
        bool Edit(Model model);
        bool Add(Model model );
    }
}