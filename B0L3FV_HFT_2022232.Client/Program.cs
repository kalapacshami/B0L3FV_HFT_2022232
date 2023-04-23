using B0L3FV_HFT_2022232.Models;
using B0L3FV_HFT_2022232.Repository;
using System;
using System.Linq;

namespace B0L3FV_HFT_2022232.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IRepository<Goblin> repo = new GoblinRepository(new GoblinDbContext());

            var items = repo.ReadAll().ToArray();
            
        }
    }
}
