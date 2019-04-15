using System;
using System.Net;
using VideoIssue.Utilities;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(VideoIssue.Droid.CustomWebClient_Android))]
namespace VideoIssue.Droid
{
    public class CustomWebClient_Android : ICustomWebClient
    {
        public async Task DownloadFile(string url, string location)
        {
            using (var webClient = new WebClient())
            {
                try
                {
                    await webClient.DownloadFileTaskAsync(new Uri(url), location);
                }
                catch (Exception ex)
                {
                    // don't do anything if the download of the resource fails
                }
            }
        }
    }
}