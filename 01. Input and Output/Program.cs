/********************
 * 콘솔을 통한 입출력
 ********************/

namespace _01._Input_and_Output
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "기본 입출력";    // Console창의 제목을 설정
            Console.BackgroundColor = ConsoleColor.Magenta;    // 텍스트 배경색 설정. 

            Console.Write("키를 입력하시오 : ");  // 문자열 출력
            Console.ReadKey();      // ConsoleKeyInfo 구조체로 할당, 콘솔창에 출력함.
            Console.WriteLine("\n입력성공");        // 문자열 출력 후 자동 줄바꿈

            Console.Write("\n키를 입력하시오 : "); 
            Console.ReadKey(true);  // 콘솔창에 출력하지 않음.
            Console.WriteLine("\n입력성공");       

            Console.ResetColor();   // 콘솔 창에 설정된 배경색과 글자색을 기본 설정 값으로 변경.
            Console.ForegroundColor = ConsoleColor.Cyan;    // 텍스트 글자색 설정

            string str = "";
            Console.Write("\n문자열을 입력하고 엔터키를 누르시오 : ");
            str = Console.ReadLine();   // string형 변수에 할당
            Console.WriteLine($"입력한 문자열은 \"{str}\" 입니다.");      // 변수 출력

            Console.Write("\n문자를 입력하고 엔터키를 누르시오 : ");
            int i = Console.Read();         // 입력한 문자를 문자를 int형으로 반환 
            Console.WriteLine($"\n입력한 문자의 아스키코드 값은 \"{i}\" 입니다."); // 변수 출력

            Console.ResetColor();   
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("\n3초 후 콘솔창이 지워집니다.");
            Thread.Sleep(3000); // 스레드를 3초간 일시 중단(밀리초 : 1/1000)
            Console.Clear();    // 콘솔 창 내용 삭제
            Console.WriteLine("1초 후 프로그램이 종료됩니다.");
            Console.ResetColor();
            
            Thread.Sleep(1000);
        }
    }
}