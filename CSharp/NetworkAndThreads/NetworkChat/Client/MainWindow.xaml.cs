using Client.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageLibrary;
using System.Globalization;

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static readonly string GENERAL_CHAT_NAME = "Общий";
        static readonly char[] TRIM_SYMBOLS = { ' ', '\t' };
        public ObservableCollection<string> Users { get; set; } = new ObservableCollection<string>();
        static readonly int SERVER_PORT = 10240;
        static readonly IPAddress SERVER_IP = IPAddress.Parse("127.0.0.1");
        static public string UserName { get; set; } = "";
        ChatClient _client = new ChatClient(SERVER_IP, SERVER_PORT);
        //Dictionary<string, string> _chatLisBoxNames = new Dictionary<string, string>();
        Dictionary<string, ObservableCollection<Message>> _chats = new Dictionary<string, ObservableCollection<Message>>();
        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            var userNameDialog = new UserNameDialog();
            while (!(bool)userNameDialog.ShowDialog()) { }

            this.Title += $" ({UserName})";

            AddTab(GENERAL_CHAT_NAME);

            _client.ReceiveMessageEvent += ReceiveMessage;
            _client.Connect(UserName);
        }
        private void ReceiveMessage(Message msg)
        {
            switch (msg.Type)
            {
                case MsgType.USER_ADD:
                    this.Dispatcher.BeginInvoke(new Action(() => Users.Add(msg.OwnerUserName)));
                    break;
                case MsgType.USER_DEL:
                    this.Dispatcher.BeginInvoke(new Action(() => Users.Remove(msg.OwnerUserName)));
                    break;
                case MsgType.MSG:
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        _chats[GENERAL_CHAT_NAME].Add(msg);
                    }));
                    break;
                case MsgType.PRIVATE_MSG:
                    //Если этот клиент получатель личного сообщения
                    if (msg.RecipientUserName == UserName || msg.OwnerUserName == UserName)
                    {
                        var tabName = (msg.RecipientUserName == UserName) ? msg.OwnerUserName : msg.RecipientUserName;
                        this.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            AddTab(tabName);
                            _chats[tabName].Add(msg);
                        }));
                    }
                    break;
            }
        }
        /// <summary>
        /// Создаёт новую вкладку
        /// </summary>
        /// <param name="tabName">Принимает заголовок вкладки</param>
        /// <returns>Возвращает true, если вкладки создана, иначе в случае существования вкладки с таким заголовком false</returns>
        private void AddTab(string tabName)
        {
            var tabKey = _chats.Keys.FirstOrDefault(k => k == tabName);

            if (tabKey == null)
            {
                _chats.Add(tabName, new ObservableCollection<Message>());

                tcGroups.Items.Add(new TabItem
                {
                    Header = new TextBlock { Text = tabName },
                    Content = new ListBox()
                    {
                        IsEnabled = false,
                        Padding = new Thickness(5),
                        ItemsSource = _chats[tabName],
                        ItemTemplate = Resources["MessageTemplate"] as DataTemplate
                    }
                });
                tcGroups.SelectedIndex = tcGroups.Items.Count - 1;
            }
        }
        /// <summary>
        /// Создаёт элемент LisBox для отображения сообщения
        /// </summary>
        /// <param name="msg">Приниает объект класса Message</param>
        /// <returns>Возвращает объект ListBoxItem</returns>
        private ListBoxItem CreateMessage(Message msg)
        {
            var tbOwner = new TextBlock() { FontSize = 10, Padding = new Thickness(0, 0, 0, 15), FontWeight = FontWeights.Bold, Text = msg.OwnerUserName };
            var tbDate = new TextBlock() { FontSize = 10, Padding = new Thickness(0, 0, 0, 15), FontWeight = FontWeights.Bold, Text = msg.Date.ToString("dd MMM HH:mm") };
            var tbText = new TextBlock() { TextWrapping = TextWrapping.Wrap, Text = msg.Text };
            Grid.SetRow(tbOwner, 0);
            Grid.SetRow(tbDate, 0);
            Grid.SetRow(tbText, 1);
            Grid.SetColumn(tbOwner, 0);
            Grid.SetColumn(tbDate, 1);
            Grid.SetColumn(tbText, 0);
            Grid.SetColumnSpan(tbText, 2);
            //var grid = new Grid()
            //{
            //    RowDefinitions = { new RowDefinition(), new RowDefinition() },
            //    ColumnDefinitions = { new ColumnDefinition(), new ColumnDefinition() },
            //    Children = { tbOwner, tbDate, tbText}
            //};

            var listBoxItem = new ListBoxItem()
            {
                VerticalContentAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = (msg.OwnerUserName == UserName) ? HorizontalAlignment.Right : HorizontalAlignment.Left,
                Width = 200,
                Content = new Border()
                {
                    CornerRadius = new CornerRadius(10),
                    Padding = new Thickness(10),
                    Background = (msg.OwnerUserName == UserName)
                    ? new SolidColorBrush(Color.FromArgb(25, 97, 123, 212))
                    : new SolidColorBrush(Color.FromArgb(25, 212, 97, 97)),
                    Child = new Grid()
                    {
                        RowDefinitions = { new RowDefinition(), new RowDefinition() },
                        ColumnDefinitions = { new ColumnDefinition(), new ColumnDefinition() },
                        Children = { tbOwner, tbDate, tbText }
                    }
                }
            };

            return listBoxItem;
        }
        private void MainWindow_Closed(object sender, EventArgs e)
        {
            _client.SendMessage(new Message() { Type = MsgType.USER_DEL, OwnerUserName = UserName});
            _client.Disconnect(UserName);
        }
        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (tbMessage.Text.Trim(TRIM_SYMBOLS) != "")
            {
                Message msg = null;
                var selectedTab = tcGroups.SelectedItem as TabItem;

                if (selectedTab != null)
                {
                    var tabTitle = selectedTab.Header as TextBlock;

                    if (tabTitle != null)
                    {
                        var tabName = tabTitle.Text;

                        msg = new Message()
                        {
                            Type = (tabName == GENERAL_CHAT_NAME) ? MsgType.MSG : MsgType.PRIVATE_MSG,
                            OwnerUserName = UserName,
                            RecipientUserName = (tabName == GENERAL_CHAT_NAME) ? null : tabName,
                            Text = tbMessage.Text
                        };
                    }
                }

                _client.SendMessage(msg);
                tbMessage.Text = "";
            }
        }
        /// <summary>
        /// Обработка события отправки сообщения по нажатию клавиши Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                btnSend_Click(null, null);
        }
        /// <summary>
        /// Обработка события двойного клика на пользователе для отправки личного сообщения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbUsers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var selectedUserName = lbUsers.SelectedItem as string;

                if (selectedUserName != null && selectedUserName != UserName)
                {
                    AddTab(selectedUserName);
                }
            }
        }
    }
}
