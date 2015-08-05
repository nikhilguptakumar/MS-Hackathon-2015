using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Net.Http;
using Windows.Storage;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace OnlineOpsMgrMPCatalogMobile
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DownloadScreen : Page
    {
        private string DisplayName { get; set; }
        private string Description { get; set; }
        private string Url { get; set; }
        private string SystemName { get; set; }

        public DownloadScreen()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            MPDataItem mpDataItemClicked = e.Parameter as MPDataItem;
            this.DisplayName = this.MPNameText.Text = mpDataItemClicked.DisplayName;
            this.Description = this.DescriptionValue.Text = mpDataItemClicked.Description;
            this.Url = mpDataItemClicked.DownloadUrl;
            this.SystemName = mpDataItemClicked.SystemName;
        }

        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            downloadUrl();

            this.Frame.Navigate(typeof(SearchScreen), null);
        }

        private async void downloadUrl()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string filename = this.DisplayName  + ".mp";
                var data = await httpClient.GetByteArrayAsync(this.Url);
                var file = await ApplicationData.Current.LocalFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);

                using (var targetStream = await file.OpenAsync(FileAccessMode.ReadWrite))
                {
                    await targetStream.AsStreamForWrite().WriteAsync(data, 0, data.Length);
                    await targetStream.FlushAsync();
                }

            }
        }
    }
}
