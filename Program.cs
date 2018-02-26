// from Program.cs
using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;


public class Form1 : Form
{
    private Button button1, button2, button3;
    private PictureBox pictureBox1;
    private System.DirectoryServices.DirectorySearcher directorySearcher1;

    public          Form1           ()  {  InitializeComponent();  }
	
    #region Vom Windows Form-Designer generierter Code

    private void InitializeComponent()
    {
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(62, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 41);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
       
			this.pictureBox1.Location = new System.Drawing.Point(46, 37);
            this.pictureBox1.Name = "pictureBox1";
            string PfadBild = @"C:\Bildverarbeitung\C#-FormsMitDerHand_IP\lena_std.tif";
            StreamReader SR = new StreamReader(PfadBild);
            Bitmap Bild = new Bitmap(SR.BaseStream);
            SR.Close();

            this.pictureBox1.Size = new System.Drawing.Size(Bild.Size.Width,Bild.Size.Height);
            this.pictureBox1.Image = Bild;

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 442);
            //this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

    }

    #endregion		

    private void Form1_Load(object sender, EventArgs e)
    {
        int x = 0;
        int y = 0;

        //kopiert oben aus der Initial Ebene um an das Bild zu kommen...
        this.pictureBox1.Location = new System.Drawing.Point(46, 37);
        this.pictureBox1.Name = "pictureBox1";
        string PfadBild = @"C:\Bildverarbeitung\C#-FormsMitDerHand_IP\lena_std.tif";
        StreamReader SR = new StreamReader(PfadBild);
        Bitmap Bild = new Bitmap(SR.BaseStream);
        Bitmap vBild = new Bitmap(Bild);        //2.bitmap um 2 verschiedene Bilder zu haben
        SR.Close();

        Color bla;

        for (y = 0; y < Bild.Width; y++)
            {
                // ...bearbeite jedes Pixel
                for (x = 0; x < Bild.Height; x++)
                {
                // schreib den Wert des Pixels in die Farb Variable "bla"
                bla = Bild.GetPixel(x,y);

                // verändere das Pixel im 2. Bild anhand des Wertes von Farbe "bla"..... in dem fall Rot
                vBild.SetPixel(x, y, Color.FromArgb(bla.R, bla.R, bla.R));

                //lade das veränderte Bild ind die PictureBox
                pictureBox1.Image = vBild;
                }
            }

    }

    private void button1_Click(object sender, EventArgs e)
    {

    }
    private void button2_Click(object sender, EventArgs e)
    {

    }
}



static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());
    }
}
