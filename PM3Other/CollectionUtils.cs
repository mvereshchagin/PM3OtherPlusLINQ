namespace PM3Other;

/// <summary>
/// Генераторы
/// </summary>
public static class CollectionUtils
{
    public static IEnumerator<char> GetLimitedEnumerator(this string str, int? minPos = null, int? maxPos = null)
    {
        minPos = minPos ?? 0;
        maxPos = maxPos ?? str.Length;

        for (var i = minPos.Value; i < maxPos.Value; i++)
            yield return str[i];
    }

    /// <summary>
    /// Если назвать метод GetEnumeraotr то работает foreach
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    public static IEnumerator<int> GetEnumerator(this int number)
    {
        for (int i = 0; i < number; i++)
            yield return i;
    }
}