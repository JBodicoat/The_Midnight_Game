﻿// Jack

using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

/// Handles saving and loading game data.
public static class SaveLoad_Jack
{
    public static List<Level1SaveData_Jack> savedGames = new List<Level1SaveData_Jack>();

    public static void Save()
    {
        savedGames.Add(Level1SaveData_Jack.current);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd");
        bf.Serialize(file, savedGames);
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGames.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            savedGames = (List<Level1SaveData_Jack>)bf.Deserialize(file);
            file.Close();
        }
    }
}
