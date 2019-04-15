using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PCLStorage;
using VideoIssue.Utilities;

namespace VideoIssue
{
    public partial class MainPage : ContentPage
    {
        private ICustomWebClient customWebClient = DependencyService.Get<ICustomWebClient>();

        public MainPage()
        {
            InitializeComponent();
        }

        public async Task CreateExample()
        {
            lblLoading.Text = "Loading...";
            var htmlString = @"<!DOCTYPE html>
                            <html>
                                <head>
                                 <title>Page Title</title>
                                </head>
                                <body>
                                    <h1>This is an example of video issue</h1>
                                    <video width=""560"" height=""315"" controls><source src=""big_buck_bunny_720p_2mb.mp4"" type=""video/mp4""></video>
                                  </body>
                            </html>";
           

            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync("Example", CreationCollisionOption.OpenIfExists);
            IFile file = await folder.CreateFileAsync("Default.html", CreationCollisionOption.ReplaceExisting);

            await file.WriteAllTextAsync(htmlString);
            //save the video
            await customWebClient.DownloadFile("https://sample-videos.com/video123/mp4/720/big_buck_bunny_720p_2mb.mp4", folder.Path + "/" + "big_buck_bunny_720p_2mb.mp4");

            ShowExample();
            lblLoading.Text = "";
        }

        public void ShowExample()
        {
            IFolder folder = FileSystem.Current.LocalStorage.GetFolderAsync("Example").Result;
            webView.Source = String.Format("file://{0}/{1}", folder.Path, "Default.html");
        }

        public async void OnCreateExample(object sender, EventArgs e)
        {
            await CreateExample();
        }
    }
}
