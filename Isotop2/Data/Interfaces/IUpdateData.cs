namespace Isotop2.Data.Interfaces
{
    internal interface IUpdateData<T> where T : class
    {
        bool Update(T? entity); //Редактирование сущности
    }
}
