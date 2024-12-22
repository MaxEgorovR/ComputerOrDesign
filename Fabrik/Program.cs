using System;

namespace Fabrik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choise the design style:\n1 - Light\n2 - Dark\n3 - Minimal");
            int choise = int.Parse(Console.ReadLine());
            IDesignFactory factory = choise == 1 ? new LightFactory() : choise == 2 ? new DarkFactory() : new MinimalFactory();
            var design = new Design(factory);
            design.start();
        }

        public interface IButton
        {
            void Descreibe();
        }

        public interface IWindow
        {
            void Descreibe();
        }

        public class DarkButton : IButton
        {
            public void Descreibe()
            {
                Console.WriteLine("It's dark button now");
            }
        }

        public class LightButton : IButton
        {
            public void Descreibe()
            {
                Console.WriteLine("It's light button now");
            }
        }

        public class MinimalButton : IButton
        {
            public void Descreibe()
            {
                Console.WriteLine("It's minimal button now");
            }
        }

        public class DarkWindow : IWindow
        {
            public void Descreibe()
            {
                Console.WriteLine("It's dark window now");
            }
        }

        public class LightWindow : IWindow
        {
            public void Descreibe()
            {
                Console.WriteLine("It's light window now");
            }
        }

        public class MinimalWindow : IWindow
        {
            public void Descreibe()
            {
                Console.WriteLine("It's minimal window now");
            }
        }

        public interface IDesignFactory
        {
            public IButton create_button();
            public IWindow create_window();
        }

        public class LightFactory : IDesignFactory
        {
            IButton IDesignFactory.create_button()
            {
                return new LightButton();
            }

            IWindow IDesignFactory.create_window()
            {
                return new LightWindow();
            }
        }

        public class DarkFactory : IDesignFactory
        {
            IButton IDesignFactory.create_button()
            {
                return new DarkButton();
            }

            IWindow IDesignFactory.create_window()
            {
                return new DarkWindow();
            }
        }

        public class MinimalFactory : IDesignFactory
        {
            IButton IDesignFactory.create_button()
            {
                return new MinimalButton();
            }

            IWindow IDesignFactory.create_window()
            {
                return new MinimalWindow();
            }
        }

        public class Design
        {
            private IWindow _window;
            private IButton _button;

            public Design(IDesignFactory designFactory)
            {
                _window = designFactory.create_window();
                _button = designFactory.create_button();
            }

            public void start()
            {
                Console.WriteLine("Wellcome!");
                _button.Descreibe();
                _window.Descreibe();
            }
        }
    }
}
