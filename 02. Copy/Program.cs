﻿/*********************************************************************************
 <메모리 저장방식>
 * 값 형식
    : 변수가 값을 담는 데이터 형식 (*스택 메모리에 할당.) 
 * 참조 형식
    : 변수의 값이 아닌 값이 있는 곳의 *주소를 담는 데이터 형식 (*힙 메모리에 할당.)

 <깊은 복사와 얕은 복사>
 * 얕은 복사 (Shallow Copy)
    : 객체를 복사할 때 참조만을 복사하는 것.
    : 참조를 복사한 것이기에 복사된 값을 변경할 경우 원본의 값도 변경됨. 
 * 깊은 복사 (Deep Copy)
    : 
*********************************************************************************/

namespace _02._Copy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "깊은 복사와 얕은 복사";    // Console창의 제목을 설정
            
        }
    }
}