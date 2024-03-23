using System;
using System.Drawing;
using System.Windows.Forms;

namespace MalovaniJagupov
{
    public partial class Form1 : Form
    {
        private bool isDrawing = false;
        private Point lastPoint;
        private Pen currentPen = new Pen(Color.Black, 2);
        private string currentTool = "Pen";
        private bool drawShapeMode = false;
        

        //eventy
        public Form1()
        {
            InitializeComponent();
            this.MouseClick += new MouseEventHandler(this.Form1_MouseClick);
            this.Paint += Form1_Paint;
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            this.MouseUp += Form1_MouseUp;
            this.Load += Form1_Load;
            checkBox1.CheckedChanged += new EventHandler(checkBox1_CheckedChanged);
          
        }

        //malba
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            using (Pen pen = new Pen(Color.Black, 2))
            {
                e.Graphics.DrawLine(pen, lastPoint, lastPoint);
            }
        }
        //ukladani toho "vymalovaneho bodu" na platne
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            lastPoint = e.Location;
        }

        //currentTool - druh stetce
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                using (Graphics g = this.CreateGraphics())
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                    //Marker fixa pen pencil - druhy stetce
                    switch (currentTool)
                    {
                        case "Pen":
                            currentPen = new Pen(panel1.BackColor, (float)numericUpDown1.Value);
                            break;
                        case "Brush":
                            currentPen = new Pen(panel1.BackColor, Math.Max((float)numericUpDown1.Value * 2, 1));
                            currentPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                            currentPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                            break;
                        case "Marker":
                            
                            Color markerColor = Color.FromArgb(128, panel1.BackColor); 
                            currentPen = new Pen(markerColor, Math.Max((float)numericUpDown1.Value * 1.5f, 1));
                            currentPen.StartCap = System.Drawing.Drawing2D.LineCap.Square;
                            currentPen.EndCap = System.Drawing.Drawing2D.LineCap.Square;
                            break;
                        case "Pencil":
                            currentPen = new Pen(panel1.BackColor, Math.Max((float)numericUpDown1.Value / 2, 1));
                            currentPen.DashPattern = new float[] { 5, 2 }; 
                            currentPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                            currentPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                            break;
                        case "Eraser":
                            //guma je bily pencil se stejnou tloustkou stetce
                            currentPen = new Pen(Color.White, (float)numericUpDown1.Value);
                            currentPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                            currentPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                            break;
                    }


                    g.DrawLine(currentPen, lastPoint, e.Location);
                }
                lastPoint = e.Location;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //musel jsem to rozkliknout protoze jinak designer.cs na me rve
            
 
            shapeComboBox.SelectedIndex = 0;

        }
        //CHATOPEN AI - panel na otevreni skoro vsech barev
        private void colorPanel_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                panel1.BackColor = colorDialog.Color;
            }
        }
        //vyber toolu neboli vyber kresleni objektu
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                currentTool = comboBox1.SelectedItem.ToString();
                drawShapeMode = (currentTool == "Rectangle" || currentTool == "Oval" || currentTool == "Triangle");

            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //musel jsem to rozkliknout protoze jinak designer.cs na me rve

        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            //smaz vsechno
            using (Graphics g = this.CreateGraphics())
            {
               
                g.Clear(this.BackColor);
            }
        }

        private void guma_Click(object sender, EventArgs e)
        {
            currentTool = "Eraser";
        }
        //uzivatel ma na vyber 3 shapy - obdelnik, oval, trojuhelnik - automaticky se vybarvi do barvy pera
        //maly bug!!! - nesmis hejbnout mysi v moment kresleni objektu, musis stat na miste, jinak se nakresli nejaka carka vybranym perem
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (drawShapeMode)
            {
                //kresli s tim co zadal user
                int width, height;
                if (int.TryParse(textBox1.Text, out width) && int.TryParse(textBox2.Text, out height))
                {
                    using (Graphics g = this.CreateGraphics())
                    {
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                        using (Brush brush = new SolidBrush(panel1.BackColor))
                        {
                            switch (shapeComboBox.SelectedItem.ToString())
                            {
                                //obdelnik
                                case "Rectangle":
                                    g.FillRectangle(brush, e.X, e.Y, width, height);
                                    break;
                                //oval
                                case "Oval":
                                    g.FillEllipse(brush, e.X, e.Y, width, height);
                                    break;
                                case "Triangle":
                                    //trojuhelnik
                                    Point[] points = {
                                new Point(e.X, e.Y),
                                new Point(e.X - width / 2, e.Y + height),
                                new Point(e.X + width / 2, e.Y + height)
                            };
                                    g.FillPolygon(brush, points);
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    //kontrola vstupu useru
                    MessageBox.Show("Invalid input. Please enter valid integer values for width and height.");
                }
            }
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            drawShapeMode = checkBox1.Checked;

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
