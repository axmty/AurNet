using System.Threading.Tasks;
using AurNet.Command;

namespace AurNet
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await CommandRunner.Run(args);
        }
    }
}
