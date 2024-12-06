using Xunit.Abstractions;

namespace SolutionTests.Tests;

public abstract class BaseTest
{
    protected ITestOutputHelper Output { get; }
    
    public BaseTest(ITestOutputHelper output)
    {
        Output = output;
    }
}