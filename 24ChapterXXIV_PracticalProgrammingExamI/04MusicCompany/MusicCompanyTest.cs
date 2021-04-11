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
            
            //Output:
            //Company Name: Music Company 1
            //Address: Country 1, City 1, Street 1, No 1
            //Owner: Owner 1
            //Singers: 6
            //Siger Name: Singer 1; Singer Nickname: Nickname 1; Albums: 8
            //Album: Album 1; Genre: Rock; Year: 1998; Sold Albums: 10000; Songs(10): Song: Song 1, Time: 1.56 min; Song: Song 2, Time: 2.56 min; Song: Song 3, Time: 3.50 min; Song: Song 4, Time: 4.00 min; Song: Song 5, Time: 5.01 min; Song: Song 6, Time: 6.00 min; Song: Song 7, Time: 7.59 min; Song: Song 8, Time: 0.40 min; Song: Song 9, Time: 0.49 min; Song: Song 10, Time: 10.00 min.
            //Album: Album 2; Genre: Pop; Year: 1976; Sold Albums: 20000; Songs(9): Song: Song 2, Time: 2.56 min; Song: Song 3, Time: 3.50 min; Song: Song 4, Time: 4.00 min; Song: Song 5, Time: 5.01 min; Song: Song 6, Time: 6.00 min; Song: Song 7, Time: 7.59 min; Song: Song 8, Time: 0.40 min; Song: Song 9, Time: 0.49 min; Song: Song 10, Time: 10.00 min.
            //Album: Album 3; Genre: Rock; Year: 1980; Sold Albums: 30000; Songs(8): Song: Song 3, Time: 3.50 min; Song: Song 4, Time: 4.00 min; Song: Song 5, Time: 5.01 min; Song: Song 6, Time: 6.00 min; Song: Song 7, Time: 7.59 min; Song: Song 8, Time: 0.40 min; Song: Song 9, Time: 0.49 min; Song: Song 10, Time: 10.00 min.
            //Album: Album 4; Genre: Folk; Year: 2020; Sold Albums: 40000; Songs(8): Song: Song 1, Time: 1.56 min; Song: Song 4, Time: 4.00 min; Song: Song 5, Time: 5.01 min; Song: Song 6, Time: 6.00 min; Song: Song 7, Time: 7.59 min; Song: Song 8, Time: 0.40 min; Song: Song 9, Time: 0.49 min; Song: Song 10, Time: 10.00 min.
            //Album: Album 5; Genre: Pop; Year: 1971; Sold Albums: 50000; Songs(1): Song: Song 5, Time: 5.01 min.
            //Album: Album 6; Genre: Rock; Year: 2001; Sold Albums: 60000; Songs(6): Song: Song 1, Time: 1.56 min; Song: Song 2, Time: 2.56 min; Song: Song 3, Time: 3.50 min; Song: Song 4, Time: 4.00 min; Song: Song 5, Time: 5.01 min; Song: Song 6, Time: 6.00 min.
            //Album: Album 7; Genre: Folk; Year: 2010; Sold Albums: 70000; Songs(1): Song: Song 7, Time: 7.59 min.
            //Album: Album 8; Genre: Rock; Year: 2021; Sold Albums: 0; Songs(0): .
            //Siger Name: Singer 2; Singer Nickname: Nickname 2; Albums: 7
            //Album: Album 2; Genre: Pop; Year: 1976; Sold Albums: 20000; Songs(9): Song: Song 2, Time: 2.56 min; Song: Song 3, Time: 3.50 min; Song: Song 4, Time: 4.00 min; Song: Song 5, Time: 5.01 min; Song: Song 6, Time: 6.00 min; Song: Song 7, Time: 7.59 min; Song: Song 8, Time: 0.40 min; Song: Song 9, Time: 0.49 min; Song: Song 10, Time: 10.00 min.
            //Album: Album 3; Genre: Rock; Year: 1980; Sold Albums: 30000; Songs(8): Song: Song 3, Time: 3.50 min; Song: Song 4, Time: 4.00 min; Song: Song 5, Time: 5.01 min; Song: Song 6, Time: 6.00 min; Song: Song 7, Time: 7.59 min; Song: Song 8, Time: 0.40 min; Song: Song 9, Time: 0.49 min; Song: Song 10, Time: 10.00 min.
            //Album: Album 4; Genre: Folk; Year: 2020; Sold Albums: 40000; Songs(8): Song: Song 1, Time: 1.56 min; Song: Song 4, Time: 4.00 min; Song: Song 5, Time: 5.01 min; Song: Song 6, Time: 6.00 min; Song: Song 7, Time: 7.59 min; Song: Song 8, Time: 0.40 min; Song: Song 9, Time: 0.49 min; Song: Song 10, Time: 10.00 min.
            //Album: Album 5; Genre: Pop; Year: 1971; Sold Albums: 50000; Songs(1): Song: Song 5, Time: 5.01 min.
            //Album: Album 6; Genre: Rock; Year: 2001; Sold Albums: 60000; Songs(6): Song: Song 1, Time: 1.56 min; Song: Song 2, Time: 2.56 min; Song: Song 3, Time: 3.50 min; Song: Song 4, Time: 4.00 min; Song: Song 5, Time: 5.01 min; Song: Song 6, Time: 6.00 min.
            //Album: Album 7; Genre: Folk; Year: 2010; Sold Albums: 70000; Songs(1): Song: Song 7, Time: 7.59 min.
            //Album: Album 8; Genre: Rock; Year: 2021; Sold Albums: 0; Songs(0): .
            //Siger Name: Singer 3; Singer Nickname: Nickname 3; Albums: 6
            //Album: Album 3; Genre: Rock; Year: 1980; Sold Albums: 30000; Songs(8): Song: Song 3, Time: 3.50 min; Song: Song 4, Time: 4.00 min; Song: Song 5, Time: 5.01 min; Song: Song 6, Time: 6.00 min; Song: Song 7, Time: 7.59 min; Song: Song 8, Time: 0.40 min; Song: Song 9, Time: 0.49 min; Song: Song 10, Time: 10.00 min.
            //Album: Album 4; Genre: Folk; Year: 2020; Sold Albums: 40000; Songs(8): Song: Song 1, Time: 1.56 min; Song: Song 4, Time: 4.00 min; Song: Song 5, Time: 5.01 min; Song: Song 6, Time: 6.00 min; Song: Song 7, Time: 7.59 min; Song: Song 8, Time: 0.40 min; Song: Song 9, Time: 0.49 min; Song: Song 10, Time: 10.00 min.
            //Album: Album 5; Genre: Pop; Year: 1971; Sold Albums: 50000; Songs(1): Song: Song 5, Time: 5.01 min.
            //Album: Album 6; Genre: Rock; Year: 2001; Sold Albums: 60000; Songs(6): Song: Song 1, Time: 1.56 min; Song: Song 2, Time: 2.56 min; Song: Song 3, Time: 3.50 min; Song: Song 4, Time: 4.00 min; Song: Song 5, Time: 5.01 min; Song: Song 6, Time: 6.00 min.
            //Album: Album 7; Genre: Folk; Year: 2010; Sold Albums: 70000; Songs(1): Song: Song 7, Time: 7.59 min.
            //Album: Album 8; Genre: Rock; Year: 2021; Sold Albums: 0; Songs(0): .
            //Siger Name: Singer 4; Singer Nickname: Nickname 4; Albums: 1
            //Album: Album 4; Genre: Folk; Year: 2020; Sold Albums: 40000; Songs(8): Song: Song 1, Time: 1.56 min; Song: Song 4, Time: 4.00 min; Song: Song 5, Time: 5.01 min; Song: Song 6, Time: 6.00 min; Song: Song 7, Time: 7.59 min; Song: Song 8, Time: 0.40 min; Song: Song 9, Time: 0.49 min; Song: Song 10, Time: 10.00 min.
            //Siger Name: Singer 5; Singer Nickname: Nickname 5; Albums: 0

            //Siger Name: Singer 6; Singer Nickname: Nickname 6; Albums: 1
            //Album: Album 6; Genre: Rock; Year: 2001; Sold Albums: 60000; Songs(6): Song: Song 1, Time: 1.56 min; Song: Song 2, Time: 2.56 min; Song: Song 3, Time: 3.50 min; Song: Song 4, Time: 4.00 min; Song: Song 5, Time: 5.01 min; Song: Song 6, Time: 6.00 min.
            //-------------- -
            //Company Name: Music Company 2
            //Address: Country 2, City 2, Street 2, No 2
            //Owner: Owner 2
            //Singers: 4
            //Siger Name: Singer 1; Singer Nickname: Nickname 1; Albums: 8
            //Album: Album 1; Genre: Rock; Year: 1998; Sold Albums: 10000; Songs(10): Song: Song 1, Time: 1.56 min; Song: Song 2, Time: 2.56 min; Song: Song 3, Time: 3.50 min; Song: Song 4, Time: 4.00 min; Song: Song 5, Time: 5.01 min; Song: Song 6, Time: 6.00 min; Song: Song 7, Time: 7.59 min; Song: Song 8, Time: 0.40 min; Song: Song 9, Time: 0.49 min; Song: Song 10, Time: 10.00 min.
            //Album: Album 2; Genre: Pop; Year: 1976; Sold Albums: 20000; Songs(9): Song: Song 2, Time: 2.56 min; Song: Song 3, Time: 3.50 min; Song: Song 4, Time: 4.00 min; Song: Song 5, Time: 5.01 min; Song: Song 6, Time: 6.00 min; Song: Song 7, Time: 7.59 min; Song: Song 8, Time: 0.40 min; Song: Song 9, Time: 0.49 min; Song: Song 10, Time: 10.00 min.
            //Album: Album 3; Genre: Rock; Year: 1980; Sold Albums: 30000; Songs(8): Song: Song 3, Time: 3.50 min; Song: Song 4, Time: 4.00 min; Song: Song 5, Time: 5.01 min; Song: Song 6, Time: 6.00 min; Song: Song 7, Time: 7.59 min; Song: Song 8, Time: 0.40 min; Song: Song 9, Time: 0.49 min; Song: Song 10, Time: 10.00 min.
            //Album: Album 4; Genre: Folk; Year: 2020; Sold Albums: 40000; Songs(8): Song: Song 1, Time: 1.56 min; Song: Song 4, Time: 4.00 min; Song: Song 5, Time: 5.01 min; Song: Song 6, Time: 6.00 min; Song: Song 7, Time: 7.59 min; Song: Song 8, Time: 0.40 min; Song: Song 9, Time: 0.49 min; Song: Song 10, Time: 10.00 min.
            //Album: Album 5; Genre: Pop; Year: 1971; Sold Albums: 50000; Songs(1): Song: Song 5, Time: 5.01 min.
            //Album: Album 6; Genre: Rock; Year: 2001; Sold Albums: 60000; Songs(6): Song: Song 1, Time: 1.56 min; Song: Song 2, Time: 2.56 min; Song: Song 3, Time: 3.50 min; Song: Song 4, Time: 4.00 min; Song: Song 5, Time: 5.01 min; Song: Song 6, Time: 6.00 min.
            //Album: Album 7; Genre: Folk; Year: 2010; Sold Albums: 70000; Songs(1): Song: Song 7, Time: 7.59 min.
            //Album: Album 8; Genre: Rock; Year: 2021; Sold Albums: 0; Songs(0): .
            //Siger Name: Singer 2; Singer Nickname: Nickname 2; Albums: 7
            //Album: Album 2; Genre: Pop; Year: 1976; Sold Albums: 20000; Songs(9): Song: Song 2, Time: 2.56 min; Song: Song 3, Time: 3.50 min; Song: Song 4, Time: 4.00 min; Song: Song 5, Time: 5.01 min; Song: Song 6, Time: 6.00 min; Song: Song 7, Time: 7.59 min; Song: Song 8, Time: 0.40 min; Song: Song 9, Time: 0.49 min; Song: Song 10, Time: 10.00 min.
            //Album: Album 3; Genre: Rock; Year: 1980; Sold Albums: 30000; Songs(8): Song: Song 3, Time: 3.50 min; Song: Song 4, Time: 4.00 min; Song: Song 5, Time: 5.01 min; Song: Song 6, Time: 6.00 min; Song: Song 7, Time: 7.59 min; Song: Song 8, Time: 0.40 min; Song: Song 9, Time: 0.49 min; Song: Song 10, Time: 10.00 min.
            //Album: Album 4; Genre: Folk; Year: 2020; Sold Albums: 40000; Songs(8): Song: Song 1, Time: 1.56 min; Song: Song 4, Time: 4.00 min; Song: Song 5, Time: 5.01 min; Song: Song 6, Time: 6.00 min; Song: Song 7, Time: 7.59 min; Song: Song 8, Time: 0.40 min; Song: Song 9, Time: 0.49 min; Song: Song 10, Time: 10.00 min.
            //Album: Album 5; Genre: Pop; Year: 1971; Sold Albums: 50000; Songs(1): Song: Song 5, Time: 5.01 min.
            //Album: Album 6; Genre: Rock; Year: 2001; Sold Albums: 60000; Songs(6): Song: Song 1, Time: 1.56 min; Song: Song 2, Time: 2.56 min; Song: Song 3, Time: 3.50 min; Song: Song 4, Time: 4.00 min; Song: Song 5, Time: 5.01 min; Song: Song 6, Time: 6.00 min.
            //Album: Album 7; Genre: Folk; Year: 2010; Sold Albums: 70000; Songs(1): Song: Song 7, Time: 7.59 min.
            //Album: Album 8; Genre: Rock; Year: 2021; Sold Albums: 0; Songs(0): .
            //Siger Name: Singer 5; Singer Nickname: Nickname 5; Albums: 0

            //Siger Name: Singer 6; Singer Nickname: Nickname 6; Albums: 1
            //Album: Album 6; Genre: Rock; Year: 2001; Sold Albums: 60000; Songs(6): Song: Song 1, Time: 1.56 min; Song: Song 2, Time: 2.56 min; Song: Song 3, Time: 3.50 min; Song: Song 4, Time: 4.00 min; Song: Song 5, Time: 5.01 min; Song: Song 6, Time: 6.00 min.
            //-------------- -
            //Company Name: Music Company 3
            //Address: Country 1, City 1, Street 1, No 1
            //Owner: Owner 1
            //Singers: 0

            //-------------- -
            //True
            //False
            //True
            //True
            //False
            //True
            //False
            //True
            //False
            //True
            //True
            //Company Name: Music Company 3
            //Address: Country 1, City 1, Street 1, No 1
            //Owner: Owner 1
            //Singers: 2
            //Siger Name: Singer 1; Singer Nickname: Nickname 1; Albums: 8
            //Album: Album 1; Genre: Rock; Year: 1998; Sold Albums: 10000; Songs(10): Song: Song 1, Time: 1.56 min; Song: Song 2, Time: 2.56 min; Song: Song 3, Time: 3.50 min; Song: Song 4, Time: 4.00 min; Song: Song 5, Time: 5.01 min; Song: Song 6, Time: 6.00 min; Song: Song 7, Time: 7.59 min; Song: Song 8, Time: 0.40 min; Song: Song 9, Time: 0.49 min; Song: Song 10, Time: 10.00 min.
            //Album: Album 2; Genre: Pop; Year: 1976; Sold Albums: 20000; Songs(9): Song: Song 2, Time: 2.56 min; Song: Song 3, Time: 3.50 min; Song: Song 4, Time: 4.00 min; Song: Song 5, Time: 5.01 min; Song: Song 6, Time: 6.00 min; Song: Song 7, Time: 7.59 min; Song: Song 8, Time: 0.40 min; Song: Song 9, Time: 0.49 min; Song: Song 10, Time: 10.00 min.
            //Album: Album 3; Genre: Rock; Year: 1980; Sold Albums: 30000; Songs(8): Song: Song 3, Time: 3.50 min; Song: Song 4, Time: 4.00 min; Song: Song 5, Time: 5.01 min; Song: Song 6, Time: 6.00 min; Song: Song 7, Time: 7.59 min; Song: Song 8, Time: 0.40 min; Song: Song 9, Time: 0.49 min; Song: Song 10, Time: 10.00 min.
            //Album: Album 4; Genre: Folk; Year: 2020; Sold Albums: 40000; Songs(8): Song: Song 1, Time: 1.56 min; Song: Song 4, Time: 4.00 min; Song: Song 5, Time: 5.01 min; Song: Song 6, Time: 6.00 min; Song: Song 7, Time: 7.59 min; Song: Song 8, Time: 0.40 min; Song: Song 9, Time: 0.49 min; Song: Song 10, Time: 10.00 min.
            //Album: Album 5; Genre: Pop; Year: 1971; Sold Albums: 50000; Songs(1): Song: Song 5, Time: 5.01 min.
            //Album: Album 6; Genre: Rock; Year: 2001; Sold Albums: 60000; Songs(6): Song: Song 1, Time: 1.56 min; Song: Song 2, Time: 2.56 min; Song: Song 3, Time: 3.50 min; Song: Song 4, Time: 4.00 min; Song: Song 5, Time: 5.01 min; Song: Song 6, Time: 6.00 min.
            //Album: Album 7; Genre: Folk; Year: 2010; Sold Albums: 70000; Songs(1): Song: Song 7, Time: 7.59 min.
            //Album: Album 8; Genre: Rock; Year: 2021; Sold Albums: 0; Songs(0): .
            //Siger Name: Singer 6; Singer Nickname: Nickname 6; Albums: 2
            //Album: Album 6; Genre: Rock; Year: 2001; Sold Albums: 60000; Songs(6): Song: Song 1, Time: 1.56 min; Song: Song 2, Time: 2.56 min; Song: Song 3, Time: 3.50 min; Song: Song 4, Time: 4.00 min; Song: Song 5, Time: 5.01 min; Song: Song 6, Time: 6.00 min.
            //Album: Album 1; Genre: Rock; Year: 1998; Sold Albums: 10000; Songs(10): Song: Song 1, Time: 1.56 min; Song: Song 2, Time: 2.56 min; Song: Song 3, Time: 3.50 min; Song: Song 4, Time: 4.00 min; Song: Song 5, Time: 5.01 min; Song: Song 6, Time: 6.00 min; Song: Song 7, Time: 7.59 min; Song: Song 8, Time: 0.40 min; Song: Song 9, Time: 0.49 min; Song: Song 10, Time: 10.00 min.
            //-------------- -
        }
    }
}
