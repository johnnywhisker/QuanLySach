using QuanLySach.ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySach
{
    class Interface
    {
        public static void showAllBooks()
        {
            Console.Clear();
            string title = "Danh sach sach";
            var table = new ConsoleTable("Ten", "Tac gia", "The loai", "Nam xuat ban", "Gia", "So Luong","Ma So");
            Console.WriteLine(String.Format("{0," + ((80 / 2) + (title.Length / 2)) + "}", title));

            foreach (Book book in Database.books)
            {
                Dictionary<string, string> processDictionary = book.getData();
                table.AddRow(
                processDictionary["name"],
                    processDictionary["author"],
                    processDictionary["category"],
                    processDictionary["year"],
                    processDictionary["price"] + " VND",
                    processDictionary["amount"],
                    processDictionary["code"]);
            }
            table.Write();
            Console.WriteLine();
            Console.Write("Bam phim bat ki de ve man hinh chinh.");
            Console.ReadKey();
        }
        public static void addBook()
        {
            Edit:
            try
            {
                Console.Write("Nhap vao ten sach :  ");
                string name = Console.ReadLine();
                Console.Write("Nhap vao tac gia :  ");
                string author = Console.ReadLine();
                Console.Write("Nhap vao the loai sach :  ");
                string category = Console.ReadLine();
                Console.Write("Nhap vao nam xuat ban :  ");
                string year = Console.ReadLine();
                Console.Write("Nhap vao gia sach :  ");
                string price = Console.ReadLine();
                if (price != "")
                {
                    float tempPrice = float.Parse(price);
                    price = tempPrice.ToString();
                }
                else {
                    throw new InvalidCastException();
                }
                Console.Write("Nhap vao so luong sach :  ");
                string amount = Console.ReadLine();
                if (amount != "")
                {
                    float tempAmount = float.Parse(amount);
                    amount = tempAmount.ToString();
                }
                else {
                    throw new InvalidCastException();
                }
                Console.Write("Nhap vao ma so sach: ");
                string code = Console.ReadLine();
                if (name == "" || author == "" || category == "" || year == ""|| code=="") {
                    throw new InvalidCastException();
                }
                Database.books.Add(new Book(name, author, category, year, float.Parse(price), int.Parse(amount),code));
            }
            catch
            {
                Console.Write("Gia tri khong hop le.Bam phim bat ki de nhap lai hoac bam 0 de huy");
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.D0 || key == ConsoleKey.NumPad0) {
                    return;
                } 
                Console.Clear();
                goto Edit;
            }

        }
        public static void findBook()
        {
            Console.Clear();
            Console.Write("Nhap vao thong tin sach can tim: ");
            string input = Console.ReadLine();
            Console.Clear();
            string title = "Danh sach ket qua tim kiem cho tu khoa ";
            var table = new ConsoleTable("Ten", "Tac gia", "The loai", "Nam xuat ban", "Gia", "So Luong","Ma So");
            Console.WriteLine(String.Format("{0," + ((80 / 2) + (title.Length / 2)) + "}\"{1}\"", title, input));
            foreach (Book book in Database.books)
            {
                if (book.isMe(input))
                {
                    Dictionary<string, string> processDictionary = book.getData();
                    table.AddRow(
                    processDictionary["name"],
                    processDictionary["author"],
                    processDictionary["category"],
                    processDictionary["year"],
                    processDictionary["price"] + " VND",
                    processDictionary["amount"],
                    processDictionary["code"]);
                }
            }
            table.Write();
            Console.WriteLine();
            Console.Write("Bam phim bat ki de ve man hinh chinh.");
            Console.ReadKey();
        }

        public static void modifyBook()
        {
            Console.Clear();
            Dictionary<string, string> processDictionary = null;
            int index = -1;
            Console.Write("Nhap vao ma so sach can sua: ");
            string input = Console.ReadLine();
            foreach (Book book in Database.books)
            {
                Dictionary<string, string> tempDic = book.getData();
                if (tempDic["code"] == input)
                {
                    index = Database.books.IndexOf(book);
                    processDictionary = tempDic;
                    break;
                }
            }
            if (processDictionary != null)
            {
                ConsoleTable info = new ConsoleTable(new ConsoleTableOptions
                {
                    EnableCount = false,
                    Columns = new[] { "Ten", "Tac gia", "The loai", "Nam xuat ban", "Gia", "So Luong","Ma So" }
                });
                info.AddRow(
                    processDictionary["name"],
                    processDictionary["author"],
                    processDictionary["category"],
                    processDictionary["year"],
                    processDictionary["price"] + " VND",
                    processDictionary["amount"],
                    processDictionary["code"]);
                Edit:
                Console.Clear();
                info.Write();

                try
                {
                    Console.Write("Nhap vao ten sach [{0}]:  ", processDictionary["name"]);
                    string name = Console.ReadLine();
                    Console.Write("Nhap vao tac gia [{0}]:  ", processDictionary["author"]);
                    string author = Console.ReadLine();
                    Console.Write("Nhap vao the loai sach [{0}]:  ", processDictionary["category"]);
                    string category = Console.ReadLine();
                    Console.Write("Nhap vao nam xuat ban [{0}]:  ", processDictionary["year"]);
                    string year = Console.ReadLine();
                    Console.Write("Nhap vao gia sach [{0}]:  ", processDictionary["price"]);
                    string price = Console.ReadLine();
                    if (price != "")
                    {
                        float tempPrice = float.Parse(price);
                        price = tempPrice.ToString();
                    }
                    Console.Write("Nhap vao so luong sach [{0}]:  ", processDictionary["amount"]);
                    string amount = Console.ReadLine();
                    if (amount != "")
                    {
                        float tempAmount = float.Parse(amount);
                        amount = tempAmount.ToString();
                    }
                    Console.Write("Nhap vao ma so sach: ");
                    string code = Console.ReadLine();
                    string[] modificationInfo = { name, author, category, year, price, amount,code};
                    Database.books[index].changeData(modificationInfo);
                }
                catch
                {
                    Console.Write("Gia tri khong hop le.Bam phim bat ki de nhap lai.");
                    Console.ReadKey();
                    Console.Clear();
                    goto Edit;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Khong tim thay sach cua co ma so: {0}. Bam phim bat ki de tro ve menu.", input);
                Console.ReadKey();
            }
        }
        public static void deleteBook()
        {
            Console.Clear();
            Dictionary<string, string> processDictionary = null;
            int index = -1;
            Console.Write("Nhap vao ma so sach can xoa: ");
            string input = Console.ReadLine();
            foreach (Book book in Database.books)
            {
                Dictionary<string, string> tempDic = book.getData();
                if (tempDic["code"] == input)
                {
                    index = Database.books.IndexOf(book);
                    processDictionary = tempDic;
                    break;
                }
            }
            if (processDictionary != null)
            {
                ConsoleTable info = new ConsoleTable(new ConsoleTableOptions
                {
                    EnableCount = false,
                    Columns = new[] { "Ten", "Tac gia", "The loai", "Nam xuat ban", "Gia", "So Luong","Ma So" }
                });
                info.AddRow(
                   processDictionary["name"],
                    processDictionary["author"],
                    processDictionary["category"],
                    processDictionary["year"],
                    processDictionary["price"] + " VND",
                    processDictionary["amount"],
                    processDictionary["code"]);
                Confirmation:
                Console.Clear();
                info.Write();
                Console.Write("Ban co chac chan muon xoa sach (y/n): ");
                string answer = Console.ReadLine();
                if (answer != "y" && answer != "n")
                {
                    Console.Clear();
                    Console.WriteLine("Khong hop le. Bam phim bat ki de nhap lai.");
                    Console.ReadKey();
                    Console.Clear();
                    goto Confirmation;
                }
                else
                {
                    if (answer == "y")
                    {
                        Database.books.RemoveAt(index);
                        Console.Clear();
                        Console.WriteLine("Xoa sach thanh cong. Bam phim bat ki de tro ve menu.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Huy xoa sach thanh cong. Bam phim bat ki de tro ve menu.");
                        Console.ReadKey();
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Khong tim thay sach cua co ma so: {0}. Bam phim bat ki de tro ve menu.", input);
                Console.ReadKey();
            }
        }
    }
}
