namespace ConsoleApp.Utils
{
    using System;

    public static class ArrayUtils
    {
        public static T GetValueOrDefault<T>(this T[] array, int index)
        {
            return index < array.Length ? array[index] : default(T);
        }
    }
}
