namespace OpenClosedDrawingShapesAfter
{
    using OpenClosedDrawingShapesAfter.Contracts;
    using System.Drawing;
    using System.Windows.Forms;

    public class Circle : IShape
    {
        public void Draw(Graphics g)
        {
            g.DrawEllipse(Pens.Red, 50, 50, 100, 100);
        }
    }
}
