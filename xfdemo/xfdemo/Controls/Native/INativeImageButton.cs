using Xamarin.Forms;

namespace xfdemo.Controls.Native
{
    public interface INativeImageButton
    {
        View BuildNativeImageButton(string text, string icon, System.Action clickAction);
    }
}
