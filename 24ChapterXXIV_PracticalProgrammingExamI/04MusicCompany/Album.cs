using System.Collections.Generic;

namespace _04MusicCompany
{
    public class Album
    {
        private string name;
        private string genre;
        private int year;
        private HashSet<Song> songs;

        public Album(string name, string genre, int year, int soldAlbumsCount, IEnumerable<Song> songs)
        {
            this.name = name;
            this.genre = genre;
            this.year = year;
            this.SoldAlbumsCount = soldAlbumsCount;
            this.songs = new HashSet<Song>(songs);
        }

        public int SoldAlbumsCount { get; set; }

        public override string ToString()
        {
            return $"Album: {this.name}; Genre: {this.genre}; Year: {this.year}; Sold Albums: {this.SoldAlbumsCount}; Songs ({this.songs.Count}): {string.Join("; ", this.songs)}.";
        }
    }
}