using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO.Ports;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public String s = "COM",ss="";

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                ss = "GO";
                Close();
            }
            else if (comboBox1.Text[0] == 'C' && comboBox1.Text[1] == 'O')
            {
                try
                {
                    s = comboBox1.Text;
                    serialPort1.PortName = s;
                    serialPort1.Open();
                    serialPort1.WriteLine("test");
                    comboBox1.Enabled = false;
                    button1.Enabled = false;
                    timer1.Start();
                }
                catch (Exception ex)
                {
                    serialPort1.Close();
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (serialPort1.BytesToRead>0)
            {
                readserial();
            }
            comboBox1.Enabled = true;
            button1.Enabled = true;
            timer1.Stop();
            serialPort1.Close();
            if (ss=="GO")
            {
                serialPort1.Close();
                Close();
            }
        }

        private void readserial()
        {
            while (serialPort1.BytesToRead>0)
            {
            ss = serialPort1.ReadLine().Trim();
            Debug.WriteLine(ss);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(SerialPort.GetPortNames());
        }
    }
}
