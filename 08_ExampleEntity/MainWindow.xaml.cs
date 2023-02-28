﻿using _05_EF_example;
using _05_EF_example.Entities;
using Microsoft.EntityFrameworkCore;
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

namespace _08_ExampleEntity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AirplanesDbContext context = new AirplanesDbContext();
        public MainWindow()
        {
            InitializeComponent();         
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //dataGrid.ItemsSource = context.Flights.ToList();
            var c = context.Clients.Find(1);
            context.Entry(c).Collection(c => c.Flights).Load();
            dataGrid.ItemsSource = c.Flights;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = context.Clients.ToList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = context.Airpleins.ToList();
        }

        private void workerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
