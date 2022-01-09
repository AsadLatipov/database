using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NajotTalimOshxona.IRepositories
{
    internal interface IAdminRepository
    {
        public void ShowMenu();
        public void ChangeFoodStatus(string foodName);
        public void ChangeCost(string foodName, double newCost);
        public void ChangeFoodStatus(string foodName, bool status);
        public void AddFood(string foodName, double foodCost, string photoLink, string description);

    }   
}