using System;
using System.Windows;
using System.Xml.Linq;
using WPF_MVVM_2048.Commands;
using WPF_MVVM_2048.Model;
using WPF_MVVM_2048.ViewModels.Base;

namespace WPF_MVVM_2048.ViewModels
{
    public class GameViewModel : ViewModel
    {
        private readonly GameModel gameModel;

        private int[,] cells;
        private string score;

        public int[,] Cells { get => cells; private set => Set(ref cells, value); }
        public string Score { get => score; private set => Set(ref score, value); }

        public GameViewModel()
        {
            gameModel = new GameModel();

            ShiftLeftCommand = new RelayCommand(ShiftLeft);
            ShiftRightCommand = new RelayCommand(ShiftRight);
            ShiftDownCommand = new RelayCommand(ShiftDown);
            ShiftUpCommand = new RelayCommand(ShiftUp);
            ResetCommand = new RelayCommand(Reset);

            Update();
        }

        #region Commands
        public static NavigationCommand NavigateToMenuPage { get => new(NavigateToPage, new Uri("View/Pages/MenuPage.xaml", UriKind.RelativeOrAbsolute)); }

        public RelayCommand ShiftLeftCommand { get; init; }
        public RelayCommand ShiftRightCommand { get; init; }
        public RelayCommand ShiftDownCommand { get; init; }
        public RelayCommand ShiftUpCommand { get; init; }
        public RelayCommand ResetCommand { get; init; }
        #endregion

        #region Operations
        private void Reset()
        {
            gameModel.Reset();
            Update();
        }

        private void CheckGameState()
        {
            Update();
            if (gameModel.IsGameOver())
            {
                MessageBoxResult result = MessageBox.Show("Вы проиграли! Желаете занести себя в список?", "Конец", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes)
                {
                    AddToStatistics();
                }

                Reset();
            }
            else if (gameModel.IsGameWin())
            {
                MessageBoxResult result = MessageBox.Show("Вы выиграли! Желаете занести себя в список?", "Конец", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes)
                {
                    AddToStatistics();
                }

                Reset();
            }
        }

        private void Update()
        {
            Cells = gameModel.Board;
            Score = gameModel.Score.ToString();
        }

        private void AddToStatistics()
        {
            string name;

            do
            {
                name = Microsoft.VisualBasic.Interaction.InputBox("Введите ваше имя: ", "Ввод имени", "");
                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Имя не может быть пустым. Пожалуйста, введите ваше имя!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } while (string.IsNullOrEmpty(name));

            Statistics.Add(name, Score);
        }
        #endregion

        #region Shifts
        private void ShiftLeft()
        {
            if (gameModel.ShiftLeft())
                CheckGameState();
        }

        private void ShiftRight()
        {
            if (gameModel.ShiftRight())
                CheckGameState();
        }

        private void ShiftDown()
        {

            if (gameModel.ShiftDown())
                CheckGameState();
        }

        private void ShiftUp()
        {
            if (gameModel.ShiftUp())
                CheckGameState();
        }
        #endregion
    }
}
