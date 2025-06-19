using FlaxEditor;
using FlaxEditor.Content.Settings;
using FlaxEditor.Utilities;
using FlaxEditor.GUI;
using FlaxEditor.GUI.ContextMenu;
using FlaxEditor.GUI.Input;
using FlaxEditor.Modules;
using FlaxEngine;
using System;
using System.IO;

namespace AFSMEditor {
    /// <summary>
    /// The AFSM Editor Plugin.
    /// </summary>
    public class AFSMHelper : EditorPlugin
    {
        public override void Initialize() {
            base.Initialize();
            
            #if FLAX_EDITOR 
                String path = Path.Combine(Globals.ProjectContentFolder, "Settings", "AURA.SaveKit.Settings.json");
                Editor.SaveJsonAsset(path, new AURA_SaveKit_Settings());
                GameSettings.SetCustomSettings("AURA.SaveKit.Config", Content.LoadAsync<JsonAsset>(path));
            #endif


            this.Editor.ContentDatabase.AddProxy(new TemplateCSharpProxy());
            this.Editor.ContentDatabase.AddProxy(new SampleCSharpProxy());
            this.Editor.ContentDatabase.Rebuild(true);
            Debug.Log("AURA.SaveKit Editor Plugin Initialized");
        }

        /// <summary>
        /// Deinitialize the plugin.
        /// </summary>
        public override void Deinitialize() { base.Deinitialize(); }
    }
}