using System;

namespace _03FileSystem
{
    public class ComputerStorageTest
    {
        private static BinaryFile binaryFile1 = new BinaryFile("BinaryFile1", DateTime.Now, DateTime.Now, new byte[1024]);
        private static BinaryFile binaryFile2 = new BinaryFile("BinaryFile2", DateTime.Now, DateTime.Now, new byte[1024]);
        private static BinaryFile binaryFile3 = new BinaryFile("BinaryFile3", DateTime.Now, DateTime.Now, new byte[1024]);
        private static BinaryFile binaryFile4 = new BinaryFile("BinaryFile4", DateTime.Now, DateTime.Now, new byte[1024]);
        private static BinaryFile binaryFile5 = new BinaryFile("BinaryFile5", DateTime.Now, DateTime.Now, new byte[1024]);
        private static BinaryFile binaryFile6 = new BinaryFile("BinaryFile6", DateTime.Now, DateTime.Now, new byte[1024]);
        private static BinaryFile binaryFile7 = new BinaryFile("BinaryFile7", DateTime.Now, DateTime.Now, new byte[1024]);
        private static BinaryFile binaryFile8 = new BinaryFile("BinaryFile8", DateTime.Now, DateTime.Now, new byte[1024]);
        private static BinaryFile binaryFile9 = new BinaryFile("BinaryFile9", DateTime.Now, DateTime.Now, new byte[1024]);        

        private static TextFile textFile1 = new TextFile("TextFile1", DateTime.Now, DateTime.Now, "File content ...");
        private static TextFile textFile2 = new TextFile("TextFile2", DateTime.Now, DateTime.Now, "File content ...");
        private static TextFile textFile3 = new TextFile("TextFile3", DateTime.Now, DateTime.Now, "File content ...");
        private static TextFile textFile4 = new TextFile("TextFile4", DateTime.Now, DateTime.Now, "File content ...");
        private static TextFile textFile5 = new TextFile("TextFile5", DateTime.Now, DateTime.Now, "File content ...");
        private static TextFile textFile6 = new TextFile("TextFile6", DateTime.Now, DateTime.Now, "File content ...");
        private static TextFile textFile7 = new TextFile("TextFile7", DateTime.Now, DateTime.Now, "File content ...");
        private static TextFile textFile8 = new TextFile("TextFile8", DateTime.Now, DateTime.Now, "File content ...");
        private static TextFile textFile9 = new TextFile("TextFile9", DateTime.Now, DateTime.Now, "File content ...");       

        private static Directory directory1 = new Directory("Directory1", DateTime.Now, new File[] { binaryFile1, binaryFile2, binaryFile3 });
        private static Directory directory2 = new Directory("Directory2", DateTime.Now, new File[] { textFile1, textFile2, textFile3 });
        private static Directory directory3 = new Directory("Directory3", DateTime.Now, new File[] { binaryFile4, binaryFile5, binaryFile6, textFile4, textFile5, textFile6 });
        private static Directory directory4 = new Directory("Directory4", DateTime.Now);
        private static Directory directory5 = new Directory("Directory5", DateTime.Now, directory1, directory2);
        private static Directory directory6 = new Directory("Directory6", DateTime.Now, new File[] { binaryFile7, binaryFile8, textFile7, textFile8 }, directory4, directory5);

        private static Device device1 = new Device("Device1", directory6);
        private static Device device2 = new Device("Device2", directory5);
        private static Device device3 = new Device("Device3", directory3);

        private static ComputerStorage computerStorage = new ComputerStorage(new Device[] { device1, device2 });

        public static void TestComputerStorage()
        {
            Console.WriteLine(computerStorage);

            directory4.AddFile(binaryFile9);
            directory4.AddFile(textFile9);

            directory3.RemoveFile(binaryFile4);
            directory3.RemoveFile(textFile4);

            directory4.AddFile(binaryFile4);
            directory4.AddFile(textFile4);

            directory6.RemoveDirectory(directory5);

            directory4.AddDirectory(directory5);

            Console.WriteLine(computerStorage.AddDevice(device3));
            Console.WriteLine(computerStorage.AddDevice(device3));

            Console.WriteLine(computerStorage.RemoveDevice(device2));
            Console.WriteLine(computerStorage.RemoveDevice(device2));

            Console.WriteLine(computerStorage);
        }

        //Expected output:
        //Device: Device1
        //Directory6\
        //Directory6\BinaryFile7.bin
        //Directory6\BinaryFile8.bin
        //Directory6\TextFile7.txt
        //Directory6\TextFile8.txt
        //Directory6\Directory4\
        //Directory6\Directory5\
        //Directory6\Directory5\Directory1\
        //Directory6\Directory5\Directory1\BinaryFile1.bin
        //Directory6\Directory5\Directory1\BinaryFile2.bin
        //Directory6\Directory5\Directory1\BinaryFile3.bin
        //Directory6\Directory5\Directory2\
        //Directory6\Directory5\Directory2\TextFile1.txt
        //Directory6\Directory5\Directory2\TextFile2.txt
        //Directory6\Directory5\Directory2\TextFile3.txt

        //Device: Device2
        //Directory5\
        //Directory5\Directory1\
        //Directory5\Directory1\BinaryFile1.bin
        //Directory5\Directory1\BinaryFile2.bin
        //Directory5\Directory1\BinaryFile3.bin
        //Directory5\Directory2\
        //Directory5\Directory2\TextFile1.txt
        //Directory5\Directory2\TextFile2.txt
        //Directory5\Directory2\TextFile3.txt

        //True
        //False
        //True
        //False
        //Device: Device1
        //Directory6\
        //Directory6\BinaryFile7.bin
        //Directory6\BinaryFile8.bin
        //Directory6\TextFile7.txt
        //Directory6\TextFile8.txt
        //Directory6\Directory4\
        //Directory6\Directory4\BinaryFile4.bin
        //Directory6\Directory4\BinaryFile9.bin
        //Directory6\Directory4\TextFile4.txt
        //Directory6\Directory4\TextFile9.txt
        //Directory6\Directory4\Directory5\
        //Directory6\Directory4\Directory5\Directory1\
        //Directory6\Directory4\Directory5\Directory1\BinaryFile1.bin
        //Directory6\Directory4\Directory5\Directory1\BinaryFile2.bin
        //Directory6\Directory4\Directory5\Directory1\BinaryFile3.bin
        //Directory6\Directory4\Directory5\Directory2\
        //Directory6\Directory4\Directory5\Directory2\TextFile1.txt
        //Directory6\Directory4\Directory5\Directory2\TextFile2.txt
        //Directory6\Directory4\Directory5\Directory2\TextFile3.txt

        //Device: Device3
        //Directory3\
        //Directory3\BinaryFile5.bin
        //Directory3\BinaryFile6.bin
        //Directory3\TextFile5.txt
        //Directory3\TextFile6.txt
    }
}