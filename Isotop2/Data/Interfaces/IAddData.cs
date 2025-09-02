namespace Isotop2.Data.Interfaces
{
    internal interface IAddData<T> where T : class
    {
        bool Add(T? entity); //Добавление сущности
    }
}
