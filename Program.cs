using System.Reflection.Emit;
using System.Collections.Generic;
public class Solution {
    public static void printChessboard(int [,] bd, int n){
        for(int row=0 ; row<n ; row++){
            for(int col=0 ; col<n ; col++)
                Console.Write(bd[row,col]);
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public static IList<string> compareBoardToIList(int [,] board){
        IList<string> solution = new List<string>();
        for(int row=0 ; row<board.GetLength(0) ; row++){
            string queensRow = "";
            for(int col=0 ; col<board.GetLength(1) ; col++){
                if(board[row,col] == 0)
                    queensRow += ".";
                else
                    queensRow += "Q";
            }
            solution.Add(queensRow);
        }
        return solution;
    }

    public static IList<IList<string>> SolveNQueens(int n) {
        // creating empty chessboard
        IList<IList<string>> allSolutions = new List<IList<string>>();
        IList<int[,]> boards = new List<int[,]>();
 
        int[,] chessboard = new int[n, n];
        _solveNQueens(chessboard, 0, 0, n, boards);
        foreach(var b in boards){
            allSolutions.Add(compareBoardToIList(b));
        }
        wSol(boards);
        writeSolution(allSolutions);
        return allSolutions;
    }

    public static int _solveNQueens(int [,]board, int col, int _row, int n, IList<int[,]> boards){
        // tutaj dodaj do tablicy 3dim a w srodku fora kontynuuj
        if(col >= n) {
            // create a new 2D array with the same dimensions as board
            int[,] boardCopy = new int[n, n];
            Array.Copy(board, boardCopy, n * n);
            // add the deep copy of board to the boards list
            boards.Add(boardCopy);
            return col;
        }

        for(int row=_row; row<n; row++){
            if(isSafe(board, row, col, n)){
                board[row, col] = 1;
                _solveNQueens(board, col+1, 0, n, boards);
                board[row, col] = 0;
            }
        }
        return -1;
    }
    public static Boolean isSafe(int [,]board, int row, int col, int n){
        for(int i=0; i<col; i++){
            if (board[row,i] == 1)
                return false;
        }
        for (int i=row, j=col; i>=0 && j>=0; i--, j--){
            if(board[i,j] == 1)
                return false;
        }
        for(int i=row, j=col; i<n && j>=0; i++, j--){
            if(board[i,j] == 1)
                return false;
        }
        return true;
    }

    public static void writeSolution(IList<IList<string>> solutions ){
        foreach(var sol in solutions){
            foreach(var s in sol)
                Console.WriteLine(s);
            Console.WriteLine();
        }
    }
    public static void wSol(IList<int[,]> solutions ){
        foreach(var sol in solutions){
            for(int row=0; row<sol.GetLength(0); row++){
                for(int col=0; col<sol.GetLength(1); col++)
                    Console.Write(sol[row,col]);
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }

    
    public static void Main(){
        SolveNQueens(6);
    }
}
