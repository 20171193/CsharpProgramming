namespace _01._Input_and_Output
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "기본 입출력";    // Console창의 제목을 설정
            Console.BackgroundColor = ConsoleColor.DarkBlue;    // 텍스트 배경색 설정. 
            Console.Write("문자를 입력하시오 : ");  // 문자열 출력
            Console.ReadKey(); // ConsoleKeyInfo 구조체로 할당 
            Console.WriteLine("\n입력성공");        // 문자열 출력 후 자동 줄바꿈

            Console.ResetColor();   // 콘솔 창에 설정된 배경색과 글자색을 기본 설정 값으로 변경.
            Console.ForegroundColor = ConsoleColor.DarkGray;    // 텍스트 글자색 설정

            string str = "";
            Console.Write("\n문자열을 입력하고 엔터키를 누르시오 : ");
            str = Console.ReadLine();   // string형 변수에 할당
            Console.WriteLine($"입력한 문자열은 \"{str}\" 입니다.");      // 출력 방식 1
            Console.WriteLine("입력한 문자열은 \"" + str + "\" 입니다."); // 출력 방식 2

            Console.WriteLine("\n3초 후 콘솔창이 지워집니다.");
            Thread.Sleep(3000); // 스레드를 3초간 일시 중단(밀리초 : 1/1000)
            Console.Clear();    // 콘솔 창 내용 삭제
            Console.WriteLine("1초 후 프로그램이 종료됩니다.");
            Thread.Sleep(1000);
        }
    }
}