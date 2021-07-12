namespace Membership.Implementation.Interface
{
   public interface IConverter<EntityModel, ViewModel>
        where EntityModel : class
        where ViewModel : class
    {
        EntityModel ConvertToEntity(ViewModel model);
        ViewModel ConverToModel(EntityModel model);
        EntityModel ConvertToEntity(ViewModel model, EntityModel self);

    }
}
