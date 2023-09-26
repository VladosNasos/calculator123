using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace calculator123
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Путь к системному калькулятору
            string calcPath = @"C:\Windows\System32\calc.exe";
            
            // Проверяем, существует ли файл калькулятора
            if (System.IO.File.Exists(calcPath))
            {
                try
                {
                    // Запускаем калькулятор
                    Process.Start(calcPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при запуске калькулятора: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Файл калькулятора не найден.");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Закрываем все процессы калькулятора
            foreach (var process in Process.GetProcessesByName("Calculator"))
            {
                process.Kill();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                // Запускаем окно параметров
                Process.Start("control.exe", "desk.cpl");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии окна параметров: {ex.Message}");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            // Путь к диспетчеру задач
            string taskManagerPath = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\System Tools\Task Manager.lnk";

            // Проверяем, существует ли ярлык для диспетчера задач
            if (System.IO.File.Exists(taskManagerPath))
            {
                try
                {
                    // Запускаем диспетчер задач с помощью ярлыка
                    Process.Start(taskManagerPath, "Task Manager");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при открытии диспетчера задач: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Файл ярлыка для диспетчера задач не найден.");
            }
        }
    }
}
