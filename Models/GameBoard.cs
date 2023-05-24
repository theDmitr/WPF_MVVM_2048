using System;
using WPF_MVVM_2048.ViewModels.Base;

namespace WPF_MVVM_2048.Models
{
    public class GameBoard : ViewModel
    {
        public readonly int boardSize = 4;
        public readonly int WinValue = 2048;

        public int[,] board;
        public int score;

        public int[,] Board { get => board; set => Set(ref board, value); }
        public int Score { get => score; set => Set(ref score, value); }

    }
}
