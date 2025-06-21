using FlaxEngine;
using System;
using AURASaveKit;

namespace Game;

/// <summary>
/// The Data Profile for the %class% component
/// </summary>
[Serializable]
public class %class%DataProfile : AURASaveKit.DataProfile {
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
        return "%class%DataProfile";
    }
}

/// <summary>
/// The SaveComponent implementation for %class%, handling save and load logic.
/// </summary>
public class %class% : SaveComponent {
    /// <summary>
    /// Holds an instance of the data profile for this component.
    /// </summary>
    public JsonAssetReference<%class%DataProfile> %class%Data;

    // Example:
    public Actor ObjectToSave; // Example of an object to save

    /// <summary>
    /// Initializes a new instance of the <see cref="%class%"/> class with the specified data profile reference.
    /// </summary>
    /// <param name="%class%Data">A reference to the data profile asset for this component.</param>

    public %class%(Actor obj, JsonAssetReference<%class%DataProfile> %class%Data) {
        this.ObjectToSave = obj;
        this.%class%Data = %class%Data;
    }


    /// <summary>
    /// Handles the logic for what to do with the data when saving.
    /// This method is called when the game state is saved.
    /// </summary>
    public override void Save() {
        // Here you can set the data to be saved
        // For example, if you have properties in %class%DataProfile, set them here
        // %class%Data.Instance.PropertyName = value;

        // EXAMPLE:
        %class%Data.Instance.Health -= 10f; // Example of setting health
        %class%Data.Instance.Score += 10; // Example of setting score
        %class%Data.Instance.position += new Vector3(1, 2, 3); // Example of updating position

        // Make sure this is called at the end of your Save method
        AURASaveKit.SaveManager.WriteData(%class%Data.Instance, out OpResultCode _);
    }

    /// <summary>
    /// Handles taking the respective data from the save file
    /// that belongs to this component. and setting it to the instance.
    /// </summary>
    public override void Load() {
        // Load the data from the saved profile
        // This will read the data from the %class%Data profile and set it to the instance
        %class%DataProfile LoadedData = AURASaveKit.SaveManager.ReadData<%class%DataProfile>(
            %class%Data.Instance,
            out OpResultCode Success
        );

if (Success != OpResultCode.Success || LoadedData == null) {
    // Handle the case where loading failed
    Debug.LogError("Failed to load %class% data profile.");
    return;
}


        Debug.Log("Data loaded successfully for %class%");
        
        Debug.Log("Health: "        + LoadedData.Health);
        Debug.Log("Score: "         + LoadedData.Score);
        Debug.Log("Position: "      + LoadedData.position);
        Debug.Log("Player Name: "   + LoadedData.PlayerName);
        // Now you can set the data from the loaded profile
    }
}