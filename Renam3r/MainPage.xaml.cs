using Id3;
using Renam3r.Services;
using System;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x407 dokumentiert.

namespace Renam3r
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MainPage : Page
    {        
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void folderBtn_Click(object sender, RoutedEventArgs e)
        {
            itemListView.ItemsSource = await FilePickServices.FilePickServicesInstance.GetFilesFromFolder();
        }

        private async void filesBtn_Click(object sender, RoutedEventArgs e)
        {
            var filesPicker = new FileOpenPicker
            {
                SuggestedStartLocation = PickerLocationId.Desktop,
                ViewMode = PickerViewMode.List
            };
            filesPicker.FileTypeFilter.Add("*");

            var blub = await filesPicker.PickMultipleFilesAsync();            
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void itemListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem != null)
            {
                DataContext = e.ClickedItem as Id3Tag;
            }
        }
    }
}
