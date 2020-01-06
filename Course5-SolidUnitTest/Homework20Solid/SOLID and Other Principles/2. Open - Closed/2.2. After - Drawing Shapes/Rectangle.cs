namespace OpenClosedDrawingShapesAfter
{
    using OpenClosedDrawingShapesAfter.Contracts;
    using System.Drawing;
    using System.Windows.Forms;

    public class Rectangle : IShape
    {
        public void Draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Red), new System.Drawing.Rectangle(0, 0, 200, 300));
        }
    }
}
