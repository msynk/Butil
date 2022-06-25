using System;


public static class Document
{
    private static string ElementName = "document";
    public static void AddEventListener(string type, Action listener, bool useCapture)
    {
        var id = Butil.SetListener(listener);
        Butil.Register(ElementName, type, "DocumentAddEventListener", id, new string[] { });
    }
}
