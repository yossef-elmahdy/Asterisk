using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;
using System.IO;
using System.Data.SqlClient;

namespace WindowsFormsApp3
{
    
    class MyTab : TabPage , IColorable
    {
        
        
        static int index;
        private string name,fullPath;

        private string _format;
        private string format
        {
            get
            {
                return _format;
            }
            set
            {
                _format = value;
                keywordslist = keywords(value);
                updateColor(Color.Brown);
                //format code
            }
        }


        SplitContainer splitContainer1 = new SplitContainer();
        RichTextBox NumbersBox = new RichTextBox();
        public RichTextBox Code = new RichTextBox();
        
        private void InitializeMyTab(string name ,string format)
        {

            // 
            // tabPage1
            // 
            this.Controls.Add(this.splitContainer1);
            this.Location = new System.Drawing.Point(4, 22);
            this.Name = name;
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(792, 347);
            this.TabIndex = index++;
            this.Text = name + '.' + format;
            this.UseVisualStyleBackColor = true;
            
            


            Code.TextChanged += new System.EventHandler(this.Code_TextChanged);

            //create file 

            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.NumbersBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Code);
            this.splitContainer1.Size = new System.Drawing.Size(786, 341);
            this.splitContainer1.SplitterDistance = 42;
            this.splitContainer1.TabIndex = 0;

            // 
            // richTextBox1 //NumberBox
            // 
            this.NumbersBox.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.NumbersBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NumbersBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NumbersBox.Enabled = false;
            this.NumbersBox.ForeColor = System.Drawing.Color.DeepPink;
            this.NumbersBox.Location = new System.Drawing.Point(0, 0);
            this.NumbersBox.Name = "NumbersBox";
            this.NumbersBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.NumbersBox.Size = new System.Drawing.Size(42, 341);
            this.NumbersBox.TabIndex = 0;
            this.NumbersBox.Text = "";
            // 
            // richTextBox2   //Code box
            // 
            this.Code.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Code.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Code.Location = new System.Drawing.Point(0, 0);
            this.Code.Name = "Code";
            this.Code.Size = new System.Drawing.Size(740, 341);
            this.Code.TabIndex = 0;
            this.Code.Text = "";
            Font font = new Font("Tahoma", 12);
            this.Code.Font = font;
            this.NumbersBox.Font = font;

        }

        public MyTab(string name, string format, string fullPath)
        {
            this.name = name;
            this.format = format;
            this.fullPath = fullPath;
            InitializeMyTab(name, format);
            setColors(Form1.colors);
            keywordslist = keywords(format);
        }

        private static List<string> keywords(string a)
        {
            List<string> b = new List<string>();
            string constr = @"Data Source=.\SAD;Initial Catalog=sadnew;User ID=sa;Password=sad";
            string q1 = "select keyword from keywords where lang = 'java';";
            string q2 = "select keyword from keywords where lang = 'c/c++';";

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand command = new SqlCommand();
                if (a == "java")
                {
                    command = new SqlCommand(q1, con);
                }
                else if (a == "c" || a == "cpp")
                {
                    command = new SqlCommand(q2, con);
                }

                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string u = reader[0].ToString();
                        b.Add(u);

                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return b;
        }
        List<String> keywordslist;
        
        public void saveTab()
        {
            try
            {
                
                using (FileStream sw = File.Create(fullPath))
                {
                    byte[] arr = new UTF8Encoding(true).GetBytes(Code.Text);
                    sw.Write(arr, 0, arr.Length);
                }

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save to the file", "Error in Saving file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void saveAs(string path)
        {
            
            saveTab();
            fullPath = path;
            name = path.Substring(path.LastIndexOf('\\') + 1);
            string[] arr = name.Split('.');
            name = arr[0];
            format = arr[1];
            this.Text = name + '.' + format;
            
            saveTab();

        }
        

        public void setFont(Font newFont)
        {
            Code.Font = newFont;
            NumbersBox.Font = newFont;
        }

        public void setColors(params Color[] colors)
        {
            splitContainer1.BackColor = colors[6];
            Code.BackColor = colors[8];
            Code.ForeColor = colors[9];

            NumbersBox.BackColor = colors[10];
            NumbersBox.ForeColor = colors[11];

        }

        //by Yossef El Mahdy at 11_12_2019        
        private void Code_TextChanged(object sender, EventArgs e)
        {
            //LinNumbers
            int prev_lines = NumbersBox.Lines.Count()+1;
            int lines = Code.Lines.Count();
            //cursor editing 
            
            if(prev_lines != lines )
            {
                string numbers = "";
                for (int i = 1; i <= lines; i++)
                {
                   numbers += i + "\n";
                }
                NumbersBox.Text = numbers;
            }

            //keywords forecolor
            updateColor(Color.IndianRed);
            //spellchecking

        }
        public void updateColor(Color color)
        {
            int curserPosition = Code.SelectionStart;
            MatchCollection matches;
            foreach(string key in keywordslist)
            {
                matches = Regex.Matches(Code.Text, "\\b"+key+"\\b");

                foreach (Match match in matches)
                {
                    Code.Select(match.Index, key.Length);
                    Code.SelectionColor = color;
                }
                Code.DeselectAll();
                Code.SelectionColor = Form1.colors[9];
                Code.SelectionStart = curserPosition;

            }
        }
        

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }

        
    }
}
