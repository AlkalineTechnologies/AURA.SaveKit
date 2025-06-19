> [!Important]
> SaveKit is still under early development. <br>
> A helper editor plugin is in the works to make managing components easier

![AURA.SaveKit Logo](/Content/SaveKit.png)

# About SaveKit
**SaveKit** is the first of the many plugins in the **AURA** plugin suite for flax engine.
SaveKit allows you to save any data you want, and easily load it

# How to use

## Installation
* Open the Flax Editor of your project you want to use SaveKit in.
* Click on Tools > Plugin in the top menu bar.
* Inside the plugin manager, click on `Clone Project` and give it any name, but most importantly, paste the URL of this repo into the `Git Path`
* Wait and you will see a popup, make sure you restart your Editor.

## Creating Save Components
Components have 3 parts to them
* The logic for saving data
* The data to be saved
* And a JsonAsset that will hold the data during runtime

### Creating the logic script & data to be saved
* Make sure you are in your game's `Source/Game/` directory, or any subdirectory within it,
* Right click and go to **New > AURA.SaveKit**, if you want to start from scratch click on **Component Template**. <br>
  Otherwise you can click on **Sample Template** to better get an example save component. It's recommended to take a look at the sample when starting with SaveKit.
* Give the file any name you want. The core logic for saving and loading has been implemented already.
* To save your own data: Add/Modify variables within the data profile class generated in the script you created <br>
Remember the name of the class, you'll need it soon.

### Create the JSonAsset
* Make sure you are in your game's `Content` directory, or any subdirectories within it.
* ***Recommended:*** Make a folder dedicated to the Save Components JSON
* Right click and go to **New > JSon Asset**, give the file any name you want.
* On the window that pops up, click on the drop down and search for the name of the class that you had to remember (will end with `DataProfile`)
* You've successfully created your first save component.

## Triggering Saves and Loads
Let's say you create a testing script attached to your scene.
You can cause all save components to Save or Load by calling `SaveManager.DispatchSave()` or `SaveManager.DispatchLoad()` respectively.
You need to register your class that contains the saving logic with `SaveManager` by using `SaveManager.Register(MYCLASS)`
 
> [!NOTE]
> An example folder will soon be uploaded <br>
