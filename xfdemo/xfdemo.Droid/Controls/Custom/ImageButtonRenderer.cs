using Xamarin.Forms;
using xfdemo.Droid.Controls.Custom;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;

[assembly: ExportRenderer(typeof(xfdemo.Controls.Custom.ImageButton), typeof(ImageButtonRenderer))]
namespace xfdemo.Droid.Controls.Custom
{
    public class ImageButtonRenderer : ButtonRenderer
    {
        protected override bool DrawChild(Canvas canvas, global::Android.Views.View child, long drawingTime)
        {
            if (((xfdemo.Controls.Custom.ImageButton)Element).Icon != null &&
                ((xfdemo.Controls.Custom.ImageButton)Element).Icon == "ic_facebook_white.png")
            {
                Bitmap icon = BitmapFactory.DecodeResource(Context.Resources, Resource.Drawable.ic_facebook_white);
                var paint = new Paint();
                canvas.DrawBitmap(icon, (canvas.Height - icon.Height) / 2, (canvas.Height - icon.Height) / 2, paint);
            }

            return base.DrawChild(canvas, child, drawingTime);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            // e.NewElement.Width and e.NewElement.Height are both -1
            SetBackgroundResource(Resource.Drawable.bg_button_border);
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            // widthMeasureSpec and heightMeasureSpec are extremely high, e.g. 10796174218
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
        }
    }
}