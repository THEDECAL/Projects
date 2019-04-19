using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FoodBucket.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        MainWindow view;
        public ObservableCollection<Models.Recipe> Recipes { get; set; } = Models.FileManager.LoadRecipes();
        private CommandRelay addCmd;
        private CommandRelay editCmd;
        private CommandRelay delCmd;
        private CommandRelay toPDFCmd;
        private CommandRelay toDOCCmd;
        public CommandRelay AddCmd
        {
            get
            {
                return addCmd ?? (addCmd = new CommandRelay((o) =>
                {
                    Models.Recipe recipe = new Models.Recipe();

                    Views.RecipeWizard rw = new Views.RecipeWizard(recipe);
                    if (rw.ShowDialog() == true)
                    {
                        Recipes.Add(recipe);
                        Models.FileManager.SaveRecipes(Recipes);
                        UpdateFilters();
                    }
                }));
            }
        }
        public CommandRelay EditCmd
        {
            get
            {
                return editCmd ?? (editCmd = new CommandRelay((o) =>
                {
                    Models.Recipe originalRecipe = o as Models.Recipe;
                    Models.Recipe copyRecipe = new Models.Recipe(originalRecipe);

                    Views.RecipeWizard rw = new Views.RecipeWizard(copyRecipe);
                    if (rw.ShowDialog() == true)
                    {
                        originalRecipe.Copy(copyRecipe);
                        Models.FileManager.SaveRecipes(Recipes);
                        UpdateFilters();
                    }
                }));
            }
        }
        public CommandRelay DelCmd
        {
            get
            {
                return delCmd ?? (delCmd = new CommandRelay((o) =>
                {
                    Models.Recipe recipe = o as Models.Recipe;
                    Recipes.Remove(recipe);
                    Models.FileManager.SaveRecipes(Recipes);
                    UpdateFilters();
                }));
            }
        }
        public CommandRelay ToPDFCmd
        {
            get
            {
                return toPDFCmd ?? (toPDFCmd = new CommandRelay((o) =>
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "PDF Файлы (*.pdf)|*.pdf";
                    sfd.DefaultExt = "pdf";

                    if (sfd.ShowDialog() == true)
                    {
                        Models.FileManager.SaveToPDF(view.fwRecipe, sfd.FileName);
                        view.lbRecipes.SelectedIndex = -1;
                    }
                }));
            }
        }
        public CommandRelay ToDOCCmd
        {
            get
            {
                return toDOCCmd ?? (toDOCCmd = new CommandRelay((o) =>
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "DOC Файлы (*.doc)|*.doc";
                    sfd.DefaultExt = "doc";

                    if (sfd.ShowDialog() == true)
                    {
                        Models.FileManager.SaveToDOC(view.fwRecipe, sfd.FileName);
                        view.lbRecipes.SelectedIndex = -1;
                    }
                }));
            }
        }
        private List<string> filterTypes;
        private List<string> filterCountries;
        public List<string> FilterTypes
        {
            get
            {
                filterTypes = Recipes.Select(o => o.Type).Distinct().ToList();
                filterTypes.Insert(0, "");

                return filterTypes;
            }
        }
        public List<string> FilterCountries
        {
            get
            {
                filterCountries = Recipes.Select(o => o.Country).Distinct().ToList();
                filterCountries.Insert(0, "");
                
                return filterCountries;
            }
        }
        public MainWindowViewModel(MainWindow view)
        {
            this.view = view;
            view.lbRecipes.SelectionChanged += lbRecipes_SelectionChanged;
            view.btnSearchFilter.Click += (o, e) => { FilterAndSearch(); };
        }
        public void UpdateFilters()
        {
            OnPropertyChanged(nameof(FilterCountries));
            OnPropertyChanged(nameof(FilterTypes));
        }
        public void FilterAndSearch()
        {
            view.lbRecipes.ItemsSource = Recipes
                .Where(o => (view.cbFilterTypes.Text == "") ? true : o.Type == view.cbFilterTypes.Text)
                .Where(o => (view.cbFilterCountries.Text == "") ? true : o.Type == view.cbFilterCountries.Text)
                .Where(o => (view.tbSearch.Text == "") ? true : o.Name.ToLower().Contains(view.tbSearch.Text.ToLower()));
        }
        public void lbRecipes_SelectionChanged(object s, EventArgs e)
        {
            view.fwRecipe.Blocks.Clear();
            if (view.lbRecipes.SelectedIndex != -1)
            {
                var recipe = view.lbRecipes.SelectedItem as Models.Recipe;
                var p1 = new Paragraph();
                p1.Inlines.Add(new Run() { Text = $"{recipe.Name} ", FontSize = 20, FontWeight = FontWeights.Bold });
                p1.Inlines.Add(new Run() { Text = $"({recipe.Country})", FontSize = 16, FontWeight = FontWeights.Bold });
                p1.Inlines.Add(new LineBreak());
                p1.Inlines.Add(new Run() { Text = $"{recipe.Type}", FontSize = 18, Foreground = Brushes.Olive });
                view.fwRecipe.Blocks.Add(p1);

                var stackp = new StackPanel();
                foreach (var item in recipe.PathToImages)
                {
                    try
                    {
                        var border = new Border()
                        {
                            Height = 240,
                            Width = 320,
                            BorderBrush = Brushes.Black,
                            BorderThickness = new Thickness(2),
                            Padding = new Thickness(3),
                            Child = new Image()
                            {
                                Source = new BitmapImage(new Uri(item)),
                                Stretch = Stretch.Uniform
                            }
                        };
                        stackp.Children.Add(border);
                    }
                    catch (Exception) { }
                }
                view.fwRecipe.Blocks.Add(new BlockUIContainer() { Child = stackp });

                var p2 = new Paragraph();
                p2.Inlines.Add(new Run() { Text = "Ингридиенты:", FontSize = 16, FontWeight = FontWeights.Bold });

                var list = new List();
                foreach (var item in recipe.Ingredients)
                {
                    var line = new ListItem() { Blocks = { new Paragraph() { Inlines = { new Run()
                    {
                        Text = $"{item.Name} ({item.Count} {item.Unit})"
                    }}}}};
                    list.ListItems.Add(line);
                }
                view.fwRecipe.Blocks.Add(list);

                var p3 = new Paragraph();
                p3.Inlines.Add(new Run() { Text = recipe.Description } );
                view.fwRecipe.Blocks.Add(p3);
            }
        }
        public void OnPropertyChanged([CallerMemberName]string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
