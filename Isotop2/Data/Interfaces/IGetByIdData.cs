namespace Isotop2.Data.Interfaces
{
    internal interface IGetByIdData<T> where T : class
    {
        T? GetById(int? id); //Получение одной сущности по ID
    }
}
