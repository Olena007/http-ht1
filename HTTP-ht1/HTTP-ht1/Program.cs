
using HTTP_ht1.Services;

Console.WriteLine("Let's get started");

var start = new StartService();

await Task.WhenAll(start.GetHttp(), start.PostHttp(), start.PutHttp(), start.DeleteHttp(), start.PostRS(), start.PostRU(), start.PostLS());
