using Id3;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage.AccessCache;
using Windows.Storage.Pickers;

namespace Renam3r.Services
{
    public class FilePickServices
    {
        public static FilePickServices FilePickServicesInstance = new FilePickServices();

        public async Task<List<Id3Tag>> GetFilesFromFolder()
        {
            var tagList = new List<Id3Tag>();

            var folderPicker = new FolderPicker
            {
                SuggestedStartLocation = PickerLocationId.Desktop,
                ViewMode = PickerViewMode.List
            };
            folderPicker.FileTypeFilter.Add(".mp3");

            var selectedFolder = await folderPicker.PickSingleFolderAsync();

            if (selectedFolder != null)
            {
                StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickerFolderToken", selectedFolder);
                await Task.Run(async () =>
                {
                    var files = await selectedFolder.GetFilesAsync();
                    foreach (var mediaFile in files)
                    {
                        var file = new Mp3File(mediaFile.Path, Mp3Permissions.ReadWrite);
                        tagList.Add(file.HasTagOfFamily(Id3TagFamily.Version2x) ? file.GetTag(Id3TagFamily.Version2x) : file.GetTag(Id3TagFamily.Version1x));
                        file.Dispose();
                    }
                });

            }

            return tagList;
        }

        //public async Task<List<Mp3File>> GetFilesFromSelection()
        //{

        //}
    }
}
