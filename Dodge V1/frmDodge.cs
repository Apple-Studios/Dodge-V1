﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dodge_V1
{
    public partial class frmDodge : Form
    {
        Graphics g; //declare a graphics object called g
        // declare space for an array of 7 objects called planet 
        Planet[] planet = new Planet[7];
        Random yspeed = new Random();
        Spaceship spaceship = new Spaceship();
        bool left, right;
        string move;

        public frmDodge()
        {
            InitializeComponent();
            for (int i = 0; i < 7; i++)
            {
                int x = 10 + (i * 75);
                planet[i] = new Planet(x);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pnlGame_Paint(object sender, PaintEventArgs e)
        {
            //get the graphics used to paint on the panel control
            g = e.Graphics;
            //call the Planet class's DrawPlanet method to draw the image planet1 
            for (int i = 0; i < 7; i++)
            {
                // generate a random number from 5 to 20 and put it in rndmspeed
                int rndmspeed = yspeed.Next(5, 20);
                planet[i].y += rndmspeed;
                planet[i].drawPlanet(g);
            }
            spaceship.drawSpaceship(g);
        }

        private void frmDodge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left) { left = true; }
            if (e.KeyData == Keys.Right) { right = true; }

        }

        private void frmDodge_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left) { left = false; }
            if (e.KeyData == Keys.Right) { right = false; }

        }

        private void tmrShip_Tick(object sender, EventArgs e)
        {
            if (right) // if right arrow key pressed
            {
                move = "right";
                spaceship.moveSpaceship(move);
            }
            if (left) // if left arrow key pressed
            {
                move = "left";
                spaceship.moveSpaceship(move);
            }

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tmrPlanet_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 7; i++)
            {
                planet[i].movePlanet();
            }
            pnlGame.Invalidate();//makes the paint event fire to redraw the panel
        }
    }
}
