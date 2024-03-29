﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseProject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        static int Level = 1;
        static int Proverka = 0;
        int NumCount = 0;
        bool LoginCheck = false;
        string LoginName;
        List<Player> playersList = new List<Player>();

        #region Настройки ButtonPanel

        private void CheckButton_Click(object sender, EventArgs e)
        {
            if (LoginCheck)
            {
                tabControl.SelectedIndex = 2;
                GetRandom();
                textBoxChR.Focus();
            }
        }

        private void RaitingButton_Click(object sender, EventArgs e)
        {
            if (LoginCheck)
            {
                tabControl.SelectedIndex = 3;
                PrinRaiting();
            }
        }

        private void SupportButton_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 4;
            label3.Focus();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            SaveAndCloseFile();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (LoginCheck) tabControl.SelectedIndex = 1;
            else tabControl.SelectedIndex = 0;

        }

        #endregion

        #region Настройки LoginPage

        private void LoginButton_Click(object sender, EventArgs e)
        {
            CheckText();
        }

        private void textBoxLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) CheckText();
        }

        public void CheckText()
        {
            if (textBoxLogin.Text!= "")
            {
                LoginName = textBoxLogin.Text.ToString();
                FileRead();
                LoginCheck = true;
                tabControl.SelectedIndex = 1;
                textBoxRead.Focus();
                UnlockButton(LoginName);
            }
            else MessageBox.Show("ERROR!!!");
        }

        #endregion

        #region Настройки GamePage

        public void ReadAndWrit()
        {
            if (textBoxRead.Text != "")
            {
                textBoxWrite.Text = "";
                int a = Convert.ToInt32(textBoxRead.Text);
                int b = GameAlgorithm.Exercises(a, Level);
                textBoxWrite.Text += Convert.ToString(b);
                textBoxRead.Text = "";
                if (NumCount < 8)
                {
                    NumCount++;
                    textBoxPrevNumX.Text += a + "\r\n";
                    textBoxPrevNumY.Text += b + "\r\n";
                }
                else
                {
                    NumCount = 0;
                    NumCount++;
                    textBoxPrevNumX.Text = "";
                    textBoxPrevNumY.Text = "";
                    textBoxPrevNumX.Text += a + "\r\n";
                    textBoxPrevNumY.Text += b + "\r\n";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Level = Convert.ToInt32((sender as Button).Text);
            ReadAndWrit();
        }

        private void textBoxRead_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                ReadAndWrit();
            }
        }

        public void UnlockButton(string player)
        {
            for (int i = 0; i < playersList.Count; i++)
            {
                if (playersList[i].name == LoginName)
                {
                    Level = playersList[i].score;
                    break;
                }
            }

            if (Level > 1) button2.Enabled = true;
            if (Level > 2) button3.Enabled = true;
            if (Level > 3) button4.Enabled = true;
            if (Level > 4) button5.Enabled = true;
            if (Level > 5) button6.Enabled = true;
            if (Level > 6) button7.Enabled = true;
            if (Level > 7) button8.Enabled = true;
            if (Level > 8) button9.Enabled = true;
            if (Level > 9) button10.Enabled = true;
            if (Level > 10) button11.Enabled = true;
            if (Level > 11) button12.Enabled = true;
            
        }

        #endregion

        #region Настройки CheckPage

        public void GetRandom()
        {
            Random rand = new Random();
            int n = rand.Next(0, 100);
            textBoxChN.Text = n.ToString();
        }

        public void Check()
        {
            int m = Convert.ToInt32(textBoxChN.Text);
            if (GameAlgorithm.Exercises(m,Level) == Convert.ToInt32(textBoxChR.Text))
            {
                Proverka++;
                if (Proverka == 1)
                {
                    Win();
                    Level++;
                    textBoxPrevNumX.Text = "";
                    textBoxPrevNumY.Text = "";
                    textBoxWrite.Text = "";
                    tabControl.SelectedIndex = 1;
                    UnlockButton(LoginName);
                    Proverka = 0;
                }
                GetRandom();
            }
            else
            {
                textBoxChT.Text = Convert.ToString("Подумай");
                textBoxChN.Text = Convert.ToString("ещё!");
                MessageBox.Show("");
                textBoxChT.Text = Convert.ToString("Если Х=");
                textBoxChN.Text = Convert.ToString(m);
            }
        }

        private void Win()
        {
            for (int i = 0; i < playersList.Count; i++)
            {
                if (playersList[i].name == LoginName)
                {
                    playersList[i].score += 1;
                    playersList.Sort();
                    break;
                }
            }
        }

        private void textBoxChR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                Check();
                textBoxChR.Text = null;
            }
        }

        #endregion

        #region Настройки RaitingPage

        private void FileRead()
        {
            StreamReader sr = new StreamReader("score.txt");
            string s = sr.ReadLine();
            while (s != "STOP")
            {
                string[] str = s.Split();
                Player p = new Player(str[0], Convert.ToInt32(str[1]));
                playersList.Add(p);
                s = sr.ReadLine();
            }

            sr.Close();
            playersList.Sort();

            for (int i = 0; i < playersList.Count; i++)
            {
                if (playersList[i].name == LoginName) 
                    return;
            }
            
            playersList.Add(new Player(LoginName, 1));
        }

        private void PrinRaiting()
        {
            textBoxRL.Text = "";
            textBoxRS.Text = "";
            int n;
            if (playersList.Count < 10)
                n = playersList.Count;
            else n = 10;
            for (int i = 0; i < n; i++)
            {
                textBoxRL.Text += playersList[i].name + "\r\n";
                textBoxRS.Text += playersList[i].score.ToString() + "\r\n";
            }
        }

        private void SaveAndCloseFile()
        {
            StreamWriter sw = new StreamWriter("score.txt");
            for (int i = 0; i < playersList.Count; i++)
            {
                sw.WriteLine(playersList[i].name + " " + playersList[i].score);
            }
            sw.Write("STOP");
            sw.Close();
        }

        #endregion
    }

    //
    //Класс для создания рейтинга игроков
    //
    class Player : IComparable<Player>
    {
        public string name;
        public int score;

        public Player(string str, int n)
        {
            name = str;
            score = n;
        }

        public int CompareTo(Player other)
        {
            if (score == other.score)
                return 0;
            if (score < other.score)
                return 1;
            else return -1;
        }
    }
}
