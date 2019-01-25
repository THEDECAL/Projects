using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testodrom
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Название программы
        /// </summary>
        const string ProgramName = "Testodrom v0.1a";
        /// <summary>
        /// Массив тестов
        /// </summary>
        Test[] lstBoxTestsList = new Test[0];
        /// <summary>
        /// Тест для хранения ответов
        /// </summary>
        Test testAnswers;
        /// <summary>
        /// Поле режима добавления
        /// </summary>
        bool isModeAdd = false;
        /// <summary>
        /// Поле режима прохождения теста
        /// </summary>
        bool isModeRun = false;
        /// <summary>
        /// Поле номера текущего вопроса (счёт начинается с 1)
        /// </summary>
        int questionPosition = 1;
        /// <summary>
        /// Таймер времени прохождения теста
        /// </summary>
        DateTime time;
        /// <summary>
        /// Таймер для времени прохождения теста
        /// </summary>
        Timer timer = new Timer() { Interval = 1000};
        public Form1()
        {
            InitializeComponent();

            //Добавление автономного теста
            Array.Resize(ref lstBoxTestsList, lstBoxTestsList.Length + 1);
            lstBoxTestsList[lstBoxTestsList.Length - 1] = (new Test(){ Name = "Комманды linux"});
            Question newQuestion = new Question() { Name = "Комманда для отображения процессов системы" };
            newQuestion.VariantsAnswers.Add(new Variant() { Name = "top", isCorrectAnswer = true });
            newQuestion.VariantsAnswers.Add(new Variant() { Name = "proc", isCorrectAnswer = false });
            newQuestion.VariantsAnswers.Add(new Variant() { Name = "showpr", isCorrectAnswer = false });
            newQuestion.VariantsAnswers.Add(new Variant() { Name = "processes", isCorrectAnswer = false });
            lstBoxTestsList[lstBoxTestsList.Length - 1].Questions.Add(newQuestion);
            newQuestion = new Question() { Name = "Комманда для отображения файлов текущей директории" };
            newQuestion.VariantsAnswers.Add(new Variant() { Name = "ls", isCorrectAnswer = true });
            newQuestion.VariantsAnswers.Add(new Variant() { Name = "dir", isCorrectAnswer = false });
            newQuestion.VariantsAnswers.Add(new Variant() { Name = "files", isCorrectAnswer = false });
            newQuestion.VariantsAnswers.Add(new Variant() { Name = "showfl", isCorrectAnswer = false });
            lstBoxTestsList[lstBoxTestsList.Length - 1].Questions.Add(newQuestion);
            newQuestion = new Question() { Name = "Комманда для отображения загружености оперативной памяти" };
            newQuestion.VariantsAnswers.Add(new Variant() { Name = "free", isCorrectAnswer = true });
            newQuestion.VariantsAnswers.Add(new Variant() { Name = "showram", isCorrectAnswer = false });
            newQuestion.VariantsAnswers.Add(new Variant() { Name = "checkmem", isCorrectAnswer = false });
            newQuestion.VariantsAnswers.Add(new Variant() { Name = "memtest", isCorrectAnswer = false });
            lstBoxTestsList[lstBoxTestsList.Length - 1].Questions.Add(newQuestion);

            lstBoxTests.DataSource = lstBoxTestsList;
            LockUnlockTestButtons(false);
            
        }
        /// <summary>
        /// Блокировка/Разблокировка элементов взаимодействия с тестом
        /// </summary>
        /// <param name="switch">Принимает true, чтобы включить элементы, false выключить</param>
        private void LockUnlockTestButtons(bool @switch)
        {
            txtBoxQuestion.Enabled = @switch;
            chkBoxVar1.Enabled = @switch;
            chkBoxVar2.Enabled = @switch;
            chkBoxVar3.Enabled = @switch;
            chkBoxVar4.Enabled = @switch;
            txtBoxVar1.Enabled = @switch;
            txtBoxVar2.Enabled = @switch;
            txtBoxVar3.Enabled = @switch;
            txtBoxVar4.Enabled = @switch;
            btnPreviousQuestion.Enabled = @switch;
            btnNextQuestion.Enabled = @switch;
            btnFinishTest.Enabled = @switch;
            btnHelp.Enabled = @switch;
        }
        /// <summary>
        /// Блокировка/Разблокировка элементов управления тестом
        /// </summary>
        /// <param name="switch">Принимает true, чтобы включить элементы, false выключить</param>
        private void LockUnlockChangeButtons(bool @switch)
        {
            lstBoxTests.Enabled = @switch;
            btnStartTest.Enabled = @switch;
            btnChangeTest.Enabled = @switch;
            btnRemoveTest.Enabled = @switch;
            btnAddTest.Enabled = @switch;
        }
        /// <summary>
        /// Метод очистки чекбоксов
        /// </summary>
        private void clearCheckBox()
        {
            chkBoxVar1.CheckState = CheckState.Unchecked;
            chkBoxVar2.CheckState = CheckState.Unchecked;
            chkBoxVar3.CheckState = CheckState.Unchecked;
            chkBoxVar4.CheckState = CheckState.Unchecked;
        }
        /// <summary>
        /// Метод очистки поля вопроса и вариантов ответа
        /// </summary>
        private void clearTxtBox()
        {
            txtBoxQuestion.Text = "";
            txtBoxVar1.Text = "";
            txtBoxVar2.Text = "";
            txtBoxVar3.Text = "";
            txtBoxVar4.Text = "";
        }
        /// <summary>
        /// Метод отображения вопроса
        /// </summary>
        private void showQuestion()
        {
            Test t = lstBoxTestsList[lstBoxTests.SelectedIndex]; //Текущий тест
            Question q = t.Questions[questionPosition - 1]; //Текущий вопрос
            Question currQ = testAnswers.Questions[questionPosition - 1]; //Текущий вопрос в хранилище ответов

            Text = t.Name;
            txtBoxQuestion.Text = q.Name;
            txtBoxVar1.Text = q.VariantsAnswers[0].Name;
            txtBoxVar2.Text = q.VariantsAnswers[1].Name;
            txtBoxVar3.Text = q.VariantsAnswers[2].Name;
            txtBoxVar4.Text = q.VariantsAnswers[3].Name;

            chkBoxVar1.CheckState = (currQ.VariantsAnswers[0].isCorrectAnswer) ? CheckState.Checked : CheckState.Unchecked;
            chkBoxVar2.CheckState = (currQ.VariantsAnswers[1].isCorrectAnswer) ? CheckState.Checked : CheckState.Unchecked;
            chkBoxVar3.CheckState = (currQ.VariantsAnswers[2].isCorrectAnswer) ? CheckState.Checked : CheckState.Unchecked;
            chkBoxVar4.CheckState = (currQ.VariantsAnswers[3].isCorrectAnswer) ? CheckState.Checked : CheckState.Unchecked;
        }
        /// <summary>
        /// Метод сохранения ответа
        /// </summary>
        private void saveAnswer()
        {
            Question currQ = testAnswers.Questions[questionPosition - 1]; //Текущий вопрос в хранилище ответов
            currQ.VariantsAnswers[0].isCorrectAnswer = (chkBoxVar1.CheckState == CheckState.Checked) ? true : false;
            currQ.VariantsAnswers[1].isCorrectAnswer = (chkBoxVar2.CheckState == CheckState.Checked) ? true : false;
            currQ.VariantsAnswers[2].isCorrectAnswer = (chkBoxVar3.CheckState == CheckState.Checked) ? true : false;
            currQ.VariantsAnswers[3].isCorrectAnswer = (chkBoxVar4.CheckState == CheckState.Checked) ? true : false;
        }
        /// <summary>
        /// Событие выбора следующего вопроса
        /// </summary>
        private void btnNextQuestion_Click(object sender, EventArgs e)
        {
            if (isModeAdd)
            {
                Question newQuestion = new Question() { Name = txtBoxQuestion.Text };
                newQuestion.VariantsAnswers.Add(new Variant()
                {
                    Name = txtBoxVar1.Text,
                    isCorrectAnswer = (chkBoxVar1.CheckState == CheckState.Checked) ? true : false
                });
                newQuestion.VariantsAnswers.Add(new Variant()
                {
                    Name = txtBoxVar2.Text,
                    isCorrectAnswer = (chkBoxVar2.CheckState == CheckState.Checked) ? true : false
                });
                newQuestion.VariantsAnswers.Add(new Variant()
                {
                    Name = txtBoxVar3.Text,
                    isCorrectAnswer = (chkBoxVar3.CheckState == CheckState.Checked) ? true : false
                });
                newQuestion.VariantsAnswers.Add(new Variant()
                {
                    Name = txtBoxVar4.Text,
                    isCorrectAnswer = (chkBoxVar4.CheckState == CheckState.Checked) ? true : false
                });

                string errors = newQuestion.CheckToValid();
                if (errors == null)
                {
                    lstBoxTestsList[lstBoxTestsList.Length - 1].Questions.Add(newQuestion);

                    clearTxtBox();
                    clearCheckBox();

                    lblBarComplete.Text = $"{lstBoxTestsList[lstBoxTestsList.Length - 1].Questions.Count}";
                }
                else MessageBox.Show(errors, ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (isModeRun)
            {
                saveAnswer();
                questionPosition++;
                if (questionPosition > lstBoxTestsList[lstBoxTests.SelectedIndex].Questions.Count) questionPosition = 1;
                showQuestion();
                lblBarComplete.Text = $"{questionPosition}/{lstBoxTestsList[lstBoxTestsList.Length - 1].Questions.Count}";
            }
        }
        /// <summary>
        /// Событие выбора предыдущего вопроса
        /// </summary>
        private void btnPreviousQuestion_Click(object sender, EventArgs e)
        {
            if (isModeRun)
            {
                saveAnswer();
                questionPosition--;
                if (questionPosition < 1) questionPosition = lstBoxTestsList[lstBoxTests.SelectedIndex].Questions.Count;
                showQuestion();
                lblBarComplete.Text = $"{questionPosition}/{lstBoxTestsList[lstBoxTestsList.Length - 1].Questions.Count}";
            }
        }
        /// <summary>
        /// Событие запуска теста
        /// </summary>
        private void btnStartTest_Click(object sender, EventArgs e)
        {
            if (lstBoxTests.SelectedIndex != -1)
            {
                time = new DateTime();
                timer.Tick += (object ss, EventArgs ee) => { time = time.AddSeconds(1); lblTime.Text = time.ToString("mm:ss"); };
                timer.Start();

                testAnswers = Test.CloneTestWithoutCorrectAnswers(lstBoxTestsList[lstBoxTests.SelectedIndex]);
                isModeRun = true;
                LockUnlockChangeButtons(false);
                LockUnlockTestButtons(true);

                txtBoxQuestion.ReadOnly = true;
                txtBoxVar1.ReadOnly = true;
                txtBoxVar2.ReadOnly = true;
                txtBoxVar3.ReadOnly = true;
                txtBoxVar4.ReadOnly = true;

                lblBarComplete.Text = $"{questionPosition}/{lstBoxTestsList[lstBoxTestsList.Length - 1].Questions.Count}";

                showQuestion();
            }
        }
        /// <summary>
        /// Событие добавление теста
        /// </summary>
        private void btnAddTest_Click(object sender, EventArgs e)
        {
            //Проверяем, чтобы поле ввода не было пусто и значения не дублировались
            if (txtBoxAddTest.Text.Length != 0 && !lstBoxTestsList.Any(line => line.Name == txtBoxAddTest.Text))
            {
                Array.Resize(ref lstBoxTestsList, lstBoxTestsList.Length + 1);
                lstBoxTestsList[lstBoxTestsList.Length - 1] = new Test() { Name = txtBoxAddTest.Text };
                lstBoxTests.DataSource = lstBoxTestsList;
                txtBoxAddTest.Text = "";

                LockUnlockTestButtons(true);
                LockUnlockChangeButtons(false);
                btnPreviousQuestion.Enabled = false;
                isModeAdd = true;
                lblBarComplete.Text = $"{lstBoxTestsList[lstBoxTestsList.Length - 1].Questions.Count}";
            }
        }
        /// <summary>
        /// Событие завершения добавления или прохождения теста
        /// </summary>
        private void btnFinishTest_Click(object sender, EventArgs e)
        {
            if (isModeAdd)
            {
                isModeAdd = false;
            }
            else if (isModeRun)
            {
                Test t = lstBoxTestsList[lstBoxTests.SelectedIndex]; //Текущий тест
                Question q = t.Questions[questionPosition - 1]; //Текущий вопрос
                Question currQ = testAnswers.Questions[questionPosition - 1]; //Текущий вопрос в хранилище ответов
                bool isContinue = true;

                saveAnswer();

                //Проверка, чтобы все вопросы имели ответы
                if (!testAnswers.Questions.All(o => o.CheckCorrectAnswers()) || testAnswers.Questions.Count == 0)
                {
                    DialogResult result = MessageBox.Show("Есть вопросы без ответов\nВсе равно завершить тест?", ProgramName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    isContinue = (result == DialogResult.No) ? false : true;
                }
                if(isContinue)
                {
                    timer.Stop();
                    isModeRun = false;
                    clearCheckBox();
                    clearTxtBox();
                    lblBarComplete.Text = "";

                    int amGenericCorrectAnswers = t.Questions.Sum(ee => ee.VariantsAnswers.Sum(i => (i.isCorrectAnswer) ? 1 : 0)) * 100;
                    double genericResult = 0;

                    for (int i = 0; i < t.Questions.Count; i++)
                    {
                        int amCorrectAnswers = t.Questions[i].VariantsAnswers.Sum(o => (o.isCorrectAnswer) ? 1 : 0);
                        int amCurrentCorrectAnswers = 0;
                        double result = 0;
                        Question tmpQ = t.Questions[i];
                        Question tmpCurrQ = testAnswers.Questions[i];
                        ;
                        for (int j = 0; j < tmpQ.VariantsAnswers.Count; j++)
                        {
                            if (tmpQ.VariantsAnswers[j].isCorrectAnswer && tmpCurrQ.VariantsAnswers[j].isCorrectAnswer)
                                amCurrentCorrectAnswers++;
                            else if (tmpQ.VariantsAnswers[j].isCorrectAnswer == false && tmpCurrQ.VariantsAnswers[j].isCorrectAnswer == true)
                                amCurrentCorrectAnswers--;
                        }
                        ;
                        result = (double)amCurrentCorrectAnswers / (double)amCorrectAnswers * 100;
                        genericResult += ((result < 0) ? 0 : result) / (double)amGenericCorrectAnswers * 100;
                    }

                    txtBoxQuestion.Text = $"Результат: {(genericResult < 0 ? 0 : Math.Round(genericResult, 1))}/100%";
                    testAnswers = null;
                    questionPosition = 1;
                }
            }
            LockUnlockChangeButtons(true);
            LockUnlockTestButtons(false);
        }
        /// <summary>
        /// Событие справки
        /// </summary>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (isModeAdd)
                MessageBox.Show("Вводите вопросы, варианты ответов и отмечайте правильные ответы переключаясь с помощью стрелок между вопросами.\nПо окончании нажмите \"Завершить\".", ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (isModeRun) ;
                MessageBox.Show("Отвечайте на вопросы отмечая галками ответы, ответов может быть один и более\nПо окончании нажмите \"Завершить\".", ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
