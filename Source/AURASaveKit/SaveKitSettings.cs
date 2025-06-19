using System;

/// <summary>
/// AFSM_Settings Script.
/// </summary>
[Serializable]
public class AURASaveKit_Settings
{
    

    /// <summary>
    /// The file path where game saves are stored.
    /// </summary>
    public string SaveFilePath = "Saves";

    /// <summary>
    /// The file extension used for saved files.
    /// </summary>
    public string FileExtension = ".save";

    /// <summary>
    /// Determines whether directories are created automatically when saving data.
    /// if the given path does not exist.
    /// </summary>
    public bool CreateDirectories = false;

    /// <summary>
    /// Determines whether encryption is used when saving data.
    /// </summary>
    /// TODO:
    // public bool UseEncryption = false;

    
}