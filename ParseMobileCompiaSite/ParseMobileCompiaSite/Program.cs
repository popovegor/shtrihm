using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Net;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Web.Configuration;
using System.Configuration;

namespace ParseM3Mobile
{
  class Program
  {
    static void Main(string[] args)
    {
      long i = 0;
      DateTime dt = new DateTime(2011, 01, 01);
      DateTime stop = DateTime.Now;
      ConcurrentBag<string> urls = new ConcurrentBag<string>();
      while (dt <= stop)
      {
        urls.Add(string.Format("http://download.m3mobile.co.kr/SDK/M3SKY/SDK/M3SKY_SDK_ver1.0.0_{0:00}{1:00}{2:00}.zip", dt.Year, dt.Month, dt.Day));
        dt = dt.AddDays(1);
        Interlocked.Increment(ref i);
      }

      Console.WriteLine(i);

      //HttpRuntimeSection setting = ConfigurationManager.GetSection("httpruntime") as HttpRuntimeSection;
      //setting.m

      foreach(var v in urls)
      {
          var req = WebRequest.Create(v);
          req.Method = "HEAD";
          var res = req.BeginGetResponse(new AsyncCallback(ar =>
          {
            var r = (ar.AsyncState as HttpWebRequest);
            try
            {
              r.EndGetResponse(ar);
              Console.WriteLine(string.Concat(r.RequestUri, ": ", "success"));
            }
            catch (Exception)
            {
              Console.WriteLine(string.Concat(r.RequestUri, ": ", "failed"));
            }
            finally
            {
              Interlocked.Decrement(ref i);
              Console.WriteLine(i);
            }
          }), req);
      };
      while (Interlocked.Read(ref i) != 0)
      {
        Thread.Sleep(1000);
      }
    }
  }
}
