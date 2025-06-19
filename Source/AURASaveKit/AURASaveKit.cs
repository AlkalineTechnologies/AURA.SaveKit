using System;
using FlaxEditor.Content.Settings;
using FlaxEngine;

namespace AURASaveKit
{
    /// <summary>
    /// The sample game plugin.
    /// </summary>
    /// <seealso cref="FlaxEngine.GamePlugin" />
    public class AURASaveKit : GamePlugin
    {
        /// <inheritdoc />
        public AURASaveKit()
        {
            _description = new PluginDescription
            {
                Name = "AURA.SaveKit",
                Category = "Other",
                Author = "Alkaline Software",
                AuthorUrl = null,
                HomepageUrl = null,
                RepositoryUrl = "https://github.com/FlaxEngine/AURASaveKit",
                Description = "This is an example plugin project.",
                Version = new Version(),
                IsAlpha = false,
                IsBeta = false,
            };
        }

        /// <inheritdoc />
        public static AURASaveKit Instance { get => PluginManager.GetPlugin<AURASaveKit>(); }

        /// <inheritdoc />
        public static Version Version { get => Instance._description.Version; }

        /// <inheritdoc />
        public AURASaveKit_Settings Settings;

        /// <inheritdoc />
        public override void Initialize()
        {
            base.Initialize();

            GameSettings.Load().CustomSettings.TryGetValue("AURA.SaveKit.Config", out JsonAsset asset);

            Settings = asset.GetInstance<AURASaveKit_Settings>();

            Debug.Log("Successfully loaded AURA.SaveKit configs");

        }

        /// <inheritdoc />
        public override void Deinitialize()
        {
            // Use it to cleanup data

            base.Deinitialize();
        }
    }
}
