using UnityEngine;
using System.IO;
using System.Linq;
using System;

public class FilePersistence : IPersistence
{
    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    const int RANDOM_NAME_LENGTH = 10;

    private ISerializer serializer;

    private string currentData = "";

    private static System.Random random = new System.Random();

    public override void Flush()
    {
        string extension = serializer.GetExtension();

        try
        {
            File.WriteAllText(Application.persistentDataPath + generateRandomString(RANDOM_NAME_LENGTH) + extension, currentData);
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }

        currentData = "";
    }

    //public override void Send(TrackerEvent trackerEvent)
    //{
    //    currentData += serializer.Serialize(trackerEvent);
    //}

    public override void SetFormat(TraceFormats newFormat)
    {
        switch (newFormat)
        {
            case TraceFormats.json:
                serializer = new JsonSerializer();
                serializer.SetFormat(TraceFormats.json);
                break;
        }
    }

    private string generateRandomString(int length)
    {
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}