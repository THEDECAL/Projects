using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestTask.Database;
using TestTask.Entities;

namespace TestTask
{
    public partial class EmployeMasterForm : Form
    {
        readonly MasterMod _mod;
        readonly Employe _emp; 

        public EmployeMasterForm(MasterMod mod, Employe emp = null)
        {
            _mod = mod;
            _emp = emp ?? new Employe();
            InitializeComponent();

            dtpBirthDay.Value = dtpBirthDay.MinDate;
            dtpDateEmp.Value = dtpBirthDay.MinDate;
            dtpDateDismiss.Value = dtpBirthDay.MinDate;
            DateTime date = DateTime.Now;
            tbPN.Text = ((DateTimeOffset)date).ToUnixTimeSeconds().ToString();

            InitListOfDepartments();
            InitListOfPositions();
            SetFields(emp);
        }

        /// <summary>
        /// Обработчик кнопки отмены
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Обработчик кнопки добавления/изменения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {

            if (IsValid())
            {
                AddUpdate();
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Ведённые данные не валидные!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Добавление или изменение сущности
        /// </summary>
        private void AddUpdate()
        {
            using (var empCrud = new Crud<Employe>())
            {
                _emp.FName = tbName.Text;
                _emp.SName = tbSName.Text;
                _emp.PName = tbPName.Text;
                _emp.PN = tbPN.Text;
                _emp.TIN = tbTIN.Text;
                var slctGender = cbGender.SelectedItem as string;
                _emp.Gender = (slctGender.Equals("М")) ? true : false;
                _emp.Birthday = dtpBirthDay.Value;
                _emp.DateOfEmployment = dtpDateEmp.Value;
                _emp.PlaceOfBirth = tbPlace.Text;
                _emp.CauseOfDismissal = tbCause.Text;
                if (dtpDateDismiss.MinDate.Equals(dtpDateDismiss.Value))
                {
                    _emp.DateOfDismissal = null;
                }
                else
                {
                    _emp.DateOfDismissal = dtpDateDismiss.Value;
                }

                var slctDep = cbDep.SelectedItem as Department;
                var slctPos = cbPosition.SelectedItem as Position;

                if (_mod == MasterMod.ADD)
                {
                    _emp.DepartmentId = slctDep.Id;
                    _emp.PositionId = slctPos.Id;
                    var newEmp = empCrud.Create(_emp);
                    empCrud.GetDbCtx().SaveChanges();
                    //Создаём первую запись при приёме на работу
                    using (var transferCrud = new Crud<TransferHistory>())
                    {
                        var newTransfer = new TransferHistory()
                        {
                            PositionId = slctPos.Id,
                            DepartmentId = slctDep.Id,
                            EmployeId = newEmp.Id
                        };
                        transferCrud.Create(newTransfer);
                    }
                }
                else if (_mod == MasterMod.UPDATE)
                {
                    if(_emp.DepartmentId != slctDep.Id ||
                        _emp.PositionId != slctPos.Id)
                    {
                        using (var transferCrud = new Crud<TransferHistory>())
                        {
                            var newTransfer = new TransferHistory()
                            {
                                PositionId = slctPos.Id,
                                DepartmentId = slctDep.Id,
                                EmployeId = _emp.Id
                            };
                            transferCrud.Create(newTransfer);
                        }
                    }
                    _emp.PositionId = slctPos.Id;
                    _emp.DepartmentId = slctDep.Id;
                    _emp.Position = null; _emp.Department = null; //Для избежания конфликта с разными связями по ID и по объекту (пр. Department и DepartmentId)
                    empCrud.Update(_emp);
                }
            }
        }

        /// <summary>
        /// Проверка обязательных полей
        /// </summary>
        /// <returns></returns>
        private bool IsValid()
        {
            if (String.IsNullOrEmpty(tbName.Text)) return false;
            if (String.IsNullOrEmpty(tbSName.Text)) return false;
            if (String.IsNullOrEmpty(tbPName.Text)) return false;
            if (String.IsNullOrEmpty(tbPN.Text)) return false;
            if (String.IsNullOrEmpty(tbTIN.Text)) return false;
            if (cbGender.SelectedIndex < 0) return false;
            if (cbDep.SelectedIndex <= 0) return false;
            if (cbPosition.SelectedIndex <= 0) return false;
            if (dtpBirthDay.MinDate.Equals(dtpBirthDay.Value)) return false;
            if (dtpDateEmp.MinDate.Equals(dtpBirthDay.Value)) return false;

            return true;
        }

        /// <summary>
        /// Инициализация списка подразделений
        /// </summary>
        private void InitListOfDepartments()
        {
            using (var crud = new Crud<Department>())
            {
                var list = crud.GetAll();
                list.Insert(0, new Department() { Name = " "});
                if (list.Count() > 0)
                {
                    cbDep.Items.AddRange(list.ToArray());
                }
                cbDep.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Инициализация списка професий
        /// </summary>
        private void InitListOfPositions()
        {
            using (var crud = new Crud<Position>())
            {
                var list = crud.GetAll();
                list.Insert(0, new Position() { Name = " " });
                if (list.Count() > 0)
                {
                    cbPosition.Items.AddRange(list.ToArray());
                }
                cbPosition.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Установить полям значения
        /// </summary>
        /// <param name="dep"></param>
        private void SetFields(Employe emp)
        {
            if (emp != null)
            {
                tbName.Text = _emp.FName;
                tbSName.Text = _emp.SName;
                tbPName.Text = _emp.PName;
                tbPN.Text = _emp.PN;
                tbTIN.Text = _emp.TIN;
                tbPlace.Text = _emp.PlaceOfBirth;
                tbCause.Text = _emp.CauseOfDismissal;
                dtpBirthDay.Value = _emp.Birthday;
                dtpDateEmp.Value = _emp.DateOfEmployment;
                if (_emp.DateOfDismissal != null)
                {
                    dtpDateDismiss.Value = _emp.DateOfDismissal.Value;
                }

                cbGender.SelectedIndex = ((_emp.Gender) ? 0 : 1);

                //Устанавливаем нужное подразделение из списка
                foreach (Department item in cbDep.Items)
                {
                    if (item.Id == _emp.DepartmentId)
                    {
                        cbDep.SelectedItem = item;
                        break;
                    }
                }

                //Устанавливаем нужную должность из списка
                foreach (Position item in cbPosition.Items)
                {
                    if (item.Id == _emp.PositionId)
                    {
                        cbPosition.SelectedItem = item;
                        break;
                    }
                }
            }
        }
    }
}
