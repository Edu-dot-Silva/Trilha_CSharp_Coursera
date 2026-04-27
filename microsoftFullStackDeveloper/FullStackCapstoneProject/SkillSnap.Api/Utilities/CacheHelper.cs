using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace SkillSnap.Api.Utilities;

/// <summary>
/// Utility class for cache management and logging
/// </summary>
public class CacheHelper
{
    private readonly IMemoryCache _cache;
    private static int _cacheHits = 0;
    private static int _cacheMisses = 0;

    public CacheHelper(IMemoryCache cache)
    {
        _cache = cache;
    }

    /// <summary>
    /// Gets a value from cache with hit/miss tracking
    /// </summary>
    public bool TryGetValueWithTracking<T>(string key, out T? value)
    {
        if (_cache.TryGetValue(key, out value))
        {
            _cacheHits++;
            return true;
        }
        _cacheMisses++;
        return false;
    }

    /// <summary>
    /// Returns cache statistics for monitoring
    /// </summary>
    public CacheStats GetStats()
    {
        return new CacheStats
        {
            Hits = _cacheHits,
            Misses = _cacheMisses,
            HitRate = _cacheHits + _cacheMisses > 0 
                ? (_cacheHits / (double)(_cacheHits + _cacheMisses)) * 100 
                : 0
        };
    }

    /// <summary>
    /// Resets cache statistics
    /// </summary>
    public void ResetStats()
    {
        _cacheHits = 0;
        _cacheMisses = 0;
    }
}

/// <summary>
/// Cache statistics model
/// </summary>
public class CacheStats
{
    public int Hits { get; set; }
    public int Misses { get; set; }
    public double HitRate { get; set; }

    public override string ToString()
    {
        return $"Cache Hits: {Hits}, Misses: {Misses}, Hit Rate: {HitRate:F2}%";
    }
}
