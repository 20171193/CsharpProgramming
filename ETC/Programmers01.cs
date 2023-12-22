using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ETC
{
    namespace Programmers01    // 게임 맵 최단거리
    {
        public struct Pos
        {
            public int x;
            public int y;

            public Pos(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        class Solution
        {

            public int[,] visited = new int[101, 101];
            public int[] dx = new int[4] { 1, 0, -1, 0 };
            public int[] dy = new int[4] { 0, 1, 0, -1 };
            public int n, m;

            public Pos player, target;

            public void BFS(int[,] map)
            {
                visited[player.y, player.x] = 1;
                Queue<Pos> q = new Queue<Pos>();
                q.Enqueue(player);

                while (q.Count > 0)
                {
                    Pos temp = q.Peek();
                    q.Dequeue();

                    for (int i = 0; i < 4; i++)
                    {
                        int nx = dx[i] + temp.x;
                        int ny = dy[i] + temp.y;

                        if (nx < 0 || nx >= m || ny < 0 || ny >= n) continue;
                        if (visited[ny, nx] > 0) continue;
                        if (map[ny, nx] == 0) continue;

                        visited[ny, nx] = visited[temp.y, temp.x] + 1;
                        Pos npos = new Pos(nx, ny);
                        q.Enqueue(npos);
                    }
                }

            }

            public int solution(int[,] maps)
            {
                int answer = 0;
                n = maps.GetLength(0);
                m = maps.GetLength(1);

                player = new Pos(0, 0);
                target = new Pos(m - 1, n - 1);

                BFS(maps);

                answer = visited[target.y, target.x] != 0 ? visited[target.y, target.x] : -1;

                return answer;
            }
        }


    }

    namespace Programmers02
    {

    }
}
