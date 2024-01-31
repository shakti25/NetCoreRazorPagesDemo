namespace RToora.DemoRazorPages.Web.Tests;

public class BasicUnitTests
{
    [Fact]
    public void PassingTest01()
    {
        // Arrange

        // Act

        // Assert
        Assert.Equal(4, Add(2, 2));
    }

    [Fact]
    public void FailingTest01()
    {
        // Arrange

        // Act

        // Assert
        Assert.Equal(5, Add(2, 3));
    }

    int Add(int x, int y)
    {
        return x + y;
    }
}