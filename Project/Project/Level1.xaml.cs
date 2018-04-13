using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Project
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Level1 : Page
    {
        public Level1()
        {
            this.InitializeComponent();

            addBorders();

            //randomNum();
            //Ellipse el1 = createBlueCircles();
            //Ellipse el2 = createRedCircles();
        }

        private void addBorders() //Adapted from code given to us in labs
        {
            int row = 5;
            int size = 75;
            
            try
            {
               gridBoard.Children.Remove(FindName("ChessBoard") as Grid);
            }
            catch
            {
            }
            // create a grid object
            Grid grdBoard = new Grid();

            // give it a name, size, horizontal alignment, vertical align
            // give it background colour, margin of 5, Grid.row = 1
            grdBoard.Name = "ChessBoard";

            //Set vertical and horizontal allignment
            grdBoard.HorizontalAlignment = HorizontalAlignment.Center;
            grdBoard.VerticalAlignment = VerticalAlignment.Center;

            //Set the size of the squares
            grdBoard.Height = size * row;
            grdBoard.Width = size * row;
            
            //Set the background colour of the grid
            grdBoard.Background = new SolidColorBrush(Colors.Gray);

            grdBoard.SetValue(Grid.ColumnProperty, 1);
            grdBoard.SetValue(Grid.RowProperty, 1);

            // add row number of row definitions and column definitions
            for (int i = 0; i < row; i++)
            {
                grdBoard.RowDefinitions.Add(new RowDefinition());
                grdBoard.ColumnDefinitions.Add(new ColumnDefinition());
            }

            // add the gameboard to the root grid children collection
            gridBoard.Children.Add(grdBoard);

            // add a border object to each cell on the grid
            // to add one border
            // create the border object
            Border brdr; // don't put this in the loop

            int iR, iC;

            for (iR = 0; iR < row; iR++) // on each row
            {
                for (iC = 0; iC < row; iC++)  // for each col on that row
                {
                  
                    brdr = new Border();

                    // give it height, width, horizontal & vertical align in centre
                    brdr.Height = size * 0.98;
                    brdr.Width = size * 0.98;

                    // sq_R_C, no duplicates here 
                    brdr.Name = iR.ToString() + iC.ToString();

                    //Set the verical and horizontal alignment
                    brdr.HorizontalAlignment = HorizontalAlignment.Center;
                    brdr.VerticalAlignment = VerticalAlignment.Center;

                    // set the Grid.col, grid.row property
                    brdr.SetValue(Grid.RowProperty, iR);
                    brdr.SetValue(Grid.ColumnProperty, iC);

                    // give it a background colour
                    brdr.Background = new SolidColorBrush(Colors.Red);
                    if (0 == (iR + iC) % 2)
                    {
                        brdr.Background = new SolidColorBrush(Colors.Transparent);
                    }
                    // add it to the board children collection
                    grdBoard.Children.Add(brdr);
           
                } // end iC
            } // end iR
 
            
        }//End addBorders

        private static int randomNum()
        {
            Random rnd = new Random();
            int num = rnd.Next(1, 10);
            return num;
        }//End randomNum

        private static Ellipse createRedCircles()
        {
 
            Ellipse redEllipse = new Ellipse();
            redEllipse.Height = 50;
            redEllipse.Width = 50;
            redEllipse.StrokeThickness = 2;
            redEllipse.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
            redEllipse.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
            return redEllipse;
        }//End addRedCircles

        private static Ellipse createBlueCircles()
        {
            Ellipse blueEllipse = new Ellipse();
            blueEllipse.Height = 50;
            blueEllipse.Width = 50;
            blueEllipse.StrokeThickness = 2;
            blueEllipse.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
            blueEllipse.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
            return blueEllipse;
        }//End addBlueCircles

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }//End Button_Click
    }
}
