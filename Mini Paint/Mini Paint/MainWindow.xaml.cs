using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mini_Paint
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
        public InkCanvas canvas { get; set; }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            string str = ((RadioButton)sender).Content.ToString();
            switch (str)
            {
                case "Red":
                    Ink.DefaultDrawingAttributes.Color = Colors.Red;
                    break;
                case "Green":
                    Ink.DefaultDrawingAttributes.Color = Colors.Green;
                    break;
                case "Blue":
                    Ink.DefaultDrawingAttributes.Color = Colors.Blue;
                    break;
                case "Magenta":
                    Ink.DefaultDrawingAttributes.Color = Colors.Magenta;
                    break;
            }
        }

        private void Mode_Checked(object sender, RoutedEventArgs e)
        {
            string str = ((RadioButton)sender).Content.ToString();
            InkCanvasEditingMode Edit = (InkCanvasEditingMode)Enum.Parse(typeof(InkCanvasEditingMode), str);
            Ink.EditingMode = Edit;
        }

        private void Shape_Checked(object sender,RoutedEventArgs e)
        {
            string str = ((RadioButton)sender).Content.ToString();
            StylusTip style = (StylusTip)Enum.Parse(typeof(StylusTip),str);
            Ink.DefaultDrawingAttributes.StylusTip = style;
        }

        private void Size_Checked(Object sender,RoutedEventArgs e)
        {
            string str = ((RadioButton)sender).Content.ToString();
            //Ink.DefaultDrawingAttributes.Height = 30;
            //Ink.DefaultDrawingAttributes.Width = 30;
            switch (str)
            {
                case "Small":
                    Ink.DefaultDrawingAttributes.Height = 2;
                    Ink.DefaultDrawingAttributes.Width = 2;
                    break;
                case "Normal":
                    Ink.DefaultDrawingAttributes.Height = 15;
                    Ink.DefaultDrawingAttributes.Width = 15;
                    break;
                case "Large":
                    Ink.DefaultDrawingAttributes.Height = 30;
                    Ink.DefaultDrawingAttributes.Width = 30;
                    break;
            }
        }

        public StrokeCollection save;
        

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            save = Ink.Strokes.Clone();
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            Ink.Strokes.Clear();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            Ink.Strokes.Clear();
            Ink.Strokes.Add(save);
        }

        private void Paste_Click(object sender, RoutedEventArgs e)
        {
            Ink.Paste();
        }

        private void Cut_Click(object sender, RoutedEventArgs e)
        {
            Ink.CutSelection();
        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            Ink.CopySelection();
        }
    }
}
