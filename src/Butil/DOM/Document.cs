using System;
using System.Dynamic;

namespace Butil;

public static class Document
{
    private const string ElementName = "document";
    private static readonly object FalseUseCapture = false;
    private static readonly object TrueUseCapture = true;

    public static void AddEventListener<T>(string domEvent, Action<T> listener, bool useCapture = false)
    {
        var domEventType = DomEventArgs.TypeOf(domEvent);
        var listenerType = typeof(T);

        if (listenerType != domEventType)
            throw new InvalidOperationException($"Invalid listner type ({listenerType}) for this dom event type ({domEventType})");

        if (domEventType == typeof(DomKeyboardEventArgs))
        {
            var id = DomKeyboardEvent.SetListener(listener as Action<DomKeyboardEventArgs>, ElementName, useCapture ? TrueUseCapture : FalseUseCapture);
            Butil.AddEventListener(ElementName, domEvent, DomKeyboardEvent.InvokeMethodName, id, DomKeyboardEventArgs.SelectedMembers, useCapture);
        }
    }

    public static void RemoveEventListener<T>(string domEvent, Action<T> listener, bool useCapture = false)
    {
        var domEventType = DomEventArgs.TypeOf(domEvent);
        var listenerType = typeof(T);

        if (listenerType != domEventType)
            throw new InvalidOperationException($"Invalid listner type ({listenerType}) for this dom event type ({domEventType})");

        if (domEventType == typeof(DomKeyboardEventArgs))
        {
            var id = DomKeyboardEvent.RemoveListener(listener as Action<DomKeyboardEventArgs>, ElementName, useCapture ? TrueUseCapture : FalseUseCapture);
            Butil.RemoveEventListener(ElementName, domEvent, id, useCapture);
        }
    }
}
