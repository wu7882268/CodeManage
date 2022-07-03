using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Delegates
{
    public delegate void JumpDelegate(string ucName);
    public delegate void JumpDelegateObj(string ucName, object obj);
    public class Delegates
    {
        public static JumpDelegate JumpDelegate;
        public static JumpDelegateObj JumpDelegateObj;
    }
}
