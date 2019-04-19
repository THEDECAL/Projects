using System;

namespace FoodBucket.ViewModels
{
    class RecipeWizardViewModel
    {
        Views.RecipeWizard view;
        public Models.Recipe Recipe { get; set; }
        private CommandRelay addIngCmd;
        private CommandRelay delIngCmd;
        private CommandRelay addImageCmd;
        private CommandRelay delImageCmd;
        private CommandRelay saveRecipeCmd;
        public CommandRelay AddIngCmd
        {
            get
            {
                return addIngCmd ?? (addIngCmd = new CommandRelay((o) =>
                {
                    var i = new Models.Ingredient();
                    Recipe.Ingredients.Add(i);
                    view.lbIngredients.SelectedItem = i;
                }));
            }
        }
        public CommandRelay DelIngCmd
        {
            get
            {
                return delIngCmd ?? (delIngCmd = new CommandRelay((o) =>
                {
                    Models.Ingredient i = o as Models.Ingredient;
                    Recipe.Ingredients.Remove(i);
                }));
            }
        }
        public CommandRelay AddImageCmd
        {
            get
            {
                return addImageCmd ?? (addImageCmd = new CommandRelay((o) =>
                {
                    ;
                    string path = o as String;
                    Recipe.PathToImages.Add(path);
                }));
            }
        }
        public CommandRelay DelImageCmd
        {
            get
            {
                return delImageCmd ?? (delImageCmd = new CommandRelay((o) =>
                {
                    string path = o as String;
                    Recipe.PathToImages.Remove(path);
                }));
            }
        }
        public CommandRelay SaveRecipeCmd
        {
            get
            {
                return saveRecipeCmd ?? (saveRecipeCmd = new CommandRelay((o) =>
                {
                    view.DialogResult = true;
                    view.Close();
                }));
            }
        }

        public RecipeWizardViewModel(Models.Recipe recipe, Views.RecipeWizard view)
        {
            Recipe = recipe;
            this.view = view;
            view.lbIngredients.SelectionChanged += lbIngredients_SelectionChanged;
        }
        public void lbIngredients_SelectionChanged(object s, EventArgs e)
        {
            if (view.lbIngredients.SelectedIndex != -1) view.gIngredientFields.IsEnabled = true;
            else view.gIngredientFields.IsEnabled = false;
        }
    }
}
