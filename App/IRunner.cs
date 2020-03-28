using System.Threading.Tasks;

namespace AurNet.App
{
    public interface IRunner
    {
        Task<int> RunAsync(string[] args);

        bool IsVerbose(string[] args);
    }
}
