using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Hide();

            string title = "Резюме";
            List<string> text = new List<string>();
            text.Add("Ф.И.О.: Звегинцев Никита Юрьевич\nДолжность: Системный администратор\nВозвраст: 28 лет");
            text.Add("Образование: С 06.2007 по 06.2010\nКомпьютерная Академия 'ШАГ'\nБезопасность компьютерных сетей и системное администрирование");
            text.Add($"Опыт работы:\nС 10.2017\nСпециалист группы поддержки отдела магистральных сетей\n\nC 08.2011 по 12.2016\nСистемный администратор интернет провайдера TernNET");
            text.Add(@"Навыки:
                    Личные качества: Целеустремленность, пунктуальность, трудолюбивость, аналитический склад ума, креативность, желание постоянно развиваться, умение работать в команде, дисциплинированность, исполнительность
                    Знание языков: Русский, Украинский, Английский: технический
                    ОС: Windows XP, Vista, 7, 8, 10; Windows Server 2003,2008; Linux(RedHat, Debian, Ubuntu, CentOS)
                    Программирование: C / C++, C#, SHELL
                    GIT: github.com/THEDECAL
                    БД: MYSQL, MSSQL
                    Гипервизоры: Xen, VMWare
                    Настройка управляемых коммутаторов: D - Link, Mikrotik, TP - Link
                    Приложения и сервисы linux: IPTABLES,IPSET,DHCPD,TFTPD,LAMP,NAGIOS,CACTI,ZABBIX,ARPWATCH,RSYSLOGD, BGP, PPTP, BIND, SQUID, APACHE
                    CMS: Joomla, WordPress, Drupal, OpenCart");

            for (int i = 0; i < text.Count; i++)
            {
                if (i == text.Count - 1)
                {
                    int avg = text.Sum(line => line.Length) / text.Count;
                    title = $"Cреднее число символово на страницу: {avg}";
                }
                MessageBox.Show(text[i], title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Close();
        }
    }
}
