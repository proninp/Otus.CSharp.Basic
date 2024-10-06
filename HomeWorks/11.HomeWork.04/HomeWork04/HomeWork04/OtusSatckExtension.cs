namespace HomeWork04;
public static class OtusSatckExtension
{
    public static void Merge<T>(this OtusSatck<T> current, OtusSatck<T> stack)
    {
        while (stack.Size > 0)
            current.Add(stack.Pop());
    }
}
