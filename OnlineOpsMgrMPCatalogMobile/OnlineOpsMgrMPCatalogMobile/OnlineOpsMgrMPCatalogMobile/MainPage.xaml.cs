using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.Data.Json;
using System.ComponentModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace OnlineOpsMgrMPCatalogMobile
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private const string urlPattern = @"http://nikgupta-pc.fareast.corp.microsoft.com/CatalogSDK/api/managementpacks?pattern=";
        public string SearchPattern { get; set; }
       
        MPDataItemList _itemList;
        public MainPage()
        {
            InitializeComponent();

            NavigationCacheMode = NavigationCacheMode.Required;
            this.Loaded += MainPage_Loaded;
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //_itemList = new MPDataItemList(urlPattern + this.SearchPattern);
            //MPListItems.ItemsSource = _itemList;
            loadUrl();
            //if (_itemList.Count == 0)
            //{
            //    NoRecordTextBlock.Visibility = Visibility.Visible;
            //    BackButton.Visibility = Visibility.Visible;
            //    MPListItems.Visibility = Visibility.Collapsed;
            //}
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.SearchPattern = e.Parameter as string;
            //loadUrl();
        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DownloadScreen), MPListItems.SelectedItem as MPDataItem);
        }

        private void loadUrl()
        {
            NoRecordTextBlock.Visibility = Visibility.Collapsed;
            BackButton.Visibility = Visibility.Collapsed;
            MPListItems.Visibility = Visibility.Visible;
            _itemList = new MPDataItemList(urlPattern + this.SearchPattern);
            MPListItems.ItemsSource = _itemList;
         }

        private void BackButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SearchScreen), null);
        }
    }

    public class MPDataItemList : ObservableCollection<MPDataItem>
    {
        public MPDataItemList(string url)
        {
            loadData(url);
        }

        public async void loadData(string url)
        {
            HttpClient http = new HttpClient();
            HttpResponseMessage response = await http.GetAsync(url);
            string webresponse = await response.Content.ReadAsStringAsync();

            JsonArray jsonArray = JsonValue.Parse(webresponse).GetArray();

            foreach (JsonValue itemValue in jsonArray)
            {
                JsonObject itemObject = itemValue.GetObject();

                this.Add(
                    new MPDataItem(
                        int.Parse(itemObject["Id"].Stringify().Trim('"')),
                        int.Parse(itemObject["Type"].Stringify().Trim('"')),
                        itemObject["Description"].Stringify().Trim('"'),
                        itemObject["DisplayName"].Stringify().Trim('"'),
                        itemObject["SystemName"].Stringify().Trim('"'),
                        itemObject["DownloadURL"].Stringify().Trim('"'),
                        int.Parse(itemObject["ParentId"].Stringify().Trim('"'))
                    )
                );
            }
        }
    }

    public class MPDataItem:INotifyPropertyChanged
    {
        private string _description, _displayname;
        public MPDataItem(String Description, String DisplayName)
        {
            this.DisplayName = DisplayName;
            this.Description = Description;
        }
        public MPDataItem(int id, int type, string description, string displayName, string systemName, string downloadUrl, int parentId)
        {
            Id = id;
            Type = type;
            Description = description;
            DisplayName = displayName;
            SystemName = systemName;
            DownloadUrl = downloadUrl;
            ParentId = parentId;
        }

        public int Id { get; private set; }
        public int Type { get; private set; }
        public string Description 
        { 
            get
            {
                return _description;
            }
            set
            {
                if(_description !=value) // old value not same as new value
                {
                    _description = value; //update new value
                    OnPropertyChanged(new PropertyChangedEventArgs("Description"));
                }
            }
        }
        public string DisplayName
        {
            get
            {
                return _displayname;
            }
            set
            {
                if (_displayname != value) // old value not same as new value
                {
                    _displayname = value; //update new value
                    OnPropertyChanged(new PropertyChangedEventArgs("DisplayName"));
                }
            }
        }
        public string SystemName { get; private set; }
        public string DownloadUrl { get; private set; }
        public int ParentId { get; private set; }

        public override string ToString()
        {
            return DisplayName;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, args);
        }
           
    }

}
