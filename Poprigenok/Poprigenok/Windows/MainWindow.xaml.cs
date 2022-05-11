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
using System.Windows.Navigation;
using System.Windows.Shapes;
using _db = Poprigenok.Model.PoprigenokEntities;

namespace Poprigenok.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DgAgentsSales.ItemsSource = _db.GetContext().Agents.ToList();
        }

        /// <summary>
        /// Удаление агента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteAgents_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DgAgentsSales.SelectedCells.Count > 0)
                {
                    int id = DgAgentsSales.SelectedIndex;
                    Model.Agents agents = _db.GetContext().Agents.Find(id);
                    _db.GetContext().Agents.Remove(agents);
                    _db.GetContext().SaveChanges();

                    MessageBox.Show("Объект удален");
                    DgAgentsSales.ItemsSource = _db.GetContext().Agents.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        /// <summary>
        /// Переход на окно добавления агента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddAgents_Click(object sender, RoutedEventArgs e)
        {
            Windows.EditAgents editAgents = new Windows.EditAgents();
            editAgents.ShowDialog();
        }
        /// <summary>
        /// Переход на окно редактирования агента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEditAgents_Click(object sender, RoutedEventArgs e)
        {
            Windows.EditAgents editAgents = new Windows.EditAgents();
            editAgents.ShowDialog();
        }
    }
}
