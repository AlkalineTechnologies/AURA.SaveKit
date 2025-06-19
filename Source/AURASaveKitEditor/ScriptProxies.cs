using FlaxEditor;
using FlaxEditor.Content;
using FlaxEditor.Content.Settings;
using FlaxEditor.GUI;
using FlaxEngine;

namespace AURASaveKitEditor
{
    /// <summary>
    /// C# Proxy for the component template.
    /// </summary>
    [ContentContextMenu("New/AURA.SaveKit/Component Template")]
    public class TemplateCSharpProxy : CSharpProxy
    {
        /// <summary>
        /// Gets the name of the C# proxy.
        /// </summary>
        public override string Name => "New component template";

        /// <summary>
        /// Gets the template path.
        /// </summary>
        protected override void GetTemplatePath(out string path)
        {
            path = "Plugins/AURA.SaveKit/Content/ComponentTemplate.cs";
        }
    }

    /// <summary>
    /// C# Proxy for the sample component.
    /// </summary>
    [ContentContextMenu("New/AURA.SaveKit/Sample Component")]
    public class SampleCSharpProxy : CSharpProxy
    {
        /// <summary>
        /// Gets the name of the C# proxy.
        /// </summary>
        public override string Name => "New Sample Component";

        /// <summary>
        /// Gets the template path.
        /// </summary>
        protected override void GetTemplatePath(out string path)
        {
            path = "Plugins/AURA.SaveKit/Content/SampleComponent.cs";
        }
    }
}
