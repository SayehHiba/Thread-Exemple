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
using System.Threading;
namespace thred
{
    public partial class Form1 : Form
    {

       
        String[] cin = new String[20];
        List<String> c = new List<String>();
        List<PictureBox> ch = new List<PictureBox>();
        PictureBox trouver;
        bool fin;
     
        Thread[] TabLigneThread = new Thread[4];
      
        public Form1()
        {
            InitializeComponent();
            fin = false;
            remplirmatrice();
            TabLigneThread[0] = new Thread(() => TraiterLigne(0));
            TabLigneThread[1] = new Thread(() => TraiterLigne(1));
            TabLigneThread[2] = new Thread(() => TraiterLigne(2));
            TabLigneThread[3] = new Thread(() => TraiterLigne(3));

           
        }
      
        void init()
        {


            TabLigneThread[0] = new Thread(() => TraiterLigne(0));
            TabLigneThread[1] = new Thread(() => TraiterLigne(1));
            TabLigneThread[2] = new Thread(() => TraiterLigne(2));
            TabLigneThread[3] = new Thread(() => TraiterLigne(3));
            

           
        }
        void TraiterLigne(int o)
        {
            
            int a=0;
            int b=0;
            if(o==0)
            {
                a = 0;
              b = 5;
            }
            if (o == 1)
            {
                a = 5;
                b = 10;
            }
            if (o == 2)
            {
                a = 10;
                b = 15;
            }
            if (o == 3)
            {
                a = 15;
                b = 20;
            }
            for (int i = a; i <b ; i++)
            {

                if (c[i] == tcin.Text)
                {
                    
                    fin = true;
                    trouver = ch[i];
                    for (int y = 0; y < 4;y++ )
                    {
                        if(y!=i)
                        {
                            TabLigneThread[y].Abort();
                        }
                    }
                        break;
                }
            }
        }
     
      

        private void remplirmatrice()
        {

            c.Add("07864256");
            c.Add("03629745");
            c.Add("09625251");
            c.Add("05363632");
            c.Add("00320415");
           c.Add("06323554");
            c.Add("03493240");
             c.Add("04632356");
             c.Add("03665659");
             c.Add("01693022");
             c.Add("02363555");
            c.Add("02555636");
            c.Add("03036522");
           c.Add("02010223");
            c.Add("03654664");
             c.Add("05321002");
            c.Add("02665363");
             c.Add("06532569");
             c.Add("04766356");
             c.Add("02656988");


            ch.Add(p11);
            ch.Add(p12);
            ch.Add(p13);
            ch.Add(p14);
            ch.Add(p15);
            ch.Add(p21);
            ch.Add(p22);
            ch.Add(p23);
            ch.Add(p24);
            ch.Add(p25);
            ch.Add(p31);
            ch.Add(p32);
            ch.Add(p33);
            ch.Add(p34);
            ch.Add(p35);
            ch.Add(p41);
            ch.Add(p42);
            ch.Add(p43);
            ch.Add(p44);
            ch.Add(p45);
        }

        private void button1_Click(object sender, EventArgs e)
        {
             
            if (c.Contains(tcin.Text))
            { 
                
                init();
                for (int j = 0; j < TabLigneThread.Length; j++)
                {
                    if (TabLigneThread[j].ThreadState == ThreadState.Unstarted)
                        TabLigneThread[j].Start();
                    else
                        if (TabLigneThread[j].ThreadState == ThreadState.Stopped)
                        {
                            TabLigneThread[j].Abort();
                            TabLigneThread[j] = null;
                            TabLigneThread[j] = new Thread(() => TraiterLigne(j));
                            TabLigneThread[j].Start();
                        }
                }
                Thread.Sleep(1000);
                if (fin == true)
                {
                  
                        foreach (PictureBox ctrl in tab.Controls)
                        {

                            if (ctrl.Name != trouver.Name)
                            {

                                ctrl.Visible = false;

                            }
                        }
                  
                   Task.Run(() => { Thread.Sleep(2000); }).Wait();
                    foreach (PictureBox ctrl in tab.Controls)
                    {

                            ctrl.Visible = true;

                    }
                    trouver = null;
                    fin = false;
                    tcin.Text = String.Empty;

                }
            }else
                 if (tcin.Text == String.Empty)
            {

                errorProvider1.SetError(tcin, "chaine vide");

            }else

                     if (tcin.Text.Length != 8)
                     {
                         errorProvider1.SetError(tcin, "longueur doit être égale à 8");
                         

                     }
                     else

               
            { MessageBox.Show("cin introuvable");
            tcin.Text = String.Empty;
            }
            
        }

      
        private void Tcin_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(((int)e.KeyChar == 08) || (((int)e.KeyChar >=48) && ((int)e.KeyChar <= 57))))
            {
                e.Handled = true;
                return;
            }
          
           
        }

        private void tcin_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear(); 
        }

       
        

    

        }

    }

        


     
        

        

     

     

    

