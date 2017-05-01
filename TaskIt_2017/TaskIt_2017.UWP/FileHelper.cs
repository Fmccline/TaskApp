using System;
using System.IO;
using Xamarin.Forms;
using TaskIt_2017.UWP;
using Windows.Storage;

[assembly: Dependency(typeof(FileHelper))]
namespace TaskIt_2017.UWP
{
    class FileHelper : IFileHelper
    {
        public string get_local_file_path(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);

        }
    }
}