using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpmon
{
    /*
    - Name: His/Her name 

    - A list of Sharpmons

    - A private property to select the Current Sharpmon

    - A number of Sharpdollars to buy items 

    - A list of Items
    */
    
    class player
    {
        //Player name
        private string Name = "";

        //List of sharpmons
        public List<Sharpmon> Sharpdex = new List<Sharpmon>();

        //Current sharpmon
        private int Current_Sharpmon = 0;
        
        public Sharpmon EnemySharpmon;

        //money
        private int Sharpdollars = 1000;

        //Items
        public List<Item> Items = new List<Item>();

        //Constructor
        public player()
        {
            
        }

        //Set player name
        public void setName()
        {
            Console.Clear();

            //We handle exception if choice is out of range
            try
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("         PROFIL            ");
                Console.WriteLine("---------------------------");
                Console.WriteLine("Write your name here : ");
                Name = Console.ReadLine();
            }
            catch (Exception)
            {
                setName();
            }
        }


        //Get player name
        public String GetName()
        {
            return Name;
        }

        //Add new sharpmon into Sharpdex
        public void AddSharpmon(Sharpmon newSharpon)
        {
            Sharpdex.Add(newSharpon);
        }

        // Total sharpmons of player
        public int SharpmonCount()
        {
            return Sharpdex.Count();
        }

        //Retrieve All sharpmons of player
        /*public List<Sharpmon> AllSharpmons()
        {
            List<Sharpmon> MySharpmons = new List<Sharpmon>();

            MySharpmons = (from Asharpmon in Sharpdex
                          select Asharpmon).ToList();

            return MySharpmons;
        }*/

        public int GetCurrentSharpmon()
        {
            return Current_Sharpmon;
        }

        public void SetCurrentSharpmon(int sharpmonIndex)
        {
            Current_Sharpmon = sharpmonIndex;
        }

        public int GetSharpdollars()
        {
            return Sharpdollars;
        }

        public void AddSharpdollars(int Addmoney)
        {
            Sharpdollars += Addmoney;
        }

        public void ReduceSharpdollars(int Addmoney)
        {
            Sharpdollars -= Addmoney;
        }

        //Add new Item into Items
        public void AddItem(Item newItem)
        {
            Items.Add(newItem);
        }

        // Total Items of player
        public int ItemsCount()
        {
            return Items.Count();
        }

        //Retrieve All Items of player
        public List<Item> AllItems()
        {
            List<Item> MyItems = new List<Item>();

            MyItems = (from AItem in Items
                       select AItem).ToList();

            return MyItems;
        }
    }
}
