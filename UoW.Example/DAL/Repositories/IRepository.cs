namespace SciMaterials.Data.Repositories;

/// <summary> Интерфейс репозиториев. </summary>
/// <typeparam name="T"></typeparam>
public interface IRepository<T> where T : class
{
    /// <summary> Получить экземпляр модели по Id. </summary>
    /// <param name="id"> Id экземпляра модли в БД. </param>
    /// <param name="disableTracking"> Отключить отслеживание изменений. </param>
    /// <returns> Найденный в БД экземпляр модли или null. </returns>
    T GetById(Guid id, bool disableTracking = true);

    /// <summary> Добавить экзепляр модели в БД. </summary>
    /// <param name="entity"> Добавляемый экземпляр. </param>
    void Add(T entity);
}
