using Avalonia;
using Avalonia.Markup.Xaml;

namespace HyperNova.CrossPlatform
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
