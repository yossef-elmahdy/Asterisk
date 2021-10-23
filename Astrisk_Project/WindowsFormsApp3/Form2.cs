using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
         //   tabControl1.TabIndex = 8;
            Console.WriteLine(tabControl1.SelectedTab.Name);
            tabControl1.SelectedTab = tabPage1 ;
            //splitContainer1.Panel2.Select();
            //tabPage2.Select();
            //richTextBox3.TabIndex = 7; 
            
        }
    }
}
