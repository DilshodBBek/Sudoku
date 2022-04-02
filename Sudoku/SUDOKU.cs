using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class SUDOKU
    {
       // public int[,] _b2;
        public int[,] Array()
        {
            //int[,] b190 = new int[9, 9;]
            //Random r = new Random();
            //for (int i = 0; i < 9; i++)
            //{
            //    for (int j = 0; j < 9; j++)
            //    {
            //        a89[i, j] = r.Next(1, 9);
            //    }
            //}

            int[,] ss = new int[9, 9];
            int[,] sudoko = new int[9, 9];
            int[,] b = new int[9, 9];
            int[,] a = new int[3, 3];
            Random x = new Random();
            int ax = x.Next(4) + 36;
            int[] b1 = new int[3];
            int[] b2 = new int[3];
            int[] b3 = new int[3];
            int[] b4 = new int[3];
            int[] b5 = new int[3];
            int[] b6 = new int[3];
            int[] b11 = new int[3];
            int[] b12 = new int[3];
            int[] b13 = new int[3];
            int[] b14 = new int[3];
            int[] b15 = new int[3];
            int[] b16 = new int[3];


            Boolean g = true;
            Random ar = new Random(), aj = new Random();
            int m = 0, a1 = 0, a2 = 0, a3 = 0, a4 = 0;

            for (int r = 0; r < 3; r++)
                for (int p = 0; p < 3; p++)
                    a[r, p] = 0;
            for (int i = 1; i < 10; i++)
            {

                a1 = ar.Next(3); a2 = aj.Next(3);
                while (a[a1, a2] != 0)
                {
                    ar = new Random(); aj = new Random();
                    a1 = ar.Next(3); a2 = aj.Next(3);
                }
                a[a1, a2] = i;
            }
            for (int i = 0; i < 3; i++)
                b1[i] = a[0, i];
            for (int i = 0; i < 3; i++)
                b2[i] = a[1, i];
            for (int i = 0; i < 3; i++)
                b3[i] = a[2, i];
            for (int i = 0; i < 3; i++)
                b4[i] = a[i, 0];
            for (int i = 0; i < 3; i++)
                b5[i] = a[i, 1];
            for (int i = 0; i < 3; i++)
                b6[i] = a[i, 2];

            for (int i = 0; i < 3; i++)
            {
                b[0, i] = b1[i];
                b[1, i + 3] = b1[i];
                b[2, i + 6] = b1[i];
            }

            for (int i = 0; i < 3; i++)
            {
                b[1, i] = b2[i];
                b[2, i + 3] = b2[i];
                b[0, i + 6] = b2[i];
            }

            for (int i = 0; i < 3; i++)
            {
                b[2, i] = b3[i];
                b[0, i + 3] = b3[i];
                b[1, i + 6] = b3[i];
            }

            for (int i = 0; i < 3; i++)
            {
                b[i, 0] = b4[i];
                b[i + 3, 2] = b4[i];
                b[i + 6, 1] = b4[i];
            }

            for (int i = 0; i < 3; i++)
            {
                b[i, 1] = b5[i];
                b[i + 3, 0] = b5[i];  //2-katak
                b[i + 6, 2] = b5[i];
            }

            for (int i = 0; i < 3; i++)
            {
                b[i, 2] = b6[i];
                b[i + 3, 1] = b6[i];
                b[i + 6, 0] = b6[i];
            }

            for (int i = 0; i < 3; i++)
                b11[i] = b[3, i];
            for (int i = 0; i < 3; i++)
                b12[i] = b[4, i];
            for (int i = 0; i < 3; i++)
                b13[i] = b[5, i];
            for (int i = 0; i < 3; i++)
                b14[i] = b[6, i];
            for (int i = 0; i < 3; i++)
                b15[i] = b[7, i];
            for (int i = 0; i < 3; i++)
                b16[i] = b[8, i];


            for (int i = 0; i < 3; i++)
            {
                b[4, i + 3] = b11[i];
                b[5, i + 6] = b11[i];
            }

            for (int i = 0; i < 3; i++)
            {
                b[5, i + 3] = b12[i];
                b[3, i + 6] = b12[i];
            }

            for (int i = 0; i < 3; i++)
            {
                b[3, i + 3] = b13[i];
                b[4, i + 6] = b13[i];
            }
            /////////////////////////////////////////////////
            for (int i = 0; i < 3; i++)
            {
                b[7, i + 6] = b14[i];
                b[8, i + 3] = b14[i];
            }

            for (int i = 0; i < 3; i++)
            {
                b[6, i + 3] = b15[i];
                b[8, i + 6] = b15[i];
            }

            for (int i = 0; i < 3; i++)
            {
                b[6, i + 6] = b16[i];
                b[7, i + 3] = b16[i];
                //}
                //for (int r = 0; r < 9; r++)
                //    for (int p = 0; p < 9; p++)
                //        ss[r, p] = b[r, p];
            }
            return b;
        }

        public int[,] sudoku(int[,] _b2, int _daraja)
        {
            int[,] b1 = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    b1[i, j] = _b2[i, j];   
                }
            }

            int a1;
            int yu = 0, yu1 = 0;
            int[,] eski = new int[9, 9];
            Random ar = new Random();
            
                for (int u = 0; u < 9; u++)
                {
                    yu = 0;
                    do
                    {
                        a1 = ar.Next(9);
                        if (_b2[u,a1]!=0)
                        {
                            _b2[u, a1] =0;
                            yu++;
                        }
                        //k++;
                        //    yu1 = 0;
                        //    a1 = ar.Next(9);
                        //    if (eski[u, a1] != 1&&eski[u, a1] !=3)
                        //    {
                        //        eski1 = u;
                        //        for (int i = 0; i < u && yu1 < _daraja; i++)
                        //        {
                        //            if (_b2[i, a1] == 0)
                        //            {
                        //                yu1++;
                        //            }
                        //        }
                        //        if (yu1 < _daraja && _b2[u, a1] != 0)
                        //        {
                        //            _b2[u, a1] = 0;
                        //            eski[u, a1] = 1;
                        //            yu++;
                        //        }
                        //        if (yu1==3)
                        //        {
                        //            eski[u, a1] = 3;
                        //        }
                        //    }
                        //    if (k==54)
                        //    {
                        //        return null;
                        //    }
                    } while (yu != _daraja);
                }
                int qk = 0;
                //a1 = ar.Next(9);
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (_b2[j, i] != 0)
                        {
                            yu1++;
                        }


                        if (yu1 > 9 - _daraja)
                        {
                            yu1--;
                            _b2[j, i] = 0;
                            // yu = _b2[j, i];

                            for (int k = 0; k < 9 && qk > -1; k++)
                            {
                                for (int l = 0; l < 9 && qk < 9 - _daraja; l++)
                                {
                                    if (_b2[l, k] != 0)
                                    {
                                        qk++;
                                    }
                                }
                                if (qk < 9 - _daraja && _b2[j, k] == 0)
                                {

                                    _b2[j, k] = b1[j, k];
                                    qk = -1;
                                }
                                else
                                {
                                    qk = 0;
                                }

                            }
                            qk = 0;
                        }
                    }
                    yu1 = 0;
                }
            return _b2;
        }
    }
}
