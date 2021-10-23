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
    public partial class Form3 : Form
    {
        Font font;
        public Form3(ref Font font , Font currentFont)
        {
            InitializeComponent();
            FontFamily[] families = FontFamily.Families;
            //FontStyle[] styles = FontStyle.
            foreach(FontFamily fontf in families)
            {
                fontsList.Items.Add(fontf.Name);
                
            }



            this.font = font;
            // need code to initialize components with CurrentFont


        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
