using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Sudoku2
    {
         const int BaseNumder = 9;
        const int QuadrBNumder = 3;
        private class Cell {
            bool[] arr;
            int z; //значение
            int n; //количество вариантов
            public Cell() {}
            public Cell(int N) {
                z = N;
                n = 9;
                if(N == 0) {
                    arr = new bool[BaseNumder];
                    for(int i = 0; i < BaseNumder; i++)
                        arr[i] = true;
                }
            }
            public Cell(Cell Other) {
                z = Other.z;
                n = Other.n;
                arr = new bool[BaseNumder];
                for(int i = 0; i < BaseNumder; i++)
                    arr[i] = Other.arr[i];
            }
            public static bool operator-(Cell First, Cell Second) {
                if(Second.z == 0) return false;
                if(First.arr[Second.z - 1]) {
                    First.arr[Second.z - 1] = false;
                    First.n--;
                }
                if(First.n == 1)
                    for(int i = 0; i < BaseNumder; i++)
                        if(First.arr[i]) {
                            First.z = ++i;
                            return true;
                        }
                return false;
            }
            public static bool operator==(Cell First, Cell Second) {
                for(int i = 0; i < BaseNumder; i++)
                    if(First.arr[i] != Second.arr[i]) return false;
                return true;
            }
            public static bool operator!=(Cell First, Cell Second) {
                return !(First == Second);
            }
            public static implicit operator bool(Cell Obj) { return Obj.z > 0; }
            public int Is { get { return z; } }
            public int N { get { return n; } }
            public bool this[int N] { get { return arr[N]; } }
        }
        Cell[,] arr;
        int n; //количество найденных
        public Sudoku2(int[,] Arr) {
            arr = new Cell[BaseNumder, BaseNumder];
            n = 0;
            for(int i = 0; i < BaseNumder; i++)
                for(int j = 0; j < BaseNumder; j++) {
                    arr[j, i] = new Cell(Arr[j, i]);
                    if(Arr[j, i] > 0) n++;
                }
        }
        public Sudoku2(Sudoku Other) {
            n = Other.n;
            arr = new Cell[BaseNumder, BaseNumder];
            for(int i = 0; i < BaseNumder; i++)
                for(int j = 0; j < BaseNumder; j++)
                    arr[j, i] = new Cell(Other.arr[j, i]);
        }
        public int N { get { return n; } }
        public int[,] Date() {
            int[,] x = new int[BaseNumder, BaseNumder];
            for(int i = 0; i < BaseNumder; i++)
                for(int j = 0; j < BaseNumder; j++)
                    x[j, i] = arr[j, i].Is;
            return x;
        }
        //Вычитание значащих клеток по горизонтали и вертикали
        public bool LineMinus() {
            int nn = n;
            for(int y = 0; y < BaseNumder; y++)
                for(int x = 0; x < BaseNumder; x++) {
                    if(!arr[x, y]) {                //Если клетка не определена
                        for(int LineNumder = 0; LineNumder < BaseNumder; LineNumder++) {
                            if(arr[x, y] - arr[x, LineNumder]) {    //Если после вычитания клетка определена
                                n++;
                                break;
                            }
                            if(arr[x, y] - arr[LineNumder, y]) {
                                n++;
                                break;
                            }
                        }
                    }
                }
            nn = n - nn;
            return nn > 0;
        }
        //Вычитание значащих клеток по квадратам
        public bool QuadrMinus() {
            int nn = n;
            for(int y = 0; y < BaseNumder; y++)
                for(int x = 0; x < BaseNumder; x++)
                    if(!arr[x, y]) {
                        for(int VertQuadr = 0; VertQuadr < QuadrBNumder; VertQuadr++) {
                            for(int HorisQuard = 0; HorisQuard < QuadrBNumder; HorisQuard++) {
                                if(arr[x, y] - arr[x - x % QuadrBNumder + VertQuadr, y - y % QuadrBNumder + HorisQuard]) {
                                    n++;
                                    break;
                                }
                            }
                            if(arr[x, y].Is > 0) break;
                        }
                    }
            nn = n - nn;
            return nn > 0;
        }
        //Поиск по единственному возможному из массива по горизонтали и вертикали
        public bool LineArr() {
            int nn = n;
            for(int Line = 0; Line < BaseNumder; Line++)
                for(int CellArr = 0; CellArr < BaseNumder; CellArr++) { //Здесь - проход по массиву вариантов клетки
                    int VarN = 0; //Счётчик варианта клетки
                    int UnCell = 0; //Счётчик неопределённых клеток
                    for(int x = 0; x < BaseNumder; x++) //Проход по горизонтали
                        if(!arr[x, Line]) {
                            UnCell++;
                            if(arr[x, Line][CellArr])
                                VarN++;
                        }
                    if(UnCell > 1 && VarN == 1) {
                        for(int x = 0; x < BaseNumder; x++)
                            if(!arr[x, Line])
                                if(arr[x, Line][CellArr]) {
                                    arr[x, Line] = new Cell(CellArr + 1);
                                    n++;
                                    break;
                                }
                    }
                    VarN = UnCell = 0;
                    for(int y = 0; y < BaseNumder; y++) //Проход по вертикали
                        if(!arr[Line, y]) {
                            UnCell++;
                            if(arr[Line, y][CellArr])
                                VarN++;
                        }
                    if(UnCell > 1 && VarN == 1) {
                        for(int y = 0; y < BaseNumder; y++)
                            if(!arr[Line, y])
                                if(arr[Line, y][CellArr]) {
                                    arr[Line, y] = new Cell(CellArr + 1);
                                    n++;
                                    break;
                                }
                    }
                }
            nn = n - nn;
            return nn > 0;
        }
        //Поиск по единственному возможному из массива по квадратам
        public bool QuadrArr() {
            int nn = n;
            for(int QuadrX = 0; QuadrX < QuadrBNumder; QuadrX++)
                for(int QuadrY = 0; QuadrY < QuadrBNumder; QuadrY++)
                    for (int CellArr = 0; CellArr < BaseNumder; CellArr++) {    //Проход по массиву клетки
                        int VarN = 0; //Счётчик варианта клетки
                        int UnCell = 0; //Счётчик неопределённых клеток
                        for(int QuadrCell = 0; QuadrCell < BaseNumder; QuadrCell++) //Проход по клеткам квадрата
                            if(!arr[QuadrCell % QuadrBNumder + QuadrX * QuadrBNumder, QuadrCell / QuadrBNumder + QuadrY * QuadrBNumder]) {
                                UnCell++;
                                if(arr[QuadrCell % QuadrBNumder + QuadrX * QuadrBNumder, QuadrCell / QuadrBNumder + QuadrY * QuadrBNumder][CellArr])
                                    VarN++;
                            }
                        if(UnCell > 1 && VarN == 1)
                            for(int r = 0; r < BaseNumder; r++) //Проход по клеткам квадрата
                                if(!arr[r % QuadrBNumder + QuadrX * QuadrBNumder, r / QuadrBNumder + QuadrY * QuadrBNumder])
                                    if(arr[r % QuadrBNumder + QuadrX * QuadrBNumder, r / QuadrBNumder + QuadrY * QuadrBNumder][CellArr]) {
                                        arr[r % QuadrBNumder + QuadrX * QuadrBNumder, r / QuadrBNumder + QuadrY * QuadrBNumder] = new Cell(CellArr + 1);
                                        n++;
                                        break;
                                    }
                }
            nn = n - nn;
            return nn > 0;
        }
    }
}
