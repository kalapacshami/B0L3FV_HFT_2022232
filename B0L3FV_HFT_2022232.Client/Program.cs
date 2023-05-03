using B0L3FV_HFT_2022232.Models;
using B0L3FV_HFT_2022232.Repository;
using System;
using System.Linq;
using B0L3FV_HFT_2022232.Logic;

namespace B0L3FV_HFT_2022232.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ctx = new GoblinDbContext();
            var repo = new GoblinRepository(ctx);
            var logic = new GoblinLogic(repo);

            var items = logic.ReadAll();
            ;
        }
    }
}
