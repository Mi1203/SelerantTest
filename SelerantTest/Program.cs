using System;
using System.IO;
using SelerantTest.Configurate;

namespace SelerantTest
{
    class Program
    {

        private const string CONFIG_FILE_NAME = "Config.txt";

        static void Main(string[] args)
        {
            ConfigTask();

            Console.ReadLine();
        }
        private static void ConfigTask()
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, CONFIG_FILE_NAME);
            var config = new Config(filePath);

            Console.WriteLine(config["id"]);
            Console.WriteLine(config["session"]["timeout"]);
            Console.WriteLine(config["session"]["server"]["0"]["host"]);
            Console.WriteLine(config["session"]["server"]["0"]["port"]);
            Console.WriteLine(config["session"]["server"]["0"]["id"]);
            Console.WriteLine(config["session"]["server"]["1"]["host"]);
            Console.WriteLine(config["session"]["server"]["1"]["port"]);
            Console.WriteLine(config["session"]["server"]["1"]["id"]);
            Console.WriteLine(config["image"]["cat"]["width"]);
            Console.WriteLine(config["image"]["cat"]["height"]);
            Console.WriteLine(config["image"]["folder"]);
            Console.WriteLine(config["test1"]["data"]);

        }
    }
}
