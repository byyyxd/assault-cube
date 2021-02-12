using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memory;

namespace assaultcube
{
    class Program
    {

        public const string health = "ac_client.exe+0x0109B74,F8";
        public const string ammo = "ac_client.exe+0x0109B74,150";

        public static Mem memory = new Mem();
        public static void change_ammo(int amount)
        {
            memory.WriteMemory(ammo, "int", Convert.ToString(amount));
        }

        public static void change_health(int amount)
        {
            memory.WriteMemory(health, "int", Convert.ToString(amount));
        }

        static void Main(string[] args)
        {

            Console.Title = " ";
            int pid = memory.GetProcIdFromName("ac_client");
            if(pid > 0)
            {
                memory.OpenProcess(pid);
                // run
            }
            Console.WriteLine("pid: {0}", pid);
            Console.WriteLine("current ammo: {0}", memory.ReadInt(ammo));
            Console.WriteLine("current health: {0}", memory.ReadInt(health));
            Console.WriteLine("\nChoose your ammo amount:");
            string r = Console.ReadLine();
            Console.WriteLine("\nFreeze the ammo in " + r + "? [ YES / NO ]");
            string rr = Console.ReadLine();
            Console.WriteLine("\nChoose your health:");
            string healthR = Console.ReadLine();
            Console.WriteLine("\nFreeze the health in " + healthR + "? [ YES / NO ]");
            string healthrr = Console.ReadLine();
            if(rr == "yes")
            {
                Console.Clear();
                do
                {
                    change_ammo(Convert.ToInt32(r));

                    System.Threading.Thread.Sleep(137);
                } while (true);
                Console.WriteLine("sucessfully changed.");
                Console.WriteLine("\npid: {0}", pid);
                Console.WriteLine("current ammo: {0}", memory.ReadInt(ammo));
                Console.WriteLine("current health: {0}", memory.ReadInt(health));
            } else if(rr == "no")
            {
                Console.Clear();
                change_ammo(Convert.ToInt32(r));
                Console.WriteLine("sucessfully changed.");
                Console.WriteLine("\npid: {0}", pid);
                Console.WriteLine("current ammo: {0}", memory.ReadInt(ammo));
                Console.WriteLine("current health: {0}", memory.ReadInt(health));
            }

            if(healthrr == "yes")
            {
                Console.Clear();
                do
                {
                    change_health(Convert.ToInt32(r));

                    System.Threading.Thread.Sleep(137);
                } while (true);
                Console.WriteLine("sucessfully changed.");
                Console.WriteLine("\npid: {0}", pid);
                Console.WriteLine("current ammo: {0}", memory.ReadInt(ammo));
                Console.WriteLine("current health: {0}", memory.ReadInt(health));
            } else if (healthrr == "no")
            {
                Console.Clear();
                change_health(Convert.ToInt32(r));
                Console.WriteLine("sucessfully changed.");
                Console.WriteLine("\npid: {0}", pid);
                Console.WriteLine("current ammo: {0}", memory.ReadInt(ammo));
                Console.WriteLine("current health: {0}", memory.ReadInt(health));
            }

            System.Threading.Thread.Sleep(-1);
        }
    }
}
