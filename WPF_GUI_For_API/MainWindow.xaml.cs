using BusinessLogic.BLL;
using DataAccess.Model;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.Json;
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
using WPF_GUI_For_API.Model;

namespace WPF_GUI_For_API
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            comboBox_addPosition.ItemsSource = Enum.GetValues(typeof(Position));
        }

        private void btn_show_players_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            Task<string> task = client.GetStringAsync("https://localhost:7033/api/Player");
            String msg = task.Result;
            List<Model.PlayerDetail> playerList = JsonSerializer.Deserialize<List<Model.PlayerDetail>>(msg);

            if (listBox_showPlayers.Items.Count != 0)
            {
                listBox_showPlayers.Items.Clear();
            }
            foreach (var p in playerList)
            {
                listBox_showPlayers.Items.Add(p);
            }
        }

        private void btn_addPlayer_Click(object sender, RoutedEventArgs e)
        {
            Position pos = (Position)Enum.Parse(typeof(Position),
                comboBox_addPosition.Items[comboBox_addPosition.SelectedIndex].ToString());
            DTO.Model.Player p = new DTO.Model.Player(textBox_addName.Text, pos);

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            StringContent content = new StringContent(JsonSerializer.Serialize(p), Encoding.UTF8, "application/json");
            HttpResponseMessage result = client.PostAsync("https://localhost:7033/api/Player", content).Result;
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show("Status: " + result.StatusCode.ToString());
            }
            else
            {
                MessageBox.Show("Player '" + p.Name + "' added to DB");
            }

            //Clear controls
            textBox_addName.Text = null;
            comboBox_addPosition.SelectedItem = null;
        }

        private void btn_showTeamsWithPlayers_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            Task<string> task = client.GetStringAsync("https://localhost:7033/api/Team");
            String msg = task.Result;
            List<Model.Team> teamList = JsonSerializer.Deserialize<List<Model.Team>>(msg);

            if (listBox_Teams.Items.Count != 0)
            {
                listBox_Teams.Items.Clear();
            }
            foreach (var t in teamList)
            {
                listBox_Teams.Items.Add(t);
            }
        }

        private void listBox_Teams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox_playersOnTeam.Items.Count != 0)
            {
                listBox_playersOnTeam.Items.Clear();
            }
            if (listBox_Teams.SelectedItem != null)
            {
                foreach (var p in ((Model.Team)listBox_Teams.SelectedItem).players)
                {
                    listBox_playersOnTeam.Items.Add(p);
                }
            }
        }

        private void btn_addPlayerToTeam_Click(object sender, RoutedEventArgs e)
        {
            if (listBox_showPlayers.SelectedItem != null && listBox_Teams.SelectedItem != null)
            {
                Model.PlayerDetail p = (Model.PlayerDetail)listBox_showPlayers.SelectedItem;
                Model.Team t = (Model.Team)listBox_Teams.SelectedItem;

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                HttpResponseMessage result = client.PutAsync("https://localhost:7033/api/Team/" + p.playerId + "/" + t.teamId, new StringContent("")).Result;
                if (result.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("Status: " + result.StatusCode.ToString());
                }
                else
                {
                    listBox_Teams.Items.Clear();
                    if (listBox_playersOnTeam.Items.Count != 0)
                    {
                        listBox_playersOnTeam.Items.Clear();
                    }
                    MessageBox.Show(p.name + " added to " + t.teamName + ".");
                }
            }
        }

        private void btn_deletePlayer_Click(object sender, RoutedEventArgs e)
        {
            Model.PlayerDetail p = (Model.PlayerDetail)listBox_showPlayers.SelectedItem;

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            HttpResponseMessage result = client.DeleteAsync("https://localhost:7033/api/Player/" + p.playerId).Result;
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show("Status: " + result.StatusCode.ToString());
            }
            else
            {
                MessageBox.Show("Player '" + p.name + "' deleted from DB");
                listBox_showPlayers.Items.Remove(p);
            }
        }

        private void btn_addPToS_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_pToS_playerId.Text != null && textBox_pToS_sponsorshipId.Text != null)
            {
                int pId = Int32.Parse(textBox_pToS_playerId.Text);
                int sId = Int32.Parse(textBox_pToS_sponsorshipId.Text);

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                HttpResponseMessage result = client.PutAsync("https://localhost:7033/api/Sponsorship/" + pId + "/" + sId, new StringContent("")).Result;
                if (result.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("Status: " + result.StatusCode.ToString());
                }
                else
                {
                    textBox_findSponsorship.Text = null;
                    textBox_pToS_playerId.Text = null;
                    textBox_pToS_sponsorshipId.Text = null;
                    label_foundSponsorship.Content = "Find sponsorship to see sponsored players";
                    if (listBox_playersOnSponsorship.Items.Count != 0)
                    {
                        listBox_playersOnSponsorship.Items.Clear();
                    }
                    MessageBox.Show("Player added to sponsorship.");
                }
            }
        }

        private void btn_findSponsorshipById_Click(object sender, RoutedEventArgs e)
        {
            int sponsorshipId = Int32.Parse(textBox_findSponsorship.Text);

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            Task<string> task = client.GetStringAsync("https://localhost:7033/api/Sponsorship/" + sponsorshipId);
            String msg = task.Result;
            Model.SponsorshipDetail sponsorship = JsonSerializer.Deserialize<Model.SponsorshipDetail>(msg);

            label_foundSponsorship.Content = "Players sponsored by " + sponsorship.sponsorshipDetailName + ":";

            if (listBox_playersOnSponsorship.Items.Count != 0)
            {
                listBox_playersOnSponsorship.Items.Clear();
            }
            foreach (var p in sponsorship.players)
            {
                listBox_playersOnSponsorship.Items.Add(p);
            }
        }
    }
}
