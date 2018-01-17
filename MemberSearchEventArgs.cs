using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CLRCore
{
    public class MemberSearchEventArgs : EventArgs
    {
        public MemberSearchEventArgs(BindingList<Member> members)
        {
            Members = members;
        }
        public BindingList<Member> Members { get; private set; }

    }
}
