# EventTracker

A wrapper around Memcache which allows an asynchronous environment to keep track of whether a given event has already happened in a specified timespan; useful for example in a situation where duplicate events may be fired but only one is important.
