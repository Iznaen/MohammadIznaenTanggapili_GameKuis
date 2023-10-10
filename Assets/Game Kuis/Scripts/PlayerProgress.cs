using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[CreateAssetMenu(
    fileName = "Player Progress",
    menuName = "Game Kuis/Player Progress"
)]

public class PlayerProgress : ScriptableObject
{
    [System.Serializable]
    public struct MainData
    {
        public int koin;
        public Dictionary<string, int> progresLevel;
    }

    [SerializeField]
    private string _filename = "save file.txt";

    public MainData progresData = new MainData();

    public void SimpanProgres()
    {
        // sampel data
        progresData.koin = 0;
        if (progresData.progresLevel == null)
        {
            progresData.progresLevel = new();
            progresData.progresLevel.Add("Level Pack 1", 3);
            progresData.progresLevel.Add("Level Pack 3", 5);
        }

        // informasi penyimpanan data
        var directory = Application.dataPath + "/Temporary";
        var path = directory + "/" + _filename;

        // membuat directory temporary
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
            Debug.Log("Directory has been created: " + directory);
        }

        // membuat file baru
        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
            Debug.Log("File created: " + path);
        }

        // var konten = $"{progresData.koin}\n";
        var fileStream = File.Open(path, FileMode.Open);
        var formatter = new BinaryFormatter();

        fileStream.Flush();
        formatter.Serialize(fileStream, progresData);

        // Menyimpan data ke dalam file menggunakan binary writer
        // var writer = new BinaryWriter(fileStream);

        // writer.Write(progresData.koin);
        // foreach (var i in progresData.progresLevel)
        // {
        //     writer.Write(i.Key);
        //     writer.Write(i.Value);
        // }

        // putuskan aliran memori dengan File
        // writer.Dispose();
        fileStream.Dispose();

        // foreach (var i in progresData.progresLevel)
        // {
        //     konten += $"{i.Key} {i.Value}\n";
        // }

        // File.WriteAllText(path, konten);

        Debug.Log($"{_filename} berhasil disimpan!");
    }

    public bool MuatProgres()
    {
        // informasi penyimpanan data
        var directory = Application.dataPath + "/Temporary";
        var path = directory + "/" + _filename;

        try
        {
            // memuat data dari file menggunakan binary formatter
            var fileStream = File.Open(path, FileMode.Open);
            var formatter = new BinaryFormatter();

            progresData = (MainData)formatter.Deserialize(fileStream);

            fileStream.Dispose();

            Debug.Log($"koin: {progresData.koin} | progres: level {progresData.progresLevel.Count}");

            return true;
        }
        catch (System.Exception e)
        {
            Debug.Log($"ERROR: Terjadi kesalahan saat memuat progres\n{e.Message}");

            return false;
        }
    }
}
