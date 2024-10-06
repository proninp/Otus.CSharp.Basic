namespace HomeWork04.Tests;

public class OutusStackTests
{
    [Fact]
    public void ConstructorShouldInitializeStackWithGivenItems()
    {
        // Arrange
        var items = new[] { 1, 2, 3 };

        // Act
        var stack = new OtusSatck<int>(items);

        // Assert
        Assert.Equal(3, stack.Size);
        Assert.Equal(3, stack.Top);
    }

    [Fact]
    public void AddShouldIncreaseSizeAndSetTop()
    {
        // Arrange
        var stack = new OtusSatck<int>();

        // Act
        stack.Add(1);
        stack.Add(2);

        // Assert
        Assert.Equal(2, stack.Size);
        Assert.Equal(2, stack.Top);
    }

    [Fact]
    public void PopShouldReturnTopItemAndDecreaseSize()
    {
        // Arrange
        var stack = new OtusSatck<int>(1, 2, 3);

        // Act
        var poppedItem = stack.Pop();

        // Assert
        Assert.Equal(3, poppedItem);
        Assert.Equal(2, stack.Size);
        Assert.Equal(2, stack.Top);
    }

    [Fact]
    public void PopShouldThrowExceptionWhenStackIsEmpty()
    {
        // Arrange
        var stack = new OtusSatck<int>();

        // Act & Assert
        var exception = Assert.Throws<InvalidOperationException>(() => stack.Pop());
        Assert.Equal("Стек пустой", exception.Message);
    }

    [Fact]
    public void PopAllElementsReturnsNullForTopWhenStackIsEmpty()
    {
        // Arrange
        var stack = new OtusSatck<string>("a", "b", "c");

        // Act
        stack.Pop();
        stack.Pop();
        stack.Pop();

        // Assert
        Assert.Null(stack.Top);
    }

    [Fact]
    public void SizeShouldReturnCorrectNumberOfEmptyStack()
    {
        // Arrange
        var stack = new OtusSatck<string>();

        // Act
        
        // Assert
        Assert.Equal(0, stack.Size);
    }

    [Fact]
    public void SizeShouldReturnCorrectNumberOfItems()
    {
        // Arrange
        var stack = new OtusSatck<int>(1, 2, 3);

        // Act
        stack.Pop();
        stack.Pop();

        // Assert
        Assert.Equal(1, stack.Size);
    }

    [Fact]
    public void ConcatShouldCombineStacks()
    {
        // Arrange
        var stack1 = new OtusSatck<string>("a", "b", "c");
        var stack2 = new OtusSatck<string>("1", "2", "3");

        // Act
        var combinedStack = OtusSatck<string>.Concat(stack1, stack2);

        // Assert
        Assert.Equal(6, combinedStack.Size);
        Assert.Equal("1", combinedStack.Top);
    }

    [Fact]
    public void ConcatThreeStacksReturnsCombinedStack()
    {
        // Arrange
        var stack1 = new OtusSatck<string>("a", "b", "c");
        var stack2 = new OtusSatck<string>("1", "2", "3");
        var stack3 = new OtusSatck<string>("А", "Б", "В");

        // Act
        var resultStack = OtusSatck<string>.Concat(stack1, stack2, stack3);

        // Assert
        Assert.Equal("А", resultStack.Pop());
        Assert.Equal("Б", resultStack.Pop());
        Assert.Equal("В", resultStack.Pop());
        Assert.Equal("1", resultStack.Pop());
        Assert.Equal("2", resultStack.Pop());
        Assert.Equal("3", resultStack.Pop());
        Assert.Equal("a", resultStack.Pop());
        Assert.Equal("b", resultStack.Pop());
        Assert.Equal("c", resultStack.Pop());

        Assert.Throws<InvalidOperationException>(() => resultStack.Pop());
    }

    [Fact]
    public void MergeShouldRetainOrderWhenMergingStacks()
    {
        // Arrange
        var stack1 = new OtusSatck<string>("a", "b", "c");
        var stack2 = new OtusSatck<string>("1", "2", "3");

        // Act
        stack1.Merge(stack2);

        // Assert
        Assert.Equal(6, stack1.Size);
        Assert.Equal("1", stack1.Top);
        stack1.Pop();
        Assert.Equal("2", stack1.Top);
    }
}