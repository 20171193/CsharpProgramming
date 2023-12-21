using System.Collections.Specialized;
using System;

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

    #region 조건문, 반복문 과제 (컴퓨터와 가위바위보)
    // <과제>
    // 컴퓨터와 가위바위보를 진행하자
    //
    // <규칙>
    //  1. 플레이어는 가위, 바위, 보 중에서 하나를 선택하여 입력하도록 하자
    //  2. 랜덤으로 컴퓨터가 가위, 바위, 보 중에 하나를 선택하게 하자
    //  3. 승패를 계산해서 플레이어가 이긴 횟수, 컴퓨터가 이긴 횟수를 보여주도록 하자
    //  4. 둘 중 한쪽이 3번 이겼을 때 누가 이겼는지 출력하고 게임을 종료하도록 하 자

    //class Program
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

    #region 테스트 코드

    #endregion
}