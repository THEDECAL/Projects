using System;
using System.Diagnostics;
using static EasyBilling.Models.IComponent;

namespace EasyBilling.Models
{
    public class PageComponent : IComponent
    {
        private ComponentActionRigths _actionRigths;

        public int Id { get; set; }

        virtual public ComponentActionRigths? ActionRigths
            { get => _actionRigths; }
        virtual public string Name { get; }

        public PageComponent(string name,
            ComponentActionRigths? actionRigths)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(name) && actionRigths != null)
                {
                    Name = name;
                    _actionRigths = actionRigths.Value;
                }
                else throw new NullReferenceException();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}