namespace _12HardDiskTree
{
    public class Folder
    {
		private string name;
		private File[] files;
		private Folder[] folders;

		public Folder(string name, File[] files, Folder[] folders)
		{
			this.Name = name;
			this.Files = files;
			this.Folders = folders;
		}

		public string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}

		public File[] Files
		{
			get { return this.files; }
			set { this.files = value; }
		}

		public Folder[] Folders
		{
			get { return this.folders; }
			set { this.folders = value; }
		}
	}
}