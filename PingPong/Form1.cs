using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPong
{
    public partial class Form1 : Form
    {
        public int speed_left = 3;
        public int speed_top = 3;
        public int points = 0;


        public Form1()
        {
            InitializeComponent();

            timer1.Enabled = true;
            Cursor.Hide();

            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.Bounds = Screen.PrimaryScreen.Bounds;

            racket.Top = (playground.Bottom -10);

            FinalScore_lbl.Left = (playground.Width / 2) - (FinalScore_lbl.Width / 2);
            FinalScore_lbl.Top = (playground.Width / 6) - (FinalScore_lbl.Width / 6);
            FinalScore_lbl.Visible = false;

            FinalPoints_lbl.Left = (playground.Width / 2) - (FinalPoints_lbl.Width / 2);
            FinalPoints_lbl.Top = (playground.Width / 6) - (FinalPoints_lbl.Width / 6);
            FinalPoints_lbl.Visible = false;

            gameover_lbl.Left = (playground.Width / 2) - (gameover_lbl.Width / 2);
            gameover_lbl.Top = (playground.Width / 4) - (gameover_lbl.Width / 4);
            gameover_lbl.Visible = false;

            pause_lbl.Left = (playground.Width / 2) - (pause_lbl.Width / 2);
            pause_lbl.Top = (playground.Width / 4) - (pause_lbl.Width / 4);
            pause_lbl.Visible = false;

            instructions_lbl.Left = (playground.Width / 2) - (instructions_lbl.Width / 2);
            instructions_lbl.Top = (playground.Width / 4) - (instructions_lbl.Width / 4);
            instructions_lbl.Visible = false;

            about_lbl.Left = (playground.Width / 2) - (about_lbl.Width / 2);
            about_lbl.Top = (playground.Width / 4) - (about_lbl.Width / 4);
            about_lbl.Visible = false;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Brickremuve();

            racket.Left = Cursor.Position.X - (racket.Width / 2);

            ball.Left += speed_left;
            ball.Top += speed_top;

            if (ball.Bottom >= racket.Top && ball.Bottom <= racket.Bottom && ball.Left >= racket.Left && ball.Right <= racket.Right)
            {
                speed_top += 1;
                speed_left += 1;
                points += 1;
                speed_top = -speed_top;
                
                Random random = new Random();
                playground.BackColor = Color.FromArgb(random.Next(155, 255), random.Next(155, 255), random.Next(155, 255));
            }

            if (ball.Left <= playground.Left)
            {
                speed_left = -speed_left;
            }
            if (ball.Right >= playground.Right)
            {
                speed_left = -speed_left;
            }
            if (ball.Top <= playground.Top)
            {
                speed_top = -speed_top;
            }
            if(ball.Bottom >= playground.Bottom)
            {
                timer1.Enabled = false;
                gameover_lbl.Visible = true;
                FinalScore_lbl.Visible = true;
                FinalPoints_lbl.Visible = true;
                FinalPoints_lbl.Text = points.ToString();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.I)
            {
                instructions_lbl.Visible = true;
                timer1.Enabled = false;
                gameover_lbl.Visible = false;
            }

            if (e.KeyCode == Keys.A)
            {
                about_lbl.Visible = true;
                timer1.Enabled = false;
                gameover_lbl.Visible = false;
                instructions_lbl.Visible = false;
            }

            if (e.KeyCode == Keys.P)
            {
                if (timer1.Enabled == false)
                {
                    timer1.Enabled = true;
                    pause_lbl.Visible = false;
                    instructions_lbl.Visible = false;
                    about_lbl.Visible = false;
                }

                else if (timer1.Enabled == true)
                {
                    timer1.Enabled = false;
                    pause_lbl.Visible = true;
                    instructions_lbl.Visible = false;
                    about_lbl.Visible = false;
                }
            }

            if (e.KeyCode == Keys.C)
            {
                timer1.Enabled = true;
                pause_lbl.Enabled = false;
                instructions_lbl.Visible = false;
                pause_lbl.Visible = false;
            }

            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }

            if (e.KeyCode == Keys.Enter)
            {
                ball.Top = 200;
                ball.Left = 30;
                speed_left = 3;
                speed_top = 3;
                points = 0;

                points_lbl.Text = "0";
                timer1.Enabled = true;
                gameover_lbl.Visible = false;
                playground.BackColor = Color.White;
                ball.BackColor = Color.Red;
                FinalPoints_lbl.Visible = false;
                FinalScore_lbl.Visible = false;
                pause_lbl.Visible = false;

                Brick1.Visible = true;
                Brick2.Visible = true;
                Brick3.Visible = true;
                Brick4.Visible = true;
                Brick5.Visible = true;
                Brick6.Visible = true;
                Brick7.Visible = true;
                Brick8.Visible = true;
                Brick9.Visible = true;
                Brick10.Visible = true;
                Brick11.Visible = true;
                Brick12.Visible = true;
                Brick13.Visible = true;
                Brick14.Visible = true;
                Brick15.Visible = true;
            }
        }

        void Brickremuve()
        {
            if (ball.Left + ball.Width >= Brick1.Left && ball.Left + ball.Width <= Brick1.Left + Brick1.Width && ball.Top + ball.Height >= Brick1.Top && ball.Top + ball.Height <= Brick1.Top + Brick1.Height + ball.Height)
            {
                Brick1.Visible = false;
                points_lbl.Text = points.ToString();
                
                if (ball.Top <= Brick1.Top)
                {
                    speed_top = -speed_top;
                }
                if (ball.Bottom >= Brick1.Bottom)
                {
                    speed_top = -speed_top;
                }
                
                
            }

            if (ball.Left + ball.Width >= Brick2.Left && ball.Left + ball.Width <= Brick2.Left + Brick2.Width && ball.Top + ball.Height >= Brick2.Top && ball.Top + ball.Height <= Brick2.Top + Brick2.Height + ball.Height)
            {
                Brick2.Visible = false;
                points_lbl.Text = points.ToString();
                
                if (ball.Top <= Brick2.Top)
                {
                    speed_top = -speed_top;
                }
                if (ball.Bottom >= Brick2.Bottom)
                {
                    speed_top = -speed_top;
                }
            }

            if (ball.Left + ball.Width >= Brick3.Left && ball.Left + ball.Width <= Brick3.Left + Brick3.Width && ball.Top + ball.Height >= Brick3.Top && ball.Top + ball.Height <= Brick3.Top + Brick3.Height + ball.Height)
            {
                Brick3.Visible = false;
                points_lbl.Text = points.ToString();
                
                if (ball.Top <= Brick3.Top)
                {
                    speed_top = -speed_top;
                }
                if (ball.Bottom >= Brick3.Bottom)
                {
                    speed_top = -speed_top;
                }
            }

            if (ball.Left + ball.Width >= Brick4.Left && ball.Left + ball.Width <= Brick4.Left + Brick4.Width && ball.Top + ball.Height >= Brick4.Top && ball.Top + ball.Height <= Brick4.Top + Brick4.Height + ball.Height)
            {
                Brick4.Visible = false;
                points_lbl.Text = points.ToString();
              
                if (ball.Top <= Brick4.Top)
                {
                    speed_top = -speed_top;
                }
                if (ball.Bottom >= Brick4.Bottom)
                {
                    speed_top = -speed_top;
                }
            }

            if (ball.Left + ball.Width >= Brick5.Left && ball.Left + ball.Width <= Brick5.Left + Brick5.Width && ball.Top + ball.Height >= Brick5.Top && ball.Top + ball.Height <= Brick5.Top + Brick5.Height + ball.Height)
            {
                Brick5.Visible = false;
                points_lbl.Text = points.ToString();
              
                if (ball.Top <= Brick5.Top)
                {
                    speed_top = -speed_top;
                }
                if (ball.Bottom >= Brick5.Bottom)
                {
                    speed_top = -speed_top;
                }
            }

            if (ball.Left + ball.Width >= Brick6.Left && ball.Left + ball.Width <= Brick6.Left + Brick6.Width && ball.Top + ball.Height >= Brick6.Top && ball.Top + ball.Height <= Brick6.Top + Brick6.Height + ball.Height)
            {
                Brick6.Visible = false;
                points_lbl.Text = points.ToString();
                
                if (ball.Top <= Brick6.Top)
                {
                    speed_top = -speed_top;
                }
                if (ball.Bottom >= Brick6.Bottom)
                {
                    speed_top = -speed_top;
                }
            }

            if (ball.Left + ball.Width >= Brick7.Left && ball.Left + ball.Width <= Brick7.Left + Brick7.Width && ball.Top + ball.Height >= Brick7.Top && ball.Top + ball.Height <= Brick7.Top + Brick7.Height + ball.Height)
            {
                Brick7.Visible = false;
                points_lbl.Text = points.ToString();
                
                if (ball.Top <= Brick7.Top)
                {
                    speed_top = -speed_top;
                }
                if (ball.Bottom >= Brick7.Bottom)
                {
                    speed_top = -speed_top;
                }
            }

            if (ball.Left + ball.Width >= Brick8.Left && ball.Left + ball.Width <= Brick8.Left + Brick8.Width && ball.Top + ball.Height >= Brick8.Top && ball.Top + ball.Height <= Brick8.Top + Brick8.Height + ball.Height)
            {
                Brick8.Visible = false;
                points_lbl.Text = points.ToString();
                
                if (ball.Top <= Brick8.Top)
                {
                    speed_top = -speed_top;
                }
                if (ball.Bottom >= Brick8.Bottom)
                {
                    speed_top = -speed_top;
                }
            }

            if (ball.Left + ball.Width >= Brick9.Left && ball.Left + ball.Width <= Brick9.Left + Brick9.Width && ball.Top + ball.Height >= Brick9.Top && ball.Top + ball.Height <= Brick9.Top + Brick9.Height + ball.Height)
            {
                Brick9.Visible = false;
                points_lbl.Text = points.ToString();
                

                if (ball.Top <= Brick9.Top)
                {
                    speed_top = -speed_top;
                }
                if (ball.Bottom >= Brick9.Bottom)
                {
                    speed_top = -speed_top;
                }
            }

            if (ball.Left + ball.Width >= Brick10.Left && ball.Left + ball.Width <= Brick10.Left + Brick10.Width && ball.Top + ball.Height >= Brick10.Top && ball.Top + ball.Height <= Brick10.Top + Brick10.Height + ball.Height)
            {
                Brick10.Visible = false;
                points_lbl.Text = points.ToString();
                

                
                if (ball.Top <= Brick10.Top)
                {
                    speed_top = -speed_top;
                }
                if (ball.Bottom >= Brick10.Bottom)
                {
                    speed_top = -speed_top;
                }
            }

            if (ball.Left + ball.Width >= Brick11.Left && ball.Left + ball.Width <= Brick11.Left + Brick11.Width && ball.Top + ball.Height >= Brick1.Top && ball.Top + ball.Height <= Brick1.Top + Brick1.Height + ball.Height)
            {
                Brick11.Visible = false;
                points_lbl.Text = points.ToString();
                

                
                if (ball.Top <= Brick11.Top)
                {
                    speed_top = -speed_top;
                }
                if (ball.Bottom >= Brick11.Bottom)
                {
                    speed_top = -speed_top;
                }

            }

            if (ball.Left + ball.Width >= Brick12.Left && ball.Left + ball.Width <= Brick1.Left + Brick12.Width && ball.Top + ball.Height >= Brick12.Top && ball.Top + ball.Height <= Brick12.Top + Brick12.Height + ball.Height)
            {
                Brick12.Visible = false;
                points_lbl.Text = points.ToString();
                

                
                if (ball.Top <= Brick12.Top)
                {
                    speed_top = -speed_top;
                }
                if (ball.Bottom >= Brick12.Bottom)
                {
                    speed_top = -speed_top;
                }
            }

            if (ball.Left + ball.Width >= Brick13.Left && ball.Left + ball.Width <= Brick13.Left + Brick13.Width && ball.Top + ball.Height >= Brick13.Top && ball.Top + ball.Height <= Brick13.Top + Brick13.Height + ball.Height)
            {
                Brick13.Visible = false;
                points_lbl.Text = points.ToString();
                

                
                if (ball.Top <= Brick13.Top)
                {
                    speed_top = -speed_top;
                }
                if (ball.Bottom >= Brick13.Bottom)
                {
                    speed_top = -speed_top;
                }
            }

            if (ball.Left + ball.Width >= Brick14.Left && ball.Left + ball.Width <= Brick14.Left + Brick14.Width && ball.Top + ball.Height >= Brick14.Top && ball.Top + ball.Height <= Brick14.Top + Brick14.Height + ball.Height)
            {
                Brick14.Visible = false;
                points_lbl.Text = points.ToString();
                

                
                if (ball.Top <= Brick14.Top)
                {
                    speed_top = -speed_top;
                }
                if (ball.Bottom >= Brick14.Bottom)
                {
                    speed_top = -speed_top;
                }
            }

            if (ball.Left + ball.Width >= Brick15.Left && ball.Left + ball.Width <= Brick15.Left + Brick15.Width && ball.Top + ball.Height >= Brick15.Top && ball.Top + ball.Height <= Brick15.Top + Brick15.Height + ball.Height)
            {
                if (ball.Top <= Brick15.Top)
                {
                    speed_top = -speed_top;
                }
                if (ball.Bottom >= Brick15.Bottom)
                {
                    speed_top = -speed_top;
                }

                Brick15.Visible = false;
                points_lbl.Text = points.ToString();
            }
        }
    }
}
