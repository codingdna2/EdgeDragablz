using HandyControl.Data;
using System.Windows;
using System.Windows.Controls;

namespace EdgeDragablz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonConfig_OnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            PopupConfig.IsOpen = true;
        }

        private void ButtonSkins_OnClick(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is Button button && button.Tag is SkinType tag)
            {
                PopupConfig.IsOpen = false;
                ((App)Application.Current).UpdateSkin(tag);
            }
        }
    }
}
