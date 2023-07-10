using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGV_model
{
    public partial class EP : Form
    {
        public EP()
        {
            InitializeComponent();
            panel1.AutoScroll = true; // Set AutoScroll property to true for the panel

            // Subscribe to the form's Load event
            this.Load += EP_Load;
            
        }
        
        private void EnterBtn_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            // Parse the user input
            if (int.TryParse(textBox1.Text, out int numberOfBoxes))
            {
                // Validate the input range
                if (numberOfBoxes >= 1 && numberOfBoxes <= 100)
                {
                    // Calculate the number of rows and columns
                    int rows = (numberOfBoxes + 2) / 3;
                    int columns = Math.Min(numberOfBoxes, 5);

                    // Calculate the size of each GroupBox
                    int groupBoxWidth = panel1.Width / columns - 8; // Adjust for margins
                    int groupBoxHeight = 140;

                    // Create the main TableLayoutPanel
                    TableLayoutPanel mainTableLayoutPanel = new TableLayoutPanel();
                    mainTableLayoutPanel.Dock = DockStyle.Fill;
                    mainTableLayoutPanel.RowCount = rows;
                    mainTableLayoutPanel.ColumnCount = columns;
                    panel1.Controls.Add(mainTableLayoutPanel);

                    // Create and add GroupBoxes to the main TableLayoutPanel
                    for (int row = 0; row < rows; row++)
                    {
                        for (int col = 0; col < columns; col++)
                        {
                            int index = row * 5 + col + 1;

                            if (index > numberOfBoxes)
                                break;

                            GroupBox groupBox = new GroupBox();
                            groupBox.Text = "AGV- " + index.ToString();
                            //groupBox.Size = new Size(260, 140);
                            groupBox.Size = new Size(groupBoxWidth, groupBoxHeight);
                            groupBox.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Italic);
                            groupBox.ForeColor = Color.White;
                            groupBox.BackColor = Color.FromArgb(150, 0, 0, 0); // Darker color, adjust the values as desired
                            this.BackColor = Color.FromArgb(255, 0, 0, 0); // Set the same color as the form's transparency key

                            // Calculate the position of the GroupBox
                            int groupBoxX = col * (groupBoxWidth + 10); // Adjust for margins
                            int groupBoxY = row * (groupBoxHeight + 10); // Adjust for margins
                            groupBox.Location = new Point(groupBoxX, groupBoxY);

                            // Create labels and TextBoxes inside the GroupBox
                            Label startingPosXLabel = new Label();
                            startingPosXLabel.Text = "Starting position X:";
                            startingPosXLabel.Location = new Point(10, 20);
                            startingPosXLabel.Size = new Size(180, 20);
                            startingPosXLabel.BackColor = Color.Transparent;
                            startingPosXLabel.ForeColor = Color.White;
                            startingPosXLabel.Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Italic);
                            groupBox.Controls.Add(startingPosXLabel);

                            TextBox startingPosTextBoxX = new TextBox();
                            startingPosTextBoxX.Location = new Point(200, 20);
                            startingPosTextBoxX.Size = new Size(50, 20);
                            groupBox.Controls.Add(startingPosTextBoxX);

                            Label startingPosYLabel = new Label();
                            startingPosYLabel.Text = "Starting position Y:";
                            startingPosYLabel.Location = new Point(10, 50);
                            startingPosYLabel.Size = new Size(180, 20);
                            startingPosYLabel.BackColor = Color.Transparent;
                            startingPosYLabel.ForeColor = Color.White;
                            startingPosYLabel.Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Italic);
                            groupBox.Controls.Add(startingPosYLabel);

                            TextBox startingPosTextBoxY = new TextBox();
                            startingPosTextBoxY.Location = new Point(200, 50);
                            startingPosTextBoxY.Size = new Size(50, 20);
                            groupBox.Controls.Add(startingPosTextBoxY);

                            Label reachingPosXLabel = new Label();
                            reachingPosXLabel.Text = "Reaching position X:";
                            reachingPosXLabel.Location = new Point(10, 80);
                            reachingPosXLabel.BackColor = Color.Transparent;
                            reachingPosXLabel.ForeColor = Color.White;
                            reachingPosXLabel.Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Italic);
                            reachingPosXLabel.Size = new Size(180, 20);
                            groupBox.Controls.Add(reachingPosXLabel);

                            TextBox reachingPosTextBoxX = new TextBox();
                            reachingPosTextBoxX.Location = new Point(200, 80);
                            reachingPosTextBoxX.Size = new Size(50, 20);
                            groupBox.Controls.Add(reachingPosTextBoxX);

                            Label reachingPosYLabel = new Label();
                            reachingPosYLabel.Text = "Reaching position Y:";
                            reachingPosYLabel.Location = new Point(10, 110);
                            reachingPosYLabel .BackColor = Color.Transparent;
                            reachingPosYLabel.ForeColor = Color.White;
                            reachingPosYLabel.Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Italic);
                            reachingPosYLabel.Size = new Size(180, 20);
                            groupBox.Controls.Add(reachingPosYLabel);

                            TextBox reachingPosTextBoxY = new TextBox();
                            reachingPosTextBoxY.Location = new Point(200, 110);
                            reachingPosTextBoxY.Size = new Size(50, 20);
                            groupBox.Controls.Add(reachingPosTextBoxY);

                            // Add the GroupBox to the main TableLayoutPanel
                            mainTableLayoutPanel.Controls.Add(groupBox, col, row);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a number between 1 and 100.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }

        private void EP_Load(object sender, EventArgs e)
        {
            // Get the size of the desktop.
            Size desktopSize = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;

            //   this.DesktopBounds = new System.Drawing.Rectangle(0, 0, desktopSize.Width, desktopSize.Height);

            int panelWidth = (int)(Screen.PrimaryScreen.Bounds.Width * 1); // Adjust the width as desired
            int panelHeight = (int)(Screen.PrimaryScreen.Bounds.Height * 1); // Adjust the height as desired

            panel1.Size = new Size(panelWidth, panelHeight);
        }
    }
}
