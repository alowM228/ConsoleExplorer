using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _6_ConsoleExplorer
{
    internal class Class1
    {
        internal class Arrow_Menu
        {
            private int y_pos_cursor;
            private int y_pos_cursor_dop;

            public List<dynamic> DrewMenu(List<string> arr)
            {
                Console.SetCursorPosition(0, y_pos_cursor);
                Console.WriteLine("->");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    y_pos_cursor_dop = y_pos_cursor--;
                    if (y_pos_cursor < 0)
                    {
                        y_pos_cursor = arr.Count() - 1;
                    }
                    else if (y_pos_cursor > arr.Count() - 1)
                    {
                        y_pos_cursor = 0;
                    }
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    y_pos_cursor_dop = y_pos_cursor++;
                    if (y_pos_cursor < 0)
                    {
                        y_pos_cursor = arr.Count() - 1;
                    }
                    else if (y_pos_cursor > arr.Count() - 1)
                    {
                        y_pos_cursor = 0;
                    }
                }
                ClearArrow(y_pos_cursor_dop);
                List<dynamic> list = new List<dynamic>();
                list.Add(y_pos_cursor);
                list.Add(key);
                return (list);
            }
            private void ClearArrow(int y_pos_cursor_dop)
            {
                Console.SetCursorPosition(0, y_pos_cursor_dop);
                Console.Write("  ");
            }
        }

    }
}
