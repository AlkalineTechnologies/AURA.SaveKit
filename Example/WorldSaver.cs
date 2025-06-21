using FlaxEngine;
using System;
using AURASaveKit;

namespace Game;

/// <summary>
/// The Data Profile for the WorldSaver component
/// </summary>
[Serializable]
public class WorldSaverDataProfile : AURASaveKit.DataProfile {
    // Create the data you want to save here.

    /// <summary>
    /// This property represents the health of the player.
    /// </summary>
    public float Playtime;

    /// <summary>
    /// This property represents the score of the player.
    /// </summary>
    public string WorldName = "DefaultWorld";

    /// <summary>
    /// This property represents the name of the player.
    /// </summary>
    public int WorldSeed = 123456789;

    /// <summary>
    /// Sets the name of the component as it will appear on the save file.
    /// This is used to identify the component when saving and loading data.
    /// The name should be unique to avoid conflicts with other components.
    /// </summary>
    public override string GetComponentName()
    {
        return "WorldSaverDataProfile";
    }
}

/// <summary>
/// The SaveComponent implementation for WorldSaver, handling save and load logic.
/// </summary>
public class WorldSaver : SaveComponent {
    /// <summary>
    /// Holds an instance of the data profile for this component.
    /// </summary>
    public JsonAssetReference<WorldSaverDataProfile> WorldSaverData;

    /// <summary>
    /// Example of an object to save. 
    /// </summary>
    public string WorldName;

    /// <summary>
    /// This property represents the seed of the world.
    /// It can be used to regenerate the world with the same parameters.
    /// </summary>
    public int WorldSeed;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="WorldSaver"/> class with the specified data profile reference.
    /// </summary>
    /// <param name="WorldSaverData">A reference to the data profile asset for this component.</param>

    public WorldSaver(JsonAssetReference<WorldSaverDataProfile> WorldSaverData,
        string WorldName, int WorldSeed)
    {

        this.WorldSaverData = WorldSaverData;
        this.WorldName = WorldName;
        this.WorldSeed = WorldSeed;
    }


    /// <summary>
    /// Handles the logic for what to do with the data when saving.
    /// This method is called when the game state is saved.
    /// </summary>
    public override void Save() {
        // Here you can set the data to be saved
        // For example, if you have properties in WorldSaverDataProfile, set them here
        // WorldSaverData.Instance.PropertyName = value;


        // EXAMPLE:
        WorldSaverData.Instance.Playtime = Time.GameTime;
        WorldSaverData.Instance.WorldName = WorldName;
        WorldSaverData.Instance.WorldSeed = WorldSeed;

        // Make sure this is called at the end of your Save method
        AURASaveKit.SaveManager.WriteData(WorldSaverData.Instance, out OpResultCode _);
    }

    /// <summary>
    /// Handles taking the respective data from the save file
    /// that belongs to this component. and setting it to the instance.
    /// </summary>
    public override void Load()
    {
        // Load the data from the saved profile
        // This will read the data from the WorldSaverData profile and set it to the instance
        WorldSaverDataProfile LoadedData = AURASaveKit.SaveManager.ReadData<WorldSaverDataProfile>(
            WorldSaverData.Instance,
            out OpResultCode Success
        );

        if (Success != OpResultCode.Success || LoadedData == null)
        {
            // Handle the case where loading failed
            Debug.LogError("Failed to load WorldSaver data profile.");
            return;
        }


        Debug.Log("Data loaded successfully for WorldSaver");

        WorldName = LoadedData.WorldName;
        WorldSeed = LoadedData.WorldSeed;
        Playtime = LoadedData.Playtime;

        Debug.Log("World Name: " + WorldName);
        Debug.Log("World Seed: " + WorldSeed);
        Debug.Log("Playtime: " + Playtime);
        // Now you can set the data from the loaded profile
    }
}