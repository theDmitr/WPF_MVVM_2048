using System;
using WPF_MVVM_2048.ViewModels.Base;

namespace WPF_MVVM_2048.Model
{
    public class GameModel : ViewModel
    {
        public const int boardSize = 4;
        public const int WinValue = 2048;
        private readonly Random random;

        private int[,] board;
        private int score;

        public int[,] Board { get => board; }
        public int Score { get => score; }

        public GameModel()
        {
            random = new Random();
            Reset();
        }

        #region Operations
        public void Reset()
        {
            board = new int[boardSize, boardSize];
            score = 0;
            GenerateRandomNumber();
            GenerateRandomNumber();
        }

        private void GenerateRandomNumber()
        {
            int row, col;

            do
            {
                row = random.Next(boardSize);
                col = random.Next(boardSize);
            } while (board[row, col] != 0);

            board[row, col] = random.Next(100) < 90 ? 2 : 4;
        }
        #endregion

        #region GameState
        public bool IsGameWin()
        {
            for (int row = 0; row < boardSize; row++)
            {
                for (int column = 0; column < boardSize; column++)
                {
                    if (board[row, column] == WinValue)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IsGameOver()
        {
            for (int row = 0; row < boardSize; row++)
            {
                for (int column = 0; column < boardSize; column++)
                {
                    if (board[row, column] == 0)
                    {
                        return false;
                    }
                }
            }

            for (int row = 0; row < boardSize; row++)
            {
                for (int column = 0; column < boardSize; column++)
                {
                    int value = board[row, column];

                    if (row > 0 && board[row - 1, column] == value)
                    {
                        return false;
                    }

                    if (row < boardSize - 1 && board[row + 1, column] == value)
                    {
                        return false;
                    }

                    if (column > 0 && board[row, column - 1] == value)
                    {
                        return false;
                    }

                    if (column < boardSize - 1 && board[row, column + 1] == value)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion

        #region Shifts
        public bool ShiftLeft()
        {
            bool shifted = false;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                int index = 0;
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] != 0)
                    {
                        if (index > 0 && board[i, index - 1] == board[i, j])
                        {
                            board[i, index - 1] *= 2;
                            board[i, j] = 0;
                            shifted = true;
                            score += board[i, index - 1];
                        }
                        else
                        {
                            if (j != index)
                            {
                                board[i, index] = board[i, j];
                                board[i, j] = 0;
                                shifted = true;
                            }
                            index++;
                        }
                    }
                }
            }
            if (shifted)
                GenerateRandomNumber();
            return shifted;
        }

        public bool ShiftRight()
        {
            bool shifted = false;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                int index = board.GetLength(1) - 1;
                for (int j = board.GetLength(1) - 1; j >= 0; j--)
                {
                    if (board[i, j] != 0)
                    {
                        if (index < board.GetLength(1) - 1 && board[i, index + 1] == board[i, j])
                        {
                            board[i, index + 1] *= 2;
                            board[i, j] = 0;
                            shifted = true;
                            score += board[i, index + 1];
                        }
                        else
                        {
                            if (j != index)
                            {
                                board[i, index] = board[i, j];
                                board[i, j] = 0;
                                shifted = true;
                            }
                            index--;
                        }
                    }
                }
            }
            if (shifted)
                GenerateRandomNumber();
            return shifted;
        }

        public bool ShiftDown()
        {
            bool shifted = false;
            for (int j = 0; j < board.GetLength(1); j++)
            {
                int index = board.GetLength(0) - 1;
                for (int i = board.GetLength(0) - 1; i >= 0; i--)
                {
                    if (board[i, j] != 0)
                    {
                        if (index < board.GetLength(0) - 1 && board[index + 1, j] == board[i, j])
                        {
                            board[index + 1, j] *= 2;
                            board[i, j] = 0;
                            shifted = true;
                            score += board[index + 1, j];
                        }
                        else
                        {
                            if (i != index)
                            {
                                board[index, j] = board[i, j];
                                board[i, j] = 0;
                                shifted = true;
                            }
                            index--;
                        }
                    }
                }
            }
            if (shifted)
                GenerateRandomNumber();
            return shifted;
        }

        public bool ShiftUp()
        {
            bool shifted = false;
            for (int j = 0; j < board.GetLength(1); j++)
            {
                int index = 0;
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    if (board[i, j] != 0)
                    {
                        if (index > 0 && board[index - 1, j] == board[i, j])
                        {
                            board[index - 1, j] *= 2;
                            board[i, j] = 0;
                            shifted = true;
                            score += board[index - 1, j];
                        }
                        else
                        {
                            if (i != index)
                            {
                                board[index, j] = board[i, j];
                                board[i, j] = 0;
                                shifted = true;
                            }
                            index++;
                        }
                    }
                }
            }
            if (shifted)
                GenerateRandomNumber();
            return shifted;
        }
        #endregion
    }
}
