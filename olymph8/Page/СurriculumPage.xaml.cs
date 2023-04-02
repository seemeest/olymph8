using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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

            //if (comboBox.SelectedItem.ToString() == "Добавить")
            //{
            //    Console.WriteLine("Add");
            //}

            //ComboBoxItem typeItem = (ComboBoxItem)comboBox.SelectedItem;
            //string value = typeItem.Content.ToString();


            //if (value == "Добавить")
            //{

               
            //}

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
                    InfoMen.Header = $" Debug_Info RowProperty= {textBox.GetValue(Grid.RowProperty)}  ColumnProperty= {textBox.GetValue(Grid.ColumnProperty)} ";

                    MenuItem DelAll=new MenuItem();
                    DelAll.Header = "удалить всё";
                    DelAll.Click += (ss, ee) =>
                    {
                        for (int jj = 0; jj < 10; jj++)
                        {
                            for (int ii = 0; ii < gridControl.Children.Count; ii++)
                            {
                                if (gridControl.Children[ii] is TextBox)
                                {

                                    gridControl.Children.RemoveAt(ii);

                                }
                            }
                        }
                    };

                    InfoMen.Background = new SolidColorBrush(Colors.Red);
                    InfoMen.Foreground = new SolidColorBrush(Colors.White);

                                 
                    MenuItem Copy = new MenuItem();
                    Copy.Header = "Копировать";
                    Copy.Command = ApplicationCommands.Copy;

                    MenuItem Past = new MenuItem();
                    Past.Header = "Вставить";
                    Past.Command = ApplicationCommands.Paste;
                    
                    MenuItem Cut = new MenuItem();
                    Cut.Header = "Стереть";
                    Cut.Command = ApplicationCommands.Cut;
                    MenuItem SelectAll = new MenuItem();
                    SelectAll.Header = "Выделить";
                    SelectAll.Command = ApplicationCommands.SelectAll;

                    //MenuItem DelRowsText = new MenuItem();
                    //DelRowsText.Header = "удалить текст";

                    //DelRowsText.Click += (ss, ee) =>
                    //{

                    //}




                    delColum.Click += (ss, ee) =>
                    {
                        removeChildrenRows(i);
                    };
                    contextmenu.Items.Add(InfoMen);

                    contextmenu.Items.Add(Copy);
                    contextmenu.Items.Add(Past);
                    contextmenu.Items.Add(Cut);
                    contextmenu.Items.Add(SelectAll);

                    contextmenu.Items.Add(delColum);
                    contextmenu.Items.Add(DelAll);
                    //contextmenu.Items.Add(DelRowsText);
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

                var textBoxesToRemove = gridControl.Children.OfType<TextBox>()
                    .Where(tb => tb.GetValue(Grid.RowProperty).ToString() == index1.ToString())
                    .ToList();

                foreach (var tb in textBoxesToRemove)
                {
                    gridControl.Children.Remove(tb);
                }

                if (Dorows > 2)
                {
                    Dorows--;
                }

                if (Otrows > 2)
                {
                    Otrows--;
                }

                Console.WriteLine(gridControl.Children.Count);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }

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


            comboBox.Items.Clear();

            List<string> list = controller.GetGroup();
            foreach (string item in list)
            {
                string Name = item.Replace('_', '-');
                ComboBoxItem comboBoxItem = new ComboBoxItem();
                comboBoxItem.Content = Name;
                comboBox.Items.Add(comboBoxItem);
            }

        }

       
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            Console.WriteLine(sender.ToString());
        }
    }
}
