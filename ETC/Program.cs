using System;
using System.Net;
using System.Data.SqlTypes;
using System.Threading.Tasks.Dataflow;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;
using System.Transactions;
using System.Reflection.Metadata.Ecma335;
using System.Collections.Specialized;
using System.Text;
using System.Runtime.Intrinsics.Arm;

namespace ETC
{
    //  1.플레이어가 코인을 얻을때 발생하는 이벤트를 구현하자
    //  2.이벤트에 반응하는 UI, SFX, VFX 객체를 구현하자
    //  3.플레이어가 코인을 얻을때 발생하는 이벤트에 반응하도록 UI, SFX, VFX를 참조하자
    //  4.플레이어가 코인을 얻으면 UI, SFX, VFX가 반응하는지 확인하자

    //  A++) 방어구의 내구도 시스템을 구현해보자
    //   플레이어가 방어구를 착용하고, 플레이어 피격시마다 내구도가 1감소하도록 구현.
    //   내구도가 0이 되면 방어구가 해제되도록 구현하자.

    // < 1~4, A++ >
    public interface IEquipmentable
    {
        public void Equip(Equipment equipment);
    }
    public class Player : IEquipmentable
    {
        private int ownCoin;    // 코인
        public int OwnCoin { get { return ownCoin; } }

        private int ownHp;  // 체력
        public int OwnHp { get { return ownHp; } }  

        public event Action OnGetCoin;      // 코인획득 이벤트
        public event Action<IEquipmentable> OnEquip;    // 방어구 장착 이벤트
        public event Action OnTakeDamage;   // 피격 시 이벤트

        public Armour myAmour;

        public Player()
        {
            ownCoin = 0;
            ownHp = 100;
        }

        public void GetCoin()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"코인 획득!");
            Console.ResetColor();
            ownCoin += 50;
            if(OnGetCoin != null)
                OnGetCoin();
        }

        #region A++
        // 이벤트 구현
        public void Equip(Equipment equipment)
        {
            Console.WriteLine("플레이어가 장비를 장착합니다.");
            myAmour = (Armour)equipment;
            if (OnEquip != null)
            {
                OnEquip(this);
            }
        }

        public void UnEquip(Equipment equipment)
        {
            // 방어구 해제 구현
            myAmour = null;
        }

        public void TakeDamage(int damage)
        {
            // 이벤트 발생 구현
            if(myAmour == null)
            {
                Console.WriteLine($"플레이어가 {damage}의 피해를 입었습니다.");
                if (ownHp - damage > 0)
                {
                    ownHp -= damage;
                }
                else
                {
                    // 추후 사망처리
                }
            }
            else
            {
                // Call 방식
                myAmour.OnDamage(damage);
            }
        }

        #endregion
    }
    #region A++
    public abstract class Equipment
    {
        protected IEquipmentable owner;
        protected int durability;
        public int Durability { get { return durability; } }
        
        public abstract void Equip(IEquipmentable owner); // 방어구 착용시 반응 구현
        public abstract void OnDamage(int value); // 피격시 행동 구현
    }

    public class Armour : Equipment
    {
        public Armour(IEquipmentable owner)
        {
            this.owner = owner;
            durability = 5;
            if(owner is Player)
            {
                Player player = (Player)owner;
                player.OnEquip -= Equip;
                player.OnEquip += Equip;
            }
        }

        public override void Equip(IEquipmentable owner)
        {
            Player player = owner as Player;
            player.myAmour = this;
            Console.WriteLine($"갑옷을 장착합니다. 내구도 : {durability}");
        }

        public override void OnDamage(int value)
        {
            if(durability - value < 1)
            {
                Console.WriteLine($"갑옷이 {value}의 피해를 입어 파괴됩니다.");
                durability = 0;
                if (owner is Player)
                {
                    Player player = (Player)owner;
                    player.OnEquip -= Equip;
                    player.UnEquip(this);
                }
            }
            else
            {
                Console.WriteLine($"갑옷이 {value}의 피해를 흡수합니다.");
                durability -= value;
            }
        }
    }

    #endregion

    public interface ICoinEventReferecable
    {
        public void GetCoinRefer();
    }

    class GameEnvironment
    {
        protected Player player;
    }

    class UI : GameEnvironment, ICoinEventReferecable
    {
        public UI(Player player)
        {
            this.player = player;
            player.OnGetCoin -= GetCoinRefer;   // 예외처리 (이미 할당되어있다면 해제 후 다시 할당)
            player.OnGetCoin += GetCoinRefer;
        }

        public void UIRendering()
        {
            Console.WriteLine("******** 플레이어 정보 ********");
            Console.Write(" $ : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(player.OwnCoin);
            Console.ResetColor();
            Console.Write(" | HP : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(player.OwnHp);
            Console.ResetColor();
            if(player.myAmour != null)
            {
                Console.Write(" | 갑옷 : ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(player.myAmour.Durability);
                Console.ResetColor();
            }
            Console.WriteLine();
        }

        public void GetCoinRefer()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("UI 출력");
            Console.ResetColor();
        }
    }
    class SFX : GameEnvironment, ICoinEventReferecable
    {
        public SFX(Player player)
        {
            this.player = player;
            player.OnGetCoin -= GetCoinRefer;
            player.OnGetCoin += GetCoinRefer;
        }
        public void GetCoinRefer()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("사운드 출력");
            Console.ResetColor();
        }
    }
    class VFX : GameEnvironment, ICoinEventReferecable
    {
        public VFX(Player player)
        {
            this.player = player;
            player.OnGetCoin -= GetCoinRefer;
            player.OnGetCoin += GetCoinRefer;
        }

        public void GetCoinRefer()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("이펙트효과 출력");
            Console.ResetColor();
        }
    }

    class Game
    {
        private Player player;
        private UI ui;
        private SFX sfx;
        private VFX vfx;

        public bool loopGame;

        public Game()
        {
            player = new Player();
            ui = new UI(player);
            sfx = new SFX(player);
            vfx = new VFX(player);
            loopGame = true;
        }

        public void Render()
        {
            ui.UIRendering();
        }
        public ConsoleKey UserInput()
        {
            Console.Write("1:코인 | 2:피격 | 3:갑옷장착 | ESC:종료 ");
            ConsoleKey inputKey = Console.ReadKey().Key;
            Console.WriteLine();
            Console.WriteLine();
            return inputKey;
        }
        public void GameLoop()
        {
            ConsoleKey inputKey;
            while(loopGame) 
            { 
                Render();
                inputKey = UserInput();
                switch(inputKey)
                {
                    case ConsoleKey.D1:
                        player.GetCoin();
                        break;
                    case ConsoleKey.D2:
                        player.TakeDamage(1);
                        break;
                    case ConsoleKey.D3:
                        if(player.myAmour == null)
                            player.Equip(new Armour(player));
                        else
                            Console.WriteLine("이미 존재하는 장비입니다.");
                        break;              
                    case ConsoleKey.Escape:
                        loopGame = false;
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
                if(inputKey != ConsoleKey.Escape)
                    Thread.Sleep(1200);
                Console.Clear();
            }
        }
    }

    class Program
    {
        static void Main(string[] argc)
        {
            Game game = new Game();
            game.GameLoop();
        }
    }


    // < 5 >
    //  5.두 수를 입력받고 숫자1 / 숫자2 의 결과를 출력하도록 하자.단, 숫자2가 0인 경우 예외처리를 통해 0으로 나눌 수 없다고 출력하도록 하자.
    //class TestException
    //{
    //    static void Main(string[] argc)
    //    {
    //        try
    //        {
    //            Console.Write("1번 숫자를 입력하시오 : ");
    //            int num1 = int.Parse(Console.ReadLine());
    //            Console.Write("2번 숫자를 입력하시오 : ");
    //            int num2 = int.Parse(Console.ReadLine());

    //            Console.WriteLine($"{num1} / {num2} = {num1 / num2}");
    //        }
    //        catch(DivideByZeroException ex)
    //        {
    //            Console.WriteLine(ex.Message);
    //            Console.WriteLine("0으로 나눌 수 없습니다.");
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(ex.Message);
    //            Console.WriteLine("입력이 잘못되었습니다.");
    //        }
    //    }
    //}
}