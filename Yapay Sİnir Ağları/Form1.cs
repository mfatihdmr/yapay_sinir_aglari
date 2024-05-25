using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yapay_Sİnir_Ağları
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void renk1(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.Aquamarine;
            btn.ForeColor = Color.DimGray;

        }

        private void renk2(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.ForeColor = Color.Aquamarine;
            btn.BackColor = Color.DimGray;
        }

        private void cikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void asagı_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void rakam(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void harfyaz(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            if (btn.BackColor == Color.White)
            {
                btn.BackColor = Color.Black;
            }
            else if (btn.BackColor == Color.Black)
            {
                btn.BackColor = Color.White;
            }
        }
        
        private void temizle_Click(object sender, EventArgs e)
        {
                Button[] btn = {
                button1,  button2,  button3,  button4,  button5,
                button6,  button7,  button8,  button9,  button10,
                button11, button12, button13, button14, button15,
                button16, button17, button18, button19, button20 ,
                button21, button22, button23, button24, button25 ,
                button26, button27, button28, button29, button30 ,
                button31, button32, button33, button34, button35 ,
                  };

            for (int i = 0; i < 35; i++)
            {
                
                    if (btn[i].BackColor == Color.Black)
                    {
                        btn[i].BackColor = Color.White;
                    }
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
           
            numericUpDown1.Value = numericUpDown1.Minimum;
            numericUpDown2.Value = numericUpDown2.Minimum;
            numericUpDown3.Value = numericUpDown3.Minimum;
            Array.Clear(ysa.Randomgiris, 0, ysa.Randomgiris.Length);
            Array.Clear(ysa.Randomcıkıs, 0, ysa.Randomcıkıs.Length);
            Array.Clear(ysa.Benimdizi, 0, ysa.Benimdizi.Length );
            Array.Clear(ysa.B_esik1, 0, ysa.B_esik1.Length);
            Array.Clear(ysa.B_esik2, 0, ysa.B_esik2.Length);
            Array.Clear(ysa.Ara, 0, ysa.Ara.Length);


        }
        YSA ysa;
        private void tanımla_Click(object sender, EventArgs e)
        {
            Button[] btn = {
                button1,  button2,  button3,  button4,  button5,
                button6,  button7,  button8,  button9,  button10,
                button11, button12, button13, button14, button15,
                button16, button17, button18, button19, button20 ,
                button21, button22, button23, button24, button25 ,
                button26, button27, button28, button29, button30 ,
                button31, button32, button33, button34, button35 ,
                  };
            ysa = new YSA(Convert.ToDouble(numericUpDown3.Value), Convert.ToDouble(numericUpDown2.Value), Convert.ToDouble(numericUpDown1.Value));
            ysa.diziaktar(btn);
            ysa.randomağırlık();
            hesap.Enabled = true;
            tanımla.Enabled = false;

        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            hesap.Enabled = false;
        }

        private void hesap_Click(object sender, EventArgs e)
        {
            
            TextBox[] tx =
             {
                textBox1,textBox2,textBox3,textBox4,textBox5
             };
            ysa.hangisi();
            
            for (int i = 0; i < 5; i++)
            {
                
                
                if (ysa.Index == i)
                {
                   
                    ysa.hesapla(ysa.Benimdizi, ysa.Randomgiris, ysa.Randomcıkıs, ysa.B_esik1, ysa.B_esik2);
                    ysa.geriyedonus(ysa.Randomgiris, ysa.Randomcıkıs, ysa.B_esik1, ysa.B_esik2, ysa.Ara,i);
                    
                    tx[i].Text = ysa.Cıktı.ToString();
                   

                }
                else if (ysa.Index != i && ysa.Index!=-1)
                {
                    
                    ysa.sıfıricin(ysa.Testdizi, ysa.Randomgiris, ysa.Randomcıkıs, ysa.B_esik1, ysa.B_esik2, i);
                    ysa.sıfırgeri(ysa.Randomgiris, ysa.Randomcıkıs, ysa.B_esik1, ysa.B_esik2, ysa.Ara, i);
                    double son = 1 - ysa.Cıktı;
                    tx[i].Text = son.ToString();
                    
                   
                }
                else if (ysa.Index==-1)
                {
                    
                    ysa.sıfıricin(ysa.Testdizi, ysa.Randomgiris, ysa.Randomcıkıs, ysa.B_esik1, ysa.B_esik2, i);
                    ysa.sıfırgeri(ysa.Randomgiris, ysa.Randomcıkıs, ysa.B_esik1, ysa.B_esik2, ysa.Ara, i);
                    double son = 1 - ysa.Cıktı;
                    tx[i].Text = son.ToString();

                }
                
            }
            hesap.Enabled = false;
            tanımla.Enabled = true;
        }
    }
}

