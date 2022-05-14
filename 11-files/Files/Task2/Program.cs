using System;
using System.IO;

namespace Task2
{
    class Program
    {
        static FileSystemWatcher fsw;
        static void ModeSelector(string mode)
        {
            if (mode == "1")
            {
                using (fsw = new FileSystemWatcher(Directory.GetCurrentDirectory()))
                {
                    fsw.Filter = "*.txt";
                    fsw.Changed += Fsw_Changed;
                    fsw.EnableRaisingEvents = true;
                    Console.WriteLine("Включён режим наблюдения");
                    Console.ReadLine();
                    Console.WriteLine("Режим наблюдения выключен");
                };
            }
            else if (mode == "2")
            {
                Console.WriteLine("Включён режим отката изменений");
                DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory());
                DirectoryInfo backup = new DirectoryInfo($@"{Directory.GetCurrentDirectory()}\Backup");

                FileInfo[] txtFiles = dir.GetFiles("*.txt");
                FileInfo[] bFiles = backup.GetFiles("*.txt");

                foreach (FileInfo f in txtFiles)
                {
                    Console.WriteLine("\n******************\n");
                    Console.WriteLine("Имя файла: " + f.Name);
                    Console.WriteLine("Время последнего изменения файла: " + f.LastWriteTime);
                }

                Console.WriteLine();
                Console.Write("Введите дату отката изменений: ");
                DateTime dateTime = Convert.ToDateTime(Console.ReadLine());
                foreach (FileInfo f in txtFiles)
                {
                    string curName = null;
                    var cur = f;
                    bool sw = false;
                    foreach (FileInfo f2 in bFiles)
                    {
                        if (f2.Name.Contains(f.Name))
                        {
                            if (curName == null && dateTime.CompareTo(f2.LastWriteTime) > -1)
                            {
                                curName = f2.Name;
                                cur = f2;
                            }

                            if (dateTime.CompareTo(f2.LastWriteTime) > -1 && cur.LastWriteTime.CompareTo(f2.LastWriteTime) < 1)
                            {
                                curName = f2.Name;
                                cur = f2;
                                sw = true;
                            }
                        }
                    }

                    if (cur != f && sw)
                    {
                        File.Copy(cur.FullName, f.FullName, true);
                        Console.WriteLine($"Файл {f.Name} изменён на {cur.Name}");
                    }
                    else
                    {
                        f.Delete();
                        Console.WriteLine($"Файл {f.Name} был удалён");
                    }
                    curName = null;
                }
            }
        }
        static void Main(string[] args)
        {
            string mode = "1";
            while (mode == "1" || mode == "2")
            {
                Console.Write("Выберите режим (1 - для наблюдения, 2 - для отката изменений): ");
                mode = Console.ReadLine();
                ModeSelector(mode);
            }
        }

        private static void Fsw_Changed(object sender, FileSystemEventArgs e)
        {
            fsw.EnableRaisingEvents = false;
            try
            {
                string dateTimeNow = $"{DateTime.Now.Day}_{DateTime.Now.Month}_{DateTime.Now.Year}_{DateTime.Now.Hour}-{DateTime.Now.Minute}-{DateTime.Now.Second}";
                File.Copy(e.Name, $@"{Directory.GetCurrentDirectory()}\Backup\{dateTimeNow}{e.Name}");
                Console.WriteLine($"Файл {e.Name} изменился");
            }
            finally
            {
                fsw.EnableRaisingEvents = true;
            }
        }
    }
}
