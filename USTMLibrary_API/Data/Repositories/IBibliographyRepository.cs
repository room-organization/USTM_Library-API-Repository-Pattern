using USTMLibrary_API.model;

namespace USTMLibrary_API.Data.Repositories
{
    public interface IBibliographyRepository
    {
        Task<IEnumerable<Bibliography>> GetAll();
        Task<Bibliography> GetById(int id);
        Task Add(Bibliography bibliography);
        Task Update(Bibliography bibliography);
        Task Delete(int id);
    }

}
