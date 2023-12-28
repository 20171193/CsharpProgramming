using System;
using System.Net;
using System.Data.SqlTypes;
using System.Threading.Tasks.Dataflow;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;
using System.Transactions;
using System.Reflection.Metadata.Ecma335;

namespace ETC
{
    // 경일 게임아카데미

    #region 입출력, 변수
    //class Program
    //{
    //    struct Userinfo
    //    {
    //        public string name;
    //        public string job;
    //        public int level;
    //        public int hp;
    //    }
    //    static void Main(string[] args)
    //    {
    //        Userinfo uinfo;
    //        Console.WriteLine("\n  <캐릭터 선택창>\n"); ;
    //        Console.Write("이름을 입력하세요 : ");
    //        uinfo.name = Console.ReadLine();
    //        Console.Write("직업을 입력하세요 : ");
    //        uinfo.job = Console.ReadLine();
    //        Console.Write("레벨을 입력하세요 : ");
    //        uinfo.level = int.Parse(Console.ReadLine());
    //        Console.Write("체력을 입력하세요 : ");
    //        uinfo.hp = int.Parse(Console.ReadLine());

    //        Console.WriteLine("\n선택하신 캐릭터는");
    //        Console.WriteLine($"이름 : {uinfo.name}");
    //        Console.WriteLine($"직업 : {uinfo.job}");
    //        Console.WriteLine($"레벨 : {uinfo.level}");
    //        Console.WriteLine($"체력 : {uinfo.hp}");
    //    }
    //}
    #endregion

    #region 연산자

    //class LeeSin
    //{
    //    const int stamina = 200;
    //    const int regenStamina = 50;
    //    const int atr = 125;
    //    public int speed = 345;
    //    public int hp = 645;
    //    public int levelPerHp = 105;
    //    public float regenHp = 7.5f;
    //    public float levelPerRegenHp = 0.7f;
    //    public float atk = 66;
    //    public float levelPerAtk = 3.7f;
    //    public float ats = 0.651f;
    //    public float levelPerAts = 0.03f;   // 3%
    //    public float amr = 36f;
    //    public float levelPerAmr = 4.9f;
    //    public float mrc = 32f;
    //    public float levelPerMrc = 2.05f;
    //    // skill damage
    //    // Q - 음파 / 공명의 일격
    //    public string q1Name = "음파";
    //    public float qDamage1 = 55f;
    //    public float qDamage1Ad = 1.15f;
    //    public string q2Name = "공명의 일격";
    //    public float qDamage2 = 110f;
    //    public float qDamage2Ad = 1.15f;
    //    // W - 방호 / 강철의 의지
    //    public string w1Name = "방호";
    //    public float w1Amor = 40f;
    //    public float w1AmorAp = 0.8f;
    //    public string w2Name = "강철의 의지";
    //    public float w2Drain = 10;
    //    // E - 폭풍 / 무력화
    //    public string e1Name = "폭풍";
    //    public float eDamage1 = 35f;
    //    public float eDamage1Ad = 1.0f;
    //    public string e2Name = "무력화";
    //    public float e2Slow = 20f;
    //    // R - 용의 분노
    //    public string rName = "용의 분노";
    //    public float rDamage = 175f;
    //    public float rDamageAd = 2.0f;
    //    public float rSplashDamagePerHp = 12f;  // 12%

    //    public void StatInfo(int level)
    //    {
    //        level -= 1;
    //        Console.ForegroundColor = ConsoleColor.Cyan;
    //        Console.WriteLine("*************************************************************************************");
    //        Console.ResetColor();
    //        Console.WriteLine($"{level + 1} 레벨 리신의 기본 능력치는 다음과 같습니다.");
    //        Console.ForegroundColor = ConsoleColor.Red;
    //        Console.Write("\n      체력 : ");
    //        Console.ResetColor();
    //        Console.WriteLine($"{hp + (levelPerHp * level)}");
    //        Console.ForegroundColor = ConsoleColor.Magenta;
    //        Console.Write(" 체력 재생 : ");
    //        Console.ResetColor();
    //        Console.WriteLine($"{regenHp + (levelPerRegenHp * level)}");
    //        Console.ForegroundColor = ConsoleColor.Blue;
    //        Console.Write("      기력 : ");
    //        Console.ResetColor();
    //        Console.WriteLine($"{stamina}");
    //        Console.ForegroundColor = ConsoleColor.Cyan;
    //        Console.Write(" 기력 회복 : ");
    //        Console.ResetColor();
    //        Console.WriteLine($"{regenStamina}");
    //        Console.ForegroundColor = ConsoleColor.Yellow;
    //        Console.Write("    공격력 : ");
    //        Console.ResetColor();
    //        Console.WriteLine($"{atk + (levelPerAtk * level)}");
    //        float tempAts = ats;
    //        for (int i = 0; i < level; i++)
    //        {
    //            tempAts += tempAts * levelPerAts;
    //        }
    //        Console.ForegroundColor = ConsoleColor.Yellow;
    //        Console.Write(" 공격 속도 : ");
    //        Console.ResetColor();
    //        Console.WriteLine($"{tempAts}");
    //        Console.ForegroundColor = ConsoleColor.Green;
    //        Console.Write("    방어력 : ");
    //        Console.ResetColor();
    //        Console.WriteLine($"{amr + (levelPerAmr * level)}");
    //        Console.ForegroundColor = ConsoleColor.DarkGreen;
    //        Console.Write("마법저항력 : ");
    //        Console.ResetColor();
    //        Console.WriteLine($"{mrc + (levelPerMrc * level)}");
    //        Console.ForegroundColor = ConsoleColor.Gray;
    //        Console.Write("    사거리 : ");
    //        Console.ResetColor();
    //        Console.WriteLine($"{atr}");
    //        Console.ForegroundColor = ConsoleColor.Gray;
    //        Console.Write("  이동속도 : ");
    //        Console.ResetColor();
    //        Console.WriteLine($"{speed}");
    //        Console.ForegroundColor = ConsoleColor.Cyan;
    //        Console.WriteLine("*************************************************************************************");
    //        Console.ResetColor();
    //        Console.WriteLine($"{level + 1} 레벨 리신의 스킬 정보는 다음과 같습니다.");
    //        Console.ForegroundColor = ConsoleColor.Red;
    //        Console.Write($"\n       Q {q1Name} : ");
    //        Console.ResetColor();
    //        Console.WriteLine($"{qDamage1 + qDamage1Ad * (atk + (levelPerAtk * level))} 의 데미지를 입힙니다.");
    //        Console.ForegroundColor = ConsoleColor.Red;
    //        Console.Write($"Q {q2Name} : ");
    //        Console.ResetColor();
    //        Console.WriteLine($"{qDamage2 + qDamage2Ad * (atk + (levelPerAtk * level))} 의 데미지를 입힙니다.");
    //        Console.ForegroundColor = ConsoleColor.Blue;
    //        Console.Write($"\n       W {w1Name} : ");
    //        Console.ResetColor();
    //        Console.WriteLine($"{w1Amor + w1AmorAp} 의 피해를 흡수하는 방어막을 획득합니다.");
    //        Console.ForegroundColor = ConsoleColor.Blue;
    //        Console.Write($"W {w2Name} : ");
    //        Console.ResetColor();
    //        Console.WriteLine($"{w2Drain}% 만큼의 피해흡혈을 얻습니다.");
    //        Console.ForegroundColor = ConsoleColor.Green;
    //        Console.Write($"\n       E {e1Name} : ");
    //        Console.ResetColor();
    //        Console.WriteLine($"{eDamage1 + eDamage1Ad * (atk + (levelPerAtk * level))} 의 데미지를 입힙니다.");
    //        Console.ForegroundColor = ConsoleColor.Green;
    //        Console.Write($"     E {e2Name} : ");
    //        Console.ResetColor();
    //        Console.WriteLine($"{e2Slow} 만큼 적의 이동속도를 감소시킵니다.");
    //        Console.ForegroundColor = ConsoleColor.Magenta;
    //        Console.Write($"\n  R {rName} : ");
    //        Console.ResetColor();
    //        Console.WriteLine($"{rDamage} 의 데미지를 입히고 충돌한 적에게 최초 대상 추가 체력의 {rSplashDamagePerHp}% 의 데미지를 입힙니다.");
    //        Console.ForegroundColor = ConsoleColor.Cyan;
    //        Console.WriteLine("*************************************************************************************");
    //        Console.ResetColor();
    //    }
    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Console.Title = "리신 스텟";
    //        Console.Write("리신 레벨을 입력하시오:");
    //        int level = int.Parse(Console.ReadLine());
    //        LeeSin lee = new LeeSin();
    //        lee.StatInfo(level);
    //    }
    //}
    #endregion

    #region 조건문, 반복문 별찍기

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        int n = 0;

    //        // 1. 1열
    //        Console.WriteLine("-------------------");
    //        Console.Write("숫자를 입력하시오:");
    //        n = int.Parse(Console.ReadLine());
    //        Console.WriteLine($"{n} 개의 별을 찍습니다.\n");
    //        Console.ForegroundColor = ConsoleColor.Cyan;
    //        for (int i = 0; i < n; i++)
    //        {
    //            Console.Write("*");
    //        }

    //        Console.ResetColor();
    //        Console.WriteLine("2초 뒤 콘솔이 지워집니다.");
    //        Thread.Sleep(3000);
    //        Console.Clear();

    //        // 2. 정사각형
    //        Console.WriteLine("-------------------");
    //        Console.Write("숫자를 입력하시오:");
    //        n = int.Parse(Console.ReadLine());
    //        Console.WriteLine($"{n}x{n} 정사각형의 별을 찍습니다.\n");
    //        Console.ForegroundColor = ConsoleColor.Cyan;
    //        for (int i = 0; i < n; i++)
    //        {
    //            for (int j = 0; j < n; j++)
    //            {
    //                Console.Write("*");
    //            }
    //            Console.WriteLine("");
    //        }

    //        Console.ResetColor();
    //        Console.WriteLine("\n2초 뒤 콘솔이 지워집니다.");
    //        Thread.Sleep(3000);
    //        Console.Clear();

    //        // 3. 직각삼각형 1~n
    //        Console.WriteLine("-------------------");
    //        Console.Write("숫자를 입력하시오:");
    //        n = int.Parse(Console.ReadLine());
    //        Console.WriteLine("직각삼각형 찍기");
    //        Console.ForegroundColor = ConsoleColor.Cyan;
    //        for (int i = 1; i <= n; i++)
    //        {
    //            for (int j = 1; j <= i; j++)
    //            {
    //                Console.Write("*");
    //            }
    //            Console.WriteLine("");
    //        }

    //        Console.ResetColor();
    //        Console.WriteLine("2초 뒤 콘솔이 지워집니다.");
    //        Thread.Sleep(3000);
    //        Console.Clear();

    //        // 4. 직각삼각형 n~1
    //        Console.WriteLine("-------------------");
    //        Console.Write("숫자를 입력하시오:");
    //        n = int.Parse(Console.ReadLine());
    //        Console.WriteLine("직각삼각형 찍기 (역방향)");
    //        Console.ForegroundColor = ConsoleColor.Cyan;

    //        for (int i = 1; i <= n; i++)
    //        {
    //            for (int j = n; j >= i; j--)
    //            {
    //                Console.Write("*");
    //            }
    //            Console.WriteLine("");
    //        }

    //        Console.ResetColor();
    //        Console.WriteLine("2초 뒤 콘솔이 지워집니다.");
    //        Thread.Sleep(3000);
    //        Console.Clear();

    //        // 5. 마름모
    //        Console.WriteLine("-------------------");
    //        Console.Write("숫자를 입력하시오:");
    //        n = int.Parse(Console.ReadLine());
    //        Console.WriteLine("마름모 찍기\n");
    //        Console.ForegroundColor = ConsoleColor.Cyan;

    //        // 1 3 5 7 9
    //        int left = n, right = n;
    //        for (int i = 1; i < n * 2; i++)
    //        {
    //            for (int j = 1; j < n * 2; j++)
    //            {
    //                if (j < left || j > right)
    //                {
    //                    Console.Write(" ");
    //                }
    //                else
    //                {
    //                    Console.Write("*");
    //                }
    //            }
    //            Console.WriteLine("");

    //            if (i < n)
    //            {
    //                left--;
    //                right++;
    //            }
    //            else
    //            {
    //                left++;
    //                right--;
    //            }
    //        }
    //        Console.ResetColor();
    //    }
    //}

    #endregion

    #region 조건문, 반복문 과제1 (컴퓨터와 가위바위보)
    // <과제>
    // 컴퓨터와 가위바위보를 진행하자
    //
    // <규칙>
    //  1. 플레이어는 가위, 바위, 보 중에서 하나를 선택하여 입력하도록 하자
    //  2. 랜덤으로 컴퓨터가 가위, 바위, 보 중에 하나를 선택하게 하자
    //  3. 승패를 계산해서 플레이어가 이긴 횟수, 컴퓨터가 이긴 횟수를 보여주도록 하자
    //  4. 둘 중 한쪽이 3번 이겼을 때 누가 이겼는지 출력하고 게임을 종료하도록 하 자

    //class JJangKKamBBo
    //{
    //    static void Main(string[] argc)
    //    {
    //        int winCountPlayer = 0; int winCountComputer = 0;
    //        string inputPlayer = "";

    //        Random rand = new Random();
    //        do
    //        {
    //            Console.ForegroundColor = ConsoleColor.Cyan;
    //            Console.WriteLine("------------------------------------------------");
    //            Console.WriteLine("----------------- 가위 바위 보 -----------------");
    //            Console.WriteLine("------------------------------------------------");
    //            Console.WriteLine("--------------- <스 코 어 보 드> ---------------");
    //            Console.WriteLine("------------------------------------------------");
    //            Console.Write($"----------- ");
    //            Console.ForegroundColor = ConsoleColor.Blue;
    //            Console.Write($"플레이어:{winCountPlayer}");
    //            Console.ForegroundColor = ConsoleColor.Yellow;
    //            Console.Write($"    컴퓨터:{winCountComputer}");
    //            Console.ForegroundColor = ConsoleColor.Cyan;
    //            Console.WriteLine($" -------------");
    //            Console.ForegroundColor = ConsoleColor.Cyan;
    //            Console.WriteLine("------------------------------------------------\n");
    //            Console.ResetColor();

    //            do
    //            {
    //                Console.Write("가위, 바위, 보 중 하나를 입력하세요: ");
    //                inputPlayer = Console.ReadLine();
    //                Console.WriteLine("");
    //            } while (inputPlayer != "가위" && inputPlayer != "바위" && inputPlayer != "보");

    //            for(int i =0; i<3; i++)
    //            {
    //                Thread.Sleep(500);
    //                Console.Write(".");
    //            }

    //            double d = rand.NextDouble();
    //            if(0 <= d && d < 0.34)  // 가위
    //            {
    //                Console.WriteLine("  컴퓨터는 \"가위\" 를 냈습니다!\n");

    //                if(inputPlayer == "바위")
    //                {
    //                    Thread.Sleep(1000);
    //                    Console.ForegroundColor = ConsoleColor.Red;
    //                    Console.WriteLine("이겼습니다!!!");
    //                    Console.ResetColor();
    //                    winCountPlayer++;
    //                }
    //                else if(inputPlayer == "보")
    //                {
    //                    Thread.Sleep(1000);
    //                    Console.ForegroundColor = ConsoleColor.DarkRed;
    //                    Console.WriteLine("졌습니다.");
    //                    Console.ResetColor();
    //                    winCountComputer++;
    //                }
    //                else
    //                {
    //                    Thread.Sleep(1000);
    //                    Console.ForegroundColor = ConsoleColor.Green;
    //                    Console.WriteLine("비겼습니다.");
    //                    Console.ResetColor();
    //                }
    //            }
    //            else if(0.34 <= d && d < 0.67)  // 바위
    //            {
    //                Console.WriteLine("  컴퓨터는 \"바위\" 를 냈습니다!\n");
    //                if (inputPlayer == "바위")
    //                {
    //                    Thread.Sleep(1000);
    //                    Console.ForegroundColor = ConsoleColor.Green;
    //                    Console.WriteLine("비겼습니다.");
    //                    Console.ResetColor();
    //                }
    //                else if (inputPlayer == "보")
    //                {
    //                    Thread.Sleep(1000);
    //                    Console.ForegroundColor = ConsoleColor.Red;
    //                    Console.WriteLine("이겼습니다!!!");
    //                    Console.ResetColor();
    //                    winCountPlayer++;
    //                }
    //                else
    //                {
    //                    Thread.Sleep(1000);
    //                    Console.ForegroundColor = ConsoleColor.DarkRed;
    //                    Console.WriteLine("졌습니다.");
    //                    Console.ResetColor();
    //                    winCountComputer++;
    //                }
    //            }
    //            else  // 보
    //            {
    //                Console.WriteLine("  컴퓨터는 \"보\" 를 냈습니다!\n");
    //                if (inputPlayer == "바위")
    //                {
    //                    Thread.Sleep(1000);
    //                    Console.ForegroundColor = ConsoleColor.DarkRed;
    //                    Console.WriteLine("졌습니다.");
    //                    Console.ResetColor();
    //                    winCountComputer++;
    //                }
    //                else if (inputPlayer == "보")
    //                {
    //                    Thread.Sleep(1000);
    //                    Console.ForegroundColor = ConsoleColor.Green;
    //                    Console.WriteLine("비겼습니다.");
    //                    Console.ResetColor();
    //                }
    //                else
    //                {
    //                    Thread.Sleep(1000);
    //                    Console.ForegroundColor = ConsoleColor.Red;
    //                    Console.WriteLine("이겼습니다!!!");
    //                    Console.ResetColor();
    //                    winCountPlayer++;
    //                }
    //            }
    //            Thread.Sleep(1200);
    //            Console.Clear();
    //        } while (winCountPlayer < 3 && winCountComputer < 3);

    //        Console.WriteLine("*************************************");
    //        if(winCountComputer > winCountPlayer)
    //        {
    //            Console.Write("***** 우승자는 ");
    //            Console.ForegroundColor = ConsoleColor.Yellow;
    //            Console.WriteLine("컴퓨터 입니다!");
    //            Console.ResetColor();
    //            Console.WriteLine("  *****");
    //        }
    //        else 
    //        {
    //            Console.Write("***** 우승자는 ");
    //            Console.ForegroundColor = ConsoleColor.Blue;
    //            Console.Write("플레이어 입니다!");
    //            Console.ResetColor();
    //            Console.WriteLine(" *****");
    //        }
    //        Console.WriteLine("*************************************");
    //    }
    //}
    #endregion

    #region 조건문, 반복문 과제2 (월남뽕)

    //class WallNamBBong
    //{
    //    struct Pair
    //    {
    //        public int num1;
    //        public int num2;

    //        public Pair()
    //        {
    //            num1 = 0;
    //            num2 = 0;
    //        }
    //    }
    //    static void Main(string[] argc)
    //    {
    //        char key = ' ';  // 입력키 초기화
    //        Random rand = new Random();
    //        bool playGame = true;


    //        do
    //        {
    //            int[] money = new int[4] { 10000, 10000, 10000, 10000 };
    //            int people = 0;
    //            int playerNum = 0;
    //            int die = 0;
    //            int stageMoney = 0; // 판돈 초기화
    //            Pair[] cardPair = new Pair[4];  // 카드 초기화

    //            Console.WriteLine("**************************************************");
    //            Console.WriteLine("******************** 월 남 뽕 ********************");
    //            Console.WriteLine("**************************************************");
    //            Console.WriteLine("**************************************************");

    //            do
    //            {
    //                Console.Write("\n게임에 참여할 인원 수를 입력하시오:");
    //                people = int.Parse(Console.ReadLine());
    //            } while (people <= 1 || people > 4);

    //            Console.WriteLine();

    //            Console.Write("카드 셔플중 ");

    //            for (int i = 0; i < people; i++)
    //            {
    //                Console.Write(".");
    //                Thread.Sleep(200);

    //                Pair temp = new Pair();
    //                temp.num1 = rand.Next(1, 9);
    //                while ((temp.num1 == temp.num2) || temp.num2 == 0)
    //                {
    //                    temp.num2 = rand.Next(1, 9);
    //                }
    //                cardPair[i].num1 = temp.num1 > temp.num2 ? temp.num2 : temp.num1;
    //                cardPair[i].num2 = temp.num1 > temp.num2 ? temp.num1 : temp.num2;
    //            }

    //            Console.WriteLine();

    //            Console.WriteLine("**************************************************");
    //            for (int i = 0; i < people; i++)
    //            {
    //                Console.WriteLine($"플레이어 {i + 1}의 카드는({cardPair[i].num1}),({cardPair[i].num2}) 자본은 {money[i]}원 입니다.");
    //            }

    //            Console.WriteLine("**************************************************");
    //            playerNum = rand.Next(1, people);
    //            Console.WriteLine($"\n당신은 플레이어는 ** {playerNum+1}번 ** 입니다.");
    //            Thread.Sleep(1500);

    //            bool win = false;
    //            while (win == false)
    //            {
    //                for (int i = 0; i < people; i++)
    //                {
    //                    int bat = 0;
    //                    if((die & (1 << i)) != 0)
    //                    {
    //                        continue;
    //                    }
    //                    if (money[i] == 0)
    //                    {
    //                        Thread.Sleep(500);
    //                        Console.WriteLine($"플레이어 {i+1}번은 소지한 금액이 없어 다음 순서로 넘어갑니다.");
    //                        continue;
    //                    }

    //                    // 유저 플레이어 입력
    //                    if (i == playerNum)
    //                    {
    //                        Console.ForegroundColor = ConsoleColor.Magenta;
    //                        Console.WriteLine("\n배팅 하시겠습니까?");
    //                        Console.Write("**** (1):배팅 ** (2):포기 ** (E): 게임종료 **** : ");
    //                        key = char.Parse(Console.ReadLine());
    //                        Console.WriteLine();
    //                        Console.ResetColor();
    //                        switch (key)
    //                        {
    //                            case '1':
    //                                Console.WriteLine($"현재 소지한 돈:{money[playerNum]}");
    //                                Console.Write("배팅할 금액:");
    //                                bat = int.Parse(Console.ReadLine());
    //                                while (bat < 100 || bat > money[playerNum])
    //                                {
    //                                    Console.WriteLine("\n잘못된 입력입니다.");
    //                                    Console.WriteLine("배팅할 금액:");
    //                                    bat = int.Parse(Console.ReadLine());
    //                                }
    //                                Console.ForegroundColor = ConsoleColor.Green;
    //                                Console.WriteLine($"\n플레이어 {i+1}번이 {bat} 원을 배팅했습니다.");
    //                                Console.ResetColor();
    //                                money[playerNum] -= bat;
    //                                stageMoney += bat;
    //                                break;
    //                            case '2':
    //                                Console.WriteLine("다음 순서로 넘어갑니다.\n");
    //                                break;
    //                            case 'e':
    //                            case 'E':
    //                            case 'ㄷ':
    //                                playGame = false;
    //                                break;
    //                        }
    //                    }
    //                    // 남은 플레이어 자동배팅
    //                    else
    //                    {
    //                        Thread.Sleep(1500);
    //                        bat = money[i];
    //                        money[i] = 0;
    //                        stageMoney += bat;
    //                        Console.ForegroundColor = ConsoleColor.Green;
    //                        Console.WriteLine($"\n플레이어 {i+1}번이 {bat} 원을 배팅했습니다.");
    //                        Console.ResetColor();
    //                    }
    //                    Thread.Sleep(500);
    //                }

    //                Thread.Sleep(500);
    //                Console.WriteLine("\n**************************************************");
    //                Console.Write($"**************** 현재 판돈:");
    //                Console.ForegroundColor = ConsoleColor.Blue;
    //                Console.Write($"{stageMoney}");
    //                Console.ResetColor();
    //                Console.WriteLine("원 ***************");
    //                Console.WriteLine("**************************************************\n");
    //                Thread.Sleep(500);

    //                for(int i=0; i<people; i++)
    //                {
    //                    if((die & (1<<i)) == 0) // 플레이어가 죽지 않았다면
    //                    {
    //                        Console.Write($"{i+1}번 플레이어 카드오픈:");
    //                        for(int j =0; j<3; j++)
    //                        {
    //                            Console.Write(".");
    //                            Thread.Sleep(300);
    //                        }
    //                        int openCard = rand.Next(1, 9);
    //                        Console.Write($"오픈한 카드는 ({cardPair[i].num1} < ");
    //                        Console.ForegroundColor= ConsoleColor.Red;
    //                        Console.Write($"{openCard}");
    //                        Console.ResetColor();
    //                        Console.WriteLine($" < {cardPair[i].num2}) 입니다!");
    //                        if(cardPair[i].num1 < openCard && cardPair[i].num2 > openCard)
    //                        {
    //                            Thread.Sleep(500);
    //                            Console.WriteLine($"{i+1}번 플레이어 게임 승리!");
    //                            Console.WriteLine($"판돈 {stageMoney}를 가져갑니다!");
    //                            money[i] += stageMoney;
    //                            win = true;
    //                            // 다이 처리
    //                            Console.WriteLine();
    //                            for(int j =0; j < people; j++)
    //                            {
    //                                if (money[j] <= 0)
    //                                {
    //                                    Console.WriteLine($"{j+1}번 플레이어는 올인하여 게임에 참가하지 못합니다.");
    //                                    Thread.Sleep(500);
    //                                    die |= (1 << j);
    //                                }
    //                            }
    //                            Thread.Sleep(7000);
    //                            Console.Clear();
    //                            break;
    //                        }
    //                        else
    //                        {
    //                            Console.WriteLine($"패배!");
    //                            Thread.Sleep(500);
    //                        }
    //                    }
    //                }
    //            }
    //        } while (playGame == true);
    //    }
    //}

    #endregion

    #region 열거형, 구조체 과제 1 (컴퓨터와 가위바위보)
    // 룰
    // 1. 플레이어에게 가위, 바위, 보 중 하나를 입력받도록 함.
    // 2. 컴퓨터는 랜덤으로 가위, 바위, 보 중에서 하나를 선택하도록 함.
    // 3. 가위바위보 승패를 계산해서 이긴측에 승수를 1올려주도록 함.
    // 4. 어느 한쪽이라도 3승을 먼저 한 경우 ~~가 승리 했습니다.

    // 조건
    // 1. Main함수의 길이는 20줄로 제한
    // 2. 가위,바위,보 string 허용 X
    // 3. 플레이어 입력을 ReadKey로 진행

    //class RockScissorsPaper
    //{
    //    public enum RPS
    //    {
    //        Scissors = 1,
    //        Rock,
    //        Paper
    //    }
    //    public enum User
    //    {
    //        Player = 0,
    //        Computer
    //    }

    //    public Random rand = new Random();
    //    public int playerScore = 0, computerScore = 0;

    //    public void Render()
    //    {
    //        Console.ForegroundColor = ConsoleColor.Red;
    //        Console.WriteLine("*******************************************");
    //        Console.ForegroundColor = ConsoleColor.Yellow;
    //        Console.WriteLine("*******************************************");
    //        Console.ForegroundColor = ConsoleColor.Green;
    //        Console.WriteLine("***           가위바위보 게임           ***");
    //        Console.ForegroundColor = ConsoleColor.Yellow;
    //        Console.WriteLine("*******************************************");
    //        Console.ForegroundColor = ConsoleColor.Red;
    //        Console.WriteLine("*******************************************");
    //        Console.ResetColor();
    //        Console.WriteLine("*******************************************");
    //        Console.WriteLine("***             스코어보드              ***");
    //        Console.WriteLine("*******************************************");
    //        Console.Write("* ");
    //        Console.ForegroundColor= ConsoleColor.Red;    
    //        Console.Write($"플레이어 : {playerScore}");
    //        Console.Write("                 ");
    //        Console.ForegroundColor = ConsoleColor.Yellow;
    //        Console.Write($"컴퓨터 : {computerScore}");
    //        Console.ResetColor();
    //        Console.WriteLine($" *");
    //        Console.WriteLine("*******************************************");


    //    }
    //    public void RenderClear()
    //    {
    //        Console.WriteLine();
    //        Console.Write("5초 뒤 결과가 갱신됩니다.");
    //        for (int i = 0; i < 4; i++)
    //        {
    //            Thread.Sleep(1000);
    //            Console.Write(".");
    //        }
    //        Console.Clear();
    //    }
    //    public RPS ComputerRandomInput()
    //    {
    //        int temp = rand.Next(1, 3);
    //        Console.Write("컴퓨터는 ");
    //        switch((RPS)temp)
    //        {
    //            case RPS.Scissors:
    //                Console.ForegroundColor = ConsoleColor.Red;
    //                Console.Write("가위");
    //                break;
    //            case RPS.Rock:
    //                Console.ForegroundColor = ConsoleColor.Blue;
    //                Console.Write("바위");
    //                break;
    //            case RPS.Paper:
    //                Console.ForegroundColor = ConsoleColor.Green;
    //                Console.Write("보");
    //                break;
    //        }
    //        Console.ResetColor();
    //        Console.WriteLine("를 냈습니다.");
    //        return (RPS)temp;
    //    }
    //    public void GamePlaying()
    //    {
    //        Console.WriteLine();
    //        Console.WriteLine("무엇을 내시겠습니까?");
    //        Console.Write("--- 가위:(1) 바위:(2) 보:(3) --- :");
    //        ConsoleKeyInfo inputKey = Console.ReadKey();
    //        while(inputKey.Key != ConsoleKey.D1 && inputKey.Key != ConsoleKey.D2 && inputKey.Key != ConsoleKey.D3)
    //        {
    //            Console.WriteLine("잘못된 입력입니다.");
    //            Console.Write("--- 가위:(1) 바위:(2) 보:(3) --- :");
    //            inputKey = Console.ReadKey();
    //        }
    //        Console.WriteLine();
    //        RPS playerKey = KeyToRPS(inputKey.Key);
    //        Console.Write("플레이어는 ");
    //        switch (playerKey)
    //        {
    //            case RPS.Scissors:
    //                Console.ForegroundColor = ConsoleColor.Red;
    //                Console.Write("가위");
    //                break;
    //            case RPS.Rock:
    //                Console.ForegroundColor = ConsoleColor.Blue;
    //                Console.Write("바위");
    //                break;
    //            case RPS.Paper:
    //                Console.ForegroundColor = ConsoleColor.Green;
    //                Console.Write("보");
    //                break;
    //            default:
    //                Console.WriteLine("에러 (GamePlaying)");
    //                break;
    //        }
    //        Console.ResetColor();
    //        Console.WriteLine("를 냈습니다.");

    //        RPS computerKey = ComputerRandomInput();

    //        Console.WriteLine();
    //        Console.Write("승패여부 판단중");
    //        for(int i=0; i<5; i++)
    //        {
    //            Thread.Sleep(300);
    //            Console.Write(".");
    //        }

    //        Console.ForegroundColor = ConsoleColor.Magenta;
    //        if (playerKey==computerKey)
    //        {
    //            Console.WriteLine(" 비겼습니다 !");
    //        }
    //        else 
    //        {
    //            switch(playerKey)
    //            {
    //                case RPS.Scissors:
    //                    if(computerKey == RPS.Rock) // 바위
    //                    {
    //                        Console.WriteLine(" 졌습니다.");
    //                        computerScore++;
    //                    }
    //                    else // 보
    //                    {
    //                        Console.WriteLine(" 이겼습니다!!!");
    //                        playerScore++;
    //                    }
    //                    break;
    //                case RPS.Rock:
    //                    if (computerKey == RPS.Paper) // 바위
    //                    {
    //                        Console.WriteLine(" 졌습니다.");
    //                        computerKey++;
    //                    }
    //                    else // 보
    //                    {
    //                        Console.WriteLine(" 이겼습니다!!!");
    //                        playerScore++;
    //                    }
    //                    break;
    //                case RPS.Paper:
    //                    if (computerKey == RPS.Scissors) // 바위
    //                    {
    //                        Console.WriteLine(" 졌습니다.");
    //                        computerScore++;
    //                    }
    //                    else // 보
    //                    {
    //                        Console.WriteLine(" 이겼습니다!!!");
    //                        playerScore++;
    //                    }
    //                    break;
    //            }
    //        }
    //        Console.ResetColor();
    //    }

    //    public void GameEnded()
    //    {
    //        for (int i = 0; i <=9; i++)
    //        {
    //            Console.Clear();
    //            if (i % 3 == 0)
    //            {
    //                Console.WriteLine("*******************************************");
    //                Console.ForegroundColor = ConsoleColor.Yellow;
    //                Console.WriteLine("*******************************************");
    //                Console.ForegroundColor = ConsoleColor.Red;
    //                Console.WriteLine("*******************************************");
    //                Console.ResetColor();
    //                Console.Write("      우승자는 ");
    //                Console.ForegroundColor = ConsoleColor.Blue;
    //                if (playerScore > computerScore)
    //                {
    //                    Console.Write("플레이어");
    //                }
    //                else
    //                {
    //                    Console.Write("컴퓨터");
    //                }
    //                Console.ResetColor();
    //                Console.WriteLine(" 입니다 !!");
    //                Console.ForegroundColor = ConsoleColor.Red;
    //                Console.WriteLine("*******************************************");
    //                Console.ForegroundColor = ConsoleColor.Yellow;
    //                Console.WriteLine("*******************************************");
    //                Console.ResetColor();
    //                Console.WriteLine("*******************************************");
    //            }
    //            else if (i % 3 == 1)
    //            {
    //                Console.ForegroundColor = ConsoleColor.Red;
    //                Console.WriteLine("*******************************************");
    //                Console.ResetColor();
    //                Console.WriteLine("*******************************************");
    //                Console.ForegroundColor = ConsoleColor.Yellow;
    //                Console.WriteLine("*******************************************");
    //                Console.ResetColor();
    //                Console.Write("      우승자는 ");
    //                Console.ForegroundColor = ConsoleColor.DarkBlue;
    //                if (playerScore > computerScore)
    //                {
    //                    Console.Write("플레이어");
    //                }
    //                else
    //                {
    //                    Console.Write("컴퓨터");
    //                }
    //                Console.ResetColor();
    //                Console.WriteLine(" 입니다 !!");
    //                Console.ForegroundColor = ConsoleColor.Yellow;
    //                Console.WriteLine("*******************************************");
    //                Console.ResetColor();
    //                Console.WriteLine("*******************************************");
    //                Console.ForegroundColor = ConsoleColor.Red;
    //                Console.WriteLine("*******************************************");
    //            }
    //            else
    //            {
    //                Console.ForegroundColor = ConsoleColor.Yellow;
    //                Console.WriteLine("*******************************************");
    //                Console.ForegroundColor = ConsoleColor.Red;
    //                Console.WriteLine("*******************************************");
    //                Console.ResetColor();
    //                Console.WriteLine("*******************************************");
    //                Console.ResetColor();
    //                Console.Write("      우승자는 ");
    //                Console.ForegroundColor = ConsoleColor.Cyan;
    //                if (playerScore > computerScore)
    //                {
    //                    Console.Write("플레이어");
    //                }
    //                else
    //                {
    //                    Console.Write("컴퓨터");
    //                }
    //                Console.ResetColor();
    //                Console.WriteLine(" 입니다 !!");
    //                Console.ResetColor();
    //                Console.WriteLine("*******************************************");
    //                Console.ForegroundColor = ConsoleColor.Red;
    //                Console.WriteLine("*******************************************");
    //                Console.ForegroundColor = ConsoleColor.Yellow;
    //                Console.WriteLine("*******************************************");
    //            }
    //            Console.ResetColor();
    //            Thread.Sleep(500);
    //        }

    //    }
    //    public User GetPlayerInput()
    //    {
    //        return User.Player;
    //    }
    //    public RPS KeyToRPS(ConsoleKey key)
    //    {
    //        switch(key)
    //        {
    //            case ConsoleKey.D1:
    //                return RPS.Scissors;
    //            case ConsoleKey.D2:
    //                return RPS.Rock;
    //            case ConsoleKey.D3:
    //                return RPS.Paper;
    //            default:
    //                Console.WriteLine("키 입력 에러 (KeyToRPS)");
    //                return RPS.Scissors;
    //        }
    //    }

    //    static void Main(string[] argc)
    //    {
    //        RockScissorsPaper rsp = new RockScissorsPaper();

    //        while (rsp.playerScore < 3 && rsp.computerScore < 3)
    //        {
    //            rsp.Render();
    //            rsp.GamePlaying();
    //            rsp.RenderClear();
    //        }
    //        rsp.GameEnded();
    //    }
    //}


    #endregion

    #region 열거형, 구조체과제 2 (방향키 입력받기)
    // 슬라이드 퍼즐 만들기
    // 5x5 판을 생성하고 랜덤한 숫자를 배치한다.
    // 시작위치는 상관없으며 ArrowKey입력시 해당 방향으로 이동한다.
    // 단, 밖으로 벗어날 수 없다.
    // 아래 예시는 0이 움직이는 것으로 가정한다.
    //class Puzzle
    //{
    //    enum Direction
    //    {
    //        LEFT = 0,
    //        RIGHT,
    //        DOWN,
    //        UP
    //    }

    //    public struct Pos
    //    {
    //        public int x;
    //        public int y;
    //        public Pos(int x, int y)
    //        {
    //            this.x = x;
    //            this.y = y;
    //        }
    //    }
    //    public Random rand = new Random();
    //    public bool[] used = new bool[26];
    //    public int[,] myMap = new int[5, 5];
    //    public Pos[] pos = new Pos[4] { new Pos(-1,0), new Pos(1,0), new Pos(0,1), new Pos(0,-1)};
    //    public Pos curPos;
    //    public void SettingMap()
    //    {
    //        for (int y = 0; y < 5; y++)
    //        {
    //            for(int x = 0; x < 5; x++)
    //            {
    //                int num = rand.Next(0, 25);
    //                while (used[num])
    //                {
    //                    num = rand.Next(0, 25);
    //                }
    //                used[num] = true;
    //                myMap[y, x] = num;
    //                if (myMap[y,x] == 0)
    //                {
    //                    curPos = new Pos(x, y);
    //                }
    //            }
    //        }
    //    }

    //    public void Render()
    //    {
    //        Console.Clear();

    //        Console.WriteLine("************************");
    //        Console.WriteLine("  방향키를 입력하세요.  ");
    //        Console.WriteLine("************************");
    //        Console.WriteLine();



    //        for (int y = 0; y < 5; y++)
    //        {
    //            Console.Write("   ");
    //            for (int x = 0; x < 5; x++)
    //            {
    //                Console.Write(" ");
    //                if (myMap[y,x] == 0)
    //                {
    //                    Console.ForegroundColor = ConsoleColor.Red;
    //                }
    //                Console.Write($"{myMap[y, x]}");
    //                Console.ResetColor();
    //                if (myMap[y,x] < 10)
    //                {
    //                    Console.Write(" ");
    //                }
    //            }
    //            Console.WriteLine();
    //        }
    //    }
    //    public void Input()
    //    {
    //        ConsoleKeyInfo key = Console.ReadKey();
    //        Pos Npos= new Pos(0,0);
    //        switch(key.Key)
    //        {
    //            case ConsoleKey.LeftArrow:
    //                {
    //                    Npos.y = curPos.y + pos[(int)Direction.LEFT].y;
    //                    Npos.x = curPos.x + pos[(int)Direction.LEFT].x;
    //                    break;
    //                }
    //                case ConsoleKey.RightArrow:
    //                {
    //                    Npos.y = curPos.y + pos[(int)Direction.RIGHT].y;
    //                    Npos.x = curPos.x + pos[(int)Direction.RIGHT].x;
    //                    break;
    //                }
    //            case ConsoleKey.UpArrow:
    //                {
    //                    Npos.y = curPos.y + pos[(int)Direction.UP].y;
    //                    Npos.x = curPos.x + pos[(int)Direction.UP].x;
    //                    break;
    //                }
    //            case ConsoleKey.DownArrow:
    //                {
    //                    Npos.y = curPos.y + pos[(int)Direction.DOWN].y;
    //                    Npos.x = curPos.x + pos[(int)Direction.DOWN].x;
    //                    break;
    //                }
    //            default:
    //                return;
    //        }
    //        Move(Npos);
    //    }
    //    public void Move(Pos nextPos)
    //    {
    //        if (nextPos.x < 0 || nextPos.x >= 5 || nextPos.y < 0 || nextPos.y >= 5) return;
    //        else
    //        {
    //            myMap[curPos.y, curPos.x] = myMap[nextPos.y, nextPos.x];
    //            curPos = nextPos;
    //            myMap[nextPos.y, nextPos.x] = 0;
    //        }
    //    }
    //    static void Main(string[] argc)
    //    {
    //        Puzzle puzzle = new Puzzle();
    //        puzzle.SettingMap();
    //        while (true)
    //        {
    //            puzzle.Render();
    //            puzzle.Input();
    //        }
    //    }
    //}

    #endregion

    #region 깊은 복사와 얕은 복사 예시코드


    //public class TestClass
    //{
    //    public int x = 0;
    //    public TestClass() { }
    //}
    //public struct TestStruct
    //{
    //    public int x = 0;
    //    public TestStruct() { }
    //}

    //class program
    //{
    //    static void Main(string[] argc)
    //    {
    //        float b = 2.2f;
    //        int a = b;
    //        plus();
    //        string str = "abcdefg";

    //        foreach (char a in str)
    //        {
    //            Console.WriteLine($"{a}");
    //        }

    //        for (int i = 0; i < 5; i++)
    //        {
    //            Console.ForegroundColor = ConsoleColor.Red;
    //            Console.WriteLine($"i = {i}");
    //            for (int j = 0; j < 5; j++)
    //            {
    //                Console.ForegroundColor = ConsoleColor.Green;
    //                Console.WriteLine($"j = {j}");
    //                break;
    //            }
    //        }


    //        TestClass class1 = new TestClass();
    //        class1.x = 1;

    //        TestClass class2 = class1;

    //        TestStruct struct1 = new TestStruct();
    //        struct1.x = 1;

    //        TestStruct struct2 = struct1;


    //        while (true)
    //        {
    //            ConsoleKeyInfo key = Console.ReadKey();
    //            if (key.Key == ConsoleKey.RightArrow)
    //            {
    //                Console.Clear();
    //                class2.x++;
    //                struct2.x++;
    //            }
    //            for (int i = 0; i < class1.x; i++)
    //            {
    //                Console.Write(" ");
    //            }
    //            Console.WriteLine("C1");
    //            for (int i = 0; i < class2.x; i++)
    //            {
    //                Console.Write(" ");
    //            }
    //            Console.WriteLine("C2");

    //            Console.WriteLine();

    //            for (int i = 0; i < struct1.x; i++)
    //            {
    //                Console.Write(" ");
    //            }
    //            Console.WriteLine("S1");

    //            for (int i = 0; i < struct2.x; i++)
    //            {
    //                Console.Write(" ");
    //            }
    //            Console.WriteLine("S2");
    //        }

    //    }

    //    static int plus() { return 0; }
    //}

    #endregion

    #region OOP 과제 1 (객체지향 프로그래밍 다루기) 
    // a. 드라이버, 차 클래스 객체 생성
    // b. 드라이버 <-> 차
    // c. 가속, 감속
    // d. 차의 속도 변화
    //enum CarType
    //{
    //    Lamborgini = 0,
    //    Porshe,
    //    Tico
    //}

    //class Driver
    //{
    //    private Car myCar;

    //    public void RideCar(Car car)
    //    {
    //        myCar = car;
    //        Console.WriteLine($"{myCar.CarName}에 탑승합니다.");
    //        Console.WriteLine($"{myCar.CarName}의 최고 속력은 {myCar.MaxSpeed}km/h 입니다.");
    //    }
    //    public void StepAccelerator(int value)
    //    {
    //        if (myCar == null)
    //        {
    //            Console.WriteLine("우선 차량에 탑승하세요.");
    //            return;
    //        }
    //        myCar.SpeedUp(value);
    //    }
    //    public void StepBrake(int value)
    //    {
    //        if (myCar == null)
    //        {
    //            Console.WriteLine("우선 차량에 탑승하세요.");
    //            return;
    //        }
    //        myCar.SpeedDown(value);
    //    }
    //}
    //class Car
    //{
    //    private CarType myCarType;
    //    public CarType MyCarType { get { return myCarType; } }

    //    private string carName;
    //    public string CarName { get { return carName; } }

    //    private int maxSpeed;
    //    public int MaxSpeed { get { return maxSpeed; } }

    //    private int speed;
    //    public int Speed { get { return speed; } }

    //    public Car(CarType carType)
    //    {
    //        myCarType = carType;
    //        switch (myCarType)
    //        {
    //            case CarType.Lamborgini:
    //                carName = "람보르기니";
    //                maxSpeed = 600;
    //                break;
    //            case CarType.Porshe:
    //                carName = "포르쉐";
    //                maxSpeed = 500;
    //                break;
    //            case CarType.Tico:
    //                carName = "티코";
    //                maxSpeed = 100;
    //                break;
    //        }
    //    }

    //    public void SpeedUp(int value)
    //    {
    //        if (speed + value <= maxSpeed)
    //        {
    //            speed += value;
    //            Console.WriteLine($"{value} km/h 만큼 가속합니다.");
    //        }
    //        else
    //        {
    //            Console.WriteLine($"{maxSpeed - speed} km/h 만큼 가속합니다.");
    //            speed = maxSpeed;
    //        }
    //        Console.WriteLine($"{speed} / {maxSpeed} km/h");
    //    }
    //    public void SpeedDown(int value)
    //    {
    //        if (speed - value >= 0)
    //        {
    //            speed -= value;
    //            Console.WriteLine($"{value} km/h 만큼 감속합니다.");
    //        }
    //        else
    //        {
    //            Console.WriteLine($"{speed} km/h 만큼 감속합니다.");
    //            speed = 0;
    //        }
    //        Console.WriteLine($"{speed} / {maxSpeed} km/h");
    //    }
    //}

    //class Program
    //{
    //    static void Main(string[] argc)
    //    {
    //        Car lamborgini = new Car(CarType.Lamborgini);
    //        Car porshe = new Car(CarType.Porshe);
    //        Car tico = new Car(CarType.Tico);

    //        Driver driver = new Driver();
    //        Console.WriteLine("탑승할 차량을 선택하시오");
    //        Console.Write("(1:람보르기니) (2:포르쉐) (3:티코)");

    //        ConsoleKeyInfo carKey;
    //        do
    //        {
    //            carKey = Console.ReadKey();
    //        } while (carKey.Key != ConsoleKey.D1 && carKey.Key != ConsoleKey.D2 && carKey.Key != ConsoleKey.D3);

    //        Console.WriteLine("\n");

    //        switch (carKey.Key)
    //        {
    //            case ConsoleKey.D1:
    //                driver.RideCar(lamborgini);
    //                break;
    //            case ConsoleKey.D2:
    //                driver.RideCar(porshe);
    //                break;
    //            case ConsoleKey.D3:
    //                driver.RideCar(tico);
    //                break;
    //        }
    //        Console.WriteLine("");

    //        Console.Write("(1:엑셀) (2:브레이크) (P:종료)");
    //        ConsoleKeyInfo inputKey;
    //        do
    //        {
    //            inputKey = Console.ReadKey();
    //            Console.WriteLine("\n");
    //            if (inputKey.Key == ConsoleKey.D1)
    //            {
    //                driver.StepAccelerator(100);
    //            }
    //            else if (inputKey.Key == ConsoleKey.D2)
    //            {
    //                driver.StepBrake(50);
    //            }
    //            else
    //            {
    //                Console.WriteLine("잘못된 입력입니다.");
    //                Console.WriteLine("(1:엑셀) (2:브레이크) (P:종료)");
    //            }
    //            Console.WriteLine();
    //        } while (inputKey.Key != ConsoleKey.P);
    //    }
    //}
    #endregion

    #region OOP 과제 2 (캡슐화:몬스터 정의 / 상속:여러 몬스터 종류 생성) 
    // a. 몬스터에 이름, 체력, 데미지 받기
    // b. 여러 몬스터 종류 생성
    // c. 오크, 슬라임, 드래곤
    // d. 오크:분노 
    // e. 슬라임 : 분열
    // f. 드래곤 : 브레스

    //class Monster
    //{
    //    protected string name;
    //    public string Name { get { return name; } }

    //    protected int hp;
    //    protected int maxHp;

    //    public void TakeHit(int value)
    //    {
    //        if (hp - value > 0)
    //        {
    //            hp -= value;
    //            Console.ForegroundColor = ConsoleColor.Red;
    //            Console.WriteLine($"{name}이/가 {value}만큼의 데미지를 입습니다.");
    //            Console.WriteLine($"{name}의 체력 : {hp}/{maxHp}");
    //            Console.ResetColor();
    //        }
    //        else
    //        {
    //            hp = 0;
    //            Console.ForegroundColor = ConsoleColor.Red;
    //            Console.WriteLine($"{name}이/가 사망합니다.");
    //            Console.ResetColor();
    //        }
    //    }
    //}

    //class Oak : Monster
    //{
    //    public Oak()
    //    {
    //        name = "오크";
    //        maxHp = 100;
    //        hp = maxHp;
    //    }

    //    public void Anger()
    //    {
    //        Console.ForegroundColor = ConsoleColor.Green;
    //        Console.WriteLine($"{name}이 분노합니다.");
    //        Console.ResetColor();
    //    }
    //}
    //class Slime : Monster
    //{
    //    public Slime()
    //    {
    //        name = "슬라임";
    //        maxHp = 50;
    //        hp = maxHp;
    //    }

    //    public void Split()
    //    {
    //        Console.ForegroundColor = ConsoleColor.Cyan;
    //        Console.WriteLine($"{name}이 분열합니다.");
    //        Console.ResetColor();
    //    }
    //}

    //class Dragon : Monster
    //{
    //    public Dragon()
    //    {
    //        name = "드래곤";
    //        maxHp = 200;
    //        hp = maxHp;
    //    }

    //    public void Breath()
    //    {
    //        Console.ForegroundColor = ConsoleColor.Magenta;
    //        Console.WriteLine($"{name}이 불을 뿜습니다.");
    //        Console.ResetColor();
    //    }
    //}

    //enum ChampionType
    //{
    //    Warrior = 1,
    //    Archer,
    //    Wizard
    //}

    //class Champion
    //{
    //    private string name;       // 직업명

    //    private int atk;    // 공격력
    //    public int Atk { get { return atk; } }

    //    public Champion(ChampionType champType)
    //    {
    //        switch (champType)
    //        {
    //            case ChampionType.Warrior:
    //                atk = 10;
    //                name = "전사";
    //                break;
    //            case ChampionType.Archer:
    //                atk = 30;
    //                name = "궁수";
    //                break;
    //            case ChampionType.Wizard:
    //                atk = 50;
    //                name = "마법사";
    //                break;
    //        }
    //        Console.ForegroundColor = ConsoleColor.Blue;
    //        Console.WriteLine($"{name}을/를 선택했습니다. 공격력:{atk}");
    //        Console.ResetColor();
    //    }

    //    public void Attack(Monster trMonster)
    //    {
    //        Console.ForegroundColor = ConsoleColor.Blue;
    //        Console.WriteLine($"{name}이/가 {trMonster.Name}을/를 {atk}의 데미지로 공격합니다.");
    //        Console.ResetColor();
    //        trMonster.TakeHit(atk);
    //    }
    //}

    //class Program
    //{
    //    static void Main(string[] argc)
    //    {
    //        bool gameLoop = true;

    //        Monster[] monsters = new Monster[3];
    //        monsters[0] = new Oak();    // 다운캐스팅
    //        monsters[1] = new Slime();
    //        monsters[2] = new Dragon();

    //        while (gameLoop)
    //        {
    //            Champion myChamp;

    //            Console.WriteLine("직업을 선택하세요.");
    //            Console.Write("(1:전사) (2:궁수) (3:마법사) (P:게임종료)");


    //            ConsoleKeyInfo jobKey = Console.ReadKey();
    //            while (jobKey.Key != ConsoleKey.D1 && jobKey.Key != ConsoleKey.D2 && jobKey.Key != ConsoleKey.D2 && jobKey.Key != ConsoleKey.P)
    //            {
    //                Console.WriteLine();
    //                Console.WriteLine("잘못된 입력입니다. 다시 입력하세요");
    //                Console.Write("(1:전사) (2:궁수) (3:마법사) (P:게임종료)");
    //                jobKey = Console.ReadKey();
    //            }
    //            Console.WriteLine("\n");

    //            switch (jobKey.Key)
    //            {
    //                case ConsoleKey.D1:
    //                    myChamp = new Champion(ChampionType.Warrior);
    //                    break;
    //                case ConsoleKey.D2:
    //                    myChamp = new Champion(ChampionType.Archer);
    //                    break;
    //                case ConsoleKey.D3:
    //                    myChamp = new Champion(ChampionType.Wizard);
    //                    break;
    //                case ConsoleKey.P:
    //                    return;
    //                default:
    //                    return;
    //            }

    //            Console.WriteLine();

    //            Console.WriteLine("공격할 대상을 선택하세요.");
    //            Console.Write("(1:오크) (2:슬라임) (3:드래곤) (P:게임종료)");

    //            Console.WriteLine();

    //            ConsoleKeyInfo targetKey = Console.ReadKey();
    //            while (targetKey.Key != ConsoleKey.D1 && targetKey.Key != ConsoleKey.D2 && targetKey.Key != ConsoleKey.D2 && targetKey.Key != ConsoleKey.P)
    //            {
    //                Console.WriteLine("잘못된 입력입니다. 다시 입력하세요");
    //                Console.Write("(1:오크) (2:슬라임) (3:드래곤) (P:게임종료)");
    //                targetKey = Console.ReadKey();
    //            }
    //            Console.WriteLine();

    //            switch (targetKey.Key)
    //            {
    //                case ConsoleKey.D1:
    //                    myChamp.Attack(monsters[0]);
    //                    break;
    //                case ConsoleKey.D2:
    //                    myChamp.Attack(monsters[1]);
    //                    break;
    //                case ConsoleKey.D3:
    //                    myChamp.Attack(monsters[2]);
    //                    break;
    //                case ConsoleKey.P:
    //                    return;
    //            }
    //            Console.WriteLine();
    //            if (monsters[0] is Oak)
    //            {
    //                Oak tempOak = (Oak)monsters[0];
    //                tempOak.Anger();
    //            }

    //            Console.WriteLine();

    //            Slime tempSlime = monsters[1] as Slime;
    //            tempSlime.Split();

    //            Console.WriteLine();

    //            Dragon tempDragon = (Dragon)monsters[2];
    //            tempDragon.Breath();

    //            Console.WriteLine();

    //        }

    //    }
    //}


    #endregion

    #region OOP 과제 3 (제일 좋아하는 게임) 
    // a. 객체 설계
    // b. 캡슐화, 상속
    enum Potential
    {
        Shooting = 0,
        Pass,
        Tackle
    }

    class Match
    {
        // 경기를 관리하는 클래스

        private Random randPlayerType;
        private Random randPlayer;

        private List<Striker> strikers;
        private List<MidFielder> midFielders;
        private List<Defender> defenders;

        private int dayCount = 1;
        public Match() 
        {
            randPlayerType = new Random();
            randPlayer = new Random();
        }

        // 경기 진행
        // 경기 종료
        // 경기 결과

        public void MatchSetting(Player[] players)
        {
            strikers = new List<Striker>();    
            midFielders = new List<MidFielder>();
            defenders = new List<Defender>();

            foreach (Player pr in players)
            {
                if(pr is Striker)
                {
                    strikers.Add((Striker)pr);
                }
                else if(pr is MidFielder)
                {
                    midFielders.Add((MidFielder)pr);
                }
                else if(pr is Defender)
                {
                    defenders.Add((Defender)pr);
                }
            }
        }

        public void PlayMatch()
        {
            Console.WriteLine($"<매치데이 {dayCount} 일차>");
            Console.WriteLine("\n오늘 경기의 선발명단 입니다!");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("공격수 : ");
            Console.ResetColor();
            foreach (Striker pr in strikers)
            {
                Console.Write($"{pr.Name} ");
            }
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("미드필더 : ");
            Console.ResetColor();
            foreach (MidFielder pr in midFielders)
            {
                Console.Write($"{pr.Name} ");
            }
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("수비수 : ");
            Console.ResetColor();
            foreach (Defender pr in defenders)
            {
                Console.Write($"{pr.Name} ");
            }
            Console.WriteLine();

            Thread.Sleep(1000);
            Console.WriteLine("경기 시작!\n");

            int trySkill = 5;
            while (trySkill > 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("경기 진행중.");
                for (int i=0; i<5; i++)
                {
                    Thread.Sleep(500);
                    Console.Write(".");
                }
                Console.ResetColor();
                Console.WriteLine();

                int prType = 0;
                int prLength = 0;
                int prIndex = 0;

                while(prLength == 0)
                {
                    prType = randPlayerType.Next(1,3);
                    switch(prType)
                    {
                        case 1:
                            prLength = strikers.Count;
                            break;
                        case 2:
                            prLength = midFielders.Count;
                            break;
                        case 3:
                            prLength = defenders.Count;
                            break;
                    }
                }

                prIndex = randPlayerType.Next(0, prLength);
                switch (prType)
                {
                    case 1:
                        strikers[prIndex].PowerShoot();
                        break;
                    case 2:
                        midFielders[prIndex].KillPass();
                        break;
                    case 3:
                        defenders[prIndex].PerfectTackle();
                        break;
                }

                trySkill--;
            }

            dayCount++;
            Thread.Sleep(1500);
            Console.Clear();
        }
    }
    class Player
    {
        // 선수 데이터
        // 1. 이름
        // 2. 능력치   (레벨업 시 각 잠재력에 따라 증가수치가 상이)
        //  a. 슈팅
        //  b. 패스
        //  c. 태클
        // 3. 경험치
        // 4. 자식
        //  a. 포워드 : 슈팅
        //  b. 미드필더 : 패스
        //  c. 수비수 : 태클

        protected string name;
        public string Name { get { return name; } } // 읽기전용 데이터

        protected Potential myPotential;

        // 능력치
        protected int shootingABT;    // 슈팅
        public int ShootingABT { get { return ShootingABT; } }

        protected int passABT;     // 패스
        public int PassABT { get { return passABT; } }

        protected int tackleABT;    // 태클
        public int TackleABT { get { return tackleABT; } }


        // 레벨업
        public void LevelUp()
        {
            // 기본 능력치 증가
            shootingABT += 2;
            passABT += 2;
            tackleABT += 2;

            // 잠재력에 따른 능력치 증가
            switch (myPotential)
            {
                case Potential.Shooting:
                    shootingABT += 3;
                    break;
                case Potential.Pass:
                    passABT += 3;
                    break;
                case Potential.Tackle:
                    tackleABT += 3;
                    break;
                default:
                    break;
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(name);
            Console.ResetColor();
            Console.WriteLine(" 레벨업에 따른 경험치가 갱신됩니다.");
            Console.Write("슈팅:");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{shootingABT}");
            Console.ResetColor();
            Console.Write("패스:");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{passABT}");
            Console.ResetColor();
            Console.Write("태클:");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{tackleABT}");
            Console.ResetColor();

            Thread.Sleep(3000);
        }

        // 능력치 출력
        public void PrintAbility()
        {
            Console.WriteLine($"<{name}의 현재 능력치 정보>");
            Console.Write("슈팅 : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{shootingABT}");
            Console.ResetColor();
            Console.Write("패스 : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{passABT}");
            Console.ResetColor();
            Console.Write("태클 : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{tackleABT}");
            Console.ResetColor();
            Console.WriteLine();
        }
    }

    class Striker : Player
    {
        public Striker(string name)
        {
            this.name = name;
            myPotential = Potential.Shooting;
            shootingABT = 8;
            passABT = 5;
            tackleABT = 3;
        }
        public void PowerShoot()
        {
            Console.WriteLine("***************************************");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(name);
            Console.ResetColor();
            Console.WriteLine("이/가 파워슛으로 골망을 가릅니다!");
            Console.WriteLine("***************************************");
            LevelUp();
        }
    }
    class MidFielder : Player
    {
        public MidFielder(string name)
        {
            this.name = name;
            myPotential = Potential.Pass;
            shootingABT = 4;
            passABT = 8;
            tackleABT = 4;
        }
        public void KillPass()
        {
            Console.WriteLine("***************************************");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(name);
            Console.ResetColor();
            Console.WriteLine("이/가 킬패스로 어시스트를 성공합니다!");
            Console.WriteLine("***************************************");
            LevelUp();
        }
    }
    class Defender : Player
    {
        public Defender(string name)
        {
            this.name = name;
            myPotential = Potential.Tackle;
            shootingABT = 3;
            passABT = 5;
            tackleABT = 8;
        }

        public void PerfectTackle()
        {
            Console.WriteLine("***************************************");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(name);
            Console.ResetColor();
            Console.WriteLine("이/가 깔끔한 태클을 성공합니다!");
            Console.WriteLine("***************************************");
            LevelUp();
        }
    }

    class FCOnline
    {
        const int MaxPlayers = 8;
        const int MaxTeamCapacity = 5;
        private int LoopCount = 5;
        private Player[] players;
        private bool[] includingPlayers;
        private Match match;


        public FCOnline()
        {
            players = new Player[MaxPlayers];
            includingPlayers = new bool[MaxPlayers] { false,false,false,false,false,false,false,false};   
        }

        private void RenderTitle()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("***************************************");
            Console.ResetColor();
            Console.WriteLine("***************************************");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("*******        FC 온라인        *******");
            Console.ResetColor();
            Console.WriteLine("***************************************");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("***************************************");
            Console.ResetColor();
            Console.WriteLine();
        }
        public void InitGame()
        {
            players[0] = new Striker("호날두");
            players[1] = new Striker("메시");
            players[2] = new Striker("음바페");
            players[3] = new MidFielder("이강인");
            players[4] = new MidFielder("심재천");
            players[5] = new MidFielder("김흥국");
            players[6] = new Defender("김민재");
            players[7] = new Defender("홍명보");
            match = new Match();

            Player[] team = new Player[MaxTeamCapacity];

            int cnt = 0;
            while(cnt < MaxTeamCapacity)
            {
                RenderTitle();

                Console.Write("명단에 포함할 선수의 번호를 입력하세요.");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"({cnt}/{MaxTeamCapacity})");
                Console.ResetColor();

                for(int i=0; i<players.Length; i++)
                {
                    if (includingPlayers[i] == true)
                    {
                        Console.Write($"   ");
                    }
                    else
                    {
                        Console.Write($"{i + 1}:{players[i].Name} ");
                    }
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                for (int i=0; i<team.Length; i++)
                {
                    if (team[i] == null) continue;
                    Console.Write($"{team[i].Name} ");
                }
                Console.WriteLine();
                Console.ResetColor();

                int inputKey = int.Parse(Console.ReadLine());
                if(inputKey < 1 || inputKey > 8)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("잘못된 입력입니다. 다시 입력하세요.");
                    Console.ResetColor();
                    Thread.Sleep(1000);
                    Console.Clear();
                    continue; 
                }
                else
                {
                    if (includingPlayers[inputKey-1] == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("이미 포함된 선수입니다. 다시 입력하세요.");
                        Console.ResetColor();
                        Thread.Sleep(1000);
                        Console.Clear();
                        continue;
                    }
                    includingPlayers[inputKey - 1] = true;
                    team[cnt] = players[inputKey - 1];
                    cnt++;
                    Thread.Sleep(100);
                    Console.Clear();
                }
            }
            Thread.Sleep(300);
            match.MatchSetting(team);
        }
        public void LoopGame()
        {
            while(LoopCount > 0)
            {
                RenderTitle();
                match.PlayMatch();
                LoopCount--;
            }

            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine("5초 뒤 게임이 종료됩니다.");
            Console.ResetColor();
            Thread.Sleep(5000);
        }

        static void Main(string[] argc)
        {
            FCOnline fcOnline = new FCOnline();
            fcOnline.InitGame();
            fcOnline.LoopGame();
        }
    }

    #endregion



}