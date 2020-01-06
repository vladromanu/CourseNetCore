namespace OpenClosedDrawingShapesAfter
{
    using System.Drawing;
    using OpenClosedDrawingShapesAfter.Contracts;

    public class DrawingManager : IDrawingManager
    {
        public Graphics formGraphics { get; }
        
        public DrawingManager(Graphics gr)
        {
            this.formGraphics = gr;
        }


        public void Draw(IShape shape)
        {
            shape.Draw(this.formGraphics);
        }
    }
}