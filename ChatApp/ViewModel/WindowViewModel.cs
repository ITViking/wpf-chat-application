using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChatApp.ViewModel
{
    public class WindowViewModel : BaseViewModel
    {
        private Window window;

        public string Test { get; set; } = "My littel test";

        public WindowViewModel(Window window)
        {
            this.window = window;
        }
    }
}
