using System;
using System.IO;

using Xamarin.Forms;
using TaskIt_2017.iOS;

[assembly: Dependency(typeof(FileHelper))]
namespace TaskIt_2017.iOS
{
    class FileHelper : IFileHelper
    {
		public string GetLocalFilePath(string filename)
        {
			string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);
        }
    }
}