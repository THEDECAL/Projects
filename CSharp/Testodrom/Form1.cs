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
        public Form1()
        {
            InitializeComponent();

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

                MessageBox.Show("Вводите вопросы и варианты ответов\n переключаясь между вопросами.\nПо окончании нажмите \"Завершить\".", ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNextQuestion_Click(object sender, EventArgs e)
        {
            if (isModeAddOrEdit)
            {
                Question newQuestion = new Question() { Name = txtBoxQuestion.Text };
                newQuestion.Variants[0] = txtBoxVar1.Text;
                newQuestion.Answers[0] = (chkBoxVar1.CheckState == CheckState.Checked) ? true : false;
                newQuestion.Variants[1] = txtBoxVar2.Text;
                newQuestion.Answers[1] = (chkBoxVar2.CheckState == CheckState.Checked) ? true : false;
                newQuestion.Variants[2] = txtBoxVar3.Text;
                newQuestion.Answers[2] = (chkBoxVar3.CheckState == CheckState.Checked) ? true : false;
                newQuestion.Variants[3] = txtBoxVar4.Text;
                newQuestion.Answers[3] = (chkBoxVar4.CheckState == CheckState.Checked) ? true : false;
                lstBoxTestsList[lstBoxTestsList.Length - 1].Questions.Add(newQuestion);

                //MessageBox.Show("Одно из полей не заполнено.\nЗаполните для продолжения.",ProgramName,MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else if (isModeRun){ }
        }
    }
}
