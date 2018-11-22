using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Practicum1
{
    class Formulier : Form
    {
        Button start = new Button();
        Button react = new Button();

        int x;
        int y;
        
        Random rnd = new Random();

        int W;

        double ID;
        double D;

        DateTime t1;
        DateTime t2;

        int rndx;
        int rndy;
        
        public Formulier()
        {
            //Waarden Formulier
            this.WindowState = FormWindowState.Maximized;
            this.Text        = "Practicum 1";
            this.BackColor   = Color.Purple;
            
            this.SizeChanged += Formulier_SizeChanged;

            //Waarden knops
            start.Text      = "Start";
            start.BackColor = Color.Yellow;

            x = 700;
            y = 380;

            Point startLoc = new Point(x, y);
            start.Location = startLoc;
            
            start.Click   += Start_Click;
            Controls.Add(start);

            //Waarden react button
            react.Text      = "Klik";
            react.BackColor = Color.Yellow;
            react.Click    += React_Click;
        }

        private void Formulier_SizeChanged(object sender, EventArgs e)
        {
            Console.WriteLine(this.Size);
        }

        public void Start_Click(object sender, EventArgs e)
        {
            //Willekeurige locatie react button
            rndx = rnd.Next(20, 1400);
            rndy = rnd.Next(20, 750);

            Point reactLoc = new Point(rndx, rndy);

            react.Location = reactLoc;

            //Willekeurige grootte react button
            W = rnd.Next(20, 100);

            Size reactSize = new Size(W, W);

            Controls.Add(react);

            Console.WriteLine("Breedte = " + W);

            //Index of difficulty
            ID = Math.Log(2) * (1 + D / W);

            Console.WriteLine("Index of difficulty = " + ID);

            t1 = DateTime.Now;
            
            start.Hide();
            react.Show();
        }

        private void React_Click(object sender, EventArgs e)
        {
            //Afstand tussen start button en react button
            int D1 = Math.Abs(rndx - x);
            int D2 = Math.Abs(rndy - y);

            D = Math.Sqrt(D1 ^ 2 + D2 ^ 2);

            Console.WriteLine("Afstand = " + D);

            //Reactietijd
            t2 = DateTime.Now;

            TimeSpan T = t2 - t1;
            
            Console.WriteLine("Reactietijd = " + T.TotalSeconds);

            start.Show();
            react.Hide();
        }
    }

    class Program
    {
        static void Main()
        {
            Formulier scherm;
            scherm = new Formulier();
            Application.Run(scherm);
        }
    }
}
