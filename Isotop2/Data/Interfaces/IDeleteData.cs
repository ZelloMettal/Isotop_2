namespace Isotop2.Data.Interfaces
{
    internal interface IDeleteData<T> where T : class
    {
        bool Delete(T? entity); //Удаление сущности
    }
}
