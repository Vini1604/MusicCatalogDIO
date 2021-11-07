using System;
using System.Collections.Generic;
using System.Linq;
using MusicCatalog.Entitites;
using MusicCatalog.Enums;

namespace MusicCatalog.Repositories
{
    public class IMusicRepository : IRepository<Music>
    {
        private List<Music> Musics = new List<Music>();
        public List<Music> Catalog()
        {
            return Musics;
        }

        public void Delete(int id)
        {
            var music = Musics.Find(x => x.Id == id);
            if (music == null)
            {
                Console.WriteLine("ID not found!!!");
                return;
            }
            music.Delete();
        }

        public Music GetElementById(int id)
        {
            var music = Musics.Find(x => x.Id == id);
            return music;
        }

        public IEnumerable<Music> GetElementsByArtists(string artist)
        {
            var musics = Musics.Where(x => x.GetArtist().ToUpper() == artist.ToUpper());
            return musics;
        }

        public IEnumerable<Music> GetElementsByGender(Gender gender)
        {
            var musics = Musics.Where(x => x.GetGender() == gender);
            return musics;
        }

        public bool HasId(int id)
        {
            if (Musics.Exists(x => x.Id == id))
            {
                return true;
            }
            else{
                return false;
            }
        }

        public void Insert(Music element)
        {
            Musics.Add(element);
        }

        public int NextId()
        {
            return Musics.Count;
        }

        public void Update(int id, Music element)
        {
            Musics[id] = element;
        }
    }
}