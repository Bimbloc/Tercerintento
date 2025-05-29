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

    private TraceFormats currentFormat; 

    public void Flush()
    {
        string extension = ""; 
        switch (currentFormat)
        {
            case TraceFormats.json:
                extension = ".json";
                break;
        }

        try
        {
            File.WriteAllText(Application.dataPath.Substring(0, Application.dataPath.LastIndexOf('/')) 
                + "/Data/" + generateRandomString(RANDOM_NAME_LENGTH) + extension, currentData);
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }

        currentData = "";
    }

    public void Send(TrackerEvent trackerEvent)
    {
        currentData += serializer.Serialize(trackerEvent);
    }

    public void SetFormat(TraceFormats newFormat)
    {
        currentFormat = newFormat;
        switch (newFormat)
        {
            case TraceFormats.json:
                serializer = new JsonSerializer();
                break;
        }
    }

    private string generateRandomString(int length)
    {
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}