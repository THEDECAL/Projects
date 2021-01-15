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
    public enum MasterMod { ADD, UPDATE };

    public partial class Form1 : Form
    {
        public Form1()
        {
            initDB();
            InitializeComponent();
            makeTree();
        }

        /// <summary>
        /// Создание дерева подразделений и их сотрудников
        /// </summary>
        /// <param name="searchText">Текст поиска</param>
        private void makeTree()
        {
            tvDepsAndEmps.Nodes.Clear();
            tvDepsAndEmps.SelectedNode = null;

            using (var depCrud = new Crud<Department>())
            {
                using (var empCrud = new Crud<Employe>())
                {
                    //Создаём список узлов подразделений
                    var depListNodes = depCrud.GetDbSet()
                        .Include(nameof(Department.ParentDepartment))
                        .AsEnumerable()
                        .Select(d => new TreeNode(d.ToString())
                        {
                            Tag = d,
                            ContextMenuStrip = ctxDepMenu
                        }).ToList();

                    //Распределяем дочерние подразделения по дереву
                    for (int i = 0; i < depListNodes.Count(); i++)
                    {
                        var node = depListNodes[i];
                        var dep = node.Tag as Department;
                        if (dep.ParentDepartmentId != null)
                        {
                            for (int o = 0; o < depListNodes.Count(); o++)
                            {
                                if (i != o)
                                {
                                    var n = depListNodes[o];
                                    var d = n.Tag as Department;
                                    if (d.Id == dep.ParentDepartmentId)
                                        n.Nodes.Add(node);
                                }
                            }
                        }
                        else
                        {
                            tvDepsAndEmps.Nodes.Add(node);
                        }
                    }

                    //Добавляем сотудников в подразделения
                    using (var historyCrud = new Crud<TransferHistory>())
                    {
                        depListNodes.ForEach(depNode =>
                        {
                            var dep = depNode.Tag as Department;
                            var empNodesList = empCrud.GetDbSet()
                                .Include(nameof(Employe.Department))
                                .Include(nameof(Employe.Position))
                                .AsEnumerable()
                                .Where(e => e.DepartmentId == dep.Id)
                                .Select(e => {
                                    //var hlst = historyCrud.Find(h => h.EmployeId == e.Id);
                                    //e.TransferHistory = hlst;

                                    return new TreeNode(e.ToString())
                                    {
                                        Tag = e,
                                        ContextMenuStrip = ctxEmpMenu
                                    };
                                })
                                .ToArray();
                            depNode.Nodes.AddRange(empNodesList);
                        });
                    }
                }
            }
        }

        /// <summary>
        /// Обработчик кнопки добавления департамента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddDep_Click(object sender, EventArgs e)
        {
            DepartmentMasterForm dauf = new DepartmentMasterForm(MasterMod.ADD);
            var result = dauf.ShowDialog();
            if (result != DialogResult.Cancel)
            {
                makeTree();
            }
        }

        /// <summary>
        /// Обработчик кнопки добавления сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddEmp_Click(object sender, EventArgs e)
        {
            EmployeMasterForm eauf = new EmployeMasterForm(MasterMod.ADD);
            var result = eauf.ShowDialog();
            if (result != DialogResult.Cancel)
            {
                makeTree();
            }
        }

        /// <summary>
        /// Обработчик кнопки поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartSearch_Click(object sender, EventArgs e)
        {
            var searchText = tbSearchText.Text.ToLower().Trim();
            makeTree();

            if (!String.IsNullOrWhiteSpace(searchText))
            {
                //Если не выбрано подразделение искать везде
                var slctNodes = (tvDepsAndEmps.SelectedNode == null)
                    ? tvDepsAndEmps.Nodes
                    : tvDepsAndEmps.SelectedNode.Nodes;

                var lst = RecursiveNodesSearch(slctNodes);
                tvDepsAndEmps.Nodes.Clear();
                tvDepsAndEmps.Nodes.AddRange(lst.Where(n =>
                {
                    var emp = n.Tag as Employe;
                    var name = $"{emp.SName} {emp.FName} {emp.PName}".ToLower().Trim();
                    return name.Contains(searchText);
                }).ToArray());
            }
        }

        /// <summary>
        /// Рекурсивный поиск сотрудников
        /// </summary>
        /// <param name="nodeCol">Коллекция узлов</param>
        /// <param name="lst">Выходной список узлов</param>
        /// <returns></returns>
        private List<TreeNode> RecursiveNodesSearch(TreeNodeCollection nodeCol, List<TreeNode> lst = null)
        {
            lst = lst ?? new List<TreeNode>();

            foreach (TreeNode node in nodeCol)
            {
                var tag = node.Tag;
                if (tag is Department)
                {
                    RecursiveNodesSearch(node.Nodes, lst);
                }
                else if (tag is Employe)
                {
                    lst.Add(node);
                }
            }
            return lst;
        }

        /// <summary>
        /// Инициализаци базы данных
        /// </summary>
        private void initDB()
        {
            //Инициализация должностей
            using (var posCrud = new Crud<Position>())
            {
                var posLIst = posCrud.GetAll();
                if (posLIst.Count() == 0)
                {
                    var posArr = new string[]
                    {"Директор", "Главный руководитель",
                        "Руководитель", "Главный специалист",
                        "Ведущий специалист", "Специалист" };
                    posArr.ToList().ForEach(p =>
                    {
                        var newPos = new Position() { Name = p };
                        posCrud.Create(newPos);
                    });
                }
            }

            //Инициализация подразделений
            using (var depCrud = new Crud<Department>())
            {
                var depList = depCrud.GetAll();
                if (depList.Count() == 0)
                {
                    var depIT = new Department()
                    {
                        Name = "IT"
                    };
                    var depDevelop = new Department()
                    {
                        Name = "Разработка",
                        ParentDepartment = depIT
                    };
                    var depSysAdm = new Department()
                    {
                        Name = "Системное администрирование",
                        ParentDepartment = depIT
                    };
                    var depFinance = new Department()
                    {
                        Name = "Финансы"
                    };
                    var depJuris = new Department()
                    {
                        Name = "Юриспруденция"
                    };

                    depCrud.Create(depIT);
                    depCrud.Create(depDevelop);
                    depCrud.Create(depSysAdm);
                    depCrud.Create(depFinance);
                    depCrud.Create(depJuris);
                }
            }
        }

        /// <summary>
        /// Обработчик кнопки изменить в контекстном меню сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsEmpEdit_Click(object sender, EventArgs e)
        {
            var node = tvDepsAndEmps.SelectedNode;
            if (node != null)
            {
                var emp = node.Tag as Employe;
                if (emp != null)
                {
                    var empMaster = new EmployeMasterForm(MasterMod.UPDATE, emp);
                    var result = empMaster.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        makeTree();
                        SetEmployeInfo(emp);
                    }
                }
            }
        }

        /// <summary>
        /// Обработчик кнопки изменить в контекстном меню подразделения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsDepEdit_Click(object sender, EventArgs e)
        {
            var node = tvDepsAndEmps.SelectedNode;
            if (node != null)
            {
                var dep = node.Tag as Department;
                if (dep != null)
                {
                    var depMaster = new DepartmentMasterForm(MasterMod.UPDATE, dep);
                    var result = depMaster.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        makeTree();
                        SetDepartmentInfo(dep);
                    }
                }
            }
        }

        /// <summary>
        /// Очистить информацию о подразделении
        /// </summary>
        private void ClearDepartmentInfo()
        {
            tbDepName.Text = String.Empty;
            tbDepDep.Text = String.Empty;
            tbState.Text = String.Empty;
            tbDateCreate.Text = String.Empty;
            tbDateClosed.Text = String.Empty;
        }

        /// <summary>
        /// Очистить иныормацию о сотруднике
        /// </summary>
        private void ClearEmployeInfo()
        {
            tbName.Text = String.Empty;
            tbSName.Text = String.Empty;
            tbPName.Text = String.Empty;
            tbPN.Text = String.Empty;
            tbTIN.Text = String.Empty;
            tbPos.Text = String.Empty;
            tbEmpDep.Text = String.Empty;
            tbGender.Text = String.Empty;
            tbBirthday.Text = String.Empty;
            tbPlace.Text = String.Empty;
            tbDateEmp.Text = String.Empty;
            tbDateDismiss.Text = String.Empty;
            tbCause.Text = String.Empty;
            lvHistory.Items.Clear();
        }

        /// <summary>
        /// Установить информацию для подразделения
        /// </summary>
        private void SetDepartmentInfo(Department d)
        {
            if (d != null)
            {
                ClearDepartmentInfo();
                tbDepName.Text = d.Name;
                tbDepDep.Text = d?.ParentDepartment?.ToString();
                tbState.Text = d.State ? "В работе" : "Закрыто";
                tbDateCreate.Text = d.DateOfCreation.ToString();
                tbDateClosed.Text = d?.DateOfClosed?.ToString();
            }
        }

        /// <summary>
        /// Установить информацию для сотрудника
        /// </summary>
        private void SetEmployeInfo(Employe e)
        {
            if (e != null)
            {
                ClearEmployeInfo();
                tbName.Text = e.FName;
                tbSName.Text = e.SName;
                tbPName.Text = e.PName;
                tbPN.Text = e.PN;
                tbTIN.Text = e.TIN;
                tbPos.Text = e?.Position?.ToString();
                tbEmpDep.Text = e?.Department?.ToString();
                tbGender.Text = e.Gender ? "М" : "Ж";
                tbBirthday.Text = e.Birthday.ToString();
                tbPlace.Text = e.PlaceOfBirth;
                tbDateEmp.Text = e.DateOfEmployment.ToString();
                tbDateDismiss.Text = e?.DateOfDismissal?.ToString();
                tbCause.Text = e.CauseOfDismissal;
                tbPos.Text = e?.Position?.Name;
                tbEmpDep.Text = e?.Department?.Name;

                //Заполняем историю переводов
                using (var depCrud = new Crud<Department>())
                {
                    using (var posCrud = new Crud<Position>())
                    {
                        using (var transCrud = new Crud<TransferHistory>())
                        {
                            var cnt = 1;
                            var transLst = transCrud.Find(t => t.EmployeId == e.Id);
                            transLst.ForEach(t =>
                            {
                                var dep = depCrud.Find(d => d.Id == t.DepartmentId)?.FirstOrDefault();
                                var pos = posCrud.Find(p => p.Id == t.PositionId)?.FirstOrDefault();
                                lvHistory.Items.Add(new ListViewItem(new string[]
                                {
                                    (cnt++).ToString(),
                                    t?.DateOfCreation.ToString(),
                                    pos.ToString(),
                                    dep.ToString()
                                }));
                            });
                        }
                    }
                }
            }
        }

        private void tvDepsAndEmps_Leave(object sender, EventArgs e)
        {
            //ClearDepartmentInfo();
            //ClearEmployeInfo();
        }

        /// <summary>
        /// Обрабочик события нажатия на узел дерева
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvDepsAndEmps_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = tvDepsAndEmps.SelectedNode;
            if (node != null)
            {
                if (node.Tag is Department)
                {
                    var dep = node.Tag as Department;
                    SetDepartmentInfo(dep);
                    ClearEmployeInfo();
                }
                else if (node.Tag is Employe)
                {
                    var emp = node.Tag as Employe;
                    SetDepartmentInfo(emp.Department);
                    SetEmployeInfo(emp);
                }
            }
        }

        private void tvDepsAndEmps_Click(object sender, EventArgs e) => tvDepsAndEmps_AfterSelect(null, null);

        /// <summary>
        /// Обработчик кнопки удалить в контекстном меню подразделения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsDepDel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Будут удалены все подподразделения и сотрудники из подразделений вы согласны?", "Внимание",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                RecursiveNodesDeleting(tvDepsAndEmps.Nodes);
                ClearDepartmentInfo();
                ClearEmployeInfo();
            }
        }

        /// <summary>
        /// Рекурсивное удаление узлов
        /// </summary>
        /// <param name="nodeCol"></param>
        private void RecursiveNodesDeleting(TreeNodeCollection nodeCol)
        {
            using (var dCrud = new Crud<Department>())
            {
                foreach (TreeNode item in nodeCol)
                {
                    var tag = item.Tag;
                    var dep = tag as Department;
                    if (item.Nodes.Count > 0)
                    {
                        RecursiveNodesDeleting(item.Nodes);
                    }
                    dCrud.Delete(dep);
                    nodeCol.Remove(item);
                }
            }
        }

        /// <summary>
        /// Обработчик кнопки удалить в контекстном меню сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsEmpDel_Click(object sender, EventArgs e)
        {
            var slctEmp = tvDepsAndEmps.SelectedNode.Tag as Employe;
            using (var empCrud = new Crud<Employe>())
            {
                empCrud.Delete(slctEmp);
                tvDepsAndEmps.Nodes.Remove(tvDepsAndEmps.SelectedNode);
            }
        }
    }
}