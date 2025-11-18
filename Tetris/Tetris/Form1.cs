using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form1 : Form
    {
        const int FIELD_INNER_WIDTH = 10;
        const int FIELD_INNER_HEIGHT = 20;
        const int TETORO_SIZE = 4;

        Block[,] Field;
        List<Block> FixedTetoro = new List<Block>();
        List<Block> MovingTetoros = new List<Block>();
        Point MovingTetoroPos = new Point();
        int Tetoro_Type;
        Random random = new Random();

        bool[][,] Tetoros = new bool[][,]
        {
            // I
            new [,]
            {
                {false, false, false, false},
                {true, true, true, true},
                {false, false, false, false},
                {false, false, false, false},
            },
            // O
            new [,]
            {
                {false, false, false, false},
                {false, true, true, false},
                {false, true, true, false},
                {false, false, false, false},
            },
            // S
            new [,]
            {
                {false, false, false, false},
                {false, true, true, false},
                {true, true, false, false},
                {false, false, false, false},
            },
            // Z
            new [,]
            {
                {false, false, false, false},
                {true, true, false, false},
                {false, true, true, false},
                {false, false, false, false},
            },
            // J
            new [,]
            {
                {false, false, false, false},
                {true, false, false, false},
                {true, true, true, false},
                {false, false, false, false},
            },
            // L
            new [,]
            {
                {false, false, false, false},
                {false, false, true, false},
                {true, true, true, false},
                {false, false, false, false},
            },
            // T
            new [,]
            {
                {false, false, false, false},
                {false, true, false, false},
                {true, true, true, false},
                {false, false, false, false},
            },
        };

        public Form1()
        {
            InitializeComponent();
            InitializeField();
            ClearField();
            ShowNewTetoro();
        }

        void InitializeField()
        {
            Field = new Block[FIELD_INNER_WIDTH, FIELD_INNER_HEIGHT];
            for (int col = 0; col < FIELD_INNER_WIDTH; col++)
            {
                for (int row = 0; row < FIELD_INNER_HEIGHT; row++)
                {
                    Field[col, row] = new Block(col, row, this);
                }
            }
        }

        void ClearField()
        {
            MovingTetoros.Clear();
            FixedTetoro.Clear();
            for (int col = 0; col < FIELD_INNER_WIDTH; col++)
            {
                for (int row = 0; row < FIELD_INNER_HEIGHT; row++)
                {
                    Field[col, row].BackColor = Color.White;
                }
            }
        }

        void ClearOldTetoro()
        {
            foreach (var block in MovingTetoros)
            {
                block.BackColor = Color.White;
            }
        }

        void ShowNewTetoro()
        {
            MovingTetoros.Clear();
            Tetoro_Type = random.Next() % 7;
            MovingTetoroPos = new Point(0, 0);
            ClearOldTetoro();

            bool[,] tetoro = Tetoros[Tetoro_Type];
            Color tetoroColor = GetTetoroColor(Tetoro_Type);

            List<Block> blocks = new List<Block>();
            for (int col = 0; col < TETORO_SIZE; col++)
            {
                for (int row = 0; row < TETORO_SIZE; row++)
                {
                    if (tetoro[row, col])
                    {
                        Field[col, row].BackColor = tetoroColor;
                        blocks.Add(Field[col, row]);
                    }
                }
            }
            MovingTetoros = blocks;
        }

        Color GetTetoroColor(int type)
        {
            if (type == 0) return Color.Aqua;
            if (type == 1) return Color.Yellow;
            if (type == 2) return Color.Green;
            if (type == 3) return Color.Red;
            if (type == 4) return Color.Blue;
            if (type == 5) return Color.Orange;
            if (type == 6) return Color.Violet;
            return Color.Gray;
        }
    }
}