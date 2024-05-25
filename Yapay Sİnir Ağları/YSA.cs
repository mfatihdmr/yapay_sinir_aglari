using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yapay_Sİnir_Ağları
{
    class YSA
    {
        private double momentumk;
        private double öğrenmek;
        private double hataoran;
        private int[] benimdizi;
        private int katmansayı;
        
        private int[,] testdizi =
        {
            {
            0,0,1,0,0,
            0,1,0,1,0,
            1,0,0,0,1,
            1,0,0,0,1,
            1,1,1,1,1,
            1,0,0,0,1,
            1,0,0,0,1,
             },
            {
            1,1,1,1,0,
            1,0,0,0,1,
            1,0,0,0,1,
            1,1,1,1,0,
            1,0,0,0,1,
            1,0,0,0,1,
            1,1,1,1,0,
            },
            {
            0,0,1,1,1,
            0,1,0,0,0,
            1,0,0,0,0,
            1,0,0,0,0,
            1,0,0,0,0,
            0,1,0,0,0,
            0,0,1,1,1,
            },
            {
            1,1,1,0,0,
            1,0,0,1,0,
            1,0,0,0,1,
            1,0,0,0,1,
            1,0,0,0,1,
            1,0,0,1,0,
            1,1,1,0,0,
            },
            {
            1,1,1,1,1,
            1,0,0,0,0,
            1,0,0,0,0,
            1,1,1,1,1,
            1,0,0,0,0,
            1,0,0,0,0,
            1,1,1,1,1,
            }

        };
      
        public double Momentumk { get => momentumk; set => momentumk = value; }
        public double Öğrenmek { get => öğrenmek; set => öğrenmek = value; }
        public double Hataoran { get => hataoran; set => hataoran = value; }
        public int[] Benimdizi { get => benimdizi; set => benimdizi = value; }
        public int Katmansayı { get => katmansayı; set => katmansayı = value; }
        public double[,] Randomgiris { get => randomgiris; set => randomgiris = value; }
        public double[] B_esik1 { get => b_esik1; set => b_esik1 = value; }
        public double[] B_esik2 { get => b_esik2; set => b_esik2 = value; }
        public double[] Randomcıkıs { get => randomcıkıs; set => randomcıkıs = value; }
        public int[,] Testdizi { get => testdizi; set => testdizi = value; }
        public double[,] Ara { get => ara; set => ara = value; }
        public double Hata { get => hata; set => hata = value; }
        public double Cıktı { get => cıktı; set => cıktı = value; }
        public double Net { get => net; set => net = value; }
        public double[] Sigmaa { get => sigmaa; set => sigmaa = value; }
        public bool A { get => a; set => a = value; }
       
        public int[] Yerinde { get => yerinde; set => yerinde = value; }
        public int Index { get => index; set => index = value; }
        

        public YSA(double momentumk, double öğrenmek, double hataoran)
        {
            this.momentumk = momentumk;
            this.öğrenmek = öğrenmek;
            this.hataoran = hataoran;
            
        }
        public YSA()
        {
            Randomgiris = new double[35,3];
            B_esik1 = new double[3];
            B_esik2 = new double[5];
            Randomcıkıs = new double[3];
            Testdizi = new int[5, 35];
            Benimdizi = new int[35];
            
        }
      
        public void diziaktar(Button[] bt)
        {
            Benimdizi = new int[35];
            for (int i = 0; i < 35; i++)
            {

                if (bt[i].BackColor == Color.Black)
                {
                    Benimdizi[i] = 1;
                }
                else if (bt[i].BackColor == Color.White)
                {
                    Benimdizi[i] = 0;
                }
            }
        }
        private double[,] randomgiris;
       
        private double[] b_esik1;
        private double[] b_esik2;
        private double[] randomcıkıs;
        

     
        public void randomağırlık()
        {
            randomgiris = new double[3,35];
            b_esik1 = new double[3];
            b_esik2 = new double[1];
            Randomcıkıs = new double[3];
            Random rnd = new Random();
            Thread.Sleep(500);
            Random rnd1 = new Random();
            Thread.Sleep(500);
            Random rnd2 = new Random();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 35; j++)
                {
                    double giris = rnd.NextDouble();

                    giris = Math.Round(giris, 2);
                    Randomgiris[i,j] = giris;

                }
               
            }
            for (int i = 0; i < 4; i++)
            {
                double esik = rnd1.NextDouble();

                esik = Math.Round(esik, 2);
                if (i < 3)
                {
                    B_esik1[i] = esik;
                }
                else if (i >= 3)
                {
                    B_esik2[i-3] = esik;
                }
            }

            for (int i = 0; i < 3; i++)
            {
               
                    double cıktı = rnd2.NextDouble();

                    cıktı = Math.Round(cıktı, 2);

                    Randomcıkıs[i] = cıktı;
            }
           
        }

        private double[,] ara;
        private double hata;
        private double cıktı;
        private double net;
        public void hesapla(int []benim,double[,] rgiris,double []rcıkıs,double []esik1,double[]esik2)
        {
            ara = new double[3, 2];
            Net = 0;
            Cıktı = 0;
            Hata = 0;
            double gecici = 0;
            for (int i = 0; i < 3; i++)
            {
                gecici = 0;
                for (int j = 0; j < 35; j++)
                {
                    gecici += benim[j] * rgiris[i, j];
                }
                gecici += gecici + esik1[i];
                ara[i, 0] = gecici;
                ara[i, 1] = (1 / (1 + Math.Exp(-gecici)));
            }

           // MessageBox.Show(ara.Length.ToString());


            for (int i = 0; i < 3; i++)
            {
                Net += Ara[i, 1] * rcıkıs[i];
            }
            
            double ckt = Net + esik2[0];
            Cıktı = (1 / (1 + Math.Exp(-ckt)));
            Hata = 1 - Cıktı;
            // MessageBox.Show(Cıktı.ToString());
            // MessageBox.Show(Hata.ToString());
           
        }
        private double[] sigmaa;

        private bool a;
        public void geriyedonus(double[,] rgiris, double[] rcıkıs, double[] esik1, double[] esik2,double[,]aradızı,int it)
        {

            sigmaa = new double[3];
            A = true;
            
            while (A==true)
            {
                double sigma = Cıktı * (1 - Cıktı) * Hata;
                for (int i = 0; i < 3; i++)
                {
                    sigmaa[i] = Ara[i, 1] * (1 - Ara[i, 1]) * rcıkıs[i] * sigma;
                }
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 35; j++)
                    {
                        rgiris[i, j] = rgiris[i, j] + ((Öğrenmek * sigmaa[i] * rgiris[i, j]) + Momentumk * it);
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    esik1[i] = esik1[i] + ((Öğrenmek * sigmaa[i] * 1) + Momentumk * it);
                }
                for (int i = 0; i < 3; i++)
                {
                    rcıkıs[i] = rcıkıs[i] + ((Öğrenmek * sigma * aradızı[i, 1]) + Momentumk * it);
                }
                esik2[0] = esik2[0] + ((Öğrenmek * sigma * 1) + Momentumk * it);

                hesapla(Benimdizi, Randomgiris, Randomcıkıs, B_esik1, B_esik2);

                
                if(Hata < Hataoran)
                {
                    A = false;
                    
                   
                }
            }
        }

       

        private int[] yerinde;
        private int index;
        public void hangisi()
        {
            yerinde = new int[5]; 
            int yerindemi = 0;
            for (int i = 0; i < 5; i++)
            {
                yerindemi = 0;
                for (int j = 0; j < 35; j++)
                {
                    if(Benimdizi[j]==Testdizi[i,j])
                    {
                        yerindemi++;
                    }
                }
                yerinde[i] = yerindemi;
            }
            
            for (int i = 0; i < 5; i++)
            {
                if(yerinde[i]==35)
                {

                    Index = i;
                    return;
                    
                }
                else 
                {
                    Index = -1;
                }

                
               
            }
            
        }



        public void sıfıricin(int[,] benim, double[,] rgiris, double[] rcıkıs, double[] esik1, double[] esik2,int a)
        {
            ara = new double[3, 2];
            Net = 0;
            Cıktı = 0;
            Hata = 0;
            double gecici = 0;
            for (int i = 0; i < 3; i++)
            {
                gecici = 0;
                for (int j = 0; j < 35; j++)
                {
                    gecici += benim[a,j] * rgiris[i, j];
                }
                gecici += gecici + esik1[i];
                ara[i, 0] = gecici;
                ara[i, 1] = (1 / (1 + Math.Exp(-gecici)));
            }

            // MessageBox.Show(ara.Length.ToString());


            for (int i = 0; i < 3; i++)
            {
                Net += Ara[i, 1] * rcıkıs[i];
            }

            double ckt = Net + esik2[0];
            Cıktı = (1 / (1 + Math.Exp(-ckt)));
            Hata = 0 - Cıktı;

            // MessageBox.Show(Cıktı.ToString());
            // MessageBox.Show(Hata.ToString());
            
        }

        public void sıfırgeri(double[,] rgiris, double[] rcıkıs, double[] esik1, double[] esik2, double[,] aradızı,int a)
        {
            sigmaa = new double[3];
            A = true;

            
            while (A == true)
            {
                
                double sigma = Cıktı * (1 - Cıktı) * Hata;
                for (int i = 0; i < 3; i++)
                {
                    sigmaa[i] = Ara[i, 1] * (1 - Ara[i, 1]) * rcıkıs[i] * sigma;
                }
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 35; j++)
                    {
                        rgiris[i, j] = rgiris[i, j] + ((Öğrenmek * sigmaa[i] * rgiris[i, j]) + Momentumk *a);
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    esik1[i] = esik1[i] + ((Öğrenmek * sigmaa[i] * 1) + Momentumk *a);
                }
                for (int i = 0; i < 3; i++)
                {
                    rcıkıs[i] = rcıkıs[i] + ((Öğrenmek * sigma * aradızı[i, 1]) + Momentumk *a);
                }
                esik2[0] = esik2[0] + ((Öğrenmek * sigma * 1) + Momentumk *a);

               sıfıricin(Testdizi, Randomgiris, Randomcıkıs, B_esik1, B_esik2,a);
                 
                if (Hata < Hataoran)
                {
                    A = false;
                    
                }
            }
           
        }












    }

}

























