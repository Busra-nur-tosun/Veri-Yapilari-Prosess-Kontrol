using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
namespace finalproje
{
    public partial class Form1 : Form
    {
        public class kuyruk
        {
            public kuyruk sonraki;
            public int sayi;
        }
        public kuyruk kuyruğun_önü = null;
        public kuyruk kuyruğun_sonu = null;
        public kuyruk kuyruğunp1_önü = null;
        public kuyruk kuyruğunp1_sonu = null;
        public kuyruk kuyruğunp2_önü = null;
        public kuyruk kuyruğunp2_sonu = null;
        public kuyruk kuyruğunp3_önü = null;
        public kuyruk kuyruğunp3_sonu = null;
        public class yıgın
        {
            public yıgın sonraki;
            public int sayı;
            public string deger;
        }
        public yıgın ilk = null;
        public yıgın p1ilk = null;
        public yıgın p2ilk = null;
        public yıgın p3ilk = null;
        public Form1()
        {
            InitializeComponent();
        }
        public int p1üretilen = 0;
        public int p2üretilen = 0;
        public int p3üretilen = 0;

        public String proses1;
    
        Random rastgele = new Random();
        //proseslerde ilk hangisinin üretimi  için tracbarlar çekildi ise diğer trackbarların hareketine kadar  sıralamaya başlıyor.
        //o an için üretilmeyen veya daha geç  üretilen değer için 0 değeri dönmektedir.

        private void trackBar1_Scroll(object sender, EventArgs e)//proses 1
        {
            if (trackBar1.Value == 0 || trackBar1.Value == 1 || trackBar1.Value == 2 || trackBar1.Value == 3 || trackBar1.Value == 4 || trackBar1.Value == 5 || trackBar1.Value == 6)
            {
                p1.Start();
            }
        }

        private void p1_Tick(object sender, EventArgs e)//proses1
        {
            for (int i = 1; i <= trackBar1.Value; i++)
            {

                p1üretilen = rastgele.Next(1, 6);
                ekle(p1üretilen, p2üretilen, p3üretilen);
                String deger = "p1--" + p1üretilen.ToString();
              
                textBox1.Text += "p1" + "--" + p1üretilen.ToString() + "\r\n";
                p1_yıgın(p1üretilen);
              
            }

            if (trackBar1.Value == 0)
            {
                p1.Stop();
            }
        }
        private void trackBar3_Scroll(object sender, EventArgs e)//proses2
        {
            if (trackBar3.Value == 0 || trackBar3.Value == 1 || trackBar3.Value == 2 || trackBar3.Value == 3 || trackBar3.Value == 4 || trackBar3.Value == 5 || trackBar3.Value == 6)
            {
                p2.Start();
            }
        }
        private void p2_Tick(object sender, EventArgs e)//proses2
        {
            for (int i = 1; i <= trackBar3.Value; i++)
            {

                p2üretilen = rastgele.Next(1, 6);

                ekle(p1üretilen, p2üretilen, p3üretilen);
                  
                p2_yıgın(p2üretilen);
                textBox3.Text += "p2" + "--" + p2üretilen.ToString() + "\r\n";
               

            }
            if (trackBar3.Value == 0)
            {
                p2.Stop();
            }
        }
        private void trackBar4_Scroll(object sender, EventArgs e)//proses3
        {
            if (trackBar4.Value == 0 || trackBar4.Value == 1 || trackBar4.Value == 2 || trackBar4.Value == 3 || trackBar4.Value == 4 || trackBar4.Value == 5 || trackBar4.Value == 6)
            {
                p3.Start();
            }
        }
        private void p3_Tick(object sender, EventArgs e)//proses3
        {
            for (int i = 1; i <= trackBar4.Value; i++)
            {

                p3üretilen = rastgele.Next(1, 6);
                
                ekle(p1üretilen, p2üretilen, p3üretilen);
                p3_yıgın(p3üretilen);
                textBox4.Text += "p3" + "--" + p3üretilen.ToString() + "\r\n";
               
            }
            if (trackBar1.Value == 0)
            {
                p3.Stop();
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (trackBar1.Value == 0 || trackBar1.Value == 1 || trackBar1.Value == 2 || trackBar1.Value == 3 || trackBar1.Value == 4 || trackBar1.Value == 5 || trackBar1.Value == 6)
            {
                islemci.Start();
            }
        }

        private void islemci_Tick(object sender, EventArgs e)
        {
            for (int i = 1; i <= trackBar2.Value; i++)
            {
                
                ekle(p1üretilen, p2üretilen, p3üretilen);
                kuyrukgöster();

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("üretim sırasına göre sıralanmakta olup o an da üretilmeyen veya geç üretilen değer için 0 dedgeri dönmektedir");
            kuyrukgöster();


        }
        private void kuyrukgöster()
        {
            textBox2.Text = null;
            if (kuyruğun_sonu == null)
            {
                MessageBox.Show("gösterilecek eleman yok");
            }
            else
            {
                kuyruk geçici = new kuyruk();
                geçici = kuyruğun_önü;
                while (geçici != null)
                {
                    textBox2.Text += geçici.sayi + "--";
                    geçici = geçici.sonraki;



                }
            }
        }
   

        private void p1_k_ekle(int p1deger)
        {
            kuyruk ekle = new kuyruk();
            ekle.sayi = p1deger;
            if (kuyruğun_önü == null)
            {
                kuyruğun_önü = kuyruğun_sonu = ekle;

            }
            else
            {
                kuyruğun_sonu.sonraki = ekle;
                kuyruğun_sonu = ekle;

            }
          
            if (kuyruğun_sonu == null)
            {
                MessageBox.Show("gösterilecek eleman yok");
            }
            else
            {
                kuyruk geçici = new kuyruk();
                geçici = kuyruğunp3_önü;
                while (geçici != null)
                {
                    textBox2.Text += "p1--" + geçici.sayi + "--";
                    geçici = geçici.sonraki;
                }
            }
        }
        private void p2_k_ekle(int p2deger)
        {
            kuyruk ekle = new kuyruk();
            ekle.sayi = p2deger;
            if (kuyruğun_önü == null)
            {
                kuyruğun_önü = kuyruğun_sonu = ekle;

            }
            else
            {
                kuyruğun_sonu.sonraki = ekle;
                kuyruğun_sonu = ekle;

            }
          
            if (kuyruğun_sonu == null)
            {
                MessageBox.Show("gösterilecek eleman yok");
            }
            else
            {
                kuyruk geçici = new kuyruk();
                geçici = kuyruğunp3_önü;
                while (geçici != null)
                {
                    textBox2.Text += "p2--" + geçici.sayi + "--";
                    geçici = geçici.sonraki;
                }
            }
        }
        private void p3_k_ekle(int p3deger)
        {
            kuyruk ekle = new kuyruk();
            ekle.sayi = p3deger;
            if (kuyruğun_önü == null)
            {
                kuyruğun_önü = kuyruğun_sonu = ekle;

            }
            else
            {
                kuyruğun_sonu.sonraki = ekle;
                kuyruğun_sonu = ekle;

            }
          
            if (kuyruğun_sonu == null)
            {
                MessageBox.Show("gösterilecek eleman yok");
            }
            else
            {
                kuyruk geçici = new kuyruk();
                geçici = kuyruğunp3_önü;
                while (geçici != null)
                {
                    textBox2.Text += "p3--" + geçici.sayi + "--";
                    geçici = geçici.sonraki;
                }
            }
        }

        public void ekle(int p1üretilen, int p2üretilen, int p3üretilen)
        {
            kuyruk ekle = new kuyruk();
            int p1deger = Convert.ToInt32(p1üretilen);
            int p2deger = Convert.ToInt32(p2üretilen);
            int p3deger = Convert.ToInt32(p3üretilen);
            if ((p1deger == p2deger) && (p3deger == p1deger) && (p2deger == p3deger))
            {

                p1_k_ekle(p1deger);
                p2_k_ekle(p2deger);
                p3_k_ekle(p3deger);
              
            }
            if ((p1deger == p2deger) && (p1deger > p3deger))
            {
                p1_k_ekle(p1deger);
                p2_k_ekle(p2deger);
                p3_k_ekle(p3deger);
              
            }

            if ((p1deger == p2deger) && (p1deger < p3deger))
            {
                p3_k_ekle(p3deger);
                p1_k_ekle(p1deger);
                p2_k_ekle(p2deger);

             
            }
            if ((p3deger == p2deger) && (p1deger < p3deger))
            {
                p3_k_ekle(p3deger);
                p2_k_ekle(p2deger);
                p1_k_ekle(p1deger);


              
            }
            if ((p3deger == p2deger) && (p1deger > p3deger))
            {
                p1_k_ekle(p1deger);
                p2_k_ekle(p2deger);
                p3_k_ekle(p3deger);

              
            }
            if ((p3deger == p1deger) && (p1deger > p2deger))
            {
                p1_k_ekle(p1deger);
                p2_k_ekle(p2deger);
                p3_k_ekle(p3deger);

               
            }
            if ((p3deger == p1deger) && (p1deger < p2deger))
            {
                p2_k_ekle(p2deger);
                p1_k_ekle(p1deger);
                p3_k_ekle(p3deger);

              
            }

            if (p1deger > p2deger && p1deger > p3deger)
            {
                p1_k_ekle(p1deger);
              
                if (p2deger > p3deger)
                {
                    p2_k_ekle(p2deger);
                   
                    p3_k_ekle(p3deger);
                    

                }
                if (p3deger > p2deger)
                {
                    p3_k_ekle(p3deger);
                     
                    p2_k_ekle(p2deger);
                     
                }
                if (p3deger == p2deger)
                {
                    p2_k_ekle(p2deger);
                     
                    p3_k_ekle(p3deger);
                  
                }

            }

            else if (p2deger > p1deger && p2deger > p3deger)
            {
                p2_k_ekle(p2deger);
                
                if (p1deger > p3deger)
                {
                    p1_k_ekle(p1deger);
                   
                    p3_k_ekle(p3deger);
                    
                }
                if (p3deger > p1deger)
                {
                    p3_k_ekle(p3deger);
                  
                    p1_k_ekle(p1deger);
                   
                }
                if (p3deger == p1deger)
                {
                    p1_k_ekle(p1deger);
                   
                    p1_k_ekle(p1deger);
                 
                }
            }
            else if (p3deger > p1deger && p3deger > p2deger)
            {
                p3_k_ekle(p3deger);
                
                if (p1deger > p2deger)
                {
                    p1_k_ekle(p1deger);
                    
                    p2_k_ekle(p2deger);
                   
                }
                if (p2deger > p1deger)
                {
                    p2_k_ekle(p2deger);
                   
                    p1_k_ekle(p1deger);
                    
                }
                if (p2deger == p1deger)
                {
                    p1_k_ekle(p1deger);
                    
                    p2_k_ekle(p2deger);
                   
                }
            
            }


        }
    

        private void button2_Click(object sender, EventArgs e)
        {
            islemci.Stop();
        }
        private void p1_yıgın(int p1üretilen)
        {
            yıgın p1_yıgın_ekle = new yıgın();
            p1_yıgın_ekle.sayı = p1üretilen;
           p1_yıgın_ekle.sonraki = p1ilk;
            p1ilk = p1_yıgın_ekle;
 
        }
        private void p2_yıgın(int p2üretilen)
        {
            yıgın p2ekle = new yıgın();
            p2ekle.sayı = p2üretilen;
            p2ekle.sonraki =p2ilk;
            p2ilk = p2ekle;

        }
        private void p3_yıgın(int p3üretilen)
        {
            yıgın p3yıgın_ekle = new yıgın();
          p3yıgın_ekle.sayı = p3üretilen;
            p3yıgın_ekle.sonraki = p3ilk;
            p3ilk = p3yıgın_ekle;

        }
        private void p1_yıgıngöster()
        {
            textBox5.Text = null;
            if (p1ilk == null)
            {
                MessageBox.Show("gösterilecek eleman yok");
            }
            else
            {
                yıgın geçici = p1ilk;
                while (geçici != null)
                {
                    textBox5.Text += "p1--"+geçici.sayı + "\r\n";
                    
                    geçici = geçici.sonraki;
                }

            }
        }
        private void p2_yıgıngöster()
        {
            textBox5.Text = null;
            if (p2ilk == null)
            {
                MessageBox.Show("gösterilecek eleman yok");
            }
            else
            {
                yıgın geçici = p2ilk;
                while (geçici != null)
                {
                    textBox5.Text += "p2--" + geçici.sayı + "\r\n";
                  
                    geçici = geçici.sonraki;
                }

            }
        }
        private void p3_yıgıngöster()
        {
            textBox5.Text = null;
            if (p3ilk == null)
            {
                MessageBox.Show("gösterilecek eleman yok");
            }
            else
            {
                yıgın geçici = p3ilk;
                while (geçici != null)
                {
                    textBox5.Text += "p3--" + geçici.sayı + "\r\n";
                  
                    geçici = geçici.sonraki;
                }

            }
        }


        
      

        private void button3_Click(object sender, EventArgs e)
        {

            if (checkBox1.Checked == true&&(checkBox2.Checked==false &&checkBox3.Checked==false))
            {

                p1_yıgıngöster();
             
            }
            if (checkBox2.Checked == true&&(checkBox1.Checked == false && checkBox3.Checked == false))
            {
              
                 p2_yıgıngöster();

            }
            if (checkBox3.Checked == true&& (checkBox2.Checked == false && checkBox1.Checked == false))
            {
                 p3_yıgıngöster();
            }
            if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true)
            {
             
                MessageBox.Show("gösterim yanlıştır");
           
            }
            if (checkBox1.Checked == true && checkBox2.Checked == true&&checkBox3.Checked==false)
            {
                MessageBox.Show("gösterim yanlıştır");

            }
            if (checkBox1.Checked == true && checkBox3.Checked == true && checkBox2.Checked == false)
            {
                MessageBox.Show("gösterim yanlıştır");

            }
            if (checkBox2.Checked == true && checkBox3.Checked == true && checkBox1.Checked == false)
            {
                MessageBox.Show("gösterim yanlıştır");

            }
           

        }
    }

}

