using System;
using MusicCatalog.Enums;

namespace MusicCatalog.Entitites
{
    public class Music : BaseClass
    {
        private string Title { get; set; }
        private string Artist{ get; set; }
        private string Album { get; set; }
        private int Year { get; set; }
        private Gender Gender { get; set; }
        private bool Deleted { get; set; }

        public Music(int id, string title, string artist, string album, int year, Gender gender)
        {
            Id = id;
            Title = title;
            Artist = artist;
            Album = album;
            Year = year;
            Gender = gender;
            Deleted = false;
        }
        public override string ToString()
        {
            return "Title: " + Title + Environment.NewLine + 
                    "Artist: " + Artist + Environment.NewLine +
                    "Album: " + Album + Environment.NewLine +
                    "Year: " + Year + Environment.NewLine +
                    "Gender: " + Gender + Environment.NewLine +
                    "Deleted ?: " + (Deleted ? "Yes" : "No");
        }
        public string GetTitle(){
            return Title;
        }

        public string GetArtist(){
            return Artist;
        }
        public Gender GetGender(){
            return Gender;
        }
        public int GetId(){
            return Id;
        }
        public bool IsDeleted(){
            return Deleted;
        }

        public void Delete(){
            Deleted = true;
        }
    }
}