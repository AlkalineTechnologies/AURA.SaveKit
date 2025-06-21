using FlaxEngine;
using System;
using AURASaveKit;

namespace Game;

/// <summary>
/// The Data Profile for the PlayerSaver component
/// </summary>
[Serializable]
public class PlayerSaverDataProfile : AURASaveKit.DataProfile {
    // Create the data you want to save here.
    
    /// <summary>
    /// This property represents the health of the player.
    /// </summary>
    public float Health = 100f;

    /// <summary>
    /// This property represents the score of the player.
    /// </summary>
    public int Score = 0;

    /// <summary>
    /// This property represents the name of the player.
    /// </summary>
    public string PlayerName = "Player";

    /// <summary>
    /// This property represents the position of the player.
    /// </summary>
    public Vector3 position = Vector3.Zero;

    /// <summary>
    /// Sets the name of the component as it will appear on the save file.
    /// This is used to identify the component when saving and loading data.
    /// The name should be unique to avoid conflicts with other components.
    /// </summary>
    public override string GetComponentName() {
        return "PlayerSaverDataProfile";
    }
}

/// <summary>
/// The SaveComponent implementation for PlayerSaver, handling save and load logic.
/// </summary>
public class PlayerSaver : SaveComponent {
    /// <summary>
    /// Holds an instance of the data profile for this component.
    /// </summary>
    public JsonAssetReference<PlayerSaverDataProfile> PlayerSaverData;

    // Example:
    public Actor ObjectToSave; // Example of an object to save

    /// <summary>
    /// Initializes a new instance of the <see cref="PlayerSaver"/> class with the specified data profile reference.
    /// </summary>
    /// <param name="PlayerSaverData">A reference to the data profile asset for this component.</param>

    public PlayerSaver(JsonAssetReference<PlayerSaverDataProfile> PlayerSaverData, Actor obj) {
        this.ObjectToSave = obj;
        this.PlayerSaverData = PlayerSaverData;
    }


    /// <summary>
    /// Handles the logic for what to do with the data when saving.
    /// This method is called when the game state is saved.
    /// </summary>
    public override void Save() {
        // Here you can set the data to be saved
        // For example, if you have properties in PlayerSaverDataProfile, set them here
        // PlayerSaverData.Instance.PropertyName = value;

        // EXAMPLE:
        PlayerSaverData.Instance.Health -= 10f; // Example of setting health
        PlayerSaverData.Instance.Score += 10; // Example of setting score
        PlayerSaverData.Instance.position += new Vector3(1, 2, 3); // Example of updating position

        // Make sure this is called at the end of your Save method
        AURASaveKit.SaveManager.WriteData(PlayerSaverData.Instance, out OpResultCode _);
    }

    /// <summary>
    /// Handles taking the respective data from the save file
    /// that belongs to this component. and setting it to the instance.
    /// </summary>
    public override void Load()
    {
        // Load the data from the saved profile
        // This will read the data from the PlayerSaverData profile and set it to the instance
        PlayerSaverDataProfile LoadedData = AURASaveKit.SaveManager.ReadData<PlayerSaverDataProfile>(
            PlayerSaverData.Instance,
            out OpResultCode Success
        );

        if (Success != OpResultCode.Success || LoadedData == null)
        {
            // Handle the case where loading failed
            Debug.LogError("Failed to load PlayerSaver data profile.");
            return;
        }


        Debug.Log("Data loaded successfully for PlayerSaver");

        Debug.Log("Health: " + LoadedData.Health);
        Debug.Log("Score: " + LoadedData.Score);
        Debug.Log("Position: " + LoadedData.position);
        Debug.Log("Player Name: " + LoadedData.PlayerName);
        // Now you can set the data from the loaded profile
        

        ObjectToSave.Name = LoadedData.PlayerName;
        ObjectToSave.Position = LoadedData.position;
    }
}