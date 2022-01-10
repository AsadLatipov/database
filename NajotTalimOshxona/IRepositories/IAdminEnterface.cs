using System.Threading.Tasks;

namespace NajotTalimOshxona.IRepositories
{
    internal interface IAdminEnterface
    {
        public bool Password();

        public void Showmenu();

        public Task<bool> AddFoodAsync();

        public Task<bool> ChangeCostAsync();

        public Task<bool> ChangeFoodStatus();
    }
}
