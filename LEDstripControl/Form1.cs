using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        LED[] LEDs = new LED[30];
        MLED[] mLEDs = new MLED[30];
        int pointer = -1;
        bool changed=false;
        bool go = false;
        Graphics g ;
        Stopwatch s = new Stopwatch();
        string[] atx=new string[5];
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 30; i++)
            {
                LEDs[i] = new LED(Color.FromArgb(0, 0, 0));
                mLEDs[i] = new MLED(LEDs[i].color,i);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (go)
            {
                if (serialPort1.BytesToRead > 0)
                {
                    readserial();
                }
            }
            Invalidate();
            if (changed)
            {
                changed = false;
                for (int i = 0; i < 30; i++)
                {
                    mLEDs[i].x = i;
                    mLEDs[i].reverse = false;
                    mLEDs[i].mtime = 0;
                }
                s.Restart();
                NewControls(pointer);
            }
            for (int i = 0; i < 30; i++)
            {
                if (LEDs[i].movement!=0)
                {
                    double MovementS = LEDs[i].mspeed/1000;
                    int cycle;
                    if (LEDs[i].bounce) cycle = 2 * (LEDs[i].maxLED - LEDs[i].minLED);
                    else cycle =LEDs[i].maxLED - LEDs[i].minLED+1;
                    int ccycle = ((int)(s.ElapsedMilliseconds*MovementS) + (LEDs[i].movement == 1 ? (i - LEDs[i].minLED + 1) : LEDs[i].maxLED - i - 1)) % cycle;
                    int move= (LEDs[i].bounce ? (cycle / 2) - Math.Abs(ccycle - (cycle / 2)) : ccycle);
                    if (LEDs[i].movement == 1) mLEDs[i].x = LEDs[i].minLED - 1 + move;
                    else mLEDs[i].x = LEDs[i].maxLED - 1 - move;
                }
                if (LEDs[i].changingLight)
                {
                    if (s.ElapsedMilliseconds % (LEDs[i].timeOut+LEDs[i].timeIn)<=LEDs[i].timeOut)
                    {
                        if (LEDs[i].fadeOut)
                        {
                            double multiplier = 0.5*Math.Cos(Math.PI * (s.ElapsedMilliseconds - 1 % (LEDs[i].timeOut + LEDs[i].timeIn)) / LEDs[i].timeOut)+0.5;
                            mLEDs[i].color = Color.FromArgb((int)((double)LEDs[i].color.R * multiplier), (int)((double)LEDs[i].color.G * multiplier), (int)((double)LEDs[i].color.B * multiplier));
                        }
                        else if (s.ElapsedMilliseconds % (LEDs[i].timeOut+LEDs[i].timeIn)>LEDs[i].timeOut-30)
                        {
                            mLEDs[i].color = Color.Black;
                        }
                    }
                    else
                    {
                        if (LEDs[i].fadeIn)
                        {
                            double multiplier = -0.5 * Math.Cos(Math.PI * ((s.ElapsedMilliseconds - 1 % (LEDs[i].timeOut + LEDs[i].timeIn)) - LEDs[i].timeOut) / LEDs[i].timeIn) + 0.5;
                            mLEDs[i].color = Color.FromArgb((int)((double)LEDs[i].color.R * multiplier), (int)((double)LEDs[i].color.G * multiplier), (int)((double)LEDs[i].color.B * multiplier));
                        }
                        else if (s.ElapsedMilliseconds % (LEDs[i].timeOut + LEDs[i].timeIn) - LEDs[i].timeOut > LEDs[i].timeIn - 30)
                        {
                            mLEDs[i].color = LEDs[i].color;
                        }
                    }
                }
                else
                {
                    mLEDs[i].color = LEDs[i].color;
                }
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Y <= 70 && e.Y >= 20 && e.X >= 20 && e.X <= this.Size.Width - 40)
            {
                pointer = (int)Math.Floor((double)((30 * (e.X - 20)) / (this.Size.Width - 65)));
                RedControl.Enabled = true;
                RedControl.Value = LEDs[pointer].color.R;
                GreenControl.Enabled = true;
                GreenControl.Value = LEDs[pointer].color.G;
                BlueControl.Enabled = true;
                BlueControl.Value = LEDs[pointer].color.B;
                NewControls(pointer);
            }
        }

        private void NewControls(int LED)
        {
            Movement.Visible = true;
            if (LEDs[LED].movement == 0) radioButtonStationary.Checked = true;
            else if (LEDs[LED].movement == 1) radioButtonRmove.Checked = true;
            else radioButtonLmove.Checked = true;

            checkBoxBounce.Visible = LEDs[LED].movement != 0;
            checkBoxBounce.Checked = LEDs[LED].bounce && LEDs[LED].movement != 0;
            MaxLED.Visible = LEDs[LED].movement == 1 || checkBoxBounce.Checked;
            label1.Visible = MaxLED.Visible;
            MaxLED.Text = LEDs[LED].maxLED.ToString();
            MinLED.Visible = LEDs[LED].movement == 2 || checkBoxBounce.Checked;
            label2.Visible = MinLED.Visible;
            MinLED.Text = LEDs[LED].minLED.ToString();
            Mspeed.Visible = LEDs[LED].movement != 0;
            Mspeed.Text = LEDs[LED].mspeed.ToString();
            label5.Visible = Mspeed.Visible;

            LightChange.Visible = true;
            if (LEDs[LED].changingLight) radioButtonClight.Checked = true;
            else radioButtonSlight.Checked = true;
            InOut.Visible = radioButtonClight.Checked;
            InOut.Checked = LEDs[LED].InOut;
            ChangeOut.Visible = radioButtonClight.Checked;
            if (LEDs[LED].fadeOut) FadeOut.Checked = true;
            else BlinkOut.Checked = true;
            if (LEDs[LED].fadeIn) FadeIn.Checked = true;
            else BlinkIn.Checked = true;
            ChangeIn.Visible = ChangeOut.Visible && !InOut.Checked;
            textBoxIn.Text = LEDs[LED].timeIn.ToString();
            textBoxOut.Text = LEDs[LED].timeOut.ToString();
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.FillEllipse(Brushes.Black, 20, 20, 20, 20);
            g.FillEllipse(Brushes.Black, this.Size.Width - 60, 20, 20, 20);
            g.FillRectangle(Brushes.Black, 30, 20, this.Size.Width - 80, 20);

            g.FillEllipse(Brushes.Black, 20, 50, 20, 20);
            g.FillEllipse(Brushes.Black, this.Size.Width - 60, 50, 20, 20);
            g.FillRectangle(Brushes.Black, 30, 50, this.Size.Width - 80, 20);

            for (int i = 0; i < 30; i++)
            {
                int x = (i * (this.Size.Width - 65) / 30) + 30;
                if (pointer == i)
                {
                    g.FillPolygon(Brushes.Red, new Point[3] { new Point(x, 10), new Point(x + 10, 10), new Point(x + 5, 15) });
                }
                g.FillEllipse(new SolidBrush(LEDs[i].color), x, 25, 10, 10);
                g.DrawEllipse(Pens.White, x - 1, 24, 12, 12);
                int tr = 0, tg = 0, tb = 0;
                for (int ii = 0; ii < 30; ii++)
                {
                    if (mLEDs[ii].x == i)
                    {
                        tr = (mLEDs[ii].color.R + tr > 255 ? 255 : mLEDs[ii].color.R + tr);
                        tg = (mLEDs[ii].color.G + tg > 255 ? 255 : mLEDs[ii].color.G + tg);
                        tb = (mLEDs[ii].color.B + tb > 255 ? 255 : mLEDs[ii].color.B + tb);
                    }
                }
                g.FillEllipse(new SolidBrush(Color.FromArgb(tr, tg, tb)), x, 55, 10, 10);
                g.DrawEllipse(Pens.White, x - 1, 54, 12, 12);
            }
        }

        private void control(object sender, EventArgs e)
        {
            if (pointer!=-1)
	        {
                HScrollBar current=((HScrollBar)sender);
                LEDs[pointer].color = Color.FromArgb(current.AccessibleName == "red" ?current.Value : LEDs[pointer].color.R, current.AccessibleName == "green" ?current.Value : LEDs[pointer].color.G, current.AccessibleName == "blue" ? current.Value : LEDs[pointer].color.B);
                mLEDs[pointer].color = LEDs[pointer].color;
                changed = true;
            }
        }
        class LED
        {
            public Color color;
            public int movement,maxLED,minLED,timeIn,timeOut;
            public double mspeed;
            public bool bounce,changingLight,fadeIn,fadeOut,InOut;
            public LED(Color ledC)
            {
                color = ledC;
                minLED = 0;
                maxLED = 29;
                movement = 0;
                timeIn = timeOut = 500;
                mspeed = 10.0;
                bounce = changingLight = fadeIn = fadeOut = false;
                InOut = true;
            }
            public bool Similar(LED test)
            {
                bool t=true;
                t &= (this.bounce == test.bounce);
                t &= (this.changingLight == test.changingLight);
                t &= (this.fadeOut == test.fadeOut);
                t &= (this.fadeIn == test.fadeIn);
                t &= (this.InOut == test.InOut);
                t &= (this.movement == test.movement);
                t &= (this.mspeed == test.mspeed);
                t &= (this.timeIn == test.timeIn);
                t &= (this.timeOut == test.timeOut);
                t &= (this.maxLED == test.maxLED);
                t &= (this.minLED == test.minLED);
                t &= (Math.Abs(this.color.R - test.color.R) + Math.Abs(this.color.G - test.color.G) + Math.Abs(this.color.B - test.color.B) < 10);
                return t;
            }
        }
        class MLED
        {
            public Color color;
            public int x,mtime;
            public bool reverse;
            public MLED(Color c, int X)
            {
                color = c;
                x = X;
                mtime = 0;
                reverse = false;
            }
        }

        private void changedRadio(object sender, EventArgs e)
        {
            RadioButton a = (RadioButton)sender;
            if (a.Checked == true)
            {
                switch (a.AccessibleName)
                {
                    case "0":
                        LEDs[pointer].movement = 0;
                        break;
                    case "1":
                        LEDs[pointer].movement = 1;
                        LEDs[pointer].minLED = pointer+1;
                        LEDs[pointer].maxLED = 30;
                        break;
                    case "2":
                        LEDs[pointer].movement = 2;
                        LEDs[pointer].minLED = 1;
                        LEDs[pointer].maxLED = pointer+1;
                        break;
                    case "3":
                        LEDs[pointer].changingLight = false;
                        break;
                    case "4":
                        LEDs[pointer].changingLight = true;
                        break;
                    case "5":
                        LEDs[pointer].fadeOut = false;
                        if (InOut.Checked) LEDs[pointer].fadeIn = false;
                        break;
                    case "6":
                        LEDs[pointer].fadeOut = true;
                        if (InOut.Checked) LEDs[pointer].fadeIn = true;
                        break;
                    case "7":
                        LEDs[pointer].fadeIn = false;
                        break;
                    case "8":
                        LEDs[pointer].fadeIn = true;
                        break;
                }

            }
            changed = true;
        }

        private void checkChange(object sender, EventArgs e)
        {
            CheckBox a = (CheckBox)sender;
            if (a.AccessibleName == "1")
            {
                LEDs[pointer].bounce = a.Checked;
                if (LEDs[pointer].movement==1) LEDs[pointer].minLED = pointer + 1;
                else LEDs[pointer].maxLED = pointer + 1;
            }
            else LEDs[pointer].InOut = a.Checked;
            changed = true;
        }

        private class difloc
        {
            public int difference;
            public List<int> location;
            public difloc(int i,int l)
            {
                difference = i;
                location = new List<int>();
                location.Add(l);
            }
        }
        public class rFinder
        {
            public int n;
            public List<int> location;
            public rFinder()
            {
                n = 0;
                location = new List<int>();
            }
            public rFinder(int nn)
            {
                n = nn;
                location = new List<int>();
                location.Add(nn);
            }
            public string pattern()
            {
                if (this.location.Count==1)
                {
                    return toBase64(this.n);
                }
                string s = "";
                int a = 0;
                List<difloc>[] diff=new List<difloc>[this.location.Count - 1];
                for (int i = 0; i < this.location.Count - 1; i++)
                {
                    diff[i]=new List<difloc>();
                    for (int ii = i+1; ii < this.location.Count; ii++)
                    {
                        int dife=this.location[ii]-this.location[i];
                        diff[i].Add(new difloc(dife, this.location[i]));
                        diff[i][0].location.Add(this.location[ii]);
                        for (int iii = ii+1; iii < this.location.Count; iii++)
                        {
                            if (this.location[iii] - this.location[ii] == dife * (iii - ii))
                            {
                                diff[i][iii - ii].location.Add(this.location[iii]);
                            }
                            else break;
                        }
                    }
                }
                List<difloc> dif = new List<difloc>();
                for (int ii = 0; ii < this.location.Count - 1; ii++)
                {
                    a = this.location[ii + 1] - this.location[ii];
                    if (dif.Exists(x => x.difference == a)) dif[dif.FindIndex(x => x.difference == a)].location.Add(this.location[ii]);
                    else dif.Add(new difloc(a,this.location[ii]));
                    if (ii==this.location.Count - 2) dif[dif.FindIndex(x => x.difference == a)].location.Add(this.location[ii + 1]);
                }
                for (int ii = 0; ii < dif.Count; ii++)
                {
                    int count = dif[ii].location.Count;
                    Debug.Write(dif[ii].difference + ":");
                    for (int i = 0; i < count; i++)
                    {
                        Debug.Write(dif[ii].location[i] + " ");
                    }
                    Debug.WriteLine("");
                    if (ii > 0) s += ",";
                    if (dif[ii].difference == 1 && count > 2)
                    {
                        s+=toBase64(dif[ii].location[0])+"-"+toBase64(dif[ii].location[count-1]);
                    }
                    else if (dif[ii].difference > 1 && count > 3)
                    {
                        s += toBase64(dif[ii].location[0]) + "|" + toBase64(dif[ii].difference)+ "|" + toBase64(dif[ii].location[count - 1]);
                    }
                    else for (int iii = 0; iii < count; iii++) s += (iii>0?",":"") + toBase64(dif[ii].location[iii]);
                }
                return s;
            }
        }
        private void Send_Click(object sender, EventArgs e)
        {
            String s ="";
            List<rFinder> find = new List<rFinder>();
            find.Add(new rFinder(0));
            for (int i = 1; i < 30; i++)
            {
                bool ab = true;
                for (int ii = 0; ii < find.Count; ii++)
                {
                    if (LEDs[find[ii].n].Similar(LEDs[i]))
                    {
                        find[ii].location.Add(i);
                        ab = false;
                    }
                }
                if (ab)
                {
                    find.Add(new rFinder(i));
                }
                
            }
            for (int c = 0; c < find.Count; c++)
            {
                int i = find[c].n;
                s = "L" + find[c].pattern() + " ";
                s += toBase64(((int)LEDs[i].color.R << 16) + ((int)LEDs[i].color.G<<8) + (int)LEDs[i].color.B)+" ";
                s += ((LEDs[i].movement << 4) + ((LEDs[i].changingLight ? 1 : 0) << 3) + ((LEDs[i].changingLight ? 1 : 0) << 2) + ((LEDs[i].fadeOut ? 1 : 0) << 1) + ((LEDs[i].fadeOut && LEDs[i].InOut) || (LEDs[i].fadeIn && !LEDs[i].InOut) ? 1 : 0));
                if (LEDs[i].movement!=0)
                {
                    s += " "+toBase64(LEDs[i].movement == 2 && !LEDs[i].bounce ? i : LEDs[i].maxLED - 1) + " ";
                    s += toBase64(LEDs[i].movement == 1 && !LEDs[i].bounce ? i : LEDs[i].minLED - 1) + " ";
                    s += toBase64((int)(LEDs[i].mspeed*1000)) + " ";
                    s += (LEDs[i].bounce ? 1 : 0);
                }
                if (LEDs[i].changingLight) s += " " + toBase64(LEDs[i].timeOut) + " " + toBase64(LEDs[i].InOut ? LEDs[i].timeOut : LEDs[i].timeIn);
                s += "!";
                if (go) serialPort1.Write(s + "\r\n");
                else Debug.WriteLine(s);
            }
        }
        public static string toBase64(int n)
        {
            return n.ToString();
            string s = "";
            if (n == 0)
            {
                return "0";
            }
            else if (n < 0)
            {
                s += "-";
                n = Math.Abs(n);
            }
            int a = (int)Math.Floor(Math.Log(n, 64));
            for (int i = a; i >= 0; i--)
            {
                s += (char)((int)'0' + (int)Math.Floor(n / Math.Pow(64, i)));
                n %= (int)Math.Pow(64, i);
            }
            return s;
        }
        public static class readf
        {
            public static List<string> re = new List<string>();
        }
        public void reading()
        {
            if (serialPort1.BytesToRead>0)
            {
                //readf.re.Add(serialPort1.ReadLine());
            }
        }
        private void TChanged(object sender, EventArgs e)
        {
            TextBox a = (TextBox)sender;
            try
            {
                switch (a.AccessibleName)
                {
                    case "0":
                        LEDs[pointer].maxLED = int.Parse(a.Text);
                        break;
                    case "1":
                        LEDs[pointer].minLED = int.Parse(a.Text);
                        break;
                    case "2":
                        LEDs[pointer].timeOut = int.Parse(a.Text);
                        if (InOut.Checked) LEDs[pointer].timeIn = LEDs[pointer].timeOut;
                        break;
                    case "3":
                        LEDs[pointer].timeIn = int.Parse(a.Text);
                        break;
                    case "4":
                        LEDs[pointer].mspeed = double.Parse(a.Text);
                        break;
                }
                atx[int.Parse(a.AccessibleName)] = a.Text;
            }
            catch (Exception)
            {
                a.Text = atx[int.Parse(a.AccessibleName)];
            }
            changed = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Form2 form2 = new Form2();
            form2.ShowDialog();
            if (form2.ss == "GO")
            {
                if (form2.s == "COM")
                {
                    Send.Text = "Debug";
                }
                else
                {
                    serialPort1.PortName = form2.s;
                    serialPort1.Open();
                    go = true;
                }
                timer1.Enabled = true;
            }
            else
            {
                Close();
            }
        }

        private void readserial()
        {
            Debug.WriteLine("->"+serialPort1.ReadLine().Trim());
        }
    }
}
