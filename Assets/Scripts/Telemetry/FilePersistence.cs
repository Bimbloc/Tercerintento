using UnityEngine;
using System.IO;
using System.Linq;
using System;

[CreateAssetMenu(fileName = "FilePersistence", menuName = "ScriptableObjects/IPersistance/FilePersistence")]
public class FilePersistence : IPersistence
{
    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    const int RANDOM_NAME_LENGTH = 10;

    private string currentData = "";

    private static System.Random random = new System.Random();

    public override void Flush() {
        string extension = serializer.GetExtension();

        while (queue.HasEvents()) {
            currentData += serializer.Serialize(queue.HandleEvent());
        }

        try {
            string dataFolder = Path.Combine(Application.persistentDataPath, "Data");
            if (!Directory.Exists(dataFolder))
            {
                Directory.CreateDirectory(dataFolder);
            }
            File.WriteAllText(dataFolder + "/" + generateRandomString(RANDOM_NAME_LENGTH) + extension, currentData);
        }
        catch (Exception e) {
            Debug.LogException(e);
        }

        currentData = "";
    }

    private string generateRandomString(int length)
    {
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}