using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Wpf_3.src;

namespace Wpf_3
{
    /// <summary>
    /// Логика взаимодействия для CreateToDO.xaml
    /// </summary>
    public partial class CreateToDO : Window
    {
        
        public CreateToDO()
        {
            InitializeComponent();
            //this.Owner.Title = "asdda"; - выдаст исключение
            DescriptionToDo.Text = "Описания нет";
            DateToDo.SelectedDate = DateTime.Today.AddDays(1);

            toDoList.Add(new ToDo("Родиться", new DateTime(2024, 01, 10), "Важно!"));
            toDoList.Add(new ToDo("Посадить сына", new DateTime(2024, 01, 11), "Важно!!"));
            toDoList.Add(new ToDo("Построить дерево", new DateTime(2024, 01, 12), "Важно!!!"));
            toDoList.Add(new ToDo("Вырастить дом", new DateTime(2024, 01, 13), "Важно!!!!"));
            toDoList.Add(new ToDo("умереть", new DateTime(2024, 01, 14), "Важно!!!!!"));
            RefreshToDoList();
            CheckboxEnableToDo_Unchecked(Owner, new RoutedEventArgs());
        }
        private void CheckboxEnableToDo_Unchecked(object sender, RoutedEventArgs e)
        {
            if (GroupBoxToDo == null || ButtonAdd == null) return;
            GroupBoxToDo.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Hidden;
        }

        private void CheckboxEnableToDo_Checked(object sender, RoutedEventArgs e)
        {
            if (GroupBoxToDo == null || ButtonAdd == null) return;
            GroupBoxToDo.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Visible;
            CreateToDO createToDO = new CreateToDO();
            createToDO.Show();
            createToDO.Owner = this;
            //this.Close();
        }
        private void RefreshToDoList()
        {
            ListToDo.ItemsSource = null;
            ListToDo.ItemsSource = toDoList;
        }
        private void ButtonAddToDo_Click(object sender, RoutedEventArgs e)
        {
            if (!DateToDo.SelectedDate.HasValue)
            {
                MessageBox.Show("Дата повесилась", Name = "Ошибка");
                return;
            }
            toDoList.Add(new ToDo(TitleToDo.Text,
                (DateTime)DateToDo.SelectedDate,
                DescriptionToDo.Text));
            TitleToDo.Text = null;
            DescriptionToDo.Text = "Описания нет";
            RefreshToDoList();
        }
        private void ButtonRemoveToDo_Click(object sender, RoutedEventArgs e)
        {
            toDoList.Remove(ListToDo.SelectedItem as ToDo);
            RefreshToDoList();
        }
    }
}
