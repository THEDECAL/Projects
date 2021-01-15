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
    public partial class DepartmentMasterForm : Form
    {
        readonly MasterMod _mod;
        readonly Department _dep;

        public DepartmentMasterForm(MasterMod mod, Department dep = null)
        {
            _mod = mod;
            _dep = dep ?? new Department();
            InitializeComponent();
            InitListOfDepartments();
            SetFields(dep);
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
            _dep.Name = tbName.Text;
            var slctItem = cbDep.SelectedItem as Department;
            _dep.ParentDepartment = null;
            _dep.ParentDepartmentId = (cbDep.SelectedIndex == 0) ? null : slctItem?.Id;

            using (var crud = new Crud<Department>())
            {
                if (_mod == MasterMod.ADD)
                {
                    _dep.State = chkbState.Checked;
                    crud.Create(_dep);
                }
                else if (_mod == MasterMod.UPDATE)
                {
                    if (_dep.State == true && chkbState.Checked == false)
                    {
                        _dep.DateOfClosed = DateTime.Now;
                    }
                    else if (_dep.State == false && chkbState.Checked == true)
                    {
                        _dep.DateOfClosed = null;
                    }
                    _dep.State = chkbState.Checked;
                    crud.Update(_dep);
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
            var slctDep = cbDep.SelectedItem as Department;
            //Родительский департамент не может быть собственным департаментом
            if (slctDep != null &&
                slctDep.Id != 0 &&
                slctDep.Id == _dep.Id) return false;

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
                    cbDep.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// Установить полям значения
        /// </summary>
        /// <param name="dep"></param>
        private void SetFields(Department dep)
        {
            if (dep != null)
            {
                //Устанавливаем нужное подразделение из списка
                foreach (Department item in cbDep.Items)
                {
                    if (dep.ParentDepartmentId != null &&
                        item.ParentDepartmentId == dep.ParentDepartmentId)
                    {
                        cbDep.SelectedItem = item;
                        break;
                    }
                }

                tbName.Text = dep.Name;
                chkbState.Checked = dep.State;
            }
        }
    }
}
