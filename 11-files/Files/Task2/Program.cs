using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Task2
{
    class Program
    {
        static FileSystemWatcher fsw;
        static string currentDirectory;
        static string backupDirectory;
        private enum Mode
        {
            Watcher,
            Rollback
        }
        static void ModeSelector(int mode)
        {
            if (Convert.ToInt32(Mode.Watcher) == mode)
            {
                using (fsw = new FileSystemWatcher(currentDirectory))
                {
                    fsw.IncludeSubdirectories = true;
                    fsw.Filter = "*.txt";
                    fsw.Changed += Fsw_Changed;
                    fsw.Created += Fsw_Created;
                    fsw.Deleted += Fsw_Deleted;
                    fsw.Renamed += Fsw_Renamed;
                    fsw.EnableRaisingEvents = true;
                    Console.WriteLine("Включён режим наблюдения");
                    Console.ReadLine();
                    Console.WriteLine("Режим наблюдения выключен");
                };
            }
            else if (Convert.ToInt32(Mode.Rollback) == mode)
            {
                Console.WriteLine("Включён режим отката изменений");
                Console.Write("Введите дату отката изменений: ");
                DateTime dateTime = Convert.ToDateTime(Console.ReadLine());
                DateTime maxDateTime = DateTime.MinValue;
                string pathToUpdate = currentDirectory;
                foreach (var path in Directory.GetDirectories(backupDirectory))
                {
                    DateTime dateTime1 = Directory.GetCreationTime(path);
                    if (dateTime1 < dateTime)
                    {
                        if (dateTime1 > maxDateTime)
                        {
                            maxDateTime = dateTime1;
                            pathToUpdate = path;
                        }
                    }
                }
                if (pathToUpdate != currentDirectory)
                {
                    Directory.Delete(currentDirectory, true);
                    Directory.CreateDirectory(currentDirectory);

                    foreach (string dirPath in Directory.GetDirectories(pathToUpdate, "*",
                    SearchOption.AllDirectories))
                    {
                        try
                        {
                            Directory.CreateDirectory(dirPath.Replace(pathToUpdate, currentDirectory));
                        }
                        catch { }
                    }

                    foreach (string newPath in Directory.GetFiles(pathToUpdate, "*.*",
                        SearchOption.AllDirectories))
                    {
                        try
                        {
                            File.Copy(newPath, newPath.Replace(pathToUpdate, currentDirectory), true);
                        }
                        catch { }
                    }
                }
            }
        }

        private static void Fsw_Renamed(object sender, RenamedEventArgs e)
        {
            fsw.EnableRaisingEvents = false;
            try
            {
                CreateBackup();
                Console.WriteLine($"Файл {e.Name} был переименован.");
            }
            finally
            {
                fsw.EnableRaisingEvents = true;
            }
        }

        private static void Fsw_Deleted(object sender, FileSystemEventArgs e)
        {
            fsw.EnableRaisingEvents = false;
            try
            {
                CreateBackup();
                Console.WriteLine($"Файл {e.Name} был удалён.");
            }
            finally
            {
                fsw.EnableRaisingEvents = true;
            }
        }

        private static void Fsw_Created(object sender, FileSystemEventArgs e)
        {
            fsw.EnableRaisingEvents = false;
            try
            {
                CreateBackup();
                Console.WriteLine($"Файл {e.Name} был создан.");
            }
            finally
            {
                fsw.EnableRaisingEvents = true;
            }
        }

        private static void Fsw_Changed(object sender, FileSystemEventArgs e)
        {
            fsw.EnableRaisingEvents = false;
            try
            {
                CreateBackup();
                Console.WriteLine($"Файл {e.Name} изменился.");
            }
            finally
            {
                fsw.EnableRaisingEvents = true;
            }
        }
        private static void CreateBackup()
        {
            string backupDirectoryNow = $@"{backupDirectory}\{DateTime.Now.Day}_{DateTime.Now.Month}_{DateTime.Now.Year}_{DateTime.Now.Hour}-{DateTime.Now.Minute}-{DateTime.Now.Second}";
            Directory.CreateDirectory(backupDirectoryNow);
            foreach (string dirPath in Directory.GetDirectories(currentDirectory, "*",
                SearchOption.AllDirectories))
            {
                try
                {
                    Directory.CreateDirectory(dirPath.Replace(currentDirectory, backupDirectoryNow));
                }
                catch { }
            }


            foreach (string newPath in Directory.GetFiles(currentDirectory, "*.*",
                SearchOption.AllDirectories))
            {
                try
                {
                    File.Copy(newPath, newPath.Replace(currentDirectory, backupDirectoryNow), true);
                }
                catch { }
            }
        }
        static void Main(string[] args)
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appConfig.json");
            var config = configurationBuilder.Build();
            currentDirectory = config["CurrentDirectory"];
            backupDirectory = config["BackupDirectory"];
            string mode = "0";
            while (mode == "0" || mode == "1")
            {
                Console.Write("Выберите режим (0 - для наблюдения, 1 - для отката изменений): ");
                mode = Console.ReadLine();
                ModeSelector(Convert.ToInt32(mode));
            }
        }
    }
}
