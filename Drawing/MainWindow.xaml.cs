using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace Drawing
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
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            for (int i = 301; i <= 400; i++)
            {

                lblNoLeft.Content = String.Format("No. {0}", i.ToString("D4"));
                lblNoLeft.Refresh();
                lblNoRight.Content = String.Format("No. {0}", i.ToString("D4"));
                lblNoRight.Refresh();

                RenderTargetBitmap renderTargetBitmap =
                new RenderTargetBitmap(Convert.ToInt32(this.Width), Convert.ToInt32(this.Height), 96, 96, PixelFormats.Pbgra32);
                renderTargetBitmap.Render(this);
                PngBitmapEncoder pngImage = new PngBitmapEncoder();
                pngImage.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
                //using (System.IO.Stream fileStream = File.Create(@"C:\Users\QC\Documents\Kangen Water\Tickets\Ticket" + i.ToString("D4") + ".png"))
                using (System.IO.Stream fileStream = File.Create(@"C:\Users\hslqng\Documents\Visual Studio 2017\Projects\TicketCreator\Drawing\Tickets\Ticket" + i.ToString("D4") + ".png"))
                {
                    pngImage.Save(fileStream);
                }
            }

        }
    }
    public static class ExtensionMethods
    {

        private static Action EmptyDelegate = delegate () { };


        public static void Refresh(this UIElement uiElement)
        {
            uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }
    }

}
