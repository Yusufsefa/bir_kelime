using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BirKelime
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (hrf1.Text == "")
                btnResult.Enabled = false;
        }

        private void rndLetters_Click(object sender, EventArgs e)
        {

            btnResult.Enabled = true;

            RndLetters();
            hrfbns.Text = "";
            radioButton1.Checked = false;
            listBox1.Items.Clear();
            radioButton2.Checked = false;
            txtPoint.Text = "";
            txtResult.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtPoint.Text = "";
            txtResult.Text = "";
            listBox1.Items.Clear();

            List<String> result = Result.getInstance().findWords(getWords(), getLetters());

            try
            {
                txtResult.Text = HighScore(result);
                txtPoint.Text = Point(HighScore(result)).ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("Word not found");
            }
            

            foreach (var item in result)
            {
                listBox1.Items.Add(item.ToString());
            }

        }

        public char[] getLetters()
        {
            if(radioButton1.Checked == true)
            {
                char[] letters = {
                    Convert.ToChar(hrf1.Text),
                    Convert.ToChar(hrf2.Text),
                    Convert.ToChar(hrf3.Text),
                    Convert.ToChar(hrf4.Text),
                    Convert.ToChar(hrf5.Text),
                    Convert.ToChar(hrf6.Text),
                    Convert.ToChar(hrf7.Text),
                    Convert.ToChar(hrf8.Text),
                    Convert.ToChar(hrfbns.Text),
                };

                return letters;
            }else
            {

                char[] letters = {
                    Convert.ToChar(hrf1.Text),
                    Convert.ToChar(hrf2.Text),
                    Convert.ToChar(hrf3.Text),
                    Convert.ToChar(hrf4.Text),
                    Convert.ToChar(hrf5.Text),
                    Convert.ToChar(hrf6.Text),
                    Convert.ToChar(hrf7.Text),
                    Convert.ToChar(hrf8.Text),
                };

                return letters;
            }
        }


        public List<String> getWords()
        {

            List<String> dicList = new List<string>();

            try
            {
                StreamReader str = File.OpenText("D:\\metin.txt");
                String word;

                while((word=str.ReadLine()) != null)
                {
                    if(word.Length > 2)
                    dicList.Add(word.ToLower());
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return dicList;
        }

        public String HighScore(List<String> words)
        {
            int size = 0;
            int indx = 0;

            for (int i = 0; i < words.Count; i++)
            {
                if (words[i].Length > size)
                {
                    size = words[i].Length;
                    indx = i;
                }
            }
            return words[indx];
        }

        public int Point(String word)
        {
            int point = 0;

            if (word.Length == 3)
                point = 3;

            if (word.Length == 4)
                point = 4;

            if (word.Length == 5)
                point = 5;

            if (word.Length == 6)
                point = 7;

            if (word.Length == 7)
                point = 9;

            if (word.Length == 8)
                point = 11;

            if (word.Length == 9)
                point = 15;

            return point;

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                char bonus = Random_Letters.getInstance().bonusLetter();
                hrfbns.Text = bonus.ToString();
            }
        }

        private void RndLetters()
        {
            char[] letters = Random_Letters.getInstance().rndLetters();

            hrf1.Text = letters[0].ToString();
            hrf2.Text = letters[1].ToString();
            hrf3.Text = letters[2].ToString();
            hrf4.Text = letters[3].ToString();
            hrf5.Text = letters[4].ToString();
            hrf6.Text = letters[5].ToString();
            hrf7.Text = letters[6].ToString();
            hrf8.Text = letters[7].ToString();

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked == true)
            {
                listBox1.Items.Clear();
            }
        }
    }
}

