using System.Net.NetworkInformation;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;
//using System.Threading.Tasks;

namespace NetScan
{
    class CommandHelper
    {
        /// <summary>
        /// Принимает аргументы и на основе первого аргумента с помощью рефлексии выполняет функцию и передаёт ей аргументы
        /// </summary>
        /// <param name="args">Принимает параметры коммандной строки</param>
        public static void Run(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                //Приводит первый аргумент к прописным буквам, а первую букву к заглавной
                var commandName = char.ToUpper(args[0][0]) + args[0].Substring(1).ToLower();

                var commandHelper = new CommandHelper();
                var type = commandHelper.GetType();
                var method = type.GetMethod(commandName);

                method.Invoke(commandHelper, new object[] { args });
            }
        }
        public static void Nics(string[] args)
        {
            var netConfigs = NetworkInterface.GetAllNetworkInterfaces()
                ?.Where(nic =>
                    nic.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                    nic.OperationalStatus != OperationalStatus.Down)
                ?.Select(nic => 
                {
                    var props = nic.GetIPProperties();
                    
                    return new
                    {
                        nic.Name,
                        nic.NetworkInterfaceType,
                        MAC = Regex.Replace(
                            nic.GetPhysicalAddress().ToString(),
                            "([0-9A-Fa-f]{2})([0-9A-Fa-f]{2})([0-9A-Fa-f]{2})([0-9A-Fa-f]{2})([0-9A-Fa-f]{2})",
                            "$1:$2:$3:$4:$5:"
                        ),
                        Speed = $"{nic.Speed / 1000000}Мбит",
                        UnicastAddresses = props.UnicastAddresses.ToList(),
                        GatewayAddresses = props.GatewayAddresses.ToList()
                    };
                })
                ?.Where(addrs => addrs.GatewayAddresses.Count > 0)
                .ToList();

            netConfigs.ForEach(cfg => {
                var type = cfg.GetType();
                var mbrs = type.GetMembers()
                    ?.Where(mbr => mbr.MemberType == System.Reflection.MemberTypes.Property)
                    .ToList();
                mbrs.ForEach(mbr =>
                {
                    var rtype = mbr.ReflectedType;
                    var prop = rtype.GetProperty(mbr.Name);
                    dynamic val = prop.GetValue(cfg, null);

                    if(prop.PropertyType == typeof(List<UnicastIPAddressInformation>) || prop.PropertyType == typeof(List<GatewayIPAddressInformation>))
                        foreach (var item in val)
                        {
                            Console.WriteLine(item.Address);
                        }
                    else
                        Console.WriteLine($"{mbr.Name}: {val}");
                 });
            });
        }
        public static void Checkport(string[] args)
        {
            if (args.Length > 1)
            {
                var ipArg = args[1];

                try
                {
                    var ip = IPAddress.Parse(ipArg);
                    var taskPool = new List<Task>();
                    var portCount = 65536;

                    Action<object> action = (port) =>
                    {
                        const int connRetries = 2;
                        for (int j = 0; j < connRetries; j++)
                        {
                            try
                            {
                                var tcpClient = new TcpClient();
                                tcpClient.Connect(ip, (int)port);
                                Console.WriteLine($"Порт {(int)port} открыт");
                                tcpClient.Close();

                                break;
                            }
                            catch (SocketException) { }
                        };
                    };

                    for (int i = 1; i < portCount; i++)
                    {
                        var task = new Task(action, i);
                        task.Start();
                        taskPool.Add(task);
                    }
                    //Task.WhenAll(taskPool).ab

                    //Task.WhenAll(taskPool).Wait();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Не верный формат IP-адреса.");
                }
            }
            else Console.WriteLine("Не достаточно аргументов.");
        }
    }
}
