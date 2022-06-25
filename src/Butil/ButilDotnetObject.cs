using System;
using Microsoft.JSInterop;

internal class ButilDotnetObject
{
    [JSInvokable]
    public void DocumentAddEventListener(Guid id, object args)
    {
        var listener = Butil.GetListener(id);
        listener.Invoke();
    }
}
