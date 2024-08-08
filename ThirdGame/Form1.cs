using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThirdGame
{
    public partial class HealthBar : Form
    {
        bool goLeft, goRight, goUp, goDown, gameOver;
        string facing = "up";
        int playerHealth = 100;
        int Speed = 10;
        int ammo = 10;
        int zombieSpeed = 3;
        int score;
        Random random = new Random();

        List<PictureBox> zombieList = new List<PictureBox>();
        public HealthBar()
        {
            InitializeComponent();
        }

        private void MainTimerEvent(object sender, EventArgs e)
        {
            if (playerHealth > 1)
            {
                progressBar1.Value = playerHealth;
            }
            else
            {
                gameOver = true;
            }
            txtAmmo.Text = "Ammo: " + ammo;
            txtScore.Text = "kills: " + score;

            if(goLeft == true && player.Left > 0)
            {
                player.Left -= Speed;
            }
            if(goRight == true && player.Left + player.Width < this.ClientSize.Width)
            {
                player.Left += Speed;
            }
            if(goUp == true && player.Top > 67)
            {
                player.Top -= Speed;
            }
            if(goDown == true && player.Top + player.Height < this.ClientSize.Height)
            {
                player.Top += Speed;
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                goLeft = true;
                facing = "left";
                player.Image = Properties.Resources.left;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
                facing = "right";
                player.Image = Properties.Resources.right;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
                facing = "up";
                player.Image = Properties.Resources.up;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
                facing = "down";
                player.Image = Properties.Resources.down;
            }


        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
                
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
               
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
              
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
               
            }

            if(e.KeyCode == Keys.Space)
            {
                shootBullet(facing);
            }

        }

        private void shootBullet( string direction)
        {
            Bullet shootBullet = new Bullet();
            shootBullet.direction = direction;
            shootBullet.bulletLeft = player.Left + (player.Width / 2);
            shootBullet.bulletTop = player.Top + (player.Height / 2);
            shootBullet.MakeBullet(this);
        }

        private void MakeZombies()
        {

        }
        private void RestartGame()
        {

        }
    }
}
