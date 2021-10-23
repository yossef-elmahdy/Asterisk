using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;



namespace WindowsFormsApp3
{
    public partial class Form1 : Form, IColorable
    {

      

        FontDialog fontDialog = new FontDialog();

        private Font currentFont ;
        public Font getFont
        {
            get
            {
                return new Font(currentFont,currentFont.Style);
            }
        }
        private Font font
        {
            get
            {
                return currentFont;
            }
            set
            {
                currentFont = value;
                //change code Font will be in tab
                foreach (TabPage t in tabControl1.TabPages)
                {
                    ((MyTab)t).setFont(value);
                }
            }
        }

        FormWindowState currentStateNotNormal;
        public Form1()
        {
            InitializeComponent();
            InitializeTapPage();
            //properties to be serialized
            font = new Font("Consolas", 12);
//   Console.WriteLine(font.FontFamily);


        }
        private void InitializeTapPage()
        {
            /*this.defaultTabPage = new MyTab("Default","cs",);
            this.tabControl1.Controls.Add(defaultTabPage);
            // 
            // defaultTabPage
            // 
            this.defaultTabPage.Location = new System.Drawing.Point(4, 22);
            this.defaultTabPage.Name = "defaultTabPage";
            this.defaultTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.defaultTabPage.Size = new System.Drawing.Size(792, 375);
            this.defaultTabPage.TabIndex = 2;
            this.defaultTabPage.Text = "Default";
            this.defaultTabPage.UseVisualStyleBackColor = true;

            this.tabControl1.SelectedTab = this.defaultTabPage;
            defaultTabPage.Code.Select();*/

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            tabControl1.Focus();

            setLightTheme(new object(), new EventArgs());
            Color aa = Color.Black;
            Console.WriteLine(typeof(Color));
            Console.WriteLine(aa.GetType());


            /*foreach(ToolStripMenuItem ii in selectAllToolStripMenuItem.DropDownItems)
            {
                ii.BackColor = Color.Blue;
            }
*//*            Console.WriteLine(menuStrip1.BackColor);
            Console.WriteLine( menuStrip1.Items.Count);

            ToolStripMenuItem mm = (ToolStripMenuItem)menuStrip1.Items[0];
            Console.WriteLine(mm.DropDownItems[0]);
            ((ToolStripMenuItem)mm.DropDownItems[0]).DropDownItems[0].BackColor = Color.Brown;

*/

            //menuStrip1.ContextMenuStrip.BackColor
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {


        }

        private void updateButtons()
        {

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void SaveFile(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count < 1)
            {
                return;
            }
            MyTab tab = ((MyTab)tabControl1.SelectedTab);
            tab.saveTab();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            //  new form
            Form form = new Form2();
            form.Visible = true;
        }

        private void findFormLoading(object sender, EventArgs e)
        {
            /*FindForm findForm = WindowsFormsApp3.FindForm.getFindForm(tabControl1);
            findForm.tab = (MyTab)tabControl1.SelectedTab;
            findForm.Visible = true;*/
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
           

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        MatchCollection matches;
        int lastMatch;
        RichTextBox rtb; //need to make an eventhandler for changing tabs .
        private void FindTrigger(object sender, EventArgs e)
        {

            //Console.WriteLine("==========FindTrigger==========");
            // delete all selections
            matches = null;
            lastMatch = -1;

            string str = textToFind.Text;
            bool caseMatching = matchCase.Checked;
            bool wordMatching = matchWord.Checked;
            bool regex = this.regex.Checked;
            rtb = ((MyTab)tabControl1.SelectedTab).Code;
            rtb.SelectAll();
            rtb.SelectionBackColor = Color.White;
            rtb.Select(0, 0);
            if (string.IsNullOrWhiteSpace(str) || string.IsNullOrEmpty(str))
            {
                return;
            }

            // test for null
            matches = Regex.Matches(rtb.Text, str);

            foreach (Match match in matches)
            {
                rtb.Select(match.Index, str.Length);
                rtb.SelectionBackColor = Color.Yellow;
            }
            //rtb.Focus();
            if (matches.Count > 0)
            {
                rtb.SelectionStart = matches[0].Index;
                rtb.Select(matches[0].Index, matches[0].Value.Length);
                rtb.SelectionBackColor = Color.Gray;
                rtb.SelectionLength = 0;
                lastMatch = 0;
            }


        }

        private void FindNextMatch(object sender, EventArgs e)
        {
            //test if there is any matches
            if (matches != null && matches.Count > 0 && lastMatch >= 0)//mybe i can delete lastmatch>=0 ?
            {
                highlight(lastMatch, Color.Yellow);

                lastMatch++;

                //return to start is reached last match
                if (matches.Count < lastMatch + 1)
                {
                    lastMatch = 0;
                }
                highlight(lastMatch, Color.Gray);


            }
        }
        private void FindPreviouMatch(object sender, EventArgs e)
        {
            if (matches != null && matches.Count > 0 && lastMatch >= 0)//mybe i can delete lastmatch>=0 ?
            {
                highlight(lastMatch, Color.Yellow);

                lastMatch--;

                //return to start is reached last match
                if (lastMatch < 0)
                {
                    lastMatch = matches.Count - 1;
                }
                highlight(lastMatch, Color.Gray);
            }
        }
        private void highlight(int matchIndex, Color color)
        {
            int startIndex = matches[matchIndex].Index;
            int length = matches[matchIndex].Value.Length;
            rtb.SelectionStart = startIndex;
            rtb.Select(startIndex, length);
            rtb.SelectionBackColor = color;
            rtb.SelectionLength = 0;
        }



        private void closeButton_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            //clear selection code ;
            //not working 
            rtb.HideSelection = true;
            FindPanel.Visible = false;
            FindPanelReset();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindPanel.Visible = true;
            textToFind.Focus();
            FindTrigger(new object(), new EventArgs());
        }

        private void ReplaceBox_Enter(object sender, EventArgs e)
        {
            if (ReplaceBox.Text == "Replacing Text" && ReplaceBox.ForeColor == Color.Silver)
            {
                ReplaceBox.ForeColor = Color.Black;
                ReplaceBox.Text = "";
            }
        }

        private void ReplaceBox_Leave(object sender, EventArgs e)
        {
            if (ReplaceBox.Text == "")
            {
                ReplaceBox.ForeColor = Color.Silver;
                ReplaceBox.Text = "Replacing Text";
            }
        }

        private void ReplaceBox_TextChanged(object sender, EventArgs e)
        {
            // Console.WriteLine("Text Changed  new Text : {0} , new Color : {1}",ReplaceBox.Text,ReplaceBox.ForeColor);

            if ((ReplaceBox.Text == "") || (ReplaceBox.Text == "Replacing Text" && ReplaceBox.ForeColor == Color.Silver))
            {
                ReplaceButton.Enabled = false;
            } else {
                ReplaceButton.Enabled = true;

            }
        }

        private void ReplaceButton_Click(object sender, EventArgs e)
        {
            FindTrigger(new object(), new EventArgs());
            string NewText = ReplaceBox.Text;
            string OldText = textToFind.Text;
            StringBuilder sb = new StringBuilder(rtb.Text);
            rtb.Text = sb.Replace(OldText, NewText).ToString();

            FindPanelReset();
            textToFind.Focus();
        }
        private void FindPanelReset()
        {
            textToFind.Text = "";
            ReplaceBox.Text = "";
            ReplaceBox_Leave(new object(), new EventArgs());
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog.Font = font;
            fontDialog.ShowDialog(this);
            font = fontDialog.Font;
        }

        public static Color[] colors = new Color[15];


        private void setDarkTheme(object sender, EventArgs e)
        {
            /**
        * Colors array contains some types of colors
        * index : 0    Color : backGround of Form
        * index : 1    Color : foreColor of Form
        * 
        * index : 2    Color : backColor of menuStrip ,StatusStrip and toolStrip
        * index : 3    Color : foreColor of menuStrip ,StatusStrip and ToolStrip
        * 
        * index : 4    Color : backColor of menuStripItems
        * index : 5    Color : foreColor of menuStripItems
        * 
        * index : 6    Color : backColor of tabPage
        * index : 7    Color : foreColor of tabPage
        * 
        * index : 8    Color : backColor of Code
        * index : 9    Color : foreColor of Code
        * 
        * index : 10   Color : backColor of LineNumbers
        * index : 11   Color : foreColor of LineNumbers
        * 
        * index : 12   Color : backColor of FindPanel
        * index : 13   Color : foreColor of FindPanel
        * 
        * 
        * 
        * ?????? Highlighting and Select color 
        * 
        * **/

            

            //this.BackColor = System.Drawing.Color.FromArgb(204,2013,240);
            //form
            colors[0] = Color.FromArgb(45,45,48);
            colors[1] = Color.FromArgb(255,255,255);
            //Strips : menu strip , toolStrip ,statusStrip
            colors[2] = colors[0];
            colors[3] = colors[1];
            ////menuStripItems
            colors[4] = Color.FromArgb(27, 27,28);
            colors[5] = colors[1];
            //TapPage --> its splitpanel
            colors[6] = Color.FromArgb(37, 37, 38);
            colors[7] = colors[1];
            //Code
            colors[8] = Color.FromArgb(30,30,30);
            colors[9] = Color.White;
            //LineNumbers
            colors[10] = Color.FromArgb(30,30,30);
            colors[11] = Color.FromArgb(43, 145, 175);
            //FindPanel
            colors[12] = Color.FromArgb(45,45,48);
            colors[13] = Color.FromArgb(200,200,200);
            setColors(colors);
        }
        private void setLightTheme(object sender, EventArgs e)
        {
            /**
        * Colors array contains some types of colors
        * index : 0    Color : backGround of Form
        * index : 1    Color : foreColor of Form
        * 
        * index : 2    Color : backColor of menuStrip ,StatusStrip and toolStrip
        * index : 3    Color : foreColor of menuStrip ,StatusStrip and ToolStrip
        * 
        * index : 4    Color : backColor of menuStripItems
        * index : 5    Color : foreColor of menuStripItems
        * 
        * index : 6    Color : backColor of tabPage
        * index : 7    Color : foreColor of tabPage
        * 
        * index : 8    Color : backColor of Code
        * index : 9    Color : foreColor of Code
        * 
        * index : 10   Color : backColor of LineNumbers
        * index : 11   Color : foreColor of LineNumbers
        * 
        * index : 12   Color : backColor of FindPanel
        * index : 13   Color : foreColor of FindPanel
        * 
        * **/

            //this.BackColor = System.Drawing.Color.FromArgb(204,2013,240);
            //form
            colors[0] = Color.FromArgb(204,213,240);
            colors[1] = Color.FromArgb(0,0,0);
            //Strips : menu strip , toolStrip ,statusStrip
            colors[2] = colors[0];
            colors[3] = colors[1];
            ////menuStripItems
            colors[4] = Color.FromArgb(233,238,255);
            colors[5] = colors[1];
            //TapPage --> its splitpanel
            colors[6] = Color.FromArgb(93,107,153);
            colors[7] = colors[1];
            //Code
            colors[8] = Color.White;
            colors[9] = Color.Black;
            //LineNumbers
            colors[10] = Color.FromArgb(230, 231, 239); 
            colors[11] = Color.FromArgb(43, 145, 175);
            //FindPanel
            colors[12] = Color.FromArgb(204, 213, 240);
            colors[13] = Color.FromArgb(0,0,0);
            setColors(colors);
        }
        
        private void setToolStripItemsColors(ToolStripMenuItem item, params Color[] colors)
        {
            
            foreach (ToolStripItem i in item.DropDownItems)
            {
                
                if (typeof(ToolStripSeparator) == i.GetType())
                {
                  /*  ((ToolStripSeparator)i).BackColor = Color.Gold;
                    ((ToolStripSeparator)i) = Color.Firebrick;*/

                    continue;

                }
                ToolStripMenuItem ii = (ToolStripMenuItem)i;
                ii.BackColor = colors[4];
                ii.ForeColor = colors[5];

                setToolStripItemsColors(ii, colors);
            }

        }
        public void setColors(params Color[] colors)
        {
            //form 0,1
            this.BackColor = colors[0];
            this.ForeColor = colors[1];   //changes labels in
            this.ExitButton.BackColor = colors[0];
            this.MaximizeButton.BackColor = colors[0];
            this.Minimize.BackColor = colors[0];
            this.ExitButton.ForeColor = colors[1];
            this.MaximizeButton.ForeColor = colors[1];
            this.Minimize.ForeColor = colors[1];
            //Strips 2, 3
            ///MenuStrip
            this.menuStrip1.BackColor = colors[2];
            this.menuStrip1.ForeColor = colors[3];
            ///ToolStrip
            this.toolStrip1.BackColor = colors[2];
            this.toolStrip1.ForeColor = colors[3];
            ///StatusStript
            this.statusStrip1.BackColor = colors[2];
            this.statusStrip1.ForeColor = colors[3];
            //menuStripItems
            foreach (ToolStripItem i in menuStrip1.Items)
            {
                ToolStripMenuItem ii = (ToolStripMenuItem)i;
                setToolStripItemsColors(ii, colors);
            }
           
            //tapPages --> splitpanel
            foreach (TabPage t in tabControl1.TabPages)
            {
                MyTab tt = (MyTab)t;
                //tt.setColors(color, color1, color2);
                tt.setColors(colors);
                tt.updateColor(colors[14]);
            }

            //Findpanel
            FindPanel.BackColor = colors[12];
            FindPanel.ForeColor = colors[13];
            



            Color color = colors[0];// Color.DarkGray;
            Color color2 = colors[1]; //Color.DarkGreen;
            Color color3 = colors[2]; //Color.DarkOliveGreen;

            this.BackColor = color;
            this.menuStrip1.BackColor = color;
            this.toolStrip1.BackColor = color;
            this.statusStrip1.BackColor = color;

            this.Update();
        }

        

      

        private void createFile(object sender, EventArgs e)
        {
            createFileDialog.Filter = "Text (*.txt)|*.txt|" + "C++ (*.cpp)|*.cpp|" + "Java (*.java)|*.java|"
                + "C# (*.cs)|*.cs|" + "All File (*.*)|*.*";

            createFileDialog.Title = "Creating A New File";
            createFileDialog.FilterIndex = 5;

            if(createFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string name = "";
                    string format = "";
                    string path = createFileDialog.FileName;

                    int last_slash = path.LastIndexOf("\\");
                    bool after_dot = false;
                    for (int i = last_slash+1; i < path.Length; i++)
                    {
                        if (path[i] == '.')
                        {
                            after_dot = true;
                            continue;
                        }
                        if (after_dot) format += path[i];
                        else name += path[i];
                    }
                    
                    File.Create(path).Close();

                    MyTab tab = new MyTab(name, format, path);
                    tabControl1.Controls.Add(tab);
                    tabControl1.SelectedTab = tab;
                    tab.Code.Select();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to create new file", "Error in creating new file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            

        }

        private void tabControl1_ControlAdded(object sender, ControlEventArgs e)
        {
            tabControl1.SelectTab(tabControl1.Controls.IndexOf(e.Control));
            ((MyTab)e.Control).Code.Select();
        }

        private void openFile(object sender, EventArgs e)
        {
            //openfile Dialog
            string path;
            string name = "";
            string format = "";

            openFileDialog.Filter = "Text (*.txt)|*.txt|" + "C++ (*.cpp)|*.cpp|" + "Java (*.java)|*.java|"
                + "C# (*.cs)|*.cs|" + "All File (*.*)|*.*";

            openFileDialog.Title = "Opening A File";
            openFileDialog.FilterIndex = 5;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog.FileName;
                try
                {
                    using (StreamReader sr = File.OpenText(path))
                    {
                       
                        int last_slash = path.LastIndexOf("\\");
                        bool after_dot = false;
                        for (int i = last_slash + 1; i < path.Length; i++)
                        {
                            if (path[i] == '.')
                            {
                                after_dot = true;
                                continue;
                            }
                            if (after_dot) format += path[i];
                            else name += path[i];
                        }

                        MyTab tab = new MyTab(name, format, path);
                        tabControl1.Controls.Add(tab);
                        tabControl1.SelectedTab = tab;
                        tab.Code.Text = sr.ReadToEnd();
                        tab.updateColor(Color.Yellow);
                        tab.Code.SelectionStart = tab.Code.Text.Length;
                        sr.Close();


                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to open this file", "Error in opening file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void saveAs(object sender, EventArgs e)
        {
            saveAsDialog.Filter = "Text (*.txt)|*.txt|" + "C++ (*.cpp)|*.cpp|" + "Java (*.java)|*.java|"
                + "C# (*.cs)|*.cs|" + "All File (*.*)|*.*";

            saveAsDialog.Title = "Save As...";
            saveAsDialog.FilterIndex = 5;
            if (saveAsDialog.ShowDialog() == DialogResult.OK)
            {
                MyTab tab = (MyTab)tabControl1.SelectedTab;
                tab.saveAs(saveAsDialog.FileName);
            }
        }

        bool mousedDown = false;
        Point currentLocation;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mousedDown = true;
                currentLocation = e.Location;
            }
            
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousedDown)
            {
                this.Location = new Point(this.Location.X +(e.X - currentLocation.X)
                            , this.Location.Y + (e.Y - currentLocation.Y));
                this.Update();
            }
            
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mousedDown = false;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void MaximizeButton_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                
            }  else if(WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }
        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            currentStateNotNormal = WindowState;
            WindowState = FormWindowState.Minimized;
        }

        private void CutFroRTB(object sender, EventArgs e)
        {
            MyTab tab = (MyTab)tabControl1.SelectedTab;
            RichTextBox code = tab.Code;
            code.Cut();
            int startIndex = code.GetFirstCharIndexOfCurrentLine();
            int endIndex = startIndex + code.Lines[code.GetLineFromCharIndex(code.SelectionStart)].Length;


            tab.updateColor(startIndex, endIndex, Color.Gold);

            Console.WriteLine("============================= ====== ");
            Console.WriteLine("StartIndex = " + startIndex);
            Console.WriteLine("EndIndex = " + endIndex);

        }
        private void CopyFroRTB(object sender, EventArgs e)
        {
            MyTab tab = (MyTab)tabControl1.SelectedTab;
            RichTextBox code = tab.Code;
            code.Copy();
        }
        private void PastToRTB(object sender, EventArgs e)
        {
            MyTab tab = (MyTab)tabControl1.SelectedTab;
            RichTextBox code = tab.Code;
            int StartIndex = code.GetFirstCharIndexOfCurrentLine ();
            code.Paste();
            //keep it so the curser will retrun back to it
            int lastIndex = code.SelectionStart;
            int EndIndex;

            int currentLine = code.GetLineFromCharIndex(lastIndex);
            int count  = code.Lines.Length ;
            if (count  == currentLine+1)
            {
                EndIndex = code.Text.Length ;
            }
            else
            {
                EndIndex = code.GetFirstCharIndexFromLine(currentLine+1);
            }

            tab.updateColor(StartIndex,EndIndex , Color.Gold);

            code.SelectionStart = lastIndex; 
            Console.WriteLine("===============");
            Console.WriteLine("StartIndex  = "+StartIndex);
            Console.WriteLine("EndIndex    = " + EndIndex);
            Console.WriteLine("currentLine = " + currentLine);
            Console.WriteLine("Count       = "+count);
            Console.WriteLine("LastIndex   = " + lastIndex);
            Console.WriteLine("Length      ="+code.Text.Length);
            Console.WriteLine("currentCurser = "+ code.SelectionStart);
            Console.WriteLine("===============");


            /**if lastLine {
            * 
            * endIndex = end of text
            * } 
            *else endIndex = startOfNextLine */
        }

        private void RedoButton_Click(object sender, EventArgs e)
        {
            MyTab tab = (MyTab)tabControl1.SelectedTab;
            RichTextBox code = tab.Code;
            code.Redo();
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            MyTab tab = (MyTab)tabControl1.SelectedTab;
            RichTextBox code = tab.Code;
            code.Undo();
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyTab tab = (MyTab)tabControl1.SelectedTab;
            RichTextBox code = tab.Code;
            code.SelectAll();
        }

        private void SaveAll(object sender, EventArgs e)
        {
            foreach(TabPage tt in tabControl1.TabPages)
            {
                MyTab tab = (MyTab)tt ;
                tab.saveTab();
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }

    public interface IColorable
    {
        void setColors(params Color[] colors);
        /**
         * Colors array contains some types of colors
         * index : 0    Color : backGround of Program
         * index : 1    Color : backGround of program bars( like toolbar and status bar)
         * index : 2    Color : Fore color1 in Program labels , menues , bars
         * index : 3    Color : Fore color2 in Program labels , menues , bars
         * index : 4    Color : BackGround Color for Code
         * index : 5    Color : Fore Color for Code
         * index : 6    Color : BackGround Color for NumbersBox
         * index : 7    Color : Fore Color for Numbers
         * 
         * **/


    }
}


//serializatoin of Application variable like last theme , Fonts , projects