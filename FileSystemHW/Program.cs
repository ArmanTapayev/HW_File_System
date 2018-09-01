using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Loger;

namespace FileSystemHW
{
    class Program
    {
        public static void MainMenu()
        {
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(new string('-', 80));
            Console.WriteLine("\t\tТема: Взаимодействие с файловой системой.");
            Console.WriteLine(new string('-', 80));
            Console.ForegroundColor = color;
            string pathDir = @"C:\Files";

            DirectoryInfo directory = new DirectoryInfo(pathDir);
            try
            {
                //DirectoryInfo directory = new DirectoryInfo(pathDir);
                if (!directory.Exists)
                {
                    directory.Create();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Создана директория {0} ",directory.FullName);
                    Console.ForegroundColor = color;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            bool inProgress = true;

            while (inProgress)
            {
                Console.ForegroundColor = color;
                ConsoleColor color1 = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(new string('-', 80));
                Console.WriteLine("" +
                    "1. Задание 1. Программа \"Loger\"\n" +
                    "2. Задание 2. Числа Фибоначчи\n" +
                    "3. Задание 3. Сложить два целых числа А и В.\n" +
                    "4. Задание 4. Подсчитать количество символов\n" +
                    "5. Выход\n");
                Console.WriteLine(new string('-', 80));
                Console.Write("> ");
                Console.ForegroundColor = color1;

                int ch = 0;
                Int32.TryParse(Console.ReadLine(), out ch);
                switch (ch)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine(new string('-', 50));
                            Console.WriteLine("Задание 1. Программа \"Loger\".");
                            Console.WriteLine(new string('-', 50));

                            string logFilePath = @"C:\Files\log.dat";    // путь к log-файлу
                            string iniFilePath = @"C:\Files\config.ini";    // путь к ini-файлу

                            FileInfo file = new FileInfo(logFilePath);
                            FileInfo file2 = new FileInfo(iniFilePath);

                            LogFile[] logs = new LogFile[5];

                            logs[0] = new LogFile(DateTime.Now, message.Error, "User 1", "Сообщение: ошибка");
                            logs[1] = new LogFile(DateTime.Now, message.Exeption, "User 2", "Сообщение: исключение");
                            logs[2] = new LogFile(DateTime.Now, message.TestMessage, "User 3", "Сообщение: тестовое сообщение");
                            logs[3] = new LogFile(DateTime.Now, message.InfoMessage, "User 4", "Сообщение: информационое сообщение");
                            logs[4] = new LogFile(DateTime.Now, message.Warning, "User 5", "Сообщение: предупреждение");

                            Console.WriteLine(new string('-', 80));
                            Console.WriteLine("Запишем настройки конфигурации в файл {0}", file2.FullName);
                            // Настройки файла конфигурации
                            using (StreamWriter iniFile = new StreamWriter(File.Open(iniFilePath, FileMode.OpenOrCreate)))
                            {
                                iniFile.WriteLine("System.DateTime");
                                iniFile.WriteLine("Дата и время: ");
                                iniFile.WriteLine("Loger.message");
                                iniFile.WriteLine("Тип сообщения: ");
                                iniFile.WriteLine("System.String");
                                iniFile.WriteLine("Имя текущего пользователя: ");
                                iniFile.WriteLine("System.String");
                                iniFile.WriteLine("Текст сообщения: ");
                            }
                            Console.WriteLine("Считаем настройки конфигурации из файла {0}", file2.FullName);
                            Console.WriteLine(new string('-', 80));
                            using (StreamReader f = new StreamReader(iniFilePath))
                            {
                                Console.WriteLine(f.ReadToEnd());
                            }
                            Console.WriteLine(new string('-', 80));
                            try
                            {
                                // создаем объект StreamWriter
                                Console.WriteLine("Запишем данные в файл {0}", file.FullName);
                                using (StreamWriter writer = new StreamWriter(File.Open(logFilePath, FileMode.OpenOrCreate)))
                                {
                                    using (StreamReader iniFile = new StreamReader(File.Open(iniFilePath, FileMode.Open)))
                                    {
                                        string[] arrayIniFile = new string[8];
                                        string line;
                                        int count = 0;
                                        while ((line = iniFile.ReadLine()) != null)
                                        {
                                            arrayIniFile[count++] = line;
                                        }
                                        foreach (LogFile item in logs)
                                        {
                                            if (arrayIniFile[0] == item.DateTimeData.GetType().ToString())
                                            {
                                                writer.Write(arrayIniFile[1]);
                                                writer.WriteLine(item.DateTimeData);
                                            }

                                            if (arrayIniFile[2] == item.MessageType.GetType().ToString())
                                            {
                                                writer.Write(arrayIniFile[3]);
                                                writer.WriteLine(item.MessageType);
                                            }

                                            if (arrayIniFile[4] == item.Name.GetType().ToString())
                                            {
                                                writer.Write(arrayIniFile[5]);
                                                writer.WriteLine(item.Name);
                                            }

                                            if (arrayIniFile[6] == item.MessageText.GetType().ToString())
                                            {
                                                writer.Write(arrayIniFile[7]);
                                                writer.WriteLine(item.MessageText);
                                            }

                                        }
                                    }

                                }
                                Console.WriteLine("Считаем данные из файла {0}", file.FullName);
                                using (StreamReader reader = new StreamReader(logFilePath, Encoding.UTF8))
                                {
                                    string text;
                                    text = reader.ReadToEnd();
                                    Console.WriteLine(new string('-', 80));
                                    Console.WriteLine("\t\t\t\tИнформация log-файла");
                                    Console.WriteLine(new string('-', 80));
                                    Console.WriteLine(text);
                                    Console.WriteLine(new string('-', 80));
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }

                        }
                        break;
                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine(new string('-', 50));
                            Console.WriteLine("Задание 2. Числа Фибоначчи");
                            Console.WriteLine(new string('-', 50));

                            string path = @"C:\Files\fibonchi.dat";

                            Console.Write("Введите количество чисел в последовательности: ");
                            int n = Convert.ToInt32(Console.ReadLine());

                            FileInfo file = new FileInfo(path);

                            byte[] f = new byte[n];

                            Console.WriteLine("Запишем данные в файл {0}", file.FullName);
                            using (FileStream fs = new FileStream(path, FileMode.Create))
                            {
                                for (int i = 0; i < n; i++)
                                {
                                    Console.Write("{0} ", Fibonachi(i));
                                    f = Encoding.Default.GetBytes(Convert.ToString(Fibonachi(i)) + " ");
                                    fs.Write(f, 0, f.Length);

                                }
                                Console.WriteLine();

                            }

                            Console.WriteLine("Допишем еще {0} чисел последовательности в файл {1}: ", n, file.FullName);

                            using (FileStream fs = new FileStream(path, FileMode.Append))
                            {
                                int len = f.Length;
                                for (int i = n; i < 2 * n; i++)
                                {
                                    Console.Write("{0} ", Fibonachi(i));
                                    f = Encoding.Default.GetBytes(Convert.ToString(Fibonachi(i)) + " ");
                                    fs.Write(f, 0, f.Length);
                                }
                                Console.WriteLine();
                            }

                            Console.WriteLine("Считаем данные из файла {0}", file.FullName);
                            using (StreamReader sr = new StreamReader(path))
                            {
                                Console.WriteLine(sr.ReadToEnd());
                            }

                        }
                        break;

                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine(new string('-', 50));
                            Console.WriteLine("Задание 3. Сложить два целых числа А и В.");
                            Console.WriteLine(new string('-', 50));

                            string pathData = @"C:\Files\input.txt";
                            string pathSum = @"C:\Files\output.txt";
                            int sum = 0;

                            FileInfo file = new FileInfo(pathData);

                            FileInfo file2 = new FileInfo(pathSum);

                            using (StreamWriter f = new StreamWriter(pathData, false))
                            {
                                Console.WriteLine("Введите 2 числа А и В: ");
                                Console.Write("A = ");
                                f.WriteLine(Console.ReadLine());
                                Console.Write("B = ");
                                f.WriteLine(Console.ReadLine());
                                Console.WriteLine("Цифры записаны в файл {0}", file.FullName);
                            }
                            Console.WriteLine(new string('-', 50));

                            Console.WriteLine("Считываем числа из файла {0}", file.FullName);
                            using (StreamReader f = new StreamReader(pathData))
                            {
                                string line;

                                while ((line = f.ReadLine()) != null)
                                {
                                    sum += Convert.ToInt32(line);
                                }

                                Console.WriteLine("Сумма чисел: sum = {0}", sum);
                            }
                            Console.WriteLine(new string('-', 50));
                            Console.WriteLine("Записываем сумму чисел в файл {0}", file2.FullName);
                            using (StreamWriter f = new StreamWriter(pathSum, false))
                            {
                                f.Write(sum.ToString());
                            }

                            Console.WriteLine("Считываем данные из файла {0}", file2.FullName);
                            using (StreamReader f = new StreamReader(pathSum, false))
                            {
                                Console.WriteLine("sum = {0}", f.ReadToEnd());
                            }
                            Console.WriteLine();
                        }
                        break;
                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine(new string('-', 50));
                            Console.WriteLine("Задание 4. Подсчитать количество символов");
                            Console.WriteLine(new string('-', 50));

                            string pathFile4 = @"C:\Files\text.txt";

                            FileInfo file = new FileInfo(pathFile4);

                            Console.WriteLine("Записываем данные побайтно в файл {0}", file.FullName);
                            using (FileStream f = new FileStream(pathFile4, FileMode.Create))
                            {
                                Console.WriteLine("Введите информацию.");
                                byte[] array = Encoding.Default.GetBytes(Console.ReadLine());
                                f.Write(array, 0, array.Length);
                            }

                            Console.WriteLine("Считываем информацию побайтно из файла {0} ", file.FullName);
                            using (FileStream f = new FileStream(pathFile4, FileMode.OpenOrCreate))
                            {
                                byte[] array = new byte[f.Length];
                                f.Read(array, 0, array.Length);
                                int count = array.Length;
                                Console.WriteLine("Количество символов: {0}", count);
                            }
                        }
                        break;
                    case 5:
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Директория {0} будет удалена.", pathDir);
                            Console.ForegroundColor = color;
                            inProgress = false;
                        }
                        break;

                    default:
                        Console.WriteLine("Повторите ввод");
                        break;
                }

            }

            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(pathDir);
                dirInfo.Delete(true);
                Console.WriteLine("Директория удалена.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        // числа Фибоначчи
        static int Fibonachi(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return Fibonachi(n - 1) + Fibonachi(n - 2);
            }
        }

        static void Main(string[] args)
        {
            MainMenu();
        }
    }
}
