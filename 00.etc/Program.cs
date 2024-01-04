namespace _00._etc
{
    #region 예외처리 Exception 
    /// <summary>
    /// 예외처리
    /// </summary>
    class DealWithException
    {
        // <try catch 예외처리>
        // 예외가 발생할 수 있는 구문을 지정하고 진행중 예외가 발생할 경우 발생한 예외를 처리하는 구문을 작성
        // try : 예외발생에 대한 검사의 범위를 지정하는 블록
        // catch : 발생한 예외를 처리하는 블록
        class TryCatch
        {
            void Main()
            {
                int value;
                try
                {
                    Console.WriteLine("수를 입력하세요(2~8) : ");
                    string input = Console.ReadLine();

                    value = int.Parse(input);

                    Console.WriteLine($"입력하신 수는 : {value}");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("잘못된 수를 입력하셨습니다.");
                    value = 8;
                }
            }
        }

        // <throw 예외 발생>
        // 의도적으로 예외를 발생시키는 방법
        // 프로그램에서 치명적일 수 있는 동작이 예상되는 경우 예외 처리를 유도하기 위해 진행
        class Throw
        {
            void Main2()
            {
                try
                {
                    int[] array = { 1, 3, 5, 7, 9 };
                    int index = Array.IndexOf(array, 8);

                    if (index < 0)
                        throw new InvalidOperationException();

                    array[index] = 0;
                }
                catch(InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("배열에서 원하는 값을 찾지 못함");
                }
            }
        }

        // <스택 풀기>
        // 함수에서 예외가 발생한 경우 catch 문을 발견할 때까지 호출된 스택을 풀어냄
        void Func3() { Console.Write("3전"); throw new Exception("스택풀기"); Console.Write("3후"); }
        void Func2() { Console.Write("2전"); Func3(); Console.Write("2후"); }
        void Func1() { Console.Write("1전"); Func2(); Console.Write("1후"); }

        void Main3()
        {
            try
            {
                Func1();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
    #endregion
}