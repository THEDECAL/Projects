using System;
using System.Linq;

namespace EasyBilling.Models
{
    public interface IComponent
    {
        string Name { get; }
        ComponentActionRigths? ActionRigths { get; }

        struct ComponentActionRigths
        {
            public bool IsCreate { get; set; }
            public bool IsUpdate { get; set; }
            public bool IsDelete { get; set; }

            public string[] GetRightsNames()
            {
                var t = GetType();
                var fields = t.GetFields().Select(f =>
                    f.GetRawConstantValue().ToString());
                return fields?.ToArray();
            }
        }
    }
/*    [Flags]
    public enum ComponentName
    {
        ClientManage = 1,
        ClientOperationHistory,
        ClientTariffManage,

        UserSearch,
        UserManager,
        UserList,

        DeviceManager,
        DeviceSearch,
        DeviceList,

        EventSearch,
        EventManager,
        EventList,

        TariffManager,
        TariffList,

        APIKeyManager,
        APIKeyList,

        AccessAndPermissionsManager,
        AccessAndPermissionsList,

        FinancialOperationsSearch,
        FinancialOperationsManager,
        FinancialOperationsList
    };

    [Flags]
    public enum ComponentAction
    {
        Read,
        Create,
        Update,
        Delete
    }*/
}
