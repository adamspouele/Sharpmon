using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Net.Mime;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Sharpmon
{
    class Game
    {
        public player thePlayer = new player();
        public Items GameItems = new Items();

        private System.Media.SoundPlayer Music = new SoundPlayer();



        public void Init()
        {
            AllSharpmons.Sharpmons.Add(new Sharpasaur());
            AllSharpmons.Sharpmons.Add(new Sharpitle());
            AllSharpmons.Sharpmons.Add(new Sharpmender());
            AllSharpmons.Sharpmons.Add(new Sharpvidia());
            AllSharpmons.Sharpmons.Add(new Sharpidgey());
        }

        public void Welcome()
        {
            //Console.BackgroundColor = ConsoleColor.DarkYellow;

            Music.SoundLocation = Directory.GetCurrentDirectory() + @"\music.wav";
            Music.PlayLooping();

            Console.WriteLine("\n");
            Console.WriteLine("---------------------------");
            Console.WriteLine("         SHARPMON            ");
            Console.WriteLine("---------------------------");
        }

        public void Start()
        {
            //Initialize some datas..
            Init();
            //------

            int choice = 0;

            while (choice <= 0 || choice >= 3)
            {

                Console.WriteLine("Enter your name to start or exit:");
                Console.WriteLine("1 - Enter my name");
                Console.WriteLine("2 - Exit");

                //We handle exception if choice is out of range
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Start();
                }

                Console.Clear();
            }

            switch (choice)
            {
                case 1:
                    thePlayer.setName();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
                default:
                    Start();
                    break;
            }
        }

        public void FirstSharpmon()
        {
            //method which allow to choose our first sharpmon

            int choice;
            Console.Clear();
            Console.WriteLine("----------------------------------");
            Console.WriteLine("         FIRST SHARPMON            ");
            Console.WriteLine("----------------------------------");
            Console.WriteLine(thePlayer.GetName() + ", Choose your first sharpmon before get starting: ");
            
            Console.WriteLine("0: Sharpmender ");
            Console.WriteLine("1: Sharpasaur ");
            Console.WriteLine("2: Sharpitle");


            //We handle exception if choice is out of range
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        thePlayer.AddSharpmon(new Sharpmender());
                        break;
                    case 1:
                        thePlayer.AddSharpmon(new Sharpasaur());
                        break;
                    case 2:
                        thePlayer.AddSharpmon(new Sharpitle());
                        break;
                    default:
                        FirstSharpmon();
                        break;
                }
            }
            catch (Exception)
            {
                FirstSharpmon();
            }

            Console.WriteLine("You get "+thePlayer.Sharpdex[0].GetName()+".");
            Console.WriteLine("Press any key to continue.. ");
            Console.ReadLine();
        }


        public void IntoTheWild()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("         SEARCHING A SHARPMON...            ");
            Console.WriteLine("---------------------------------------");

            Console.WriteLine("Press any key to find a sharpmon.. ");
            Console.ReadLine();

            int val;
            Random rand = new Random();
            val = rand.Next(0, AllSharpmons.Sharpmons.Count);

            thePlayer.EnemySharpmon = AllSharpmons.Sharpmons[val];
            Console.WriteLine("you met a "+AllSharpmons.Sharpmons[val].GetName()+" !");

            Console.WriteLine("Choose your sharpmon from your sharpdex: ");

            for (int i = 0; i < thePlayer.Sharpdex.Count; i++)
            {
                Console.WriteLine(i+": "+thePlayer.Sharpdex[i].GetName());
            }

            try
            {
                int sharpchoice;
                sharpchoice = Convert.ToInt32(Console.ReadLine());

                if ((sharpchoice >= 0) && (sharpchoice < thePlayer.Sharpdex.Count))
                {
                    thePlayer.SetCurrentSharpmon(sharpchoice);
                    GameItems.setTarget(thePlayer.Sharpdex[thePlayer.GetCurrentSharpmon()]);
                }
                else
                {
                    Console.WriteLine(AllSharpmons.Sharpmons[val].GetName() + " fled !");
                    Console.WriteLine("Press any key to continue.. ");
                    Console.ReadLine();
                    IntoTheWild();
                }

            }
            catch (Exception)
            {
                Console.WriteLine(AllSharpmons.Sharpmons[val].GetName()+" fled !");
                Console.WriteLine("Press any key to continue.. ");
                Console.ReadLine();
                IntoTheWild();
            }

            Console.WriteLine("You chose "+thePlayer.Sharpdex[thePlayer.GetCurrentSharpmon()].GetName());
            Console.WriteLine("Press any key to continue.. ");
            Console.ReadLine();

            //Launch fight !
            FightSystem();
        }

        public void FightSystem()
        {
            Console.Clear();

            //If isPlayer = false so it's the enemy sharpmon turn
            bool isPlayer = false;

            while ((thePlayer.EnemySharpmon.GetHp() >= 1) && (thePlayer.Sharpdex[thePlayer.GetCurrentSharpmon()].GetHp() >=1))
            {
                
                Console.Clear();
                Console.WriteLine("-------------------------");
                Console.WriteLine("         FIGHT !            ");
                Console.WriteLine("-------------------------");

                Console.WriteLine("| "+thePlayer.EnemySharpmon.GetName()+"            |");
                Console.WriteLine("| HP: "+thePlayer.EnemySharpmon.GetHp()+"/"+thePlayer.EnemySharpmon.GetBaseHp() + "       Lvl: " + thePlayer.EnemySharpmon.GetExperience()+"|");
                Console.WriteLine("| Pow: " + thePlayer.EnemySharpmon.GetPower() + "         Def: " + thePlayer.EnemySharpmon.GetDefense() + "|");
                Console.WriteLine("| Acc: " + thePlayer.EnemySharpmon.GetAccuracy() + "          Dod: " + thePlayer.EnemySharpmon.GetDodge() + "|");
                Console.WriteLine("+-----------------------+");
                Console.WriteLine("| " + thePlayer.Sharpdex[thePlayer.GetCurrentSharpmon()].GetName() + "           |");
                Console.WriteLine("| HP: " + thePlayer.Sharpdex[thePlayer.GetCurrentSharpmon()].GetHp() + "/" + thePlayer.Sharpdex[thePlayer.GetCurrentSharpmon()].GetBaseHp() + "       Lvl: " + thePlayer.Sharpdex[thePlayer.GetCurrentSharpmon()].GetExperience() + "|");
                Console.WriteLine("| Pow: " + thePlayer.Sharpdex[thePlayer.GetCurrentSharpmon()].GetPower() + "         Def: " + thePlayer.Sharpdex[thePlayer.GetCurrentSharpmon()].GetDefense() + "|");
                Console.WriteLine("| Acc: " + thePlayer.Sharpdex[thePlayer.GetCurrentSharpmon()].GetAccuracy() + "          Dod: " + thePlayer.Sharpdex[thePlayer.GetCurrentSharpmon()].GetDodge() + "|");
                Console.WriteLine("+-----------------------+");
                
                

                if (isPlayer == false) //enemy turn
                {
                    Console.WriteLine(thePlayer.EnemySharpmon.GetName()+" begin !");

                    int attackchose;
                    Random rand = new Random();
                    attackchose = rand.Next(0, thePlayer.EnemySharpmon.Attacks.Count);
                    thePlayer.EnemySharpmon.Attacks[attackchose].TheEnemy = thePlayer.Sharpdex[thePlayer.GetCurrentSharpmon()];
                    thePlayer.EnemySharpmon.Attacks[attackchose].SelfSharpmon = thePlayer.EnemySharpmon;
                    thePlayer.EnemySharpmon.setExperience(thePlayer.Sharpdex[thePlayer.GetCurrentSharpmon()].GetExperience());  //Set Enemy's Experience to player's experience. 

                    Console.WriteLine(thePlayer.EnemySharpmon.GetName()+" launch "+thePlayer.EnemySharpmon.Attacks[attackchose].GetAttackName());

                    Console.WriteLine("This sharpmon has attacked.");

                    for (int i = 0; i < thePlayer.EnemySharpmon.Attacks[attackchose].getDamage(); i++)
                    {
                        thePlayer.EnemySharpmon.Attacks[attackchose].LaunchAttack();
                    }
                    

                }
                else //your turn
                {
                    Console.WriteLine("Your "+thePlayer.Sharpdex[thePlayer.GetCurrentSharpmon()].GetName() + " begin !");

                    int Choice = 0;
                    try
                    {
                        Console.WriteLine("What will you do ?");
                        Console.WriteLine("0: Attack");
                        Console.WriteLine("1: Change Sharpmon");
                        Console.WriteLine("2: Use Object");
                        Console.WriteLine("3: Capture");
                        Console.WriteLine("4: Run Away");

                        Choice = Convert.ToInt32(Console.ReadLine());
                        
                        switch (Choice)
                        {
                            case 0:
                                Console.WriteLine("Choose your attack: ");

                                for (int i = 0; i < thePlayer.Sharpdex[thePlayer.GetCurrentSharpmon()].Attacks.Count; i++)
                                {
                                    Console.WriteLine(i + ": " + thePlayer.Sharpdex[thePlayer.GetCurrentSharpmon()].Attacks[i].GetAttackName());
                                }

                                int attackchose = -1;
                                try
                                {
                                    
                                    attackchose = Convert.ToInt32(Console.ReadLine());

                                    if ((attackchose >= 0) && (attackchose < thePlayer.Sharpdex[thePlayer.GetCurrentSharpmon()].Attacks.Count))
                                    {
                                        thePlayer.Sharpdex[thePlayer.GetCurrentSharpmon()].Attacks[attackchose].TheEnemy = thePlayer.EnemySharpmon;
                                        thePlayer.Sharpdex[thePlayer.GetCurrentSharpmon()].Attacks[attackchose].SelfSharpmon = thePlayer.Sharpdex[thePlayer.GetCurrentSharpmon()];

                                        for (int i = 0; i < thePlayer.Sharpdex[thePlayer.GetCurrentSharpmon()].Attacks[attackchose].getDamage(); i++)
                                        {
                                            thePlayer.Sharpdex[thePlayer.GetCurrentSharpmon()].Attacks[attackchose].LaunchAttack();
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("You made an error !");
                                    }

                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("You made an error !");
                                }

                                Console.WriteLine(thePlayer.EnemySharpmon.GetName() + " launch " + thePlayer.EnemySharpmon.Attacks[attackchose].GetAttackName());
                                break;
                            case 1:
                                Console.WriteLine("Choose an other sharpmon: ");

                                for (int i = 0; i < thePlayer.Sharpdex.Count; i++)
                                {
                                    Console.WriteLine(i + ": " + thePlayer.Sharpdex[i].GetName());
                                }

                                try
                                {
                                    int sharpchoice;
                                    sharpchoice = Convert.ToInt32(Console.ReadLine());

                                    if ((sharpchoice >= 0) && (sharpchoice < thePlayer.Sharpdex.Count))
                                    {
                                        thePlayer.SetCurrentSharpmon(sharpchoice);
                                        GameItems.setTarget(thePlayer.Sharpdex[thePlayer.GetCurrentSharpmon()]);
                                    }
                                    else
                                    {
                                        Console.WriteLine("You made an error !");
                                    }
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("You made an error !");
                                    IntoTheWild();
                                }

                                Console.WriteLine("You chose " + thePlayer.Sharpdex[thePlayer.GetCurrentSharpmon()].GetName());
                                Console.WriteLine("Press any key to continue.. ");
                                Console.ReadLine();
                                break;
                            case 2:
                                if (thePlayer.Items.Count == 0)
                                {
                                    Console.WriteLine("You have no Item !");
                                    Console.WriteLine("Press any key to continue.. ");
                                    Console.ReadLine();
                                    break;
                                }
                                Console.WriteLine("My Items List:");
                                for (int i = 0; i < thePlayer.Items.Count; i++)
                                {
                                    Console.WriteLine(i + " - " + thePlayer.Items[i].Name+" Description: "+thePlayer.Items[i].Description);
                                }
                                int id;
                                Console.WriteLine("Enter the Item Id:");
                                try
                                {
                                    id = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine(thePlayer.Items[id].Name + " is used !");
                                    thePlayer.Items[id].Use();
                                    thePlayer.Items.RemoveAt(id);
                                    Console.WriteLine("Press any key to continue.. ");
                                    Console.ReadLine();
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("You made an error !");
                                    Console.WriteLine("Press any key to continue.. ");
                                    Console.ReadLine();
                                }
                                break;
                            case 3:
                                //Capture
                                //(Enemy MaxHP – HP) / 100 – 0.5 % chance
                                float capture = ((float)thePlayer.EnemySharpmon.GetBaseHp() - (float)thePlayer.Sharpdex[thePlayer.GetCurrentSharpmon()].GetHp()) / ((float) (100 - 0.5));

                                    if (capture > 0.05)
                                    {
                                        Sharpmon copySharpmon = null;

                                        foreach (var sharp in thePlayer.Sharpdex.Where(sharp => sharp.GetName() == thePlayer.EnemySharpmon.GetName()))
                                        {
                                            copySharpmon = sharp;
                                        }

                                    
                                        thePlayer.Sharpdex.Add((thePlayer.EnemySharpmon).Clone());
                                        Console.WriteLine("You had capture this sharpmon !");
                                        Console.WriteLine("Press any key to continue.. ");
                                        Console.ReadLine();
                                        Menu();
                                       
                                    }
                                    else
                                    {
                                        Console.WriteLine("You failed to capture this sharpmon.");
                                        Console.WriteLine("Press any key to continue.. ");
                                        Console.ReadLine();
                                    }
                                    
                                break;
                            case 4:
                                //Run Away 
                                //PlayerSharpmon / (PlayerSharpmon + EnemySharpmon) % chance
                                float runAway = (float)((float)(thePlayer.Sharpdex[thePlayer.GetCurrentSharpmon()].GetSpeed())/ (float)(thePlayer.Sharpdex[thePlayer.GetCurrentSharpmon()].GetSpeed() + thePlayer.EnemySharpmon.GetSpeed()));
                                
                                    if (runAway > 0.5)
                                    {
                                        Console.WriteLine("you fled !");
                                        Console.WriteLine("Press any key to continue.. ");
                                        Console.ReadLine();
                                        Menu();

                                    }
                                    else
                                    {
                                        Console.WriteLine("you failed to run away.");
                                        Console.WriteLine("Press any key to continue.. ");
                                        Console.ReadLine();
                                    }
                                
                                break;
                            default:
                                break;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Press any key to continue.. ");
                        Console.ReadLine();
                    }
                    
                }

                Console.ReadLine();
                
                //We change the player turn
                if (isPlayer == true)
                    isPlayer = false;
                else
                    isPlayer = true;
            }
            
            //If player loose
            if (thePlayer.Sharpdex[thePlayer.GetCurrentSharpmon()].GetHp() <= 0)
            {
                Console.WriteLine("You lost the fight..");
                Console.WriteLine("Press any key to continue.. ");
                thePlayer.EnemySharpmon = null;
                thePlayer.Sharpdex[thePlayer.GetCurrentSharpmon()].RestoreProperties();
                Console.ReadLine();

            }
            else if(thePlayer.EnemySharpmon.GetHp() <= 0)   //If computer loose
            {

                Console.WriteLine("You win the fight !");

                Random rand = new Random();
                Random rand2 = new Random();
                int earnedMoney = rand.Next(100, 500);
                thePlayer.AddSharpdollars(earnedMoney);
                Console.WriteLine("You win +"+earnedMoney+" $");

                int EnemyExp = thePlayer.EnemySharpmon.GetExperience();
                int earnedExp = 1;
                thePlayer.Sharpdex[thePlayer.GetCurrentSharpmon()].AddExperience(earnedExp);
                Console.WriteLine("Your sharpmon win +" + earnedExp + " Experience(s).");
                thePlayer.EnemySharpmon = null;
                Console.WriteLine("Press any key to continue.. ");
                Console.ReadLine();
            }


        }

        private void Shop()
        {
            Console.Clear();
            Console.WriteLine("-------------------------");
            Console.WriteLine("         SHOP            ");
            Console.WriteLine("-------------------------");
            Console.WriteLine("CREDITS: " + thePlayer.GetSharpdollars() + " $ \n\n");

            Console.WriteLine("Catalog: \n");
            
            for (int i = 0; i < GameItems.All.Count; i++)
            {
                Console.WriteLine(i+" - "+GameItems.All[i].Name+"\n Price: "+ GameItems.All[i].Price + " $ \n Description: " + GameItems.All[i].Description + "\n Sell Price: " + GameItems.All[i].SellPrice+" $ ");
                Console.WriteLine("\n");
            }

            Console.WriteLine("-------------------------");
            Console.WriteLine("1: Buy an Item");
            Console.WriteLine("2: Sale an Item");
            Console.WriteLine("3: Return to main menu");

            try
            {
                int choice;
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        int id;
                        Console.WriteLine("Enter the product Id:");
                        try
                        {
                            id = Convert.ToInt32(Console.ReadLine());

                            if (thePlayer.GetSharpdollars() < GameItems.All[id].Price)
                            {
                                Console.WriteLine("You have not enough money to buy this Item !");
                                Console.WriteLine("Press any key to continue.. ");
                                Console.ReadLine();
                                Shop();
                                break;
                            }

                            thePlayer.ReduceSharpdollars(GameItems.All[id].Price);
                            thePlayer.Items.Add(GameItems.All[id]);
                            Console.WriteLine(GameItems.All[id].Name+ " is bought.");

                            Console.WriteLine("Press any key to continue.. ");
                            Console.ReadLine();
                            Shop();
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("You made an error !");
                            Console.WriteLine("Press any key to continue.. ");
                            Console.ReadLine();
                            Shop();
                            break;
                        }
                        break;
                    case 2:
                        if (thePlayer.Items.Count == 0)
                        {
                            Console.WriteLine("You have no Item !");
                            Console.WriteLine("Press any key to continue.. ");
                            Console.ReadLine();
                            Shop();
                            break;
                        }

                        Console.WriteLine("My Items List:");
                        for (int i = 0; i < thePlayer.Items.Count; i++)
                        {
                            Console.WriteLine(i + " - " + thePlayer.Items[i].Name +"\n Sell Price: " + thePlayer.Items[i].SellPrice + " $ ");
                        }
                        int id2;
                        Console.WriteLine("Enter the product Id:");
                        try
                        {
                            id2 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(thePlayer.Items[id2].Name + " is sold.");
                            thePlayer.AddSharpdollars(thePlayer.Items[id2].SellPrice);
                            thePlayer.Items.RemoveAt(id2);
                            Console.WriteLine("Press any key to continue.. ");
                            Console.ReadLine();
                            Shop();
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("You made an error !");
                            Console.WriteLine("Press any key to continue.. ");
                            Console.ReadLine();
                            Shop();
                            break;
                        }
                        break;
                    case 3:
                        Menu();
                        break;
                    default:
                        Shop();
                        break;
                }
            }
            catch (Exception)
            {
                Shop();
            }
        }

        public void Centre()
        {

            int choice;
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("         SHARPMON CENTER            ");
            Console.WriteLine("---------------------------------\n");

            
            for (int i = 0; i < thePlayer.Sharpdex.Count; i++)
            {
                Console.WriteLine(i+" - "+thePlayer.Sharpdex[i].GetName()+" HP:"+thePlayer.Sharpdex[i].GetHp());
            }
            Console.WriteLine("\n");

            Console.WriteLine("What do you want ?");
            Console.WriteLine("0: Heal a sharpmon ");
            Console.WriteLine("1: Return to main menu ");

            try
            {
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        for (int i = 0; i < thePlayer.Sharpdex.Count; i++)
                        {
                            thePlayer.Sharpdex[i].RestoreProperties();
                        }
                        Console.WriteLine("All your sharpmons are healthy !");
                        Console.WriteLine("Press any key to continue.. ");
                        Console.ReadLine();
                        Centre();
                        break;
                    case 1:
                        Menu();
                        break;
                    default:
                        Centre();
                        break;
                }
            }
            catch (Exception)
            {
                Menu();
            }

            Console.ReadLine();
        }

        private void Menu()
        {

            int choice;
            Console.Clear();
            Console.WriteLine("-------------------------");
            Console.WriteLine("         MENU            ");
            Console.WriteLine("-------------------------");
            Console.WriteLine("CREDITS: "+thePlayer.GetSharpdollars()+" $ \n");
            Console.WriteLine("Hello " + thePlayer.GetName() + " !");
            Console.WriteLine("Welcome in Sharpmon world!\n");
            Console.WriteLine("Where do you want to go ?");
            Console.WriteLine("0: Into the wild ");
            Console.WriteLine("1: In the shop");
            Console.WriteLine("2: In the Sharpmon Center");
            Console.WriteLine("3: Exit game");
            

            //We handle exception if choice is out of range
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        Console.Clear();
                        IntoTheWild();
                        break;
                    case 1:
                        Shop();
                        break;
                    case 2:
                        Centre();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Menu();
                        break;
                }
            }
            catch (Exception)
            {
                Menu();
            }

        }

        public void Update()
        {
            Menu();
        }
    }
}
