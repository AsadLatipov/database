using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NajotTalimOshxona.IRepositories
{
    internal interface IAdminEnterface
    {
        public bool Password();
        public void Showmenu();
        public bool AddFood();
        public bool ChangeCost();
        public bool ChangeFoodStatus();
    }
}
