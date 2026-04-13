using NUnit.Framework;

namespace MarsRover.Tests;

public class HelloWorldTests
{
    [Test]
    public void Successfully_runs_a_test()
    {
        Assert.That(true, Is.True);
    }
}