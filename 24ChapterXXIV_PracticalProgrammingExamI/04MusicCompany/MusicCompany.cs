using System;
using System.Collections.Generic;

namespace _04MusicCompany
{
    public  class MusicCompany
    {
        private string name;
        private string address;
        private string owner;
        private HashSet<Singer> singers;

        public MusicCompany(string name, string address, string owner, IEnumerable<Singer> singers)
        {
            this.name = name;
            this.address = address;
            this.owner = owner;
            this.singers = new HashSet<Singer>(singers);
        }

        public bool AddSinger(Singer singer)
        {
            return this.singers.Add(singer);
        }

        public bool RemoveSinger(Singer singer)
        {
            return this.singers.Remove(singer);
        }

        public override string ToString()
        {
            return $"Company Name: {this.name}{Environment.NewLine}Address: {this.address}{Environment.NewLine}Owner: {this.owner}{Environment.NewLine}Singers: {this.singers.Count}{Environment.NewLine}{string.Join(Environment.NewLine, this.singers)}{Environment.NewLine}{new string('-', 15)}";
        }
    }
}