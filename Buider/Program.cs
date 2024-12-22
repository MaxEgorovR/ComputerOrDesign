using System;

namespace Buider
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choise the computer:\n1 - Office\n2 - Budget\n3 - Game");
            int choise = int.Parse(Console.ReadLine());
            ComputerDirector director = new ComputerDirector(choise == 1 ? new OfficeComputerBuilder() : choise == 2 ? new BudgetComputerBuilder() : new GameComputerBuilder());
            director.BuildComputer();
            var character = director.GetCharacter();
            Console.WriteLine(character.ToString());
        }
        public class Computer
        {
            public string CPU { get; set; }
            public int RAM { get; set; }
            public int ROM { get; set; }
            public string GPU { get; set; }
            public override string ToString()
            {
                return $"CPU: {CPU}\n" +
                    $"RAM: {RAM}\n" +
                    $"ROM: {ROM}\n" +
                    $"GPU: {GPU}";
            }
        }

        public abstract class ComputerBuilder
        {
            protected Computer computer = new Computer();
            public abstract void SetCPU();
            public abstract void SetGPU();
            public abstract void SetRAM();
            public abstract void SetROM();

            public Computer GetResult()
            {
                return computer;
            }
        }

        public class OfficeComputerBuilder : ComputerBuilder
        {
            public override void SetCPU()
            {
                computer.CPU = "zeon";
            }

            public override void SetGPU()
            {
                computer.GPU = "built-in";
            }

            public override void SetRAM()
            {
                computer.RAM = 8;
            }

            public override void SetROM()
            {
                computer.ROM = 512;
            }
        }

        public class BudgetComputerBuilder : ComputerBuilder
        {
            public override void SetCPU()
            {
                computer.CPU = "i5";
            }

            public override void SetGPU()
            {
                computer.GPU = "discrete";
            }

            public override void SetRAM()
            {
                computer.RAM = 16;
            }

            public override void SetROM()
            {
                computer.ROM = 1024;
            }
        }

        public class GameComputerBuilder : ComputerBuilder
        {
            public override void SetCPU()
            {
                computer.CPU = "i7";
            }

            public override void SetGPU()
            {
                computer.GPU = "discrete";
            }

            public override void SetRAM()
            {
                computer.RAM = 32;
            }

            public override void SetROM()
            {
                computer.ROM = 2048;
            }
        }

        public class ComputerDirector
        {
            private ComputerBuilder builder;

            public ComputerDirector(ComputerBuilder builder)
            {
                this.builder = builder;
            }

            public void BuildComputer()
            {
                builder.SetCPU();
                builder.SetGPU();
                builder.SetRAM();
                builder.SetROM();
            }

            public Computer GetCharacter()
            {
                return builder.GetResult();
            }
        }
    }
}
