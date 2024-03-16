using BusinessLogic.BLL;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;

namespace WPF_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            player = new Player();
            team = new Team();
            //teamList = new ObservableCollection<Team> {  };

            
            comboBox_ShowPosition.ItemsSource = Enum.GetValues(typeof(Position));
            listBox_Teams.ItemsSource = BBBLL.GetAllTeams();
        }

        BasketballBLL BBBLL = new BasketballBLL();
        Player player;
        Team team;
        //ObservableCollection<Team> teamList;

        private void btn_showPlayers_Click(object sender, RoutedEventArgs e)
        {
            List<Player> playerList = BBBLL.GetAllPlayers();

            if (listBox_AllPlayers.Items.Count != 0)
            {
                listBox_AllPlayers.Items.Clear();
            }

            foreach (Player p in playerList)
            {
                listBox_AllPlayers.Items.Add(p);
            }
        }

        private void btn_createPlayer_Click(object sender, RoutedEventArgs e)
        {
            Position pos;
            if (radio_createPG.IsChecked == true)
            {
                pos = Position.PointGuard;
            }
            else if (radio_createSG.IsChecked == true)
            {
                pos = Position.ShootingGuard;
            }
            else if (radio_createSF.IsChecked == true)
            {
                pos = Position.SmallForward;
            }
            else if (radio_createPF.IsChecked == true)
            {
                pos = Position.PowerForward;
            }
            else
            {
                pos = Position.Center;
            }
            Player p = new Player(textBox_createName.Text, pos);
            BBBLL.AddPlayer(p);

            //Clear controls
            textBox_createName.Text = null;
            radio_createPG.IsChecked = true;

            //Show popup window
            MessageBox.Show($"Player '{p.Name}' added to DB");
        }

        private void btn_FindPlayer_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = player;

            try
            {
                player = BBBLL.GetPlayer(Int32.Parse(textBox_FindById.Text));
                textBlock_ShowId.Text = player.PlayerId.ToString();
                textBox_ShowName.Text = player.Name;
                comboBox_ShowPosition.Text = player.Position.ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

            //string str = comboBox_ShowPosition.Items[comboBox_ShowPosition.SelectedIndex].ToString();
            //InkBoard.EditingMode = (Position)Enum.Parse(typeof(Position), 
            //    comboBox_ShowPosition.Items[comboBox_ShowPosition.SelectedIndex].ToString());


            //comboBox_ShowPosition
            //textBox_ShowPosition.Text = player.Position.ToString();
        }

        private void btn_editPlayer_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = player;

            player.Name = textBox_ShowName.Text;
            player.Position = (Position)Enum.Parse(typeof(Position), 
                comboBox_ShowPosition.Items[comboBox_ShowPosition.SelectedIndex].ToString());

            BBBLL.EditPlayer(player);
            MessageBox.Show($"Player with id {player.PlayerId} edited");
        }

        private void btn_DeletePlayer_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = player;

            BBBLL.DeletePlayer(Int32.Parse(textBlock_ShowId.Text));
            MessageBox.Show($"{player.Name}, id={player.PlayerId} deleted");
        }

        private void btn_createTeam_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = team;

            team = new Team(textBox_TeamName.Text);
            BBBLL.AddTeam(team);

            //Update teams ListBox
            listBox_Teams.ItemsSource = BBBLL.GetAllTeams();

            //Clear controls
            textBox_TeamName.Text = null;

            //Show popup window
            MessageBox.Show($"Team '{team.TeamName}' added to DB");
        }

        private void listBox_Teams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TeamDetail TD = (TeamDetail)listBox_Teams.SelectedItem;

            List<Player> playerList = TD.Players;

            if (listBox_PlayersOnTeam.Items.Count != 0)
            {
                listBox_PlayersOnTeam.Items.Clear();
            }

            foreach (Player p in playerList)
            {
                listBox_PlayersOnTeam.Items.Add(p);
            }
        }

        private void btn_AddPlayerToTeam_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = player;

            TeamDetail teamDetail = (TeamDetail)listBox_Teams.SelectedItem;

            if (player != null && teamDetail != null)
            {
                BBBLL.AddPlayerToTeam(player.PlayerId, teamDetail.TeamDetailId);

                //Update ListBox
                listBox_Teams.ItemsSource = BBBLL.GetAllTeams();

                //Show popup window
                MessageBox.Show($"{player.Name} (Id: {player.PlayerId}) added to {teamDetail.TeamDetailName}");
            }
            else
            {
                //Show popup window
                MessageBox.Show($"Error: Could not add player to team");
            }
        }

        private void btn_DeteteTeam_Click(object sender, RoutedEventArgs e)
        {
            TeamDetail teamDetail = (TeamDetail)listBox_Teams.SelectedItem;
            BBBLL.RemovePlayersFromTeam(teamDetail.TeamDetailId);
            BBBLL.DeleteTeam(teamDetail.TeamDetailId);

            //Update ListBox
            listBox_Teams.ItemsSource = BBBLL.GetAllTeams();

            //Show popup window
            MessageBox.Show($"{teamDetail.TeamDetailName} (Team Id: {teamDetail.TeamDetailId}) removed from DB");
        }
    }
}
