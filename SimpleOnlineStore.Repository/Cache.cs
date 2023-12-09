using Microsoft.Extensions.Caching.Memory;

namespace Repository
{
    public class Cache
    {
        public string GetCachedData(IMemoryCache memoryCache)
        {            
            if (!memoryCache.TryGetValue("CacheKey", out string cachedData))
                memoryCache.Get("CacheKey");

            return cachedData;
        }

        public void SetCachedData(IMemoryCache memoryCache, string cacheKey, string cacheData)
        {
            memoryCache.Set(cacheKey, cacheData, TimeSpan.FromMinutes(2));
        }

        public void RemoveCachedData(IMemoryCache memoryCache, string cacheKey)
        {
            memoryCache.Remove(cacheKey);
        }
    }
}
