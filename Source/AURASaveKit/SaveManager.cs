using FlaxEngine;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace AURASaveKit;

/// <summary>
/// Represents the result codes for save/load operations.
/// </summary>
public enum OpResultCode
{
    /// <summary>
    /// The operation completed successfully.
    /// </summary>
    Success,
    /// <summary>
    /// The specified file was not found.
    /// </summary>
    FileNotFound,
    /// <summary>
    /// The specified file could not be read.
    /// </summary>
    DirectoryNotFound,
    /// <summary>
    /// No changes were detected during the operation.
    /// </summary>
    NoChangesDetected,
    /// <summary>
    /// The data was invalid or corrupted.
    /// </summary>
    InvalidData,
}

/// <summary>
/// Manages the registration and saving of save components.
/// </summary>
public class SaveManager
{
    /// <summary>
    /// List of registered save components. These will have their data saved.
    /// </summary>
    public static List<SaveComponent> RegisteredComponents = new List<SaveComponent>();

    /// <summary>
    /// Gets the file path where save data will be stored.
    /// </summary>
    public static string SaveFilePath => AURASaveKit.Instance.Settings.SaveFilePath;

    /// <summary>
    /// Gets or sets the name of the current save file.
    /// </summary>
    public static string CurrentSaveName { get; set; } = "DefaultSave";

    public static AURASaveKit_Settings Settings => AURASaveKit.Instance.Settings;

    /// <summary>
    /// Clears the list of registered save components.
    /// </summary>


    static string path => Path.Combine(
                Settings.SaveFilePath,
                CurrentSaveName + Settings.FileExtension
            );

    /// <summary>
    /// Writes the data of the DataProfile to the save file.
    /// </summary>
    public static void WriteData(DataProfile Data, out OpResultCode Result)
    {
        CurrentSaveName = new string(
            CurrentSaveName.Where(
                c => char.IsLetterOrDigit(c) || c == '_' || c == '-' || c == '.'
            ).ToArray());

        Debug.LogWarning("SAVING TO: " + path);

        if (!Directory.Exists(Settings.SaveFilePath) && Settings.CreateDirectories)
        {
            Directory.CreateDirectory(Settings.SaveFilePath);
        } else if (!Directory.Exists(Settings.SaveFilePath))
        {
            Debug.LogError("Save directory does not exist: " + Settings.SaveFilePath);
            Result = OpResultCode.DirectoryNotFound;
            return;
        }

        JObject SaveData;
        string NewHash = Data.GenerateHash();

        if (File.Exists(path))
        {
            string FileContents = File.ReadAllText(path);
            SaveData = JObject.Parse(FileContents);

            JObject Hashes = SaveData["Meta"]["Hashes"] as JObject;
            if (Hashes != null && Hashes.TryGetValue(Data.GetComponentName(), out JToken OldHash))
            {
                if (OldHash.Value<string>() == NewHash)
                {
                    // No changes detected, no need to save
                    Debug.Log("No changes detected on "
                        + Data.GetComponentName() + ". Skipping save.");
                    Result = OpResultCode.NoChangesDetected;
                    return;
                }
            } else {
                Hashes[Data.GetComponentName()] = NewHash;
            }
        }
        else
        {
            SaveData = new JObject();

            SaveData["Meta"] = new JObject
            {
                ["SaveVersion"] = AURASaveKit.Version.ToString(),
                ["DateTime"] = DateTime.UtcNow.ToString("yyy-MM-dd HH:mm:ss"),
                ["Hashes"] = new JObject()
            };
        }

        SaveData["Meta"]["Version"] = AURASaveKit.Version.ToString();
        SaveData["Meta"]["DateTime"] = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");

        SaveData["Meta"]["Hashes"][Data.GetComponentName()] = NewHash;

        SaveData[Data.GetComponentName()] = JObject.Parse(
            FlaxEngine.Json.JsonSerializer.Serialize(Data)
        );

        File.WriteAllText(path, SaveData.ToString(Newtonsoft.Json.Formatting.Indented));
        Result = OpResultCode.Success;
    }

    /// <summary>
    /// Reads the data from the save file and returns it as a DataProfile object.
    /// </summary>
    public static T ReadData<T>(T Data, out OpResultCode Success) where T : DataProfile, new()
    {

        if (!File.Exists(path)) {
            Debug.LogError("File not found: " + path);
            Success = OpResultCode.FileNotFound;
            return default;
        }

        String JsonText = File.ReadAllText(path);
        JObject SaveData = JObject.Parse(JsonText);

        String OldHash = SaveData["Meta"]["Hashes"][Data.GetComponentName()].ToString();

        String NewHash = Data.GenerateHash();

        if (OldHash == NewHash)
        {
            Debug.Log("No changes detected on " + Data.GetComponentName() + ". Skipping load.");
            Success = OpResultCode.NoChangesDetected;
            return default;
        }

        // Here you would implement the logic to read the data from a file or other storage.
        // For now, we just return the passed data.
        Success = OpResultCode.Success;
        return Data;
    }

    public static void DispatchLoad() {
        for (int i = 0; i < RegisteredComponents.Count; i++)
        {
            RegisteredComponents[i].Load();
        }
    }

    public static void DispatchSave() {
        for (int i = 0; i < RegisteredComponents.Count; i++) {
            RegisteredComponents[i].Save();
        }

    }
    
    /// <summary>
    /// Destructor to clear registered components.
    /// </summary>
    ~SaveManager()
    {
        RegisteredComponents.Clear();
    }
}