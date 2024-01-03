using System;
using System.Xml;
namespace Main
{
    #region ENUM
    public enum MapType
    {
        Home = 0,
        City,
        WeaponFactory
    }
    #endregion
    #region 인터페이스
    public interface IEquipable
    {
        public void Equiped();
    }
    public interface IChooseable
    {
        public void Choise(int index);
    }
    public interface IOpenable
    {
        public void Open();
    }
    public interface IUseable
    {
        public void Use();
    }
    public interface IRideable
    {
        public void Ride();
    }
    public interface IEntranceable
    {
        public void Entrance();
    }
    public interface IInputable
    {
        public ConsoleKeyInfo InputKey();
        public string InputString();
    }
    #endregion
    class Game
    {
        public Player player;
        public UI ui;
        public List<Map> maps;
        public Game()
        {
            maps = new List<Map>();
            maps.Add(new Home());
            maps.Add(new City());
            maps.Add(new WeaponFactory());
            maps[(int)MapType.Home].Gates[0].linkedMap = maps[(int)MapType.WeaponFactory];
            maps[(int)MapType.Home].Gates[1].linkedMap = maps[(int)MapType.City];
            maps[(int)MapType.City].Gates[0].linkedMap = maps[(int)MapType.Home];
            maps[(int)MapType.WeaponFactory].Gates[0].linkedMap = maps[(int)MapType.Home];
            player = new Player(maps[(int)MapType.Home]);
            ui = new UI();
        }
        public void Rungame()
        {
            while (true)
            {
                ui.RenderUI(player);
                ui.TimeClear(500);
            }
        }
    }
    class UI
    {
        public void RenderUI(Player player)
        {
            Map curMap = player.curMap;
            Console.Write($"현위치:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(curMap.Name);
            Console.ResetColor();
            Console.WriteLine();
            // 아이템 슬롯
            for (int i = 0; i < player.Items.Count; i++)
            {
                Console.Write($"{i + 1}:{player.Items[i]} ");
            }
            Console.WriteLine();
            Console.WriteLine("\n ");
            curMap.RenderGateList();
            Console.WriteLine();
            ConsoleKeyInfo inputKey = player.InputKey();
            switch (inputKey.Key)
            {
                case ConsoleKey.D1:
                    player.OpenGate(curMap.Gates[0]);
                    break;
                case ConsoleKey.D2:
                    if (curMap.Gates.Count < 2)
                    {
                        Console.WriteLine("2번 게이트는 존재하지 않습니다. 1번으로 들어갑니다.");
                        player.OpenGate(curMap.Gates[0]);
                    }
                    else
                    {
                        player.OpenGate(curMap.Gates[1]);
                    }
                    break;
                case ConsoleKey.D3:
                    if (curMap.Gates.Count < 2)
                    {
                        Console.WriteLine("3번 게이트는 존재하지 않습니다. 1번으로 들어갑니다.");
                        player.OpenGate(curMap.Gates[0]);
                    }
                    else
                    {
                        player.OpenGate(curMap.Gates[1]);
                    }
                    break;
                default:
                    Console.WriteLine("1번 게이트로 들어갑니다.");
                    player.OpenGate(curMap.Gates[0]);
                    break;
            }
        }
        public void TimeClear(int time)
        {
            Thread.Sleep(time);
            Console.Clear();
        }
    }
    class Player : IInputable
    {
        public Map curMap;
        private List<Item> items;
        public List<Item> Items { get { return items; } }
        public Player(Map startMap)
        {
            curMap = startMap;
            items = new List<Item>();
        }
        public void GetItem()
        {
        }
        public void OpenGate(Gate gate)
        {
            gate.Open();
            curMap = gate.linkedMap;
            curMap.Entrance();
            curMap.RenderItemList();
            ConsoleKey key;
            do
            {
                Console.WriteLine("획득할 아이템을 입력하세요");
                key = InputKey().Key;
                switch (key)
                {
                    case ConsoleKey.D1:
                        break;
                    case ConsoleKey.D2:
                        break;
                    case ConsoleKey.D3:
                        break;
                    case ConsoleKey.D4:
                        break;
                    default:
                        key = ConsoleKey.Escape;
                        break;
                }
            } while (key != ConsoleKey.Escape);
        }
        public ConsoleKeyInfo InputKey()
        {
            return Console.ReadKey();
        }
        public string InputString()
        {
            return Console.ReadLine();
        }
    }
    #region 탈것
    //class Mobility : IRideable
    //{
    //}
    //class Ship : Mobility, IOpenable
    //{
    //}
    #endregion
    #region 맵
    class Map : IEntranceable
    {
        protected MapType mapType;
        public MapType MapType { get { return mapType; } }
        protected Box box;
        public Box Box_ { get { return box; } }
        protected List<Gate> gates;
        public List<Gate> Gates { get { return gates; } }
        protected string name;
        public string Name { get { return name; } }
        public void RenderGateList()
        {
            for (int i = 0; i < gates.Count; i++)
            {
                Console.Write($"{i + 1}:{gates[i].Name} ");
            }
        }
        public void RenderItemList()
        {
            for (int i = 0; i < box.items.Count; i++)
            {
                Console.Write($"{i + 1}:{box.items[i]} ");
            }
        }
        public void Entrance()
        {
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(500);
                Console.Write(".");
            }
            Console.WriteLine();
        }
    }
    class Home : Map
    {
        public Home()
        {
            mapType = MapType.Home;
            name = "집";
            gates = new List<Gate>();
            gates.Add(new Gate("무기 제작소"));
            gates.Add(new Gate("마을"));
            box = new Box(MapType.City);
        }
        public void Entrance()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(name);
            Console.ResetColor();
            Console.Write("에 입장합니다.");
            base.Entrance();
        }
    }
    class City : Map
    {
        public City()
        {
            mapType = MapType.City;
            name = "마을";
            gates = new List<Gate>();
            gates.Add(new Gate("집"));
            box = new Box(MapType.City);
        }
        public void Entrance()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(name);
            Console.ResetColor();
            Console.Write("에 입장합니다.");
            base.Entrance();
        }
    }
    class WeaponFactory : Map
    {
        public WeaponFactory()
        {
            mapType = MapType.WeaponFactory;
            name = "무기 제작소";
            gates = new List<Gate>();
            gates.Add(new Gate("집"));
            box = new Box(MapType.WeaponFactory);
        }
        public void Entrance()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(name);
            Console.ResetColor();
            Console.Write("에 입장합니다.");
            base.Entrance();
        }
    }
    #endregion
    #region 맵 오브젝트
    class Box : IChooseable
    {
        public List<Item> items;
        public Box(MapType map)
        {
            items = new List<Item>();
            SetItemBox(map);
        }
        private void SetItemBox(MapType map)
        {
            switch (map)
            {
                case MapType.City:
                    items.Add(new HpPotion());
                    items.Add(new MpPotion());
                    items.Add(new Herb());
                    items.Add(new NikeShoes());
                    break;
                case MapType.WeaponFactory:
                    items.Add(new Sword());
                    items.Add(new Bow());
                    items.Add(new Armor());
                    break;
                default:
                    break;
            }
        }
        public void Choise(int index)
        {
            Console.Write($"{index + 1}번 상자를 엽니다.");
            Thread.Sleep(300);
        }
    }
    class Gate : IOpenable
    {
        public Map linkedMap;
        private string name;
        public string Name { get { return name; } }
        public Gate(string name)
        {
            this.name = name;
        }
        public void Open()
        {
            Console.WriteLine($"{name}를 엽니다.");
        }
    }
    #endregion
    #region 아이템
    class Item
    {
        protected string name;
        public string Name { get { return name; } }
        public virtual void IntoSlot()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(name);
            Console.ResetColor();
            Console.WriteLine("을/를 슬롯에 넣습니다.");
            Thread.Sleep(500);
            Console.Clear();
        }
    }
    // 마을 아이템
    class HpPotion : Item, IUseable
    {
        public HpPotion()
        {
            name = "체력 물약";
        }
        public void Use()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(name);
            Console.ResetColor();
            Console.WriteLine("을 사용해 체력을 회복합니다.");
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
    class MpPotion : Item, IUseable
    {
        public MpPotion()
        {
            name = "마력 물약";
        }
        public void Use()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(name);
            Console.ResetColor();
            Console.WriteLine("을 사용해 마력을 회복합니다.");
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
    class Herb : Item, IUseable
    {
        public Herb()
        {
            name = "약초";
        }
        public void Use()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(name);
            Console.ResetColor();
            Console.WriteLine("를 사용해 상태이상을 제거합니다.");
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
    class NikeShoes : Item, IEquipable
    {
        public NikeShoes()
        {
            name = "나이키 신발";
        }
        public override void IntoSlot()
        {
            base.IntoSlot();
            Equiped();
        }
        public void Equiped()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(name);
            Console.ResetColor();
            Console.WriteLine("을 장착합니다. 이동속도가 증가합니다.");
        }
    }
    // 무기제작소 아이템
    class Sword : Item, IEquipable
    {
        public Sword()
        {
            name = "검";
        }
        public override void IntoSlot()
        {
            base.IntoSlot();
            Equiped();
        }
        public void Equiped()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(name);
            Console.ResetColor();
            Console.WriteLine("을 장착합니다. 공격력이 증가합니다.");
        }
    }
    class Bow : Item, IEquipable
    {
        public Bow()
        {
            name = "활";
        }
        public override void IntoSlot()
        {
            base.IntoSlot();
            Equiped();
        }
        public void Equiped()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(name);
            Console.ResetColor();
            Console.WriteLine("을 장착합니다. 사거리가 증가합니다.");
        }
    }
    class Armor : Item, IEquipable
    {
        public Armor()
        {
            name = "갑옷";
        }
        public override void IntoSlot()
        {
            base.IntoSlot();
            Equiped();
        }
        public void Equiped()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(name);
            Console.ResetColor();
            Console.WriteLine("을 장착합니다. 방어력이 증가합니다.");
        }
    }
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Rungame();
        }
    }
}

