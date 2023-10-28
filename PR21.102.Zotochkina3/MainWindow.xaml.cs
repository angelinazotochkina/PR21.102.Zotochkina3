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

namespace PR21._102.Zotochkina3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int N = int.Parse(txtSize.Text);
                int minRange = int.Parse(txtMinRange.Text);
                int maxRange = int.Parse(txtMaxRange.Text);

                int[] array = GenerateArray(N, minRange, maxRange);
                SortEvenOdd(array);

                txtResult.Text = string.Join(", ", array);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }
        private int[] GenerateArray(int N, int minRange, int maxRange)
        {
            Random random = new Random();
            int[] array = new int[N];

            for (int i = 0; i < N; i++)
            {
                array[i] = random.Next(minRange, maxRange + 1);
            }

            return array;
        }

        private void SortEvenOdd(int[] array)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left < right)
            {
                while (array[left] % 2 == 0 && left < right)
                {
                    left++;
                }

                while (array[right] % 2 != 0 && left < right)
                {
                    right--;
                }

                if (left < right)
                {
                    int temp = array[left];
                    array[left] = array[right];
                    array[right] = temp;
                }
            }
        }
    }
}


