namespace CommonLibrary.Extensions
{
    public static class EnumerableExtension
    {
        public static bool In<T>(this T? value, IEnumerable<T> collection)
        {
            return collection.Contains(value);
        }

        public static bool In<T>(this T? value, params T?[] collection)
        {
            return collection.Contains(value);
        }

        public static IEnumerable<T> NotNull<T>(this IEnumerable<T?> collection)
        {
            return collection.Where(x => x != null).Select(x => x!);
        }

        public static async Task<IEnumerable<T>> WaitAllAsync<T>(this IEnumerable<Task<T>> collection)
        {
            var tasks = collection.ToArray();

            await Task.WhenAll(tasks);

            return tasks.Select(x => x.Result);
        }

        public static async Task WaitAllAsync(this IEnumerable<Task> collection)
        {
            await Task.WhenAll(collection.ToArray());
        }

        public static async Task<List<T>> ToListAsync<T>(this Task<IEnumerable<T>> collectionTask)
        {
            var collection = await collectionTask;
            return collection.ToList();
        }

        public static async Task<T[]> ToArrayAsync<T>(this Task<IEnumerable<T>> collectionTask)
        {
            var collection = await collectionTask;
            return collection.ToArray();
        }
    }
}
