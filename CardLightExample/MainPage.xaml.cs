using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CardLightExample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            pnlCard1Details.Lights.Add(new HoverLight());
            pnlCard1Details.Lights.Add(new AmbLight());

            pnlCard2Details.Lights.Add(new HoverLight());
            pnlCard2Details.Lights.Add(new AmbLight());

            ElementCompositionPreview.SetIsTranslationEnabled(pnlCard2, true);
            pnlCard2.PointerEntered += PnlCard2Details_PointerEntered;
            pnlCard2.PointerExited += PnlCard2_PointerExited;
        }

        private void PnlCard2_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            var translationAnimation = Window.Current.Compositor.CreateVector3KeyFrameAnimation();
            translationAnimation.InsertKeyFrame(1, new Vector3(0, 0, 0));
            translationAnimation.Duration = TimeSpan.FromSeconds(0.333);
            translationAnimation.Target = "Translation";

            ElementCompositionPreview.GetElementVisual(pnlCard2).StartAnimation("Translation", translationAnimation);
        }

        private void PnlCard2Details_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            var translationAnimation = Window.Current.Compositor.CreateVector3KeyFrameAnimation();
            translationAnimation.InsertKeyFrame(1, new Vector3(0, 0, 48));
            translationAnimation.Duration = TimeSpan.FromSeconds(0.333);
            translationAnimation.Target = "Translation";

            ElementCompositionPreview.GetElementVisual(pnlCard2).StartAnimation("Translation", translationAnimation);
        }
    }
}
