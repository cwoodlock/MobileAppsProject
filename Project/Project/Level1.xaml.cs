using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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

        private void addBorders()
        {
            int iR;
            int iC;

            for(iR =0;iR < 8; iR++)
            {
                for (iC = 0; iC < 8; iC++)
                {
                    Border b = new Border();
                    Border outOfBounds = new Border();

                    //To get the position of the pieces on the board we must name the positions
                    b.Name = iR.ToString() + "_" + iC.ToString();
                }
            }
            
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
