using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace keygeneratorFINAL
{
    public partial class Form1 : Form
    {
        public int[] intCode = new int[127];

        public char[] charCode = new char[25];

        public int[] intNumber = new int[25];

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  KEY NUMBER
            string GetDiskVolumeSerialNumber()
            {
                new ManagementClass("win32_NetworkAdapterConfiguration");
                ManagementObject managementObject = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
                managementObject.Get();
                return managementObject.GetPropertyValue("VolumeSerialNumber").ToString();
            }

            string GetCpu()
            {
                string result = null;
                foreach (ManagementBaseObject managementBaseObject in new ManagementClass("win32_Processor").GetInstances())
                {
                    result = ((ManagementObject)managementBaseObject).Properties["Processorid"].Value.ToString();
                }
                return result;
            }

            string GetMNum()
            {
                return (GetCpu() + GetDiskVolumeSerialNumber()).Substring(0, 24);
            }

            string GetRNum()
            {
                void SetIntCode()
                {
                    for (int i = 1; i < intCode.Length; i++)
                    {
                        intCode[i] = i % 9;
                    }
                }

                SetIntCode();
                string mnum = GetMNum();
                for (int i = 1; i < charCode.Length; i++)
                {
                    charCode[i] = Convert.ToChar(mnum.Substring(i - 1, 1));
                }
                for (int j = 1; j < intNumber.Length; j++)
                {
                    intNumber[j] = Convert.ToInt32(charCode[j]) + intCode[Convert.ToInt32(charCode[j])];
                }
                string text = "";
                for (int k = 1; k < intNumber.Length; k++)
                {
                    if ((intNumber[k] >= 48 && intNumber[k] <= 57) || (intNumber[k] >= 65 && intNumber[k] <= 90) || (intNumber[k] >= 97 && intNumber[k] <= 122))
                    {
                        text += Convert.ToChar(intNumber[k]).ToString();
                    }
                    else if (intNumber[k] > 122)
                    {
                        text += Convert.ToChar(intNumber[k] - 10).ToString();
                    }
                    else
                    {
                        text += Convert.ToChar(intNumber[k] - 9).ToString();
                    }
                }
                return text;
            }
            textBox1.Text = GetRNum();
            // SPY NUMBER BELOW
            string GetSpyNum()
            {
                for (int i = 1; i < intCode.Length; i++)
                {
                    intCode[i] = i % 19;
                }
                string mnum = GetMNum();
                for (int j = 1; j < charCode.Length; j++)
                {
                    charCode[j] = Convert.ToChar(mnum.Substring(j - 1, 1));
                }
                for (int k = 1; k < intNumber.Length; k++)
                {
                    intNumber[k] = Convert.ToInt32(charCode[k]) + intCode[Convert.ToInt32(charCode[k])];
                }
                string text = "";
                for (int l = 1; l < intNumber.Length; l++)
                {
                    if ((intNumber[l] >= 48 && intNumber[l] <= 57) || (intNumber[l] >= 65 && intNumber[l] <= 90) || (intNumber[l] >= 97 && intNumber[l] <= 122))
                    {
                        text += Convert.ToChar(intNumber[l]).ToString();
                    }
                    else if (intNumber[l] > 122)
                    {
                        text += Convert.ToChar(intNumber[l] - 10).ToString();
                    }
                    else
                    {
                        text += Convert.ToChar(intNumber[l] - 9).ToString();
                    }
                }
                return text;
            }
            textBox2.Text = GetSpyNum();

        }
    }
}
