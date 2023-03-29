using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace olymph8
{
    /// <summary>
    /// Логика взаимодействия для АdministratorPage.xaml
    /// </summary>
    public partial class АdministratorPage : Page
    {
        public АdministratorPage()
        {
            InitializeComponent();
        }

        private void Click_Visibel_Menu(object sender, MouseButtonEventArgs e)
        {
            int Milliseconds = 250;
            DoubleAnimation MenuAnimation = new DoubleAnimation();
            if (ReferenceInfo.Width == 150)
            {
           

                MenuAnimation.From = 150;
                MenuAnimation.To = 0;
                MenuAnimation.Duration = TimeSpan.FromMilliseconds(Milliseconds);
                ReferenceInfo.BeginAnimation(Border.WidthProperty, MenuAnimation);
            }
            else
            {

                MenuAnimation.From = 0;
                MenuAnimation.To = 150;
                MenuAnimation.Duration = TimeSpan.FromMilliseconds(Milliseconds);
                ReferenceInfo.BeginAnimation(Border.WidthProperty, MenuAnimation);
            }


    
        }

        private void TextBlock_MouseMove(object sender, MouseEventArgs e)
        {
           
            
            ((TextBlock)sender).Opacity=0.7;
        }       
        private void TextBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            ((TextBlock)sender).Opacity = 1;
        }       
        private void Click_Lessons_plan(object sender, MouseEventArgs e)
        {
            //СurriculumPage
            //AdminFrame
            ReferenceInfo.Width = 0;
            AdminFrame.Content = new СurriculumPage();
          
        }


    }
}
