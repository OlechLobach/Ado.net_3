using System;
using System.Windows;
using ClassLibrary;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        private GameDbContext _context;

        public MainWindow()
        {
            InitializeComponent();
            _context = new GameDbContext();
            _context.Database.Migrate(); // Apply pending migrations and ensure database is created
            LoadGames();
        }

        private void AddGameButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.TryParse(CopiesSoldTextBox.Text, out int copiesSold))
                {
                    var game = new Game
                    {
                        Title = TitleTextBox.Text,
                        Developer = DeveloperTextBox.Text,
                        Genre = GenreTextBox.Text,
                        ReleaseDate = ReleaseDatePicker.SelectedDate ?? DateTime.Now,
                        GameMode = GameModeTextBox.Text,
                        CopiesSold = copiesSold
                    };

                    _context.Games.Add(game);
                    _context.SaveChanges();
                    LoadGames();
                }
                else
                {
                    MessageBox.Show("Invalid number format for Copies Sold.");
                }
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show($"Error saving game: {ex.Message}");
            }
        }

        private void LoadGames()
        {
            GamesListBox.ItemsSource = _context.Games.ToList();
        }
    }
}