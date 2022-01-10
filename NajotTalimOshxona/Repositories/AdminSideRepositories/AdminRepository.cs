using NajotTalimOshxona.Consists;
using NajotTalimOshxona.IRepositories;
using NajotTalimOshxona.Moduls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace NajotTalimOshxona.Repositories
{

    internal class AdminRepository : IAdminRepository
    {
        #region ShowMenu
        public void ShowMenu()
        {
            Console.WriteLine("|{0,3}|{1,10}|{2,10}|{3,10}|", "ID", "Name", "Cost", "IsActive");
            for (int i = 0; i < 24; i++)
                Console.Write("-");

            Console.WriteLine("\n");

            string json = File.ReadAllText(Paths.FoodsDbPath);
            IList<Food> foods = JsonConvert.DeserializeObject<IList<Food>>(json);

            int idx = 0;
            foreach (Food food in foods)
            {
                Console.WriteLine("|{0,3}|{1,10}|{2,10}|{3,10}|", $"{idx++}", $"{food.Name}", $"{food.Cost}", $"{food.IsActive}");
                for (int i = 0; i < 24; i++) Console.Write("-");
                Console.WriteLine("\n");
            }
        }
        #endregion

        #region ChangeCost
        public void ChangeCost(string foodName, double newCost)
        {
            string json = File.ReadAllText(Paths.FoodsDbPath);

            IList<Food> foods = JsonConvert.DeserializeObject<List<Food>>(json);

            foreach (var food in foods)
                if (food.Name == foodName)
                    food.Cost = newCost;

            File.WriteAllText(Paths.FoodsDbPath, JsonConvert.SerializeObject(foods));

        }
        #endregion

        #region AddFood
        public void AddFood(string foodName, double foodCost, string photoLink, string description)
        {
            string json = File.ReadAllText(Paths.FoodsDbPath);
            IList<Food> foods = JsonConvert.DeserializeObject<IList<Food>>(json);

            foods.Add(new Food { Name = foodName, Cost = foodCost, Photolink = photoLink, Description = description });

            File.WriteAllText(Paths.FoodsDbPath, JsonConvert.SerializeObject(foods));
        }
        #endregion

        #region ChangeFoodStatus
        public void ChangeFoodStatus(string foodName, bool status)
        {
            string json = File.ReadAllText(Paths.FoodsDbPath);

            IList<Food> foods = JsonConvert.DeserializeObject<List<Food>>(json);

            foreach (var food in foods)
                if (food.Name == foodName)
                    food.IsActive = status;

            File.WriteAllText(Paths.FoodsDbPath, JsonConvert.SerializeObject(foods));
        }
        public void ChangeFoodStatus(string foodName)
        {
            string json = File.ReadAllText(Paths.FoodsDbPath);

            IList<Food> foods = JsonConvert.DeserializeObject<List<Food>>(json);

            foreach (var food in foods)
                if (food.Name == foodName)
                    food.IsActive = true;

            File.WriteAllText(Paths.FoodsDbPath, JsonConvert.SerializeObject(foods));
        }
        #endregion

    }
}