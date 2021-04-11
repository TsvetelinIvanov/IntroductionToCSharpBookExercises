using System;

namespace _04MusicCompany
{
    public class MusicCompanyTest
    {
        private static Song song1 = new Song("Song 1", 1.56);
        private static Song song2 = new Song("Song 2", 2.56);
        private static Song song3 = new Song("Song 3", 3.5);
        private static Song song4 = new Song("Song 4", 4);
        private static Song song5 = new Song("Song 5", 5.01);
        private static Song song6 = new Song("Song 6", 6);
        private static Song song7 = new Song("Song 7", 7.59);
        private static Song song8 = new Song("Song 8", 0.4);
        private static Song song9 = new Song("Song 9", 0.49);
        private static Song song10 = new Song("Song 10", 10);

        private static Album album1 = new Album("Album 1", "Rock", 1998, 10000, new Song[] { song1, song2, song3, song4, song5, song6, song7, song8, song9, song10 });
        private static Album album2 = new Album("Album 2", "Pop", 1976, 20000, new Song[] { song2, song3, song4, song5, song6, song7, song8, song9, song10 });
        private static Album album3 = new Album("Album 3", "Rock", 1980, 30000, new Song[] { song3, song4, song5, song6, song7, song8, song9, song10 });
        private static Album album4 = new Album("Album 4", "Folk", 2020, 40000, new Song[] { song1, song1, song1, song4, song5, song6, song7, song8, song9, song10 });
        private static Album album5 = new Album("Album 5", "Pop", 1971, 50000, new Song[] { song5 });
        private static Album album6 = new Album("Album 6", "Rock", 2001, 60000, new Song[] { song1, song2, song3, song4, song5, song6 });
        private static Album album7 = new Album("Album 7", "Folk", 2010, 70000, new Song[] { song7, song7, song7, song7, song7, song7 });
        private static Album album8 = new Album("Album 8", "Rock", 2021, 0, new Song[] { });

        private static Singer singer1 = new Singer("Singer 1", "Nickname 1", new Album[] { album1, album2, album3, album4, album5, album6, album7, album8 });
        private static Singer singer2 = new Singer("Singer 2", "Nickname 2", new Album[] { album2, album3, album4, album5, album6, album7, album8 });
        private static Singer singer3 = new Singer("Singer 3", "Nickname 3", new Album[] { album3, album3, album3, album4, album5, album6, album7, album8 });
        private static Singer singer4 = new Singer("Singer 4", "Nickname 4", new Album[] { album4 });
        private static Singer singer5 = new Singer("Singer 5", "Nickname 5", new Album[] { });
        private static Singer singer6 = new Singer("Singer 6", "Nickname 6", new Album[] { album6, album6, album6, album6, album6, album6 });

        private static MusicCompany musicCompany1 = new MusicCompany("Music Company 1", "Country 1, City 1, Street 1, No 1", "Owner 1", new Singer[] { singer1, singer2, singer3, singer4, singer5, singer6 });
        private static MusicCompany musicCompany2 = new MusicCompany("Music Company 2", "Country 2, City 2, Street 2, No 2", "Owner 2", new Singer[] { singer1, singer2, singer2, singer2, singer5, singer6 });
        private static MusicCompany musicCompany3 = new MusicCompany("Music Company 3", "Country 1, City 1, Street 1, No 1", "Owner 1", new Singer[] { });

        public static void TestMusicCompany()
        {
            Console.WriteLine(musicCompany1);
            Console.WriteLine(musicCompany2);
            Console.WriteLine(musicCompany3);

            Console.WriteLine(musicCompany3.AddSinger(singer1));
            Console.WriteLine(musicCompany3.AddSinger(singer1));
            Console.WriteLine(musicCompany3.AddSinger(singer2));
            Console.WriteLine(musicCompany3.RemoveSinger(singer2));
            Console.WriteLine(musicCompany3.RemoveSinger(singer2));

            Console.WriteLine(singer6.AddAlbum(album1));
            Console.WriteLine(singer6.AddAlbum(album1));
            Console.WriteLine(singer6.AddAlbum(album7));
            Console.WriteLine(singer6.RemoveAlbum(album5));
            Console.WriteLine(singer6.RemoveAlbum(album7));

            Console.WriteLine(musicCompany3.AddSinger(singer6));
            Console.WriteLine(musicCompany3);
        }
    }
}
