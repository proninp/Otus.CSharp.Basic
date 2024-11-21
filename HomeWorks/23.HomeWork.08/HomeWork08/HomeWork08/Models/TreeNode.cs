namespace HomeWork08.Models;
public class TreeNode<T> where T : IComparable<T>
{
    public required T Value { get; set; }

    public TreeNode<T>? Left { get; set; }

    public TreeNode<T>? Right { get; set; }
}
