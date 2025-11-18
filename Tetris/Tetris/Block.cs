using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    internal class Block : PictureBox
    {
        const int BLOCK_SIZE = 20;
        static readonly Point LeftTopBlock = new Point(50, 30);

        public Block(int colum, int row, Form parent)
        {
            this.Width = BLOCK_SIZE;
            this.Height = BLOCK_SIZE;
            this.Parent = parent;
            this.BackColor = Color.Gray;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Location = new Point(BLOCK_SIZE * colum + LeftTopBlock.X, BLOCK_SIZE * row + LeftTopBlock.Y);

            Colum = colum;
            Row = row;
        }

        public int Colum { get; private set; }
        public int Row { get; private set; }
    }
}