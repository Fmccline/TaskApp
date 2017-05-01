using System;
using System.IO;

using Xamarin.Forms;
using TaskIt_2017.iOS;

[assembly: Dependency(typeof(FileHelper))]
namespace TaskIt_2017.iOS
{
    class FileHelper : IFileHelper
    {
        public string get_local_file_path(string filename)
        {
            string doc_folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string lib_folder = Path.Combine(doc_folder, "..", "Library", "Databases");

            if (!Directory.Exists(lib_folder))
            {
                Directory.CreateDirectory(lib_folder);
            }

            return Path.Combine(lib_folder, filename);
        }
    }
}