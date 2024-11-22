using System.ComponentModel.Design;
using HomeWork08.Abstractions;

namespace HomeWork08.Models;
public class BinaryTree<T>
    where T : class, IComparable<T>
{
    private TreeNode<T>? _root;
    private readonly IEntityPrinter<T> _printer;

    public BinaryTree(IEntityPrinter<T> printer)
    {
        _printer = printer;
    }

    public void Add(T value)
    {
        if (_root is null)
        {
            _root = new TreeNode<T> { Value = value };
            return;
        }
        Add(_root, value);
    }

    private void Add(TreeNode<T> node, T value)
    {
        if (node.Value.CompareTo(value) > 0)
        {
            if (node.Left is null)
                node.Left = new TreeNode<T> { Value = value };
            else
                Add(node.Left, value);
        }
        else
        {
            if (node.Right is null)
                node.Right = new TreeNode<T> { Value = value };
            else
                Add(node.Right, value);
        }
    }

    public void SymmetricTraverse()
    {
        if (_root is not null)
            SymmetricTraverse(_root);
    }


    private void SymmetricTraverse(TreeNode<T> node)
    {
        if (node.Left is not null)
            SymmetricTraverse(node.Left);

        _printer.ShowInfo(node.Value);

        if (node.Right is not null)
            SymmetricTraverse(node.Right);
    }

    public T? Get(Func<T, int> comparer)
    {
        return Get(_root, comparer);
    }

    private T? Get(TreeNode<T>? node, Func<T, int> comparer)
    {
        if (node is null)
            return default;
        var compareResult = comparer(node.Value);
        if (compareResult > 0)
        {
            return Get(node.Left, comparer);
        }
        else if (compareResult < 0)
        {
            return Get(node.Right, comparer);
        }
        else
        {
            return node.Value;
        }
    }
}
