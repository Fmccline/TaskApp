using System;
using System.IO;
using Xamarin.Forms;
using TaskIt_2017.Droid;

[assembly: Dependency(typeof(FileHelper))]
namespace TaskIt_2017.Droid
{
    class FileHelper : IFileHelper
    {
		public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}