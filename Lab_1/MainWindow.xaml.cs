using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
using Microsoft.Win32;

namespace Lab_1
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

        private void payment1_Click(object sender, RoutedEventArgs e)
        {
            ArrayList myAL = new ArrayList();
            int index;
            try
            {
                int itemCount = Convert.ToInt32(textBox.Text);

            Random rnd1 = new Random();
            int number;
            int[] mass = new int[itemCount];
            lbMain.Items.Clear();
            lbMain.Items.Add("Сгенерированный массив:");
            for (index = 1; index <= itemCount; index++)
            {
                number = -100 + rnd1.Next(200);
                mass[index-1] = number;
                myAL.Add(number);

                lbMain.Items.Add(number);
            }
            
                if (itemCount > 2)
                {
            
                    /* Вычисление количества чисел больших своих соседей */
                    int count=0;
                    lbMain.Items.Add("Количество чисел больших своих соседей:");
                    for (index = 1; index < itemCount-1; index++)
                    {
                        if (mass[index] > mass[index - 1] && mass[index] > mass[index + 1])
                        {
                            count++;
                        }
                    }
                    lbMain.Items.Add(count);
                    /* // */

                
                    /* Нахождение номера первого элемента, большего 25 */
                    int num25 = 0, account = 0, summ = 0;
                    for (index = 0; index < itemCount; index++)
                    {
                        if (account == 0 && mass[index] > 25)
                        {
                            num25 = index;
                            account = 1;
                        }

                        /* Сумма элементов, больших 2 элемента */
                        if (mass[index] > mass[1])
                        {
                            summ += mass[index];
                        }
                    }
                    if (account == 0)
                    {
                        lbMain.Items.Add("Нет элементов, больших 25");
                    }
                    else
                    {
                        lbMain.Items.Add("Номер первого элемента, большего 25:");
                        lbMain.Items.Add(num25 + 1);
                    }

                    lbMain.Items.Add("Сумма элементов, больших 2 элемента:");
                    lbMain.Items.Add(summ);
                    /* // */
                }
            }
            catch
            {
                textBox.Clear();
                MessageBox.Show("Ошибка: неверный тип вводимых данных!");
            }
        }

        private void payment2_Click(object sender, RoutedEventArgs e)
        {
            ArrayList myAL = new ArrayList();
            int index;
            try
            {
                int itemCount = Convert.ToInt32(textBox.Text);

            Random rnd1 = new Random();
            int number;
            lbMain.Items.Clear();
            lbMain.Items.Add("Исходный массив");
            for (index = 1; index <= itemCount; index++)
            {
                number = -100 + rnd1.Next(200);
                myAL.Add(number);

                lbMain.Items.Add(number);
            }
            myAL.Sort();
            lbMain.Items.Add("Отсортированный массив");
            foreach (int elem in myAL)
            {
                lbMain.Items.Add(elem);
            }

            }
            catch
            {
                textBox.Clear();
                MessageBox.Show("Ошибка: неверный тип вводимых данных!");
            }
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog myDialog = new SaveFileDialog();
            myDialog.Filter = "Текст(*.TXT)|*.TXT" + "|Все файлы (*.*)|*.* ";

            if (myDialog.ShowDialog() == true)
            {
                string filename = myDialog.FileName;
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename, false))
                {
                    foreach (Object item in lbMain.Items)
                    {
                        file.WriteLine(item);
                    }
                }
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
