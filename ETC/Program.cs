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

namespace ETC
{

    #region 1. 일반화 활용 배열 복사
    // 1. 일반화를 이용하여 어떤 자료형의 배열이더라도 복사가능한 함수를 구현.
    //class Generic
    //{
    //    static void ArrayCopy<T>(T[] arr, T[] temp)
    //    {
    //        for(int i =0; i<arr.Length; i++)
    //        {
    //            temp[i] = arr[i];
    //        }
    //    }
    //    static void Main(string[] argc)
    //    {
    //        int[] a = new int[5] { 1, 2, 3, 4, 5 };
    //        int[] b = new int[5];
    //        float[] c = new float[5] { 1.2f, 2.3f, 3.4f, 4.5f, 5.6f };
    //        float[] d = new float[5];

    //        Console.WriteLine("befor copy");
    //        Console.Write("int b:");
    //        for(int i =0; i<5; i++)
    //        {
    //            Console.Write($"{b[i]},");
    //        }
    //        Console.WriteLine();
    //        Console.Write("float d:");
    //        for (int i = 0; i < 5; i++)
    //        {
    //            Console.Write($"{d[i]},");
    //        }
    //        Console.WriteLine();

    //        ArrayCopy<int>(a, b);
    //        ArrayCopy<float>(c, d);

    //        Console.WriteLine("after copy");
    //        Console.Write("int b:");
    //        for (int i = 0; i < 5; i++)
    //        {
    //            Console.Write($"{b[i]},");
    //        }
    //        Console.WriteLine();
    //        Console.Write("float d:");
    //        for (int i = 0; i < 5; i++)
    //        {
    //            Console.Write($"{d[i]},");
    //        }
    //        Console.WriteLine();
    //    }
    //}
    #endregion

    #region 2. 대리자를 활용 계산기
    // 2. 대리자를 이용하여 계산기 구현.

    public class Program
    {
        bool runProgram;
        private RenderManager renderMgr;
        private InputManager inputMgr;
        private Calculator cal;
        public Program()
        {
            renderMgr = new RenderManager();
            inputMgr = new InputManager();
            cal = new Calculator();
            runProgram = true;
        }

        public void RunProgram()
        {
            while (runProgram)
            {
                renderMgr.Rendering(inputMgr.strbd);
                if(inputMgr.InputString())
                {
                    cal.SetCommand(inputMgr.left, inputMgr.oper, inputMgr.right);
                    inputMgr.InputComplete(cal.Equal());
                    renderMgr.RenderClear(200);
                    renderMgr.Rendering(inputMgr.strbd);
                }
                else
                {
                    renderMgr.RenderClear(200);
                }
            }
        }
    }
    public class RenderManager
    {
        public void Rendering(StringBuilder strbd)
        {
            Console.WriteLine("--------------");
            Console.WriteLine(strbd);
            Console.WriteLine("--------------");
            Console.WriteLine();
        }
        public void RenderClear(int time)
        {
            Thread.Sleep(time);
            Console.Clear();
        }
    }
    public class InputManager
    {
        public Calculator cal;
        public StringBuilder strbd;
        public double left; 
        public double right;
        public char oper;

        private bool[] inputCondition;
        private int bIndex;
        public InputManager()
        {
            strbd = new StringBuilder();
            cal = new Calculator(); 
            inputCondition = new bool[3] { false,false,false};
            bIndex = 0;
        }
        public bool InputString()
        {
            strbd.Append(" ");
            string temp = Console.ReadLine();
            inputCondition[bIndex] = true;
            switch(bIndex)
            {
                case 0: // left
                    left = double.Parse(temp);
                    break;
                case 1: // oper
                    oper = char.Parse(temp);
                    break;
                case 2: // right
                    right = double.Parse(temp);
                    break;
            }
            strbd.Append(temp);
            bIndex++;
            if (bIndex > 2)
            {
                strbd.Append(" = ");
                return true;
            }
            else
            {
                return false;
            }
        }
        public void InputComplete(double result)
        {
            // 입력조건 충족
            strbd.Append(" = ");
            strbd.Append(result);
            ResetCondition();   
        }
        private void ResetCondition() // 입력조건 초기화
        {
            bIndex = 0;
            Array.Fill<bool>(inputCondition, false);
            strbd.Clear();
        }
    }

    public class Calculator
    {
        Func<double, double, double> fd;
        double left;
        double right;
        public double Plus(double left, double right) { return left + right; }
        public double Minus(double left, double right) { return left - right; }
        public double Multi(double left, double right) { return left * right; }
        public double Divide(double left, double right) { return left / right; }
        public double Mod(double left, double right) { return left % right; }

        public void SetCommand(double left, char oper, double right)
        {
            this.left = left;
            this.right = right;
            // 계산금지
            switch (oper)
            {
                case '+':
                    fd = Plus;
                    break;
                case '-':
                    fd = Minus;
                    break;
                case '*':
                    fd = Multi;
                    break;
                case '/':
                    fd = Divide;
                    break;
                case '%':
                    fd = Mod;
                    break;
            }
        }
        public double Equal()
        {
            // 조건문 쓰기 금지
            return fd(left, right);
        }
    }
    public class TestCalculator
    {
        public static void Main()
        {
            Program program = new Program();
            program.RunProgram();
        }
    }
    #endregion

    #region 3. 콜백함수 활용 버튼
    //// 3. 콜백함수를 이용하여 플레이어를 조작하는 UI 버튼제작 (점프, 대시)
    //abstract class Button
    //{
    //    protected Action action;
    //    public virtual void OnClick()
    //    {
    //        if(action != null)
    //        {
    //            action();
    //        }
    //    }
    //}

    //class DashButton : Button
    //{
    //    public DashButton(Action action)
    //    {
    //        this.action = action;
    //    }
    //    public override void OnClick()
    //    {
    //        Console.WriteLine("대쉬버튼 클릭");
    //        base.OnClick();
    //    }
    //}
    //class JumpButton : Button
    //{
    //    public JumpButton(Action action)
    //    {
    //        this.action = action;
    //    }
    //    public override void OnClick()
    //    {
    //        Console.WriteLine("점프버튼 클릭");
    //        base.OnClick();
    //    }
    //}

    //class Player
    //{
    //    public void Dash()
    //    {
    //        Console.ForegroundColor = ConsoleColor.Green;
    //        Console.WriteLine("플레이어 대시");
    //        Console.ResetColor();
    //    }
    //    public void Jump()
    //    {
    //        Console.ForegroundColor = ConsoleColor.Cyan;
    //        Console.WriteLine("플레이어 점프");
    //        Console.ResetColor();
    //    }
    //}

    //class TestButton
    //{
    //    static void Main(string[] args) 
    //    {
    //        Player player = new Player();
    //        Button dashButton = new DashButton(player.Dash);
    //        Button jumpButton = new JumpButton(player.Jump);

    //        dashButton.OnClick();
    //        jumpButton.OnClick();   
    //    }
    //}
    #endregion

    #region A+ Array.FindAll<>()
    // A+. Array.FindAll() 을 이용하여 int 배열안에 있는 5보다 작은수들을 모두 찾는 기능 구현.
    //class TestAFA
    //{
    //    static void Main(string[] argc)
    //    {
    //        int[] arr = new int[10] { 1, -5, 7, 10, 12, 3, -8, 9, 4, 5 };
    //        int[] arr2 = Array.FindAll<int>(arr, value => value < 5);
    //        Array.Sort(arr2);

    //        Console.ForegroundColor = ConsoleColor.Red;
    //        Console.WriteLine("Ascending Array");
    //        Console.ResetColor();
    //        for (int i = 0; i < arr2.Length; i++)
    //        {
    //            Console.Write($"{arr2[i]} ");
    //        }
    //        Console.WriteLine();

    //        Array.Sort(arr2, (a, b) => (a > b) ? -1 : 1);

    //        Console.ForegroundColor = ConsoleColor.Blue;
    //        Console.WriteLine("Descending Array");
    //        Console.ResetColor();
    //        for (int i = 0; i < arr2.Length; i++)
    //        {
    //            Console.Write($"{arr2[i]} ");
    //        }
    //    }
    //}
    #endregion
}