using Microsoft.Extensions.Caching.Memory;

namespace Core.Utilities.Managers
{
    public class MemoryCacheManager
    {
        private readonly IMemoryCache _memoryCache;
        public MemoryCacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public void Create<T>(string key, T getData, TimeSpan? absoluteExpireTime = null, TimeSpan? slidingExpireTime = null)
        {
            var cacheOptions = new MemoryCacheEntryOptions();

            if (absoluteExpireTime.HasValue)
                cacheOptions.SetAbsoluteExpiration(absoluteExpireTime.Value);

            if (slidingExpireTime.HasValue)
                cacheOptions.SetSlidingExpiration(slidingExpireTime.Value);

            _memoryCache.Set(key, getData, cacheOptions);
        }


    }
}
