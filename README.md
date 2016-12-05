# EventTracker

A wrapper around Memcache which allows an asynchronous environment to keep track of whether a given event has already happened in a specified timespan; useful for example in a situation where duplicate events may be fired but only one is important.

Works like a [debouncer](http://benalman.com/code/projects/jquery-throttle-debounce/docs/files/jquery-ba-throttle-debounce-js.html) but instead of firing after events have calmed down, it fires first and then suppresses any subsequent events in a set timespan.
