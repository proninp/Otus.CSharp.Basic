namespace HomeWork08.Models;
internal class BinaryTree<T>
    where T : IComparable<T>
{
    private TreeNode<T>? _root;

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

    private TreeNode<T>? SymmetricTraverse(TreeNode<T>? node, Func<T, bool> selector)
    {
        if (node is null)
            return default;

        // TODO

        if (selector(node.Value))
            return node;
    }

    public T? Get(Func<T, bool> selector)
    {
        var node = SymmetricTraverse(_root, selector);
        if (node is null)
            return default;
        return node.Value;
    }


}
