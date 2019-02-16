using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsExam
{
    public partial class Form1 : Form
    {
        ImageList images = new ImageList();
        Button prevBtn;
        public Form1()
        {
            InitializeComponent();

            InitImages();
            InitButtons();
        }
        private void InitImages()
        {
            images.ImageSize = new Size(30, 30);
            images.Images.Add(Image.FromFile(@"./Images/white_checker.png"));
            images.Images.Add(Image.FromFile(@"./Images/black_checker.png"));
        }
        private void InitButtons()
        {
            const int rows = 8, cols = 8;
            int x = 0, y = 0;
            int btnSize = 45;
            bool shift = true;
            for (int i = 0; i < rows; i++)
            {

                for (int j = 0; j < cols; j++)
                {
                    Checker checker = new Checker(new Point { X = i, Y = j });
                    Button btn = new Button
                    {
                        Size = new Size(btnSize, btnSize),
                        Location = new Point(x, y),
                        BackColor = (!shift) ? Color.Black : Color.White,
                        FlatStyle = FlatStyle.Flat,
                        Tag = checker
                    };
                    btn.Click += Movement;
                    //Для отладки
                    //btn.Text = checker.Position.ToString();
                    //btn.ForeColor = Color.White;

                    if (btn.BackColor == Color.Black && (i < 3 || i > 4))
                    {
                        Image image = null;
                        if (i < 3)
                        {
                            image = images.Images[0];
                            checker.Color = Color.White;
                        }
                        else if (i > 4)
                        {
                            image = images.Images[1];
                            checker.Color = Color.Black;
                        }
                        btn.Image = image;
                        //Для отладки
                    }
                    else if (btn.BackColor == Color.White) btn.Enabled = false;
                    else checker.IsEmpty = true;

                    this.Controls.Add(btn);
                    x += btnSize;
                    shift = !shift;
                }
                shift = !shift;
                y += btnSize;
                x = 0;
            }
        }
        private void Movement(object sender, EventArgs e)
        {
            Button currBtn = sender as Button;
            Checker currChk = currBtn.Tag as Checker;
            Checker prevChk = (prevBtn != null) ? prevBtn.Tag as Checker : null;
            //Выдеяем шашку, а предыдущей шашке снимет выделение
            if (prevBtn != null  ) prevBtn.ForeColor = Color.Empty;
            currBtn.ForeColor = (currBtn.ForeColor != Color.Red) ? Color.Red : Color.Empty;
            ;
            if (prevBtn != null && prevBtn.ForeColor != Color.Red)
            {
                if (currChk.IsEmpty)
                {
                    Checker tmpChk = currChk;
                    Point tmpP = currChk.Position;
                    
                    currChk.Position = prevChk.Position;
                    prevChk.Position = tmpP;
                    currBtn.Tag = prevBtn.Tag;
                    prevBtn.Tag = tmpChk;
                    currBtn.ForeColor = Color.Empty;
                    currBtn.Image = prevBtn.Image;
                    prevBtn.Image = null;
                }
            }
            prevBtn = currBtn;
        }
    }
}
