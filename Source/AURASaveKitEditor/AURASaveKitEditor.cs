#if FLAX_EDITOR
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
using AURASaveKit;

namespace AURASaveKitEditor {
    /// <summary>
    /// The AURA Editor Plugin.
    /// </summary>
    public class AURASaveKitEditor : EditorPlugin
    {
        public override void InitializeEditor() {
            base.InitializeEditor();

            String path = Path.Combine(Globals.ProjectContentFolder, "Settings", "AURA.SaveKit.Settings.json");
            Editor.SaveJsonAsset(path, new AURASaveKit_Settings());
            GameSettings.SetCustomSettings("AURA.SaveKit.Config", Content.LoadAsync<JsonAsset>(path));

            Editor.ContentDatabase.AddProxy(new TemplateCSharpProxy());
            Editor.ContentDatabase.AddProxy(new SampleCSharpProxy());
            Editor.ContentDatabase.Rebuild(true);
            Debug.Log("AURA.SaveKit Editor Plugin Initialized");
        }

        /// <summary>
        /// Deinitialize the plugin.
        /// </summary>
        public override void DeinitializeEditor() { base.DeinitializeEditor(); }
    }
}
#endif