using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            
            chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;
            //chart1.ChartAreas[0].AxisY.Maximum = 2;
            //chart1.ChartAreas[0].AxisY.Minimum = -1;
            //chart1.ChartAreas[0].AxisX.Maximum = 120;
            //chart1.ChartAreas[0].AxisX.Minimum = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen) { serialPort1.Close(); }
            foreach (String portNames in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(portNames);
            }

            comboBox2.Items.Add(115200);
            comboBox2.Items.Add(9600);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBox1.SelectedItem.ToString();
            serialPort1.BaudRate = (int)comboBox2.SelectedItem;

            serialPort1.Open();

            //richTextBox1.Text += serialPort1.ReadLine();
        }
        double counter = 0;
        int d0value, d1value, d2value, d3value;
        int currentValue;
        public void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
                         currentValue = serialPort1.ReadByte();
             d0value = currentValue & 0x01;
             d1value = currentValue & 2;
            
             d2value = currentValue & 4;
             d3value = currentValue & 8;

            //richTextBox1.Text += serialPort1.ReadLine();
            label1.Text = currentValue.ToString();

            chart1.Series["d0"].Points.AddXY(counter, d0value);
            chart1.Series["d1"].Points.AddXY(counter, d1value);
            chart1.Series["d2"].Points.AddXY(counter, d2value);
            chart1.Series["d3"].Points.AddXY(counter, d3value);
            counter += 1;
            //if(counter % 2 == 0)
            //{
            //    counter = 0;
            //    //foreach (var series in chart1.Series)
            //    //{
            //    //    series.Points.Clear();
            //    //}
            //    chart1.Series["d0"].Points.Clear();
            //    chart1.Series["d1"].Points.Clear();
            //    chart1.Series["d2"].Points.Clear();
            //    chart1.Series["d3"].Points.Clear();
            //}
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if ((counter < values.Length))
            //{
            //    //chart1.Series["test1"].Points.AddXY(counter, values[counter]);
            //    //counter += 0.01;
            //}

            //Random rdn = new Random();
            //for (int i = 0; i < 10; i++)
            //{
            //    chart1.Series["test1"].Points.AddXY
            //                    (i, i);
            //    //chart1.Series["test2"].Points.AddXY
            //    //                (i+1, i+1);
            //}


            //chart1.Series["test1"].Color = Color.Red;

            //chart1.Series["test2"].Color = Color.Blue;
        }
    }
}
