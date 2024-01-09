namespace _00._etc
{
    #region 예외처리 Exception 
    /// <summary>
    /// 예외처리
    /// </summary>
    class DealWithException
    {
        // <try catch 예외처리>
        // 예외가 발생할 수 있는 구문을 지정하고 진행중 예외가 발생할 경우 발생한 예외를 처리하는 구문을 작성
        // try : 예외발생에 대한 검사의 범위를 지정하는 블록
        // catch : 발생한 예외를 처리하는 블록
        class TryCatch
        {
            void Main()
            {
                int value;
                try
                {
                    Console.WriteLine("수를 입력하세요(2~8) : ");
                    string input = Console.ReadLine();

                    value = int.Parse(input);

                    Console.WriteLine($"입력하신 수는 : {value}");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("잘못된 수를 입력하셨습니다.");
                    value = 8;
                }
            }
        }

        // <throw 예외 발생>
        // 의도적으로 예외를 발생시키는 방법
        // 프로그램에서 치명적일 수 있는 동작이 예상되는 경우 예외 처리를 유도하기 위해 진행
        class Throw
        {
            void Main2()
            {
                try
                {
                    int[] array = { 1, 3, 5, 7, 9 };
                    int index = Array.IndexOf(array, 8);

                    if (index < 0)
                        throw new InvalidOperationException();

                    array[index] = 0;
                }
                catch(InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("배열에서 원하는 값을 찾지 못함");
                }
            }
        }

        // <스택 풀기>
        // 함수에서 예외가 발생한 경우 catch 문을 발견할 때까지 호출된 스택을 풀어냄
        void Func3() { Console.Write("3전"); throw new Exception("스택풀기"); Console.Write("3후"); }
        void Func2() { Console.Write("2전"); Func3(); Console.Write("2후"); }
        void Func1() { Console.Write("1전"); Func2(); Console.Write("1후"); }

        void Main3()
        {
            try
            {
                Func1();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
    #endregion
}

namespace _00._Project_BlackJack
{
    public enum Member
    {
        Player = 0,
        Dealer
    }
    class GameManager
    {
        private int[] cardPool;     // 전체 카드풀
        public bool drawEnd = false;    // 카드를 더 뽑을지?
        public int minDrawCount = 2;    // 최소 두번의 카드를 뽑아야함

        List<int> playerCardPool = new List<int>(); // 플레이어 카드풀
        public List<int> PlayerCardPool { get { return playerCardPool; } }

        private int playerSum = 0; // 플레이어 카드의 합
        public int PlayerSum { get { return playerSum; } }

        List<int> dealerCardPool = new List<int>(); // 딜러 카드풀
        public List<int> DealerCardPool { get { return dealerCardPool; } }


        private int dealerSum = 0;  // 딜러 카드의 합
        public int DealerSum { get { return dealerSum; } }

        Random rand;

        public void InitCardPool()  // 카드풀 초기화
        {
            rand = new Random();
            // A 2 3 4 5 6 7 8 9 10*4
            // 위의 카드세팅을 2벌 가지고 시작.
            cardPool = new int[10] { 2, 2, 2, 2, 2, 2, 2, 2, 2, 8 };
        }

        // 카드풀에서 랜덤으로 카드를 하나 뽑아 반환한다.
        public void CardShuffle(Member member)
        {

            int drawCard = 0;

            Console.Write("카드 셔플중");
            for (int i = 0; i < 4; i++)
            {
                Console.Write(".");
                Thread.Sleep(200);
            }
            Console.WriteLine();

            do // 뽑은 카드가 카드풀에 존재할 때까지
            {
                drawCard = rand.Next(0, 9); // 인덱스 기준이므로 0~9
            } while (cardPool[drawCard] <= 0);

            cardPool[drawCard]--;

            switch (member)
            {
                case Member.Player:
                    if (drawCard == 0)   // A카드를 뽑은 경우 (1 or 11) 
                    {
                        int input = 0;
                        Console.WriteLine("\n        A를 뽑았습니다 !");
                        do
                        {
                            Console.Write("\n    1로 사용:(1) 11로 사용:(2) :");
                            input = int.Parse(Console.ReadLine());

                        } while (input != 1 && input != 2);
                        Console.WriteLine();
                        if (input == 1)
                        {
                            playerCardPool.Add(1);
                            playerSum += 1;
                        }
                        else
                        {
                            playerCardPool.Add(11);
                            playerSum += 11;
                        }
                    }
                    else
                    {
                        playerCardPool.Add(drawCard + 1);
                        playerSum += drawCard + 1;
                    }
                    break;
                case Member.Dealer:
                    // 딜러가 A카드를 뽑은 경우
                    if (drawCard == 0)
                    {
                        // 11로 사용했을 때 21이 넘어가면 1로 사용.
                        if (dealerSum + 11 > 21)
                        {
                            dealerCardPool.Add(1);
                            dealerSum += 1;
                        }
                        else
                        {
                            dealerCardPool.Add(11);
                            dealerSum += 11;
                        }
                    }
                    else
                    {
                        dealerCardPool.Add(drawCard + 1);
                        dealerSum += drawCard + 1;
                    }

                    break;
            }
        }
    }

    class Game
    {
        GameManager gm;         // 딜러의 역할을 하는 GameManager
        bool gameLoop = true;   // 게임 루프의 실행여부
        public int width = 0;   // UI 넓이

        public Game(int width)
        {
            this.width = width * 2;
        }

        #region 렌더링 관련 함수목록
        // 화면 UI 렌더링
        public void Rendering()
        {
            RenderClear();
            // 타이틀
            RenderLine(ConsoleColor.Red, 1);
            RenderLine(ConsoleColor.Yellow, 1);
            RenderText(" 블 랙 잭 ", ConsoleColor.White);
            RenderLine(ConsoleColor.Yellow, 1);
            RenderLine(ConsoleColor.Red, 1);

            // 내가뽑은 카드 현황
            Console.WriteLine();
            RenderText(" 보 관 함 ", ConsoleColor.Cyan);
            for (int i = 0; i < gm.PlayerCardPool.Count; i++)
            {
                if (i % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write($"{gm.PlayerCardPool[i]} ");
                Console.ResetColor();
            }
            Console.WriteLine("\n");
        }
        // 화면 UI 클리어
        public void RenderClear()
        {
            Thread.Sleep(1000);
            Console.Clear();
            Thread.Sleep(100);
        }

        // 텍스트 렌더 함수
        public void RenderText(string text, ConsoleColor color)
        {
            if (text.Length + 2 < width)
            {
                int space = width - text.Length;
                for (int i = 0; i < space / 2 - 1; i++)
                {
                    Console.Write("*");
                }
                Console.ForegroundColor = color;
                Console.Write(text);
                Console.ResetColor();
                for (int i = 0; i < space / 2 - 1; i++)
                {
                    Console.Write("*");
                }
            }
            else
            {
                Console.ForegroundColor = color;
                Console.Write(text);
                Console.ResetColor();
            }
            Console.WriteLine();
        }
        // 라인 렌더 함수 (맵그리기)
        public void RenderLine(ConsoleColor color, int height)
        {
            Console.ForegroundColor = color;
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }
        #endregion

        // 게임 초기화
        public void InitGame()
        {
            gm = new GameManager();
            gm.InitCardPool();  // 카드풀 초기화
        }

        #region 유저 입력관련 함수목록
        public bool IsDrawContinue()
        {
            // 이미 게임이 결정난 경우
            if (gm.PlayerSum >= 21)
            {
                return false;
            }

            RenderLine(ConsoleColor.Yellow, 1);
            Console.WriteLine("카드를 한장 더 뽑으시겠습니까?");
            Console.WriteLine("    예:(1)    아니요:(2) ");
            RenderLine(ConsoleColor.Yellow, 1);

            int input = 0;
            do
            {
                input = int.Parse(Console.ReadLine());
            } while (input != 1 && input != 2);

            if (input == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 게임진행 관련 함수목록
        public void PlayGame()  // 실질적인 게임 루프
        {
            while (gameLoop)
            {
                Rendering();
                while (gm.drawEnd == false)
                {
                    if (gm.minDrawCount-- > 0)   // 최소 minDrawCount(2)만큼의 드로우를 강제실행.
                    {
                        gm.CardShuffle(Member.Player);
                        gm.CardShuffle(Member.Dealer);
                        Rendering();
                    }
                    else
                    {
                        bool dContinue = IsDrawContinue();
                        if (dContinue)
                        {
                            gm.CardShuffle(Member.Player);
                            Rendering();
                        }
                        else
                        {
                            CheckGame();
                            gameLoop = false;
                            break;
                        }
                    }
                }
            }
        }
        public void CheckGame() // 최종 결과 도출
        {
            Console.WriteLine();
            Console.WriteLine("딜러의 카드를 오픈합니다.");
            for (int i = 0; i < gm.DealerCardPool.Count; i++)
            {
                if (i % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write($"{gm.DealerCardPool[i]} ");
                Console.ResetColor();
            }
            Console.WriteLine("\n");

            Thread.Sleep(2000);

            if (gm.PlayerSum > gm.DealerSum)
            {
                RenderLine(ConsoleColor.Blue, 1);
                RenderText(" 승 리 ", ConsoleColor.Red);
                RenderLine(ConsoleColor.Blue, 1);
            }
            else if (gm.PlayerSum == gm.DealerSum)
            {
                RenderLine(ConsoleColor.Blue, 1);
                RenderText(" 무승부 ", ConsoleColor.Green);
                RenderLine(ConsoleColor.Blue, 1);
            }
            else
            {
                RenderLine(ConsoleColor.Blue, 1);
                RenderText(" 패배 ", ConsoleColor.Gray);
                RenderLine(ConsoleColor.Blue, 1);
            }

            Thread.Sleep(2000);
        }
        #endregion
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(15);
            game.InitGame();
            game.PlayGame();
        }
    }
}