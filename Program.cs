using System;
using MusicCatalog.Entitites;
using MusicCatalog.Enums;
using MusicCatalog.Repositories;

namespace MusicCatalog
{
    class Program
    {
        static IMusicRepository repository= new IMusicRepository();
        static void Main(string[] args)
        {
            string mainMenuOption = GetMainMenuOption();

            while (mainMenuOption.ToUpper() != "X")
            {
                 switch (mainMenuOption)
                 {
                    case "1":
                        GetMusics();
                        break;
                    case "2":
                        InsertMusic();
                        break;
                    case "3":
                        UpdateMusic();
                        break;
                    case "4":
                        DeleteMusic();
                        break;
                    case "5":
                        ShowMusic();
                        break;
                    case "6":
                        ShowMusicsByGender();
                        break;
                    case "7":
                        ShowMusicsByArtist();
                        break;
                    case "C":
                        Console.Clear();
                        Console.ReadLine();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                 }
                 mainMenuOption = GetMainMenuOption();
            }
        }

        private static void ShowMusicsByArtist()
        {
            Console.Clear();
            Console.Write("Type an artist to filter: ");
            string artist = Console.ReadLine();
            var musicsByArtist = repository.GetElementsByArtists(artist);
            if (musicsByArtist == null)
            {
                Console.WriteLine("Musics not found!!");
                Console.ReadLine();
                return;
            }
            foreach (Music music in musicsByArtist)
            {
                if (!music.IsDeleted())
                {
                    Console.WriteLine("#ID {0}: - {1}", music.GetId(), music.GetTitle());
                }
            }
            Console.ReadLine();
        }

        private static void ShowMusicsByGender()
        {
            Console.Clear();
            foreach (int i in Enum.GetValues(typeof(Gender)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Gender), i));
            }
            Console.Write("Type a number to filter by gender: ");
            int gender = int.Parse(Console.ReadLine());
            var genderList = repository.GetElementsByGender((Gender) gender);
            Console.WriteLine();
            if (genderList == null)
            {
                Console.WriteLine("Musics not found!!!");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Musics with gender {0}", (Gender)gender);
            foreach(Music music in genderList){
                if (!music.IsDeleted())
                {
                    Console.WriteLine("#ID {0}: - {1}", music.GetId(), music.GetTitle());
                }
            }
            Console.ReadLine();
        }

        private static void ShowMusic()
        {
            Console.Clear();
            Console.Write("Type an ID to search a music: ");
            int id = int.Parse(Console.ReadLine());
            var music = repository.GetElementById(id);
            if (music == null)
            {
                Console.WriteLine("Music not found !!");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Music founded!!!");
            Console.WriteLine(music);
            Console.ReadLine();
        }

        private static void DeleteMusic()
        {
            Console.Clear();
            Console.Write("Type an ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            repository.Delete(id);

        }

        private static void UpdateMusic()
        {
            Console.Clear();
            Console.Write("Type an ID to update: ");
            int id = int.Parse(Console.ReadLine());
            bool existId = repository.HasId(id);
            if (!existId)
            {
                Console.WriteLine("ID not found!!");
                return;
            }
            Console.Clear();
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("Artist: ");
            string artist = Console.ReadLine();
            Console.WriteLine("Gender:");
            foreach (int i in Enum.GetValues(typeof(Gender)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Gender), i));
            }
            Console.Write("Type a number for a gender: ");
            int gender = int.Parse(Console.ReadLine());
            Console.Write("Album: ");
            string album = Console.ReadLine();
            Console.Write("Year: ");
            int year = int.Parse(Console.ReadLine());
            Music music = new Music (id, title, artist, album, year, (Gender)gender);
            repository.Update(id, music);
        }

        private static void InsertMusic()
        {
            Console.Clear();
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("Artist: ");
            string artist = Console.ReadLine();
            Console.WriteLine("Gender:");
            foreach (int i in Enum.GetValues(typeof(Gender)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Gender), i));
            }
            Console.Write("Type a number for a gender: ");
            int gender = int.Parse(Console.ReadLine());
            Console.Write("Album: ");
            string album = Console.ReadLine();
            Console.Write("Year: ");
            int year = int.Parse(Console.ReadLine());
            Music music = new Music (repository.NextId(), title, artist, album, year, (Gender)gender);
            repository.Insert(music);
        }

        private static void GetMusics()
        {
            Console.Clear();
            Console.WriteLine("Music list:");
            var list = repository.Catalog();
            if (list.Count == 0 )
            {
                Console.WriteLine("Musics not found!!");
                Console.ReadLine();
                return;
            }

            foreach(Music music in list){
                if (!music.IsDeleted())
                {
                    Console.WriteLine("#ID {0}: - {1}", music.GetId(), music.GetTitle());
                }
            }
            Console.ReadLine();
        }

        private static string GetMainMenuOption()
        {
            Console.Clear();
            Console.WriteLine();
			Console.WriteLine("Welcome to your music catalog");
			Console.WriteLine("Please select your option:");

			Console.WriteLine("1- Show your musics:");
			Console.WriteLine("2- Insert a new music");
			Console.WriteLine("3- Update music");
			Console.WriteLine("4- Delete music");
			Console.WriteLine("5- Show music informations");
            Console.WriteLine("6- Show musics by gender");
            Console.WriteLine("7- Show musics by artist");
			Console.WriteLine("C- Clear Screen");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string mainMenuOption = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return mainMenuOption;
        }
    }
}
