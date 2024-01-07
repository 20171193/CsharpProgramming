/***********************************************************************************************************************
 
 * 객체지향 프로그래밍 - OOP(Object-Oriented Programming)
    * 절차지향 : 프로그램의 순차적인 처리를 위주로 설계하는 방법 (C)
    * 객체지향 : 서로 상호작용하는 객체를 기본 단위로 구성하는 방법 (C#, C++)
               : 비교적 복잡한 구조에 대한 설계에 용이
 
 * 객체지향 4특징
    * 1.캡슐화 : 객체를 상태와 기능으로 묶는 것.
               : 객체의 내부 상태와 기능을 *숨기고, 허용한 상태와 기능만의 *엑세스 허용.
    * 2.다형성 : 부모클래스의 함수를 자식클래스에서 *재정의하여 자식 클래스의 다른 반응을 구현.
    * 3.추상화 : 관련 특성 및 엔터티의 상호 작용을 클래스로 모델링하여 시스템의 추상적 표현을 정의.
    * 4.상속   : 부모클래스의 모든 기능을 가지는 자식 클래스를 설계.
    * 
 
 * 객체설계 5원칙 (SOLID)
    * (S)단일 책임 원칙      : 객체는 오직 하나의 책임을 가져야 함.
    * (O)개방 폐쇄 원칙      : 객체는 확장에 개방적, 수정에 폐쇄적이어야 함.
    * (L)리스코프 치환 원칙   : 자식클래스는 언제나 자신의 부모클래스를 대체할 수 있어야 함.
    * (I)인터페이스 분리 원칙 : 인터페이스는 작은 단위들로 분리시켜 구성하며, 사용하지 않는 함수는 포함하지 않아야 함.
    * (D)의존성 역전 원칙     : 객체는 하위클래스(상위클래스를 구현한 객체)보다 상위클래스(추상성이 높은 상위 개념)에 의존해야함.
 
 ************************************************************************************************************************/

namespace _03._OOP
{
    #region 추상화(Abstraction)
    abstract class Item // 하나 이상의 추상함수를 포함하는 추상클래스
    {
        // 구체화 시킬 수 없는 기능을 추상적 표현으로 선언
        // 밑에 선언한 Sell, Use 등의 기능은 각각의 Item(Potion, Bomb 등)에서 각각 구체화됨.
        public abstract void Sell();    // 추상함수는 선언만 진행.
                                        // 자식에서 구체화
        public abstract void Use();
    }
    class Potion : Item
    {
        public override void Sell()
        {
            Console.WriteLine("포션을 판매하여 30골드를 획득합니다.");
        }
        public override void Use()
        {
            Console.WriteLine("포션을 사용해 체력을 회복합니다.");
        }
    }
    class Branch : Item
    {
        public override void Sell()
        {
            Console.WriteLine("나뭇가지를 판매하여 50골드를 획득합니다.");
        }
        public override void Use() { } // 추상함수를 사용하지 않는 경우라도 꼭 구현해야함.
    }
    #endregion

    #region 캡슐화(Encapsulation)
    class Bank
    {
        // 허용한 정보와 기능의 엑세스를 허용하고 보관/보호할 정보와 기능들을 캡슐/은닉화
        
        // coin이란 변수에 대한 직접적인 접근을 private으로 막는다.
        private int coin;   // coin변수는 직접 접근이 불가.

        public void EarnCoin(int value) // 외부에서 호출 -> 내부에서 동작
        {
            coin += value;
        }
        public void SpendCoin(int value)
        {
            if (value <= coin)
            {
                coin -= value;
            }
        }
    }
    #endregion

    #region 상속(Inheritance)
    class Monster
    {
        // 공통된 기능을 Monster라는 부모클래스에서 정의합니다.
        // Monster클래스를 상속하는 자식클래스에게 모든 기능을 부여합니다.
        protected string name;  // Monster클래스를 상속한 클래스에서 접근가능.
        
        public void Move()  // 공통된 기능
        {
            Console.WriteLine($"{name} 이/가 움직입니다.");
        }
        public void NormalAttack()  // 공통된 기능
        {
            Console.WriteLine($"{name} 이/가 공격합니다.");
        }
    }
    class Zombie : Monster
    {
        public Zombie()
        {
            name = "좀비";
        }
        public void Bite()  // 자식의 추가기능
        {
            Console.WriteLine($"{name} 가 깨뭅니다.");
        }
    }
    class Slime : Monster
    {
        public Slime()
        {
            name = "슬라임";
        }
        public void Split() // 자식의 추가기능
        {
            Console.WriteLine($"{name} 이 분열합니다.");
        }
    }

    #endregion

    #region 다형성(Polymorphism)
    class Skill
    {
        // 부모클래스 Skill의 멤버 Execute는 Skill을 상속하는 자식클래스에서 다양하게 재정의가 가능.
        // Skill(FireBall, Dash)의 Execute는 각각 다르게 동작.
        public virtual void Execute()   // 가상함수 정의
        {
            Console.WriteLine("스킬 재사용 대기시간을 진행시킴");
        }
    }
    class FireBall : Skill
    {
        public override void Execute()
        {
            base.Execute();     // 부모클래스(base)의 Execute 함수 실행
                                // 꼭 부모클래스의 기능을 실행할 필요는 없음.
            Console.WriteLine("화염구 발사");

        }
    }
    class Dash : Skill
    {
        public override void Execute()
        {
            Console.WriteLine("근거리 대쉬");
        }
    }

    // 새로운 클래스를 추가하거나 확장할 때 기존 코드에 영향을 최소화할 수 있음.
    class Player
    {
        Skill skill;

        public void LearnSkill(Skill skill)
        {
            this.skill = skill;
        }

        public void UseSkill()
        {
            skill.Execute();
        }
    }

    // Heal이라는 새로운 클래스를 추가한다고 가정했을 때, 기존 소스를 수정할 필요가 없음. 
    class Heal : Skill
    {
        public override void Execute()
        {
            base.Execute();
            Console.WriteLine("체력을 회복합니다.");
        }
    }

    #endregion

    class Program
    { 
        static void Main(string[] args)
        {
            #region 추상화 사용예제
            Console.WriteLine("     < 추상화 사용 예시 >\n");
            //Item item = new Item();       // error : 추상클래스는 인스턴스생성 불가
            Item potion = new Potion();
            potion.Use();   // 구체화 한 실제기능 실행
            potion.Sell();
            Item branch = new Branch();
            branch.Use();   // 정의하지 않은 함수
            branch.Sell();
            #endregion

            #region 캡슐화 사용예제
            Bank bank = new Bank();
            //bank.coin = 100000;       // error : private으로 선언된 coin에 직접 접근 불가
            bank.EarnCoin(2000);
            bank.SpendCoin(2000);
            #endregion

            #region 상속 사용예제
            Console.WriteLine("\n     <   상속 사용 예시 >\n");
            Zombie zombie1 = new Zombie();
            Slime slime1 = new Slime();

            // 자식클래스에서는 부모클래스에서 정의한 기능 모두를 사용가능
            zombie1.NormalAttack();
            slime1.NormalAttack();

            // 각각의 자식클래스에서 새로 추가한 기능을 사용가능
            zombie1.Bite();
            slime1.Split();

            // *다운캐스팅 : 부모클래스는 자식클래스 자료형으로 명시적 형변환 가능.
            //            : 명시적 = 수동적
            Monster monster1 = new Zombie();   // monster1을 자식클래스인 Zombie형으로 다운캐스팅
            Zombie zombie2 = (Zombie)monster1;
            if(monster1 is Zombie)
            {
                Console.WriteLine("형변환 성공 : monster1은 Zombie형 입니다.");    // 실행
            }
            else
            {
                Console.WriteLine("형변환 실패 : monster1은 Zombie형이 아닙니다.");   // 실행x
            }
            //Slime slime2 = (Slime)monster1;    // error : monster1은 현재 Zombie형이므로 Slime의 부모클래스가 아님.
            Slime asSlime = monster1 as Slime;  // 형변환이 가능하다면 형변환.
            if (monster1 is Slime)
            {
                Console.WriteLine("형변환 성공 : monster1은 Slime형 입니다.");    // 실행
            }
            else
            {
                Console.WriteLine("형변환 실패 : monster1은 Slime형이 아닙니다.");   // 실행x
            }
            #endregion

            #region 다형성 사용예제
            Console.WriteLine("\n     < 다형성 사용 예시 >\n");

            Skill fireBall = new FireBall();
            fireBall.Execute();

            Skill dash = new Dash();
            dash.Execute();

            Player player = new Player();
            Skill heal = new Heal();
            player.LearnSkill(heal);
            player.UseSkill();
            #endregion
        }
    }
}