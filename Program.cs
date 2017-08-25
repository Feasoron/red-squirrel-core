using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace RedSquirrel
{
    public class Program
    {
      public static void Main(string[] args)
       {
           BuildWebHost(args).Run();
       }
    }
}
