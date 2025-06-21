using FlaxEditor;
using FlaxEngine;

namespace Game;

/// <summary>
/// Example script to test saving and loading game data.
/// You can attach this script to an empty actor in your scene, or the scene itself for testing.
/// </summary>
public class SaveTester : Script
{

    // Components
    [Header("Component One")]
    public JsonAssetReference<PlayerSaverDataProfile> PlayerData;
    public PlayerSaver PlayerSave;

    // Variables to set up the data within playerSaver
    public string PlayerName = "MyPlayer";
    public int PlayerScore = 0;
    public float PlayerHealth = 100f;
    public Vector3 PlayerPosition = Vector3.Zero;
    public Actor ObjectToSave;


    [Header("Component Two")]
    public JsonAssetReference<WorldSaverDataProfile> WorldData;

    public WorldSaver WorldSave;

    // Variables to set up the data within worldSaver
    public string WorldName = "MyWorld";
    public int WorldSeed = 123456789;
    public float Playtime = 0f;



    [Header("Save Paths")]
    public string[] SampleSaveNames = { "SaveOne", "SaveTwo", "SaveThree", "SaveFour", "SaveFive" };
    [range(0, 4)] public int SelectedSaveName;

    [ShowInEditor] private string CurrentSaveName => SampleSaveNames[SelectedSaveName];


    /// <summary>
    /// This method is called to test saving the saved data.
    /// Just click on the respective button on the script component
    /// in the editor to trigger it.
    /// </summary>
    [Button]
    public void TestSaves() {
        ValidateData();
        SaveManager.CurrentSaveName = CurrentSaveName;
        SaveManager.DispatchSave();
    }


    /// <summary>
    /// This method is called to test loading the saved data.
    /// Just click on the respective button on the script component
    /// in the editor to trigger it.
    /// </summary>
    [Button]
    public void TestLoads() {
        ValidateData();
        SaveManager.CurrentSaveNames = CurrentSaveName;
        SaveManager.DispatchLoad();
    }

    void ValidateData() {
        PlayerSave ??= new PlayerSaver(PlayerData, ObjectToSave);
        WorldSave ??= new WorldSaver(WorldData, WorldName, WorldSeed);
    }


    public override void OnDestroy()
    {
        SaveManager.Clear();
    }
}