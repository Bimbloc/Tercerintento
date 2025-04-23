using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class FilePersistence : IPersistence
{
    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    const int RANDOM_NAME_LENGTH = 8;

    private ISerializer serializer;

    private string currentData = "";

    private static System.Random random = new System.Random();

    public void Flush()
    {
        File.WriteAllText(generateRandomString(RANDOM_NAME_LENGTH), currentData);
        currentData = "";
    }

    public void Send(ITrackerEvent trackerEvent)
    {
        currentData += serializer.Serialize(trackerEvent);
    }

    public void SetFormat(TraceFormats newformat)
    {
        switch (newformat)
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