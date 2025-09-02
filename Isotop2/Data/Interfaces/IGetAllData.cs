namespace Isotop2.Data.Interfaces
{
    internal interface IGetAllData<T> where T : class
    {
        List<T>? GetAll(); //Получение всех данных
    }
}
