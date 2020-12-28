using System;
using System.Windows;
using WpfDemoHenJigg.Model;


namespace WpfDemoHenJigg.View
{
    /// <summary>
    /// Interaction logic for InfoEditView.xaml
    /// </summary>
    public partial class InfoEditView : Window
    {
        
        public InfoEditView(Student stu)
        {
            InitializeComponent();

            this.DataContext = new { StuInfo = stu };
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
