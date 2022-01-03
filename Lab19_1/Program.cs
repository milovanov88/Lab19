using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача №19");
            List<Computer> Computers = new List<Computer>()
            {
                new Computer() {id="01", brand="Asus", processorType="AMD Ryzen 3", processorFrequency="3.5", RAM=8, hardDisk=1000, videoCard=8, price=100, quantity=10 },
                new Computer() {id="02", brand="HP", processorType="AMD Ryzen 5", processorFrequency="3.5", RAM=8, hardDisk=512, videoCard=8, price=120, quantity=15 },
                new Computer() {id="03", brand="LENOVO", processorType="AMD Ryzen 7", processorFrequency="3.7", RAM=8, hardDisk=256, videoCard=16, price=150, quantity=50 },
                new Computer() {id="04", brand="Dell", processorType="Intel Core i3", processorFrequency="4.0", RAM=8, hardDisk=256, videoCard=8, price=145, quantity=20 },
                new Computer() {id="05", brand="APPLE", processorType="Intel Core i5", processorFrequency="3.9", RAM=32, hardDisk=1000, videoCard=16, price=250, quantity=30 },
                new Computer() {id="06", brand="Intel", processorType="Intel Core i7", processorFrequency="4.0", RAM=32, hardDisk=512, videoCard=32, price=200, quantity=45 }
            };

            Console.WriteLine("Введите процессор компьютера");
            string processor = Console.ReadLine();
            List<Computer> Computer1 = Computers.Where(x => x.processorType == processor).ToList();
            Print(Computer1);

            Console.WriteLine("Введите требуемый объем оперативной памяти");
            int RAMSize = Convert.ToInt32(Console.ReadLine());
            List<Computer> Computer2 = Computers.Where(x => x.RAM >= RAMSize).ToList();
            Print(Computer2);

            Console.WriteLine("Список компьютеров по возрастанию цены");
            List<Computer> Computer3 = Computers.OrderBy(x => x.price).ToList();
            Print(Computer3);

            Console.WriteLine("Список компьютеров по типам процессоров");

            IEnumerable<IGrouping<string, Computer>> Computer4 = Computers.GroupBy(x => x.processorFrequency);
            foreach (IGrouping<string, Computer> gr in Computer4)
            {
                Console.WriteLine(gr.Key);
                foreach (Computer e in gr)
                {
                    Console.WriteLine($"{e.id} {e.brand} {e.processorType} {e.processorFrequency} {e.RAM} {e.hardDisk} {e.price} {e.quantity}"); ;
                }
            }
            Console.WriteLine("Самый дорогой компьютер");
            Computer Computer5 = Computers.OrderByDescending(x => x.price).FirstOrDefault();
            Console.WriteLine($"{Computer5.id} {Computer5.brand} {Computer5.processorType} {Computer5.processorFrequency} {Computer5.RAM} {Computer5.hardDisk} {Computer5.price} {Computer5.quantity}");

            Console.WriteLine("Самый бюджетный компьютер");
            Computer Computer6 = Computers.OrderBy(x => x.price).FirstOrDefault();
            Console.WriteLine($"{Computer6.id} {Computer6.brand} {Computer6.processorType} {Computer6.processorFrequency} {Computer6.RAM} {Computer6.hardDisk} {Computer6.price} {Computer6.quantity}");

            Console.WriteLine("Компьютеры в наличии более чем 30 штук");
            Console.WriteLine(Computers.Any(x => x.quantity >= 30));
            Console.ReadKey();

        }
        static void Print(List<Computer> Computers)
        {
            foreach (Computer e in Computers)
            {
                Console.WriteLine($"{e.id} {e.brand} {e.processorType} {e.processorFrequency} {e.RAM} {e.hardDisk} {e.price} {e.quantity}");
            }
            Console.WriteLine();
        }

    }
}