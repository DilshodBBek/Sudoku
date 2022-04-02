using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class My_Sudoku : Form
    {
        public My_Sudoku()
        {
            InitializeComponent();
        }
        int[,] aw = new int[9, 9];
        int[,] sudoku = new int[9, 9];
        int[,] aw1=new int[9,9];
        int hisoblagich=0,hi=0;
        SUDOKU S = new SUDOKU();
        
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 9;
            dataGridView1.ColumnCount = 9;
            //aw = S.Array();
            //aw1 = aw;
            //S._b2 = aw;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button4.Enabled = true;
            button5.Enabled = true;
            int Daraja = 5;
            //do
            //{
                hi = 0;
                aw = S.Array();
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        aw1[i, j] = aw[i, j];
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                    }
                }
                sudoku = S.sudoku(aw, Daraja);

            //    for (int i = 0; i < 9; i++)
            //    {
            //        for (int j = 0; j < 9; j++)
            //        {
            //            if (sudoku[j, i] == 0)
            //            {
            //                hisoblagich++;
            //            }
            //        }
            //        if (hisoblagich == Daraja) { hi++; }
            //        hisoblagich = 0;
            //    }
            //} while (hi < 9);
            hi = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = null;
                }
            }
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (sudoku[i,j]!=0)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = sudoku[i, j];
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.LightBlue;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button4.Enabled = true;
            button5.Enabled = true;
            int Daraja = 6;
            //do
            //{
                hi = 0;
                aw = S.Array();
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        aw1[i, j] = aw[i, j];
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                    }
                }
                sudoku = S.sudoku(aw, Daraja);

            //    for (int i = 0; i < 9; i++)
            //    {
            //        for (int j = 0; j < 9; j++)
            //        {
            //            if (sudoku[j, i] == 0)
            //            {
            //                hisoblagich++;
            //            }
            //        }
            //        if (hisoblagich == Daraja) { hi++; }
            //        hisoblagich = 0;
            //    }
            //} while (false||hi < 9);
            hi = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = null;
                }
            }
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (sudoku[i, j] != 0)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = sudoku[i, j];
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.LightPink;
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button4.Enabled = true;
            button5.Enabled = true;
            int Daraja = 7;
            //do
            //{
                hi = 0;
                aw = S.Array();
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        aw1[i, j] = aw[i, j];
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                    }
                }
                sudoku = S.sudoku(aw, Daraja);

            //    for (int i = 0; i < 9; i++)
            //    {
            //        for (int j = 0; j < 9; j++)
            //        {
            //            if (sudoku[j, i] == 0)
            //            {
            //                hisoblagich++;
            //            }
            //        }
            //        if (hisoblagich == Daraja) { hi++; }
            //        hisoblagich = 0;
            //    }
            //} while (false||hi <9);
            hi = 0;



                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                            dataGridView1.Rows[i].Cells[j].Value = null;
                    }
                }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (sudoku[i, j] != 0)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = sudoku[i, j];
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.LightGreen;
                        dataGridView1.Rows[i].Cells[j].ReadOnly = true;
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool t = true;
            for (int i = 0; i < 9&&t; i++)
            {
                for (int j = 0; j < 9&&t; j++)
                {
                    if (Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value) != aw1[i, j]) { t = false; }
                }
            }
            if (t)
            {
                MessageBox.Show("Barcha katakchalar to`g`ri to`ldirilgan!");
            }
            else
            {
                MessageBox.Show("Katakchalar noto`g`ri to`ldirilgan!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = aw1[i, j];
                }
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            using (Brush borderBrush = new SolidBrush(Color.DarkBlue))
            {
                using (Pen borderPen = new Pen(borderBrush, 6))
                {
                    Rectangle rd = e.CellBounds;
                    rd.Width += 3;
                    rd.Height += 3;
                    rd.X = rd.Left + 3;
                    rd.Y = rd.Top + 3;
                    e.Graphics.DrawRectangle(borderPen, rd);
                    e.Handled = true;
                }
            }
        }

    }
}
