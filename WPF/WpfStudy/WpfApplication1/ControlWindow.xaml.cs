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
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// ControlWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ControlWindow : Window
    {
        public ControlWindow()
        {
            InitializeComponent();
            BindFontFamily();
        }

        /// <summary>
        /// 系统字体列表
        /// </summary>
        private void BindFontFamily()
        {
            List<TextBlock> fontsTB = new List<TextBlock>();
            foreach (var family in Fonts.SystemFontFamilies)
            {
                foreach (var fontName in family.FamilyNames)
                {
                    TextBlock tb = new TextBlock { Text = fontName.Value };
                    fontsTB.Add(tb);
                }
            }
            lbFontFamily.SetBinding(ListBox.ItemsSourceProperty, new Binding { Source = fontsTB });
        }
    }
}
