using System.Collections.Generic;
using MusicCatalog.Enums;

namespace MusicCatalog.Repositories
{
    public interface IRepository<T>
    {
         List<T> Catalog();
         T GetElementById(int id);
         IEnumerable<T> GetElementsByGender(Gender gender);
         IEnumerable<T> GetElementsByArtists(string artist);
         bool HasId(int id);
         void Insert(T element);
         void Delete(int id);
         void Update(int id, T element);
         int NextId();
    }
}