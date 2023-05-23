using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MVVM_2048.Commands;
using WPF_MVVM_2048.Models.Statistics;

namespace WPF_MVVM_2048.ViewModels
{
    public class GameEndViewModel
    {
        public static DialogEndCommand DialogEndCommand { get => new(HandleDialogEnd); }

        private static void HandleDialogEnd(string name)
        {
            
        }
    }
}
