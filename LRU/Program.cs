// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var cacheStore = new Dictionary<string, CacheValue>();

async Task<Object?> GetValue(string key)
{
    if(cacheStore.TryGetValue(key, out CacheValue cacheValue))
    {
        cacheValue._counter++;
        return cacheValue._value;
    }
    dynamic a = 1;
    a = a + 1;
    return null;
}

async Task<Object?> Set(string key, Object? value)
{
    if(cacheStore.TryGetValue(key, out CacheValue cacheValue))
    {
        cacheValue._counter=0;
        cacheValue._value = value;
        return cacheValue._value;
    }
    else
    {
        cacheStore.Add(key, new CacheValue{_counter = 0, _value = value});
        return value;
    }
}

async Task RemoveLRU(int counterOffset)
{
    var keyList = cacheStore.Where(x => x.Value._counter < counterOffset)
        .Select(x => x.Key);

    foreach(var key in keyList)
        cacheStore.Remove(key);
}


public class CacheValue{
    public int _counter = 0;
    public Object? _value;
}