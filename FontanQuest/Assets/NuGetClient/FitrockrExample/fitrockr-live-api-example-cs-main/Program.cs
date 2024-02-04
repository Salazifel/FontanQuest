using syp.biz.SockJS.NET.Client;
using syp.biz.SockJS.NET.Client.Event;
using syp.biz.SockJS.NET.Common.Interfaces;

namespace fitrockr_live_stomp_sample { }

public static class Program
{
    static string url = "https://api.fitrockr.com/ws";
    static string apiKey = "<api-key>";
    static string tenantId = "<tenantId>";


    public static void Main(string[] args)
    {
        Console.Out.WriteLine("Connect to " + url);
        SockJS.SetLogger(new ConsoleLogger());
        SockJS sockJs = new SockJS(url);
        
        sockJs.AddEventListener("open", (sender, e) => 
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("X-API-Key", apiKey);
            headers.Add("X-Tenant", tenantId);
            sockJs.Connect(headers);
            Console.Out.WriteLine("# CONNECTING");
        });
    
        sockJs.AddEventListener("CONNECTED", (sender, e) =>
        {
            Console.Out.WriteLine($"# CONNECTED!");
            sockJs.Subscribe("/topic/live/" + tenantId, new Dictionary<string, string>());
        });
        
        sockJs.AddEventListener("MESSAGE", (sender, e) =>
        {
            if (e[0] is not TransportMessageEvent msg) return;
            var dataString = msg.Data.ToString();
            Console.Out.WriteLine(dataString);
        });
        
        sockJs.AddEventListener("close", (sender, e) =>
        {
            Console.WriteLine("Connection closed");
        });
        
        Console.WriteLine("\npress any key to exit the process...");
        Console.ReadKey();
    }
}

internal class ConsoleLogger : ILogger
{
    public void Debug(string message) { /* Ignore low level debug messages */ }

    public void Error(string message) => Console.Out.WriteLine(($"{DateTime.Now:s} [ERR] {message}"));

    public void Info(string message) => Console.Out.WriteLine($"{DateTime.Now:s} [INF] {message}");
}