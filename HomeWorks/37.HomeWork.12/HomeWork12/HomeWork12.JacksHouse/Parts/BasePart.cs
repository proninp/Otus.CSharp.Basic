using System.Collections.Immutable;

namespace HomeWork12.JacksHouse.Parts;
public abstract class BasePart
{
    public ImmutableList<string> Poem { get; protected set; } = [];

    public ImmutableList<string> AddPoem(ImmutableList<string> list)
    {
        var poemText = GetPoemText();
        Poem = list.Add(poemText);
        return Poem;
    }

    protected abstract string GetPoemText();
}