using System.Threading.Tasks;

namespace VideoIssue.Utilities
{
    public interface ICustomWebClient
    {
        Task DownloadFile(string url, string location);
    }
}
