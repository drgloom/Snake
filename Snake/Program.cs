using System;
using System.Threading;

namespace Snake {
    class Program {
        static void Main(string[] args) {
            Game game = new Game(20, 1);
            game.Start();
            //game.start();
            //Console.WriteLine("1");
            //Thread.Sleep(1000);
            //Console.WriteLine("2");
            //Board board = new Board(20);
            //board._board[0, 0]._type = CellType.FOOD;
            //board.print();
            {
        /*  Console.WriteLine(" ");

            Console.Write('\u2500');
            Console.Write('\u2501');
            Console.Write('\u2502');
            Console.Write('\u2503');
            Console.Write('\u2504');
            Console.Write('\u2505');
            Console.Write('\u2506');
            Console.Write('\u2507');
            Console.Write('\u2508');
            Console.Write('\u2509');
            Console.Write('\u250A');
            Console.Write('\u250B');
            Console.Write('\u250C');
            Console.Write('\u250D');
            Console.Write('\u250E');
            Console.Write('\u250F');

            Console.WriteLine(" ");

            Console.Write('\u2510');
            Console.Write('\u2511');
            Console.Write('\u2512');
            Console.Write('\u2513');
            Console.Write('\u2514');
            Console.Write('\u2515');
            Console.Write('\u2516');
            Console.Write('\u2517');
            Console.Write('\u2518');
            Console.Write('\u2519');
            Console.Write('\u251A');
            Console.Write('\u251B');
            Console.Write('\u251C');
            Console.Write('\u251D');
            Console.Write('\u251E');
            Console.Write('\u251F');

            Console.WriteLine(" ");

            Console.Write('\u2520');
            Console.Write('\u2521');
            Console.Write('\u2522');
            Console.Write('\u2523');
            Console.Write('\u2524');
            Console.Write('\u2525');
            Console.Write('\u2526');
            Console.Write('\u2527');
            Console.Write('\u2528');
            Console.Write('\u2529');
            Console.Write('\u252A');
            Console.Write('\u252B');
            Console.Write('\u252C');
            Console.Write('\u252D');
            Console.Write('\u252E');
            Console.Write('\u252F');

            Console.WriteLine(" ");

            Console.Write('\u2530');
            Console.Write('\u2531');
            Console.Write('\u2532');
            Console.Write('\u2533');
            Console.Write('\u2534');
            Console.Write('\u2535');
            Console.Write('\u2536');
            Console.Write('\u2537');
            Console.Write('\u2538');
            Console.Write('\u2539');
            Console.Write('\u253A');
            Console.Write('\u253B');
            Console.Write('\u253C');
            Console.Write('\u253D');
            Console.Write('\u253E');
            Console.Write('\u253F');

            Console.WriteLine(" ");

            Console.Write('\u2540');
            Console.Write('\u2541');
            Console.Write('\u2542');
            Console.Write('\u2543');
            Console.Write('\u2544');
            Console.Write('\u2545');
            Console.Write('\u2546');
            Console.Write('\u2547');
            Console.Write('\u2548');
            Console.Write('\u2549');
            Console.Write('\u254A');
            Console.Write('\u254B');
            Console.Write('\u254C');
            Console.Write('\u254D');
            Console.Write('\u254E');
            Console.Write('\u254F');

            Console.WriteLine(" ");

            Console.Write('\u2550');
            Console.Write('\u2551');
            Console.Write('\u2552');
            Console.Write('\u2553');
            Console.Write('\u2554');
            Console.Write('\u2555');
            Console.Write('\u2556');
            Console.Write('\u2557');
            Console.Write('\u2558');
            Console.Write('\u2559');
            Console.Write('\u255A');
            Console.Write('\u255B');
            Console.Write('\u255C');
            Console.Write('\u255D');
            Console.Write('\u255E');
            Console.Write('\u255F');

            Console.WriteLine(" ");

            Console.Write('\u2560');
            Console.Write('\u2561');
            Console.Write('\u2562');
            Console.Write('\u2563');
            Console.Write('\u2564');
            Console.Write('\u2565');
            Console.Write('\u2566');
            Console.Write('\u2567');
            Console.Write('\u2568');
            Console.Write('\u2569');
            Console.Write('\u256A');
            Console.Write('\u256B');
            Console.Write('\u256C');
            Console.Write('\u256D');
            Console.Write('\u256E');
            Console.Write('\u256F');

            Console.WriteLine(" ");

            Console.Write('\u2570');
            Console.Write('\u2571');
            Console.Write('\u2572');
            Console.Write('\u2573');
            Console.Write('\u2574');
            Console.Write('\u2575');
            Console.Write('\u2576');
            Console.Write('\u2577');
            Console.Write('\u2578');
            Console.Write('\u2579');
            Console.Write('\u257A');
            Console.Write('\u257B');
            Console.Write('\u257C');
            Console.Write('\u257D');
            Console.Write('\u257E');
            Console.Write('\u257F');

            Console.WriteLine(" ");

            Console.Write('\u2580');
            Console.Write('\u2581');
            Console.Write('\u2582');
            Console.Write('\u2583');
            Console.Write('\u2584');
            Console.Write('\u2585');
            Console.Write('\u2586');
            Console.Write('\u2587');
            Console.Write('\u2588');
            Console.Write('\u2589');
            Console.Write('\u258A');
            Console.Write('\u258B');
            Console.Write('\u258C');
            Console.Write('\u258D');
            Console.Write('\u258E');
            Console.Write('\u258F');

            Console.WriteLine(" ");

            Console.Write('\u2590');
            Console.Write('\u2591');
            Console.Write('\u2592');
            Console.Write('\u2593');
            Console.Write('\u2594');
            Console.Write('\u2595');
            Console.Write('\u2596');
            Console.Write('\u2597');
            Console.Write('\u2598');
            Console.Write('\u2599');
            Console.Write('\u259A');
            Console.Write('\u259B');
            Console.Write('\u259C');
            Console.Write('\u259D');
            Console.Write('\u259E');
            Console.Write('\u259F');

            Console.WriteLine(" ");

            Console.Write('\u25A0');
            Console.Write('\u25A1');
            Console.Write('\u25A2');
            Console.Write('\u25A3');
            Console.Write('\u25A4');
            Console.Write('\u25A5');
            Console.Write('\u25A6');
            Console.Write('\u25A7');
            Console.Write('\u25A8');
            Console.Write('\u25A9');
            Console.Write('\u25AA');
            Console.Write('\u25AB');
            Console.Write('\u25AC');
            Console.Write('\u25AD');
            Console.Write('\u25AE');
            Console.Write('\u25AF');

            Console.WriteLine(" "); */
        }
            //string key;
            //bool run = true;
/*            while (run) {
                Console.WriteLine("1. Начать новую игру");
                Console.WriteLine("2. Присоединиться");
                Console.WriteLine("3. Выйти из программы");
                key = Console.ReadLine();
                Console.Clear();
                switch (key) {
                    case "1" :
                        //game begin
                        break;
                    case "2" :
                        //todo присоединение к серверу
                        break;
                    case "3" :
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Введен неверный пункт меню");
                        break;
                }
                //if break;
            }*/
        }
    }
}
