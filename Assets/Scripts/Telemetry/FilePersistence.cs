using UnityEngine;
using System.IO;
using System.Linq;
using System;
using System.Text;

[CreateAssetMenu(fileName = "FilePersistence", menuName = "ScriptableObjects/IPersistance/FilePersistence")]
public class FilePersistence : IPersistence
{
    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    const int RANDOM_NAME_LENGTH = 10;

    private string currentData = "";

    private static System.Random random = new System.Random();

    private FileStream file = null;

    public override void Flush() {
        while (queue.HasEvents()) {
            currentData += serializer.Serialize(queue.HandleEvent());
        }

        if (file != null) {
            try {
                byte[] info = new UTF8Encoding(true).GetBytes(currentData);
                file.Write(info, 0, info.Length);
            } catch (Exception e) {
                Debug.LogException(e);
            }
        }

        currentData = "";
    }

    private string generateRandomString(int length) {
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    public override void Init() {
        try {
            string dataFolder = Path.Combine(Application.persistentDataPath, "Data");
            if (!Directory.Exists(dataFolder)) {
                Directory.CreateDirectory(dataFolder);
            }
            file = File.OpenWrite(Path.Combine(dataFolder, generateRandomString(RANDOM_NAME_LENGTH) + serializer.GetExtension()));
        } catch(Exception e) {
            Debug.LogException(e);
            file = null;
        }
    }

    public override void End() {
        file?.Close();
        file = null;
    }
}