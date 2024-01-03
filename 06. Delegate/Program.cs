using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace _06._Delegate
{
    class Specifier  // 지정자
    {
        public class Item
        {
            public string name;
            public int level;
            public float weight;

            public Item(string name, int level, float weight)
            {
                this.name = name;
                this.level = level;
                this.weight = weight;
            }
        }

        void Main()
        {
            Item[] inventory = new Item[5];

            inventory[0] = new Item("포션", 1, 3.2f);
            inventory[1] = new Item("갑옷", 2, 1.2f);
            inventory[2] = new Item("방패", 3, 4.5f);
            inventory[3] = new Item("검", 7, 8.8f);
            inventory[4] = new Item("폭탄", 6, 12.6f);



            // 이름으로 찾기
            int findIndex = -1;
            string findName = "방패";
            for(int i =0; i<inventory.Length; i++)
            {
                if (inventory[i].name == findName)
                {
                    findIndex = i;
                    break;
                }
            }

            // 레벨로 찾기
            int findLevel = 6;
            for(int i = 0; i<inventory.Length; i++)
            {
                if (inventory[i].level == findLevel)
                {
                    findLevel = i;
                    break;
                }
            }

            // 무게로 찾기
            float findWeight = 12.6f;
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i].weight == findWeight)
                {
                    findWeight = i;
                    break;
                }
            }

            // 찾아야할 것이 많아지면 위의 코드를 계속 작성해야함.
            
            
            int index1 = FindIndex(inventory, FindByName);
            int index1_ = FindIndex(inventory, value => value.name == "방패");    // 람다식
            
            int index2 = FindIndex(inventory, FindWeight6);
            int index2_ = FindIndex(inventory, value => value.weight == 6); // 람다식
        }

        public static bool FindByName(Item item)
        {
            return item.name == "방패";
        }
        public static bool FindWeight6(Item item)
        {
            return item.weight == 6;
        }

        public static int FindIndex(Item[] inventory, Predicate<Item> predicate)
        {
            for(int i =0; i<inventory.Length; i++)
            {
                if (predicate(inventory[i]))
                {
                    return i;
                }
            }
            // 못찾은 경우
            return -1;
        }
    }
    class LamDa
    {
        // 잠깐 쓰고 버리는 함수들은 멤버함수로 만드는 것이 번거로움.
        bool Less1(int value)
        {
            return value < 1;
        }
        bool Less2(int value)
        {
            return value < 2;
        }
        bool Less3(int value)
        {
            return value < 3;
        }


        void Main()
        {
            Action<string> action;

            // <함수를 통한 할당>
            // 클래스에 정의된 함수를 직접 할당
            // 클래스의 멤버함수로 연결하기 위한 기능이 있을 경우 적합
            action = Message;


            // <무명메서드>
            // 함수를 통한 연결은 함수가 직접적으로 선언되어 있어야 사용 가능
            // 할당하기 위한 함수가 간단하고 **자주 사용될수록 비효율적
            // 간단한 표현식을 통해 함수를 즉시 작성하여 전달하는 방법
            // 전달하기 위한 함수가 간단하고 일회성으로 사용될 경우에 적합
            action = delegate (string str) { Console.WriteLine(str); };


            // <람다식>
            // 무명메서드의 간단한 표현식
            action = (str) => { Console.WriteLine(str); };
            action = str => Console.WriteLine(str);

        }

        void Message(string str) { Console.WriteLine(str); }
    }

    class Program
    {
        /****************************************************************
         * 대리자 (Delegate)
         * 
         * 특정 매개 변수 목록 및 반환 형식이 있는 함수에 대한 참조
         * 대리자 인스턴스를 통해 함수를 호출 할 수 있음
         ****************************************************************/

        // <델리게이트 정의>
        // delegate 반환형 델리게이트이름(매개변수들);
        public delegate float DelegateMethod1(float x, float y);
        public delegate void DelegateMethod2(string str);


        public float Plus(float left, float right) { return left + right; }
        public float Minus(float left, float right) { return left - right; }
        public float Multi(float left, float right) { return left * right; }
        public float Divide(float left, float right) { return left / right; }
        public void Message(string message) { Console.WriteLine(message); }


        // <델리게이트 사용>
        // 반환형과 매개변수가 일치하는 함수를 델리게이트 변수에 할당
        // 델리게이트 변수에 참조한 함수를 대리자를 통해 호출 가능
        void Main1()
        {
            DelegateMethod1 delegate1 = new DelegateMethod1(Plus);  // 델리게이트 인스턴스 생성
            DelegateMethod2 delegate2 = Message;                    // 간략한 문법의 델리게이트 인스턴스 생성

            delegate1.Invoke(20, 10);   // Plus(20, 10);            // Invoke를 통해 참조되어 있는 함수를 호출
            delegate2("메세지");        // Message("메세지");       // 간략한 문법의 델리게이트 함수 호출

            delegate1 = Plus;
            Console.WriteLine(delegate1(20, 10));       // output : 30
            delegate1 = Minus;
            Console.WriteLine(delegate1(20, 10));       // output : 10
            delegate1 = Multi;
            Console.WriteLine(delegate1(20, 10));       // output : 200
            delegate1 = Divide;
            Console.WriteLine(delegate1(20, 10));       // output : 2

            // delegate2 = Plus;        // error : 반환형과 매개변수가 일치하지 않은 함수는 참조 불가
        }

        static void Main(string[] args)
        {

        }
    }

}