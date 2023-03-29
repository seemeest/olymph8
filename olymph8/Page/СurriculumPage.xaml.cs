using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace olymph8
{
    /// <summary>
    /// Логика взаимодействия для СurriculumPage.xaml
    /// </summary>
    /// 

    public partial class СurriculumPage : Page
    {

        DataBaeController controller;
        public СurriculumPage()
        {
            InitializeComponent();
            controller= new DataBaeController();

          
            List<string> list = controller.GetGroup();
            foreach (string item in list)
            {
                string Name = item.Replace('_', '-');
                ComboBoxItem comboBoxItem = new ComboBoxItem();
                comboBoxItem.Content = Name;
                comboBox.Items.Add(comboBoxItem);
            }


        }

        private void comboBox_MouseDown(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

            if (comboBox.SelectedItem.ToString() == "Добавить")
            {
                Console.WriteLine("Add");
            }

            ComboBoxItem typeItem = (ComboBoxItem)comboBox.SelectedItem;
            string value = typeItem.Content.ToString();


            if (value == "Добавить")
            {

               
            }

        }
        int Otrows = 2;
        int Dorows = 2;
        int index = 0;
        private void GridController()
        {

            Random random = new Random();
            
            int columns = 9;
            

            for (int i = Otrows; i < Dorows; i++)
            {
                RowDefinition rowDefinition = new RowDefinition();
                rowDefinition.Height = GridLength.Auto;
                gridControl.RowDefinitions.Add(rowDefinition);
              
                for (int j = 0; j < columns; j++)
                {
                    index++;
                    TextBox textBox = new TextBox();
                    textBox.Height = 30;
                    textBox.BorderThickness = new Thickness(0.2f);
                    textBox.BorderBrush= new SolidColorBrush(Colors.Black);
                    textBox.SetValue(Grid.RowProperty, i);
                    textBox.Name= $"t{i}{j}{index}";
                    textBox.Text= random.Next().ToString();
                    textBox.SetValue(Grid.ColumnProperty, j);
                    



                    ContextMenu contextmenu = new ContextMenu();
                    textBox.ContextMenu= contextmenu;
                    MenuItem delColum= new MenuItem();
                    delColum.Header = "Удалить столбец";

              
                    MenuItem InfoMen = new MenuItem();
                    InfoMen.Header = $" {textBox.GetValue(Grid.RowProperty)} {textBox.GetValue(Grid.ColumnProperty)} ";

                    delColum.Click += (ss, ee) =>
                    {
                        
                        removeChildrenRows(i);
                      
                    };

                    contextmenu.Items.Add(delColum);
                    contextmenu.Items.Add(InfoMen);
                    gridControl.Children.Add(textBox); 

                }
            }
            Otrows++;


        }
        public void removeChildrenRows(int index1)
        {
            try
            {
              
                
                index1--;

                Console.WriteLine(index1);
                for (int j = 0; j < 10; j++) 
                    for (int i = 0; i < gridControl.Children.Count; i++)
                    {
                        if (gridControl.Children[i] is TextBox)
                        {
                            if (((TextBox)gridControl.Children[i]).GetValue(Grid.RowProperty).ToString() == index1.ToString()) 
                            {
                                gridControl.Children.RemoveAt(i);
                            }

                        }

                    }       
         
                    for (int i = 0; i < gridControl.Children.Count; i++)
                    {
                        if (gridControl.Children[i] is TextBox)
                        {

                            if (int.Parse(((TextBox)gridControl.Children[i]).GetValue(Grid.RowProperty).ToString()) > int.Parse(index1.ToString()))
                            {

                                
                                int value = int.Parse(((TextBox)gridControl.Children[i]).GetValue(Grid.RowProperty).ToString());
                                Console.WriteLine($"БОЛЬШЕ  {value}");
                                ((TextBox)gridControl.Children[i]).SetValue(Grid.RowProperty, value - 1);
                            }
                            

                        }

                    }
                Dorows--;
                Otrows--;
            }
             catch (Exception err) { Console.WriteLine(err); }
            //gridControl.RowDefinitions.RemoveAt(index1);
            Console.WriteLine(index1);

        }

        private void Button_Add_colum(object sender, RoutedEventArgs e)
        {
            Dorows++;
            GridController();
            Console.WriteLine(Dorows);
        }    
        private void Button_Save(object sender, RoutedEventArgs e)
        {
            Console.WriteLine($"Button_Save");
            string name,Term1, FK1, Sm_Work1, Term2, FK2, Sm_Work2, Teacher, Konsult,GroupName;
            name = Term1 = FK1 = Sm_Work1 = Term2 = FK2 = Sm_Work2 = Teacher = Konsult = GroupName = "";


            GroupName = GroupNameTB.Text.ToLower();
            GroupName= GroupName.Replace('-', '_');

            if (!controller.CreateTable(GroupName)) return;
            controller.removeData(GroupName);

           foreach (var item in gridControl.Children)
            {
                if(item is TextBox)
                {
                    if(((TextBox)item).Text==string.Empty) { ((TextBox)item).Text = "нет"; }
                    var  nameTb = ((TextBox)item).Name.ToString();
                    switch (nameTb[2]) {

                        case '0':
                        name = ((TextBox)item).Text;
                            Console.WriteLine(name);
                        break; case '1':
                        Term1 = ((TextBox)item).Text;
                            Console.WriteLine(Term1);
                            break; case '2':
                        FK1 = ((TextBox)item).Text;
                            Console.WriteLine(FK1);
                        break; case '3':
                        Sm_Work1 = ((TextBox)item).Text;
                            Console.WriteLine(Sm_Work1);
                        break; case '4':
                        Term2 = ((TextBox)item).Text;
                            Console.WriteLine(Term2);
                        break; case '5':
                        FK2 = ((TextBox)item).Text;
                            Console.WriteLine(FK2);
                        break; case '6':
                        Sm_Work2 = ((TextBox)item).Text;
                            Console.WriteLine(Sm_Work2);
                        break; case '7':
                        Teacher = ((TextBox)item).Text;
                            Console.WriteLine(Teacher);
                        break; case '8':
                        Konsult = ((TextBox)item).Text;
                            Console.WriteLine(Konsult);
                            controller.AddTta(name, Term1, FK1, Sm_Work1, Term2, FK2, Sm_Work2, Teacher, Konsult, GroupName);
                            break;

                    }

                }
            }

        }

       
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            Console.WriteLine(sender.ToString());
        }
    }
}
