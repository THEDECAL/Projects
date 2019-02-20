using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static WindowsFormsExam.Checker;

namespace WindowsFormsExam
{
    partial class Form1 : Form
    {
        /// <summary>
        /// Текущий игрок
        /// false - Белый, true - Чёрный
        /// </summary>
        Color CurrentGamer = Color.White;
        /// <summary>
        /// Размер одной клетки
        /// </summary>
        Size btnSize = new Size(60, 60);
        /// <summary>
        /// Размер доски в клетках
        /// </summary>
        const int rows = 8, cols = rows;
        /// <summary>
        /// Список изображений
        /// </summary>
        ImageList images;
        /// <summary>
        /// Предыдущая клетка/кнопка
        /// </summary>
        Button prevBtn;
        /// <summary>
        /// Счёт: [0] - Белые, [1] - Чёрные
        /// </summary>
        int[] score = new int[2];
        /// <summary>
        /// Счётчик ходов
        /// </summary>
        int stepCount = 1;
        public Form1()
        {
            InitializeComponent();

            InitImages();
            InitWindows();
            InitButtons();
        }
        /// <summary>
        /// Метод иницмализации списка изображений
        /// </summary>
        private void InitImages()
        {
            images = new ImageList();
            images.ImageSize = new Size(btnSize.Width / 4 * 3, btnSize.Height / 4 * 3);
            images.ColorDepth = ColorDepth.Depth32Bit;
            images.TransparentColor = Color.White;
            images.Images.Add(Image.FromFile(@"./Images/white_checker.png"));
            images.Images.Add(Image.FromFile(@"./Images/black_checker.png"));
            images.Images.Add(Image.FromFile(@"./Images/king_white_checker.png"));
            images.Images.Add(Image.FromFile(@"./Images/king_black_checker.png"));
            images.Images.Add(Image.FromFile(@"./Images/deck.jpg"));
        }
        /// <summary>
        /// Метод иницмализации главного окна и статус панели
        /// </summary>
        private void InitWindows()
        {
            this.Size = new Size(btnSize.Width * rows + rows, btnSize.Height * rows + rows * 3 + statusStrip1.Size.Height + 4);
            this.MinimumSize = btnSize;
            this.BackgroundImage = images.Images[4];
            this.BackgroundImageLayout = ImageLayout.Tile;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;

            statusStrip1.Items.AddRange(new ToolStripItem[]
            {
                new ToolStripLabel { TextAlign = ContentAlignment.MiddleLeft, Text = $"СЧЁТ" },
                new ToolStripLabel { TextAlign = ContentAlignment.MiddleLeft, Text = $"Чёрные: {score[0].ToString()}"},
                new ToolStripLabel { TextAlign = ContentAlignment.MiddleRight, Text = $"Белые: {score[0].ToString()}"},
                new ToolStripLabel { TextAlign = ContentAlignment.MiddleRight, Text = $"Ход № {stepCount.ToString()}" }
            });

            UpdateStat(null, null);
        }
        private void InitButtons()
        {
            int x = 0, y = 0;
            bool shift = true;

            //prevBtn = new Button { Tag = new Checker(CType.Empty) };

            for (int i = 0; i < rows; i++, x = 0, y += btnSize.Height, shift = !shift)
            {

                for (int j = 0; j < cols; j++, x += btnSize.Width, shift = !shift)
                {
                    Checker checker = new Checker(CType.Empty, pnt:(new Point(i, j)));// CheckerRef[CType.Empty] { _Point = new Point(i, j) };
                    Color black = Color.FromArgb(160, Color.Black);
                    Color white = Color.FromArgb(160, Color.White);
                    
                    var tmp = new Button
                    {
                        Size = btnSize,
                        FlatStyle = FlatStyle.Flat,
                        Location = new Point(x, y),
                        BackColor = (!shift) ? black : white
                    };

                    if (tmp.BackColor == black && (i < 3 || i > 4))
                    {
                        Image image = null;
                        if (i < 3)
                        {
                            image = images.Images[0];
                            checker._Color = Color.White;
                        }
                        else if (i > 4)
                        {
                            image = images.Images[1];
                            checker._Color = Color.Black;
                        }
                        
                        tmp.Image = image;
                        tmp.Tag = checker;
                        tmp.Click += Movement;
                        //tmp.Click += UpdateStat;
                    }
                    else if (tmp.BackColor == white) tmp.Enabled = false;
                    else
                    {
                        checker.IsEmpty = true;
                        tmp.Tag = checker;
                        tmp.Click += Movement;
                        tmp.Click += UpdateStat;
                    }
                    
                    this.Controls.Add(tmp);
                }
            }
        }
        private void UpdateQueueGamer() => CurrentGamer = (CurrentGamer == Color.White) ? Color.Black : Color.White;
        private void UpdateStat(object sender, EventArgs e)
        {
            var chk = (prevBtn as Button)?.Tag as Checker;

            Text = $"Ход {(chk == null || chk._Color == Color.White ? "Белых" : "Чёрных")}";
            statusStrip1.Items[1].Text = $"Чёрные: {score[0].ToString()}";
            statusStrip1.Items[2].Text = $"Белые: {score[1].ToString()}";
            statusStrip1.Items[3].Text = $"Ход № {(stepCount + 1).ToString()}";
        }
        /// <summary>
        /// Метод поиска шашек противника на момент боя
        /// </summary>
        /// <param name="p">Точка клетки получателя</param>
        /// <returns>Возвращает список точек класса Point между клетками отправителя и получателя</returns>
        private List<Point> TakeCheckers(Point currP)
        {
            var blacklist = new List<Point>();

            try
            {
                Checker prevChk = prevBtn?.Tag as Checker;

                if (prevBtn != null)
                {
                    int amCheckersToTake = Math.Abs(currP.X - prevChk._Point.X);

                    if (amCheckersToTake > 1 && amCheckersToTake < 8)
                    {
                        for (int i = 0; i < amCheckersToTake - 1; i++)
                        {
                            int tmpX = (currP.X > prevChk._Point.X) ? currP.X - 1 : currP.X + 1;
                            int tmpY = (currP.Y > prevChk._Point.Y) ? currP.Y - 1 : currP.Y + 1;

                            var btn = this.Controls[(tmpX * rows + tmpY) + 1] as Button;
                            var chk = btn?.Tag as Checker;

                            if (prevChk._Color != chk._Color) blacklist.Add(currP = chk._Point);
                            else throw new Exception();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Msg(ex.ToString(), MessageBoxIcon.Error);
                return null;
            }

            return blacklist;
        }
        /// <summary>
        /// Метод покаа сообщений
        /// </summary>
        /// <param name="text">Текст сообщения</param>
        /// <param name="icon">Иконка сообщения</param>
        private void Msg(string text, MessageBoxIcon icon)  => MessageBox.Show(text, "", MessageBoxButtons.OK, icon);
        /// <summary>
        /// Метод передвижения шашек
        /// </summary>
        private void Movement(object s, EventArgs e)
        {
            try
            {
                var currBtn = s as Button; //Кнопка получатель
                var currChk = currBtn?.Tag as Checker; //Шашка получатель
                var prevChk = prevBtn?.Tag as Checker; //Шашка отправитель

                //Выдеяем шашку
                currBtn.ForeColor = (currBtn.ForeColor != Color.Red) ? Color.Red : Color.Empty;

                //Если это шашки текущего игрока
                if (prevBtn != null && currBtn != null && prevChk._Color == CurrentGamer)
                {
                    if (!prevChk.IsEmpty && currChk.IsEmpty)
                    {
                        //Проверяем, наличие шашек под бой
                        var blacklist = TakeCheckers(currChk._Point);
                        bool isAvail = (blacklist.Count > 0) ? true : false;

                        if (prevChk.CheckerType > CType.WhiteKing ||
                            (prevChk._Color == Color.White && currChk._Point.X == prevChk._Point.X + (isAvail ? 2 : 1)) ||
                            (prevChk._Color == Color.Black && currChk._Point.X + (isAvail ? 2 : 1) == prevChk._Point.X))
                        {
                            #region
                            //Меняем координаты и делаем ротацию
                            Point tmp = currChk._Point;
                            currBtn.Image = prevBtn.Image;
                            prevBtn.Image = null;
                            currChk._Point = prevChk._Point;
                            prevChk._Point = tmp;
                            currBtn.Tag = prevBtn?.Tag;
                            prevBtn.Tag = currChk;

                            //Захват шашек противника
                            blacklist.ForEach(o =>
                            {
                                var btn = this.Controls[(o.X * rows + o.Y) + 1] as Button;
                                var chk = btn?.Tag as Checker;

                                btn.Image = null;
                                chk._Color = Color.Empty;
                                chk.IsEmpty = true;

                                if (prevChk._Color == Color.White) score[0]++;
                                else score[1]++;
                            });

                            //Меняем значок дамки
                            if ((prevChk.CheckerType == CType.WhiteEasy && prevChk._Point.X == 7) ||
                                (prevChk.CheckerType == CType.BlackEasy && prevChk._Point.X == 0))
                            {
                                currBtn.Image = (prevChk.CheckerType < CType.BlackEasy) ? images.Images[2] : images.Images[3];
                                prevChk.CheckerType = (prevChk.CheckerType < CType.BlackEasy) ? CType.BlackKing : CType.WhiteKing;
                            }
                            #endregion
                            stepCount++;
                        }
                        currBtn.ForeColor = prevBtn.ForeColor = Color.Empty;
                        prevBtn = null;
                        UpdateQueueGamer();
                    }
                }
                else prevBtn = currBtn;
            }
            catch (Exception ex) { }// { Msg(ex.ToString(), MessageBoxIcon.Error); }
        }
    }
}
