using System;
using System.Threading.Tasks;
using AurNet.Http;

namespace AurNet
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var client = new AurHttpClient();
            var response = await client.Search("foobar", SearchField.NameDesc);
            Console.WriteLine(response);
        }
    }
}
