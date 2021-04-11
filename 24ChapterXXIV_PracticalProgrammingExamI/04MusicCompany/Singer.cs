using System;
using System.Collections.Generic;

namespace _04MusicCompany
{
    public class Singer
    {
        private string name;
        private string nickname;
        private HashSet<Album> albums;

        public Singer(string name, string nickname, IEnumerable<Album> albums)
        {
            this.name = name;
            this.nickname = nickname;
            this.albums = new HashSet<Album>(albums);
        }

        public bool AddAlbum(Album album)
        {
            return this.albums.Add(album);
        }

        public bool RemoveAlbum(Album album)
        {
            return this.albums.Remove(album);
        }

        public override string ToString()
        {
            return $"Siger Name: {this.name}; Singer Nickname: {this.nickname}; Albums: {this.albums.Count}{Environment.NewLine}{string.Join(Environment.NewLine, this.albums)}";
        }
    }
}