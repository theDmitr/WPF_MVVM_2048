using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVVM_2048.Model
{
    public class Player
    {
        public string Name { get; init; }
        public string Score { get; set; }

        public Player(string name, string score)
        {
            Name = name;
            Score = score;
        }
    }
}
