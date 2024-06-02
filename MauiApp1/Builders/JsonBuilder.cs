using System.Collections.Generic;
using System.Text.Json;

public class JsonBuilder
{
    private readonly Dictionary<string, object> _data;

    public JsonBuilder()
    {
        _data = new Dictionary<string, object>();
    }

    public JsonBuilder AddElement(string key, object value)
    {
        _data[key] = value;
        return this;
    }

    public string Build()
    {
        return JsonSerializer.Serialize(_data);
    }
}