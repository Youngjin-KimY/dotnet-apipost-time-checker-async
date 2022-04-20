using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace memo;

class Program
{
    static async Task Main()
    {

        HttpClient Client = new HttpClient();
        Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        Stopwatch sw = new Stopwatch();
        sw.Start();
        var res1task = postAsync(1);
        
        
        var res2task = postAsync(2);
        
        
        var res3task = postAsync(3);


        var res1 = await res1task;
        
        var res2 = await res2task;
        
        var res3 = await res3task;
        
        sw.Stop();
        Console.WriteLine(String.Format("totolRuningTime : {0}",sw.ElapsedMilliseconds));
        
        Console.WriteLine(String.Format("Total thread {0}",ThreadPool.ThreadCount));
    }

    public static async Task<String> postAsync(int num)
    {
        Random rnd = new Random();
        Console.WriteLine(String.Format("Start {0} with ThreadId_{1}",num,Thread.CurrentThread.ManagedThreadId));
        var time = rnd.Next(1000, 10000);
        
        Stopwatch sw = new Stopwatch();
        
        sw.Start();
        await Task.Delay(time);
        sw.Stop();
        Console.WriteLine(String.Format("DelayTime : {0}",sw.ElapsedMilliseconds));
        Console.WriteLine(String.Format("Complete {0} with ThreadId_{1}",num,Thread.CurrentThread.ManagedThreadId));
        return "2";
    }
}

class student
{
    private string _name = "yjkim";
    public string name
    {
        get => _name;
        set
        {
            _name = value;
        }
    }

    public string dept { get; set; }
    

    public void ChangeName(string name)
    {
        this._name = name;
    }
}

