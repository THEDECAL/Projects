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
        const string ProgramName = "Testodrom";
        Test[] lstBoxTestsList = new Test[0];
        bool isModeAddOrEdit = false;
        bool isModeRun = false;
        int questionPosition = 1;
        public Form1()
        {
            InitializeComponent();

            Array.Resize(ref lstBoxTestsList, lstBoxTestsList.Length + 1);
            lstBoxTestsList[lstBoxTestsList.Length - 1] = (new Test(){ Name = "Комманды linux"});
            Question newQuestion = new Question() { Name = "Комманда для отображения процессов системы." };
            newQuestion.VariantsAnswers.Add(new Variant() { Name = "top", isCorrectAnswer = true });
            newQuestion.VariantsAnswers.Add(new Variant() { Name = "proc", isCorrectAnswer = false });
            newQuestion.VariantsAnswers.Add(new Variant() { Name = "showpr", isCorrectAnswer = false });
            newQuestion.VariantsAnswers.Add(new Variant() { Name = "processes", isCorrectAnswer = false });
            lstBoxTestsList[lstBoxTestsList.Length - 1].Questions.Add(newQuestion);
            newQuestion = new Question() { Name = "Комманда для отображения файлов текущей директории." };
            newQuestion.VariantsAnswers.Add(new Variant() { Name = "ls", isCorrectAnswer = true });
            newQuestion.VariantsAnswers.Add(new Variant() { Name = "dir", isCorrectAnswer = false });
            newQuestion.VariantsAnswers.Add(new Variant() { Name = "files", isCorrectAnswer = false });
            newQuestion.VariantsAnswers.Add(new Variant() { Name = "showfl", isCorrectAnswer = false });
            lstBoxTestsList[lstBoxTestsList.Length - 1].Questions.Add(newQuestion);
            newQuestion = new Question() { Name = "Комманда для отображения загружености оперативной памяти." };
            newQuestion.VariantsAnswers.Add(new Variant() { Name = "free", isCorrectAnswer = true });
            newQuestion.VariantsAnswers.Add(new Variant() { Name = "showram", isCorrectAnswer = false });
            newQuestion.VariantsAnswers.Add(new Variant() { Name = "checkmem", isCorrectAnswer = false });
            newQuestion.VariantsAnswers.Add(new Variant() { Name = "memtest", isCorrectAnswer = false });
            lstBoxTestsList[lstBoxTestsList.Length - 1].Questions.Add(newQuestion);

            lstBoxTests.DataSource = lstBoxTestsList;
            LockUnlockTestButtons(false);
        }
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
            btnFinish.Enabled = @switch;
        }

        private void LockUnlockChangeButtons(bool @switch)
        {
            lstBoxTests.Enabled = @switch;
            btnStartTest.Enabled = @switch;
            btnChangeTest.Enabled = @switch;
            btnRemoveTest.Enabled = @switch;
            btnAddTest.Enabled = @switch;
        }

        private void btnStartTest_Click(object sender, EventArgs e)
        {
            if (lstBoxTests.SelectedIndex != -1)
            {
                isModeRun = true;
                LockUnlockChangeButtons(false);
                LockUnlockTestButtons(true);

                txtBoxQuestion.ReadOnly = true;
                txtBoxVar1.ReadOnly = true;
                txtBoxVar2.ReadOnly = true;
                txtBoxVar3.ReadOnly = true;
                txtBoxVar4.ReadOnly = true;

                lblBarComplete.Text = $"{questionPosition}/{lstBoxTestsList[lstBoxTestsList.Length - 1].Questions.Count}";

                selectQuestion();
            }
        }

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
                isModeAddOrEdit = true;
                lblBarComplete.Text = $"{lstBoxTestsList[lstBoxTestsList.Length - 1].Questions.Count}";

                MessageBox.Show("Вводите вопросы, варианты ответов и отмечайте правильные ответы переключаясь с помощью стрелок между вопросами.\nПо окончании нажмите \"Завершить\".", ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNextQuestion_Click(object sender, EventArgs e)
        {
            if (isModeAddOrEdit)
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
                if (checkCheckBoxes())
                {
                    questionPosition++;
                    if (questionPosition > lstBoxTestsList[lstBoxTests.SelectedIndex].Questions.Count) questionPosition = 1;
                    selectQuestion();
                    lblBarComplete.Text = $"{questionPosition}/{lstBoxTestsList[lstBoxTestsList.Length - 1].Questions.Count}";

                    clearCheckBox();
                }
                //else
            }
        }
        private void clearCheckBox()
        {
            chkBoxVar1.CheckState = CheckState.Unchecked;
            chkBoxVar2.CheckState = CheckState.Unchecked;
            chkBoxVar3.CheckState = CheckState.Unchecked;
            chkBoxVar4.CheckState = CheckState.Unchecked;
        }
        private void clearTxtBox()
        {
            txtBoxQuestion.Text = "";
            txtBoxVar1.Text = "";
            txtBoxVar2.Text = "";
            txtBoxVar3.Text = "";
            txtBoxVar4.Text = "";
        }

        private void selectQuestion()
        {
            Test t = lstBoxTestsList[lstBoxTests.SelectedIndex];
            Text = t.Name;
            txtBoxQuestion.Text = t.Questions[questionPosition - 1].Name;
            txtBoxVar1.Text = t.Questions[questionPosition - 1].VariantsAnswers[0].Name;
            txtBoxVar2.Text = t.Questions[questionPosition - 1].VariantsAnswers[1].Name;
            txtBoxVar3.Text = t.Questions[questionPosition - 1].VariantsAnswers[2].Name;
            txtBoxVar4.Text = t.Questions[questionPosition - 1].VariantsAnswers[3].Name;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (isModeAddOrEdit)
            {
                isModeAddOrEdit = false;
            }
            else if (isModeRun)
            {
                isModeRun = false;

                clearCheckBox();
                clearTxtBox();
                lblBarComplete.Text = "";

                double amCorrectAnswers = lstBoxTestsList[lstBoxTests.SelectedIndex].Questions.Sum
                    (
                        ee => ee.VariantsAnswers.Sum(i => (i.isCorrectAnswer) ? 1 : 0)
                    );
                //double amCurrentCorrectAnswers
                //txtBoxQuestion.Text = $"Результат: {result}/100%";
            }

            LockUnlockChangeButtons(true);
            LockUnlockTestButtons(false);
        }
        private bool checkCheckBoxes()
        {
            return
                (
                    chkBoxVar1.CheckState == CheckState.Unchecked &&
                    chkBoxVar2.CheckState == CheckState.Unchecked &&
                    chkBoxVar3.CheckState == CheckState.Unchecked &&
                    chkBoxVar4.CheckState == CheckState.Unchecked
                ) ? false : true;
        }

        private void btnPreviousQuestion_Click(object sender, EventArgs e)
        {
            if (isModeRun)
            {
                if (checkCheckBoxes())
                {
                    questionPosition--;
                    if (questionPosition < 1) questionPosition = lstBoxTestsList[lstBoxTests.SelectedIndex].Questions.Count;
                    selectQuestion();
                    lblBarComplete.Text = $"{questionPosition}/{lstBoxTestsList[lstBoxTestsList.Length - 1].Questions.Count}";

                    clearCheckBox();
                }
                //else MessageBox("Не выбран ни один ответ");
            }
        }
    }
}
