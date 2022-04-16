using System.Drawing;

namespace Game
{
    public static class GraphicsExtenstion
    {
        public static void DrawImage(this Graphics g, Image image, PointF pointF,RectangleF rectangle,GraphicsUnit scrUnit)
        {
            g.DrawImage(image,pointF.X,pointF.Y,rectangle,scrUnit);
        }
    }
}