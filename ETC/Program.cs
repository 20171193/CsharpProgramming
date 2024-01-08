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
using System.ComponentModel;
using System.Reflection.Metadata;

namespace ETC
{
    //    ⦁	상점 게임 만들기
    //⦁	상점에서는 다음 작업들이 가능하다.
    //⦁	아이템 구매
    //⦁	아이템 판매
    //⦁	아이템 확인
    //⦁	아이템은 기본적으로 이름, 설명, 가격을 가지고 있으며,
    //무기는 공격력, 방어구는 방어력, 장신구는 체력을 상승시키는 수치를 가진다.
    //⦁	아이템 구매 메뉴 선택시 상점이 소유하고 있는 아이템들 목록이 제공되고,
    //구매하고자 하는 아이템을 선택시 구매를 진행한다. 단, 돈이 부족하다면 구매는 진행되지 않는다.
    //구매가 완료되면 소유한 아이템에 구매한 아이템이 추가되며, 아이템에 의해 플레이어 능력이 상승한다.
    //⦁	아이템 판매 메뉴 선택시 플레이어가 소유하고 있는 아이템들 목록이 제공되고,
    //판매하고자 하는 아이템을 선택시 판매를 진행한다. 단, 소유한 아이템이 없다면 진행되지 않는다.
    //판매가 완료되면 소유한 아이템에 판매한 아이템이 제거되며, 아이템에 의해 플레이어 능력이 하락한다.
    //⦁	아이템 확인 메뉴 선택시 플레이어가 소유하고 있는 아이템들 목록이 제공되고,
    //아이템들에 의해 상승한 플레이어 최종 능력치를 보여준다.
    //플레이어는 최대 6개의 아이템을 소유할 수 있으며 빈칸은 보여주지 않는다.

    public class InputManager
    {
        private static InputManager staticInputMGR;
        public static InputManager Instance()
        {
            if (staticInputMGR == null)
            {
                staticInputMGR = new InputManager();
            }
            return staticInputMGR;
        }
        public int UserInputKey()
        {
            return ConsoleKeyToInt(Console.ReadKey().Key);
        }

        private int ConsoleKeyToInt(ConsoleKey inputKey)
        {
            // 1~3을 제외한 키는 0으로 간주.
            switch (inputKey)
            {
                case ConsoleKey.D1:
                    return 1;
                case ConsoleKey.D2:
                    return 2;
                case ConsoleKey.D3:
                    return 3;
                default:
                    return 0;
            }
        }
    }

    public enum ItemType 
    {
        LONG_SWORD = 0,      // 롱소드          : 공격력
        CLOTH_ARMOR,         // 천갑옷          : 방어력
        TEAR_OF_THE_GODDES   // 여신의 눈물     : 체력
    }
    public interface IPurchaseable
    {
        public void Perchase();
    }
    public interface ISaleable
    {
        public void Sale();
    }

    public class Item
    {
        protected ItemType thisType;    // enum 아이템 타입
        public ItemType ThisType { get { return thisType; } }

        protected string name;  // 이름
        public string Name { get { return name; } }

        protected string description;   // 설명
        public string Description { get { return description; } }

        protected float price;  // 가격
        public float Price { get { return price; } }

        public virtual void PrintItemInfo()
        {
            Console.WriteLine($"{(int)thisType+1}. {name}");
            Console.WriteLine($"\t가격 : {string.Format("{0:#,0}", price)}G");
            Console.WriteLine($"\t설명 : {description}");
        }
    }
    public class LongSword : Item
    {
        private float atk;  // 공격력
        public float Atk { get { return atk; } private set { atk = value; } }

        public LongSword()
        {
            thisType = ItemType.LONG_SWORD;
            name = "롱소드";
            description = "기본적인 검이다.";
            price = 450f;
            Atk = 15f;
        }
        public override void PrintItemInfo()
        {
            base.PrintItemInfo();
            Console.WriteLine($"\t공격력 상승 : {atk}");
        }
    }
    public class ClothArmor : Item
    {
        private float amr;      // 방어력
        public float Amr { get { return amr; } private set { amr = value; } }

        public ClothArmor()
        {
            thisType = ItemType.CLOTH_ARMOR;
            name = "천갑옷";
            description = "얇은 갑옷이다.";
            price = 450f;
            Amr = 10f;
        }
        public override void PrintItemInfo()
        {
            base.PrintItemInfo();
            Console.WriteLine($"\t방어력 상승 : {amr}");
        }
    }
    public class TearOfTheGoddes : Item
    {
        private float extraHp;      // 추가 hp
        public float ExtraHp { get { return extraHp; } private set { extraHp = value; } }

        public TearOfTheGoddes()
        {
            thisType = ItemType.TEAR_OF_THE_GODDES;
            name = "여신의 눈물";
            description = "희미하게 푸른빛을 품고 있는 보석이다.";
            price = 800f;
            ExtraHp = 10f;
        }
        public override void PrintItemInfo()
        {
            base.PrintItemInfo();
            Console.WriteLine($"\t체력 상승 : {extraHp}");
        }
    }

    public class Player
    {
        private float ownGold;  // 소지한 골드
        public float OwnGold { get { return ownGold; } set { ownGold = value; } }

        private float hp;   // 체력
        public float Hp { get { return hp; } private set { hp = value; } }

        private float atk;   // 공격력
        public float Atk { get { return atk; } private set { atk = value; } }

        private float amr;   // 방어력
        public float Amr { get { return amr; } private set { amr = value; } }


        private Item[] itemSlot;    // 아이템 슬롯
        public Item[] ItemSlot { get { return itemSlot; } }

        public Player(Game game)
        {
            itemSlot = new Item[6];
            OwnGold = 10000f;
            Hp = 100f;
            Atk = 15f;
            Amr = 30f;
            game.OnPlayerMenuAction += SaleItem;
        }

        public void PrintPlayerInfo()
        {
            Console.WriteLine($"플레이어   골드 보유량 : {string.Format("{0:#,0}",OwnGold)}G");
            Console.WriteLine($"플레이어 공격력 상승량 : {Atk}");
            Console.WriteLine($"플레이어 방어력 상승량 : {Amr}");
            Console.WriteLine($"플레이어   체력 상승량 : {Hp}");
            Console.WriteLine();
        }

        public void PrintItemSlot()
        {
            for(int i =0; i<itemSlot.Length; i++)
            {
                if (itemSlot[i] == null) return;
                Item item = itemSlot[i];

                Console.WriteLine($"{i + 1}. {item.Name}");
                Console.WriteLine($"\t가격 : {string.Format("{0:#,0}", item.Price)}G");
                Console.WriteLine($"\t설명 : {item.Description}");
                if (item is LongSword)
                {
                    LongSword temp = (LongSword)item;
                    Console.WriteLine($"\t공격력 상승 : {temp.Atk}");
                }
                else if (item is ClothArmor)
                {
                    ClothArmor temp = (ClothArmor)item;
                    Console.WriteLine($"\t방어력 상승 : {temp.Amr}");
                }
                else if (item is TearOfTheGoddes)
                {
                    TearOfTheGoddes temp = (TearOfTheGoddes)item;
                    Console.WriteLine($"\t체력 상승 : {temp.ExtraHp}");
                }
                Console.WriteLine();
            }
        }
        public void RegistItemSlot(Item item)
        {
            for (int i = 0; i < itemSlot.Length; i++)
            {
                if (itemSlot[i] == null)
                {
                    itemSlot[i] = item;
                    return;
                }
            }
            Console.WriteLine("빈 슬롯이 없습니다.");
        }
        public void SaleItem(int itemIndex)
        {
            for (int i = 0; i < itemSlot.Length; i++)
            {
                if (itemSlot[i] != null)
                {
                    if (itemSlot[i].ThisType == (ItemType)(itemIndex-1))
                    {
                        Console.WriteLine($"{itemSlot[i].Name}를 판매합니다.");
                        switch (itemSlot[i].ThisType)
                        {
                            case ItemType.LONG_SWORD:
                                LongSword ls = (LongSword)itemSlot[i];
                                Atk -= ls.Atk;
                                Console.WriteLine($"플레이어의 공격력이 {ls.Atk}감소하여 {Atk}이 됩니다.");
                                break;
                            case ItemType.CLOTH_ARMOR:
                                ClothArmor ca = (ClothArmor)itemSlot[i];
                                Amr -= ca.Amr;
                                Console.WriteLine($"플레이어의 방어력이 {ca.Amr}감소하여 {Amr}이 됩니다.");
                                break;
                            case ItemType.TEAR_OF_THE_GODDES:
                                TearOfTheGoddes tg = (TearOfTheGoddes)itemSlot[i];
                                Hp -= tg.ExtraHp;
                                Console.WriteLine($"플레이어의 방어력이 {tg.ExtraHp}감소하여 {Hp}이 됩니다.");
                                break;
                        }
                        ownGold += itemSlot[i].Price;
                        Console.WriteLine($"보유한 골드가 {string.Format("{0:#,0}", itemSlot[i].Price)}G 상승하여 {string.Format("{0:#,0}", ownGold)}G가 됩니다.");
                        itemSlot[i] = null;
                        return;
                    }
                }
            }

            Console.WriteLine("슬롯에 없는 아이템입니다.");
        }
        public void UpdateItemAbility(Item item)
        {
            OwnGold -= item.Price;
            if (item is LongSword)
            {
                LongSword temp = (LongSword)item;
                Atk += temp.Atk;
            }
            else if (item is ClothArmor)
            {
                ClothArmor temp = (ClothArmor)item;
                Amr += temp.Amr;
            }
            else if (item is TearOfTheGoddes)
            {
                TearOfTheGoddes temp = (TearOfTheGoddes)item;
                Hp += temp.ExtraHp;
            }
            else return;
        }
    }

    public enum ShopMenuType
    {
        PERCHASE = 1,
        SALE,
        ITEMINFO
    }
    public class Shop
    {
        private Item[] itemList;
        public Shop(Game game)
        {
            itemList = new Item[3];
            itemList[(int)ItemType.LONG_SWORD] = new LongSword();
            itemList[(int)ItemType.CLOTH_ARMOR] = new ClothArmor();
            itemList[(int)ItemType.TEAR_OF_THE_GODDES] = new TearOfTheGoddes();

            game.OnShopMenuAction += PerchaseItem;
        }

        public void PrintItemList()
        {
            foreach (Item item in itemList)
            {
                item.PrintItemInfo();
                Console.WriteLine();
            }
            Console.Write("아이템 번호를 입력하세요 (취소 0) :");
        }
        public void PerchaseItem(int itemIndex, Player player)
        {
            if (player.OwnGold >= itemList[itemIndex - 1].Price)
            {
                player.RegistItemSlot(itemList[itemIndex - 1]);
                player.UpdateItemAbility(itemList[itemIndex - 1]);
            }
            else
            {
                Console.WriteLine("소지한 돈이 부족합니다.");
            }
        }
    }

    public class Game
    {
        private Player player;
        private Shop shop;

        private bool loopGame;
        public Action<int,Player> OnShopMenuAction;
        public Action<int> OnPlayerMenuAction;

        public Game()
        {
            player = new Player(this);
            shop = new Shop(this);
            loopGame = true;
        }
        public bool RenderChooseMode()
        {
            Console.WriteLine("\n=========== 상점 메뉴 ============");
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("2. 아이템 판매");
            Console.WriteLine("3. 아이템 확인");
            Console.Write("메뉴를 선택하세요 :");
            int inputKey = InputManager.Instance().UserInputKey();
            switch(inputKey)
            {
                case 1:
                    RenderPerchaseMode();
                    return true;
                case 2:
                    RenderSaleMode();
                    return true;
                case 3:
                    RenderItemInfoMode();
                    return true;
                default:
                    return false;
            }
        }

        public void RenderPerchaseMode()
        {
            Console.WriteLine("\n============ 아이템 구매 ============\n");
            shop.PrintItemList();
            int inputKey = InputManager.Instance().UserInputKey();
            if (inputKey == 0) return;

            Console.WriteLine();

            if (OnShopMenuAction != null)
                OnShopMenuAction(inputKey, player);

            Console.WriteLine();
        }
        public void RenderSaleMode()
        {
            Console.WriteLine("\n============ 아이템 판매 ============");
            shop.PrintItemList();
            int inputKey = InputManager.Instance().UserInputKey();
            if (inputKey == 0) return;

            Console.WriteLine();
            if (OnPlayerMenuAction != null)
                OnPlayerMenuAction(inputKey);

            Console.WriteLine();
        }
        public void RenderItemInfoMode()
        {
            Console.WriteLine("\n============ 아이템 확인 ============\n");

            player.PrintPlayerInfo();
            player.PrintItemSlot();

            Console.WriteLine();
        }

        public void LoopGame()
        {
            Console.WriteLine("*****************************************");
            Console.WriteLine("************** 아이템 상점 **************");
            Console.WriteLine("*****************************************\n");


            while (loopGame)
            {
                loopGame = RenderChooseMode();
            }
        }
    }
    public class Program
    {
        static void Main(string[] argc)
        {
            Game game = new Game();
            game.LoopGame();
        }
    }
}