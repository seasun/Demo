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
using Microsoft.Win32;

namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mediaMusic.LoadedBehavior = MediaState.Manual;
            this.Closing += new System.ComponentModel.CancelEventHandler(MainWindow_Closing);
            //this.ShowInTaskbar = false;//这个狠
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult mbr = MessageBox.Show("确定要关闭播放器？", "", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (mbr == MessageBoxResult.Cancel)
                e.Cancel = true;
        }

        private void selectMusic_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.InitialDirectory = @"G:\Seasun\Music";
            openDialog.Filter = "音频文件(*.mp3,*.wav)|*.mp3;*.wav";
            openDialog.ShowDialog();
            fileFullPath.Text = openDialog.FileName;
            try
            {
                mediaMusic.Source = new Uri(fileFullPath.Text);
            }
            catch (UriFormatException)
            {
                lbMes.Content = "无效的音频路径";
            }
            //为啥这事件没效
            openDialog.FileOk += new System.ComponentModel.CancelEventHandler(openDialog_FileOk);
        }

        void openDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(fileFullPath.Text))
            {
                mediaMusic.Play();
            }
            else
            {
                lbMes.Content = "请选择歌曲再操作";
            }
        }

        private void pause_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(fileFullPath.Text))
            {
                mediaMusic.Pause();
            }
            else
            {
                lbMes.Content = "请选择歌曲再操作";
            }
        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(fileFullPath.Text))
            {
                mediaMusic.Stop();
            }
            else
            {
                lbMes.Content = "请选择歌曲再操作";
            }
        }
    }
}
