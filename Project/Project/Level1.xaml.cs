﻿using System;
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
        int row = 5;
        int size = 75;

        public Level1()
        {
            this.InitializeComponent();

            addBorders();
            setupThePieces();

            //randomNum();
            //Ellipse el1 = createBlueCircles();
            //Ellipse el2 = createRedCircles();
        }

        private void addBorders() //Adapted from code given to us in labs
        {   
            
            // create a grid object
            Grid grdBoard = new Grid();

            // give it a name, size, horizontal alignment, vertical align
            // give it background colour, margin of 5, Grid.row = 1
            grdBoard.Name = "GridGame";

            //Set vertical and horizontal allignment
            grdBoard.HorizontalAlignment = HorizontalAlignment.Center;
            grdBoard.VerticalAlignment = VerticalAlignment.Center;

            //Set the size of the squares
            grdBoard.Height = size * row;
            grdBoard.Width = size * row;
            
            //Set the background colour of the grid
            grdBoard.Background = new SolidColorBrush(Colors.Transparent);

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
                    brdr.Background = new SolidColorBrush(Colors.Transparent);
                    if (0 == (iR + iC) % 2)
                    {
                        brdr.Background = new SolidColorBrush(Colors.Transparent);
                    }
                    // add it to the board children collection
                    grdBoard.Children.Add(brdr);
           
                } // end iC
            } // end iR
 
            
        }//End addBorders

        private void setupThePieces()
        {
            // check the size of board and decide how many cats, how many mice

            int numRed = 5;
            int numBlue = 20;
            Ellipse redEl;
            Ellipse blueEl;
            Grid board = FindName("GridGame") as Grid;

           
            
            int iR, iC;
            for (iR = 0; iR < row; iR++) // on each row
            {
                for (iC = 0; iC < row; iC++)  // for each col on that row
                {
                    for (int i = 0; i < numBlue; i++)
                    {
                        blueEl = new Ellipse();

                        //Give the elipse a name
                        blueEl.Name = "blue" + (i + 1).ToString();

                        //give the elipse a size
                        blueEl.Height = size * 0.85;
                        blueEl.Width = size * 0.85;

                        //Set the vertical and horizontal alignment
                        blueEl.HorizontalAlignment = HorizontalAlignment.Center;
                        blueEl.VerticalAlignment = VerticalAlignment.Center;

                        //Set a styling for the ellipse
                        blueEl.Fill = new SolidColorBrush(Colors.Blue);
                        blueEl.Stroke = new SolidColorBrush(Colors.Black);
                        blueEl.StrokeThickness = 2;

                        blueEl.SetValue(Grid.RowProperty, (iR));
                        blueEl.SetValue(Grid.ColumnProperty, iC);

                        //Add to the board
                        //cat.Tapped += El1_Tapped;
                        board.Children.Add(blueEl);
                    }
                
            }

            for (int i = 0; i < numRed; i++)
            {
               redEl = new Ellipse();

               //Give the elipse a name
               redEl.Name = "red" + (i + 1).ToString();

                    //give the elipse a size
                    redEl.Height = size * 0.85;
                    redEl.Width = size * 0.85;

                    //Set the vertical and horizontal alignment
                    redEl.HorizontalAlignment = HorizontalAlignment.Center;
                    redEl.VerticalAlignment = VerticalAlignment.Center;

                    //Set a colour for the ellipse
                    redEl.Fill = new SolidColorBrush(Colors.Red);
                    redEl.Stroke = new SolidColorBrush(Colors.Black);
                    redEl.StrokeThickness = 2;

                    int rand = randomNum(); //Generate a random number

                    redEl.SetValue(Grid.RowProperty, (rand * i)); //set the row randomly


                    redEl.SetValue(Grid.ColumnProperty, i * 2); //set the column

                    //cat.Tapped += El1_Tapped;
                    board.Children.Add(redEl);
                }






                //cat.Tapped += El1_Tapped;
                //board.Children.Add(blueEl);
            }


        }

        private static int randomNum()
        {
            Random rnd = new Random();
            int num = rnd.Next(1, 5);
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
