using System;
using System.Linq;
using System.Windows;
using FootballLeague.DataAccess;
using FootballLeague.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballLeagueApp
{
    public partial class MainWindow : Window
    {
        private FootballDbContext _context;

        public MainWindow()
        {
            InitializeComponent();
            _context = new FootballDbContext();
            _context.Database.Migrate(); // Забезпечення створення бази даних
            LoadTeams();
        }

        private void AddTeamButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var team = new FootballTeam
                {
                    TeamName = TeamNameTextBox.Text,
                    City = CityTextBox.Text,
                    Wins = int.Parse(WinsTextBox.Text),
                    Losses = int.Parse(LossesTextBox.Text),
                    Draws = int.Parse(DrawsTextBox.Text),
                    GoalsScored = int.Parse(GoalsScoredTextBox.Text),
                    GoalsConceded = int.Parse(GoalsConcededTextBox.Text)
                };

                _context.Teams.Add(team);
                _context.SaveChanges();
                LoadTeams();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding team: {ex.Message}");
            }
        }

        private void LoadTeams()
        {
            TeamsListBox.ItemsSource = _context.Teams.ToList();
        }
    }
}