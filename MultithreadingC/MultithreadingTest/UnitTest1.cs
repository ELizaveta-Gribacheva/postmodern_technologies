namespace MultithreadingTest;

using System.Threading;
using Xunit;

public class GameLoopTests
{
    [Fact]
    public void GameLoop_RunsAndStopsWithoutException()
    {
        var loop = new GameLoop();

        var thread = new Thread(() =>
        {
            loop.Start();
            Thread.Sleep(200); 
            loop.Stop();
        });

        thread.Start();
        thread.Join();

        Assert.True(true); 
    }
}
