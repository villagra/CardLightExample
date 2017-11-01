using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace CardLightExample
{
    public class AmbLight : XamlLight
    {
        protected override void OnConnected(UIElement newElement)
        {
            if (newElement == null) return;

            Compositor compositor = Window.Current.Compositor;

            // Create AmbientLight and set its properties
            AmbientLight ambientLight = compositor.CreateAmbientLight();
            ambientLight.Color = Colors.White;

            // Associate CompositionLight with XamlLight
            CompositionLight = ambientLight;

            // Add UIElement to the Light's Targets
            AmbLight.AddTargetElement(GetId(), newElement);
        }

        protected override void OnDisconnected(UIElement oldElement)
        {
            // Dispose Light when it is removed from the tree
            AmbLight.RemoveTargetElement(GetId(), oldElement);
            CompositionLight.Dispose();
        }

        protected override string GetId() => typeof(AmbLight).FullName;
    }
}