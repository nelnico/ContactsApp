namespace Contacts.Api.Common.Extensions;

public static class Extensions
{
    private static readonly Random rnd = new();

    public static T PickRandom<T>(this IList<T> source)
    {
        var randIndex = rnd.Next(source.Count);
        return source[randIndex];
    }
}   