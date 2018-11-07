using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практика
{
    class Program
    {
        static ModelEntity db = new ModelEntity();

        static void Main(string[] args)
        {
            Task2();
            Console.ReadLine();
        }

        static void Task1()
        {
            var areas = db.Area.Where(p => p.WorkingPeople != null && p.WorkingPeople > 2).Select(p => p.Name);
            foreach( var item in areas)
            {
                Console.WriteLine(areas);
            }
        }

        static void Task2()
        {
            var areas = from f in db.Area
                        where f.AssemblyArea == true
                        select f;
            foreach(var item in areas)
            {
                Console.WriteLine(item.Name);
            }
        }

        static void Task3()
        {
            var areas = db.Area.Take(10);
            foreach(var item in areas)
            {
                Console.WriteLine(item.Name);
            }
        }
        static void Task5_6()
        {
            var areas = db.Area.SkipWhile(p=>p.OrderExecution == null);//!= null
            foreach (var item in areas)
            {
                Console.WriteLine(item.Name);
            }
        }

        static void Task7()
        {
            var areas =
                db
                .Area
                .Where(p => db.Area.Where(w => w.IP == p.IP)
                .Count() == 1);
            foreach( var item in areas)
            {
                Console.WriteLine(item.Name + ": " + item.IP);
            }
        }

        static void Task8()
        {
            int[] nums = { 22, 23, 24, 25, 26, 27, 28};
            var timer = db.Timer.Where(p => p.AreaId != null && nums.ToList().Contains((int)p.AreaId));
        }

        static void Task9()
        {
            DateTime start = new DateTime(2017, 6, 1);
            DateTime end = new DateTime(2017, 8, 30);

            List<int> nums = new List<int>() {38, 39, 102 };
            var timer = db.Timer
                .Where(p => p.AreaId != null && nums.Contains((int)p.AreaId))
                .Where(p => p.DateFinish != null && p.DateFinish != DateTime.MinValue)
                .Where(p => p.DateStart >= start && p.DateFinish > end);
        }
    }
}
