using SpeechLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace At_Yarisi
{
    public partial class Form1 : Form
    {
        int BirinciAtSolaUzaklik, ikinciAtSolaUzaklik, UcuncuAtSolaUzaklik;
        int bittimi = 0;
        Random rastgele = new Random();
        private void btnBaslat_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SpVoice ses = new SpVoice();
            SpeechRecognitionEngine sr = new SpeechRecognitionEngine();
            Grammar g = new DictationGrammar();
            sr.LoadGrammar(g);
            int birinciatinGenisligi = pictureBox1.Width;
            int ikinciatinGenisligi = pictureBox2.Width;
            int ucuncuatinGenisligi = pictureBox3.Width;
            int BitisUzakligi = lblBitisCizgisi.Left;
            pictureBox1.Left = pictureBox1.Left + rastgele.Next(5,15);
            pictureBox2.Left = pictureBox2.Left + rastgele.Next(5,15);
            pictureBox3.Left = pictureBox3.Left + rastgele.Next(5,15);

            if (pictureBox1.Left>pictureBox2.Left+5&&pictureBox2.Left>pictureBox3.Left+5)
            {
                lblsonuc.Text = "1 Numaralı At önde ";
            }
            if (pictureBox2.Left > pictureBox1.Left + 5 && pictureBox2.Left > pictureBox3.Left + 5)
            {
                lblsonuc.Text = "2 Numaralı At önde ";
            }
            if (pictureBox3.Left > pictureBox1.Left + 5 && pictureBox3.Left > pictureBox2.Left + 5)
            {
                lblsonuc.Text = "3 Numaralı At önde ";
            }


            if (birinciatinGenisligi+pictureBox1.Left>=BitisUzakligi)
            {
                bittimi = 1;
                timer1.Enabled = false;
                ses.Speak("1 numaralı at yarışı kazandı");
            }

            if (ikinciatinGenisligi + pictureBox2.Left >= BitisUzakligi)
            {
                bittimi = 1;
                timer1.Enabled = false;
                ses.Speak("2 numaralı at yarışı kazandı");
            }

            if (ucuncuatinGenisligi + pictureBox3.Left >= BitisUzakligi)
            {
                bittimi = 1;
                timer1.Enabled = false;
                ses.Speak("3 numaralı at yarışı kazandı");
            }

            if (bittimi == 1)
            {
                pictureBox1.Left = 0;
                pictureBox2.Left = 0;
                pictureBox3.Left = 0;
                lblsonuc.Text = "";
                bittimi = 0;
            }

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BirinciAtSolaUzaklik = pictureBox1.Left;
            ikinciAtSolaUzaklik = pictureBox2.Left;
            UcuncuAtSolaUzaklik = pictureBox2.Left;
        }
    }
}
