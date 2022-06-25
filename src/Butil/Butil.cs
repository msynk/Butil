using System;
using System.Collections.Generic;
using Microsoft.JSInterop;

public static class Butil
{
    private static bool _isInitialized;
    private static IJSRuntime _jsRuntime = default!;
    private static Dictionary<Guid, Action> _listeners = new();

    public static void Init(IJSRuntime jsRuntime)
    {
        if (_isInitialized) return;

        _isInitialized = true;
        _jsRuntime = jsRuntime;
        var dotnetObj = DotNetObjectReference.Create(new ButilDotnetObject());
        _jsRuntime.InvokeVoidAsync("butil.init", dotnetObj);
    }

    public static void Register(string elementName, string eventName, string dotnetMethodName, Guid dotnetMethodId, string[] selectedMembers)
    {
        _jsRuntime.InvokeVoidAsync("butil.register", elementName, eventName, dotnetMethodName, dotnetMethodId, selectedMembers);
    }

    public static Action GetListener(Guid id)
    {
        return _listeners[id];
    }

    public static Guid SetListener(Action listener)
    {
        var id = Guid.NewGuid();
        _listeners[id] = listener;
        return id;
    }
}
