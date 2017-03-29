using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecialApp.Web.Helpers
{
  public static class GenerixExtensions
  {
    public static void AddSpecialWebAppCompression(this IServiceCollection services)
    {
      //https://www.softfluent.com/blog/dev/2017/01/13/Enabling-gzip-compression-with-ASP-NET-Core
      services.Configure<GzipCompressionProviderOptions>(options => options.Level = System.IO.Compression.CompressionLevel.Optimal);
      services.AddResponseCompression();
    }
  }
}
