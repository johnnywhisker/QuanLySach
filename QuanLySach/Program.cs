using SimpleCMenu.Menu;
using System;

namespace QuanLySach
{
    class Program
    {
        static void exit() {
            Database.UpdateDatabase();
            Environment.Exit(69);           
        }
        static void Main(string[] args) {
            Database.UpdateDataset();
            Console.Clear();
            ConsoleMenu menu = new ConsoleMenu();
            string headerText = "  ____                              _                   _____                  _     " +
                Environment.NewLine + " / __ \\                            | |                 / ____|                | |    " +
                Environment.NewLine + "| |  | |  _   _    __ _   _ __     | |       _   _    | (___     __ _    ___  | |__  " +
                Environment.NewLine + "| |  | | | | | |  / _` | | '_ \\    | |      | | | |    \\___ \\   / _` |  / __| | '_ \\ " +
                Environment.NewLine + "| |__| | | |_| | | (_| | | | | |   | |____  | |_| |    ____) | | (_| | | (__  | | | |" +
                Environment.NewLine + " \\___\\_\\  \\__,_|  \\__,_| |_| |_|   |______|  \\__, |   |_____/   \\__,_|  \\___| |_| |_|" +
                Environment.NewLine + "                                              __/ |                                  " +
                Environment.NewLine + "                                             |___/                                   ";
            menu.Header = headerText;          
            menu.SubTitle = "\n-----------------------------------MENU---------------------------------------";
            menu.addMenuItem(1, "Them sach", Interface.addBook);
            menu.addMenuItem(2, "Xem tat ca sach", Interface.showAllBooks);
            menu.addMenuItem(3, "Tim kiem sach", Interface.findBook);
            menu.addMenuItem(4, "Sua thong tin sach", Interface.modifyBook);
            menu.addMenuItem(5, "Xoa sach", Interface.deleteBook);
            menu.addMenuItem(0, "Thoat",Program.exit);
            menu.showMenu();
            Console.ReadKey();
            
        }
    }
}
