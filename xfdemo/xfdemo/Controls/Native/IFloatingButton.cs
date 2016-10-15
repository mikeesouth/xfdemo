using Xamarin.Forms;

namespace xfdemo.Controls.Native
{
    public interface IFloatingButton
    {
        View BuildFloatingButton(System.Action clickAction);
    }
}
