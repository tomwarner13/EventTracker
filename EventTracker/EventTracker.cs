using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;

namespace EventTracking
{
  /// <summary>
  /// A simple wrapper around MemCache that tracks whether a specific event has already been fired within a preset interval of time.
  /// </summary>
  public class EventTracker : IDisposable
  {
    private readonly MemoryCache _cache;
    private readonly TimeSpan _span;

    /// <summary>
    /// Creates a new instance of EventTracker, which will keep track of events occuring within the given timespan
    /// </summary>
    /// <param name="span">The length of time to track events</param>
    public EventTracker(TimeSpan span)
    {
      _cache = new MemoryCache(Guid.NewGuid().ToString());
      _span = span;
    }

    /// <summary>
    /// Check whether an specific event has occured within the recent timespan.
    /// </summary>
    /// <param name="identifier">A string which identifies the specific event</param>
    /// <returns>True if the event has already occured within the specified timespan, otherwise false</returns>
    public bool CheckEvent(string identifier)
    {
      var result = _cache.Get(identifier);

      var policy = new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.Add(_span) };
      _cache.Set(identifier, true, policy);

      return result != null;
    }

    public void Dispose()
    {
      _cache.Dispose();
    }
  }
}
