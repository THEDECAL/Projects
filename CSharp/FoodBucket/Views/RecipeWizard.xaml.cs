using MahApps.Metro.Controls;

namespace FoodBucket.Views
{
    /// <summary>
    /// Логика взаимодействия для RecipeWizard.xaml
    /// </summary>
    public partial class RecipeWizard : MetroWindow
    {
        private RecipeWizard()
        {
            InitializeComponent();
        }
        public RecipeWizard(Models.Recipe recipe = null) : this()
        {
            DataContext = new ViewModels.RecipeWizardViewModel(recipe, this);
        }
    }
}
