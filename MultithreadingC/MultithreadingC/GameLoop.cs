using System;
using System.Diagnostics;
using System.Threading;

public class GameLoop
{
    private const int TargetFps = 60;
    private const double TargetFrameTime = 1000.0 / TargetFps; 

    private bool _running;
    private Thread? _loopThread;

    public void Start()
    {
        if (_running) return;
        _running = true;

        _loopThread = new Thread(RunLoop);
        _loopThread.Start();
    }

    public void Stop()
    {
        _running = false;
        _loopThread?.Join();
    }

    private void RunLoop()
    {
        var stopwatch = new Stopwatch();

        while (_running)
        {
            stopwatch.Restart();
            
            Update(TargetFrameTime / 1000.0); 
            
            stopwatch.Stop();
            var elapsed = stopwatch.Elapsed.TotalMilliseconds;
            var sleepTime = TargetFrameTime - elapsed;

            if (sleepTime > 0)
                Thread.Sleep((int)sleepTime);
        }
    }

    private void Update(double deltaTime)
    {
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Update called — deltaTime: {deltaTime:F4}s");
    }
}