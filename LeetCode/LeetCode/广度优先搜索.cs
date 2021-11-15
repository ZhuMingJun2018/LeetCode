using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class 广度优先搜索
    {
        #region 695. 岛屿的最大面积 2021-11-15 13:56:51
        public static int _695_MaxAreaOfIsland(int[][] grid)
        {
            if (grid.Length == 0
                || grid[0].Length == 0)
                return 0;
            int max = 0;
            //find island
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    max = Math.Max(max, _656_FindSurroundIsland(grid, i, j));
                }
            }
            return max;
        }

        private static int _656_FindSurroundIsland(int[][] grid, int x, int y)
        {
            if (x < 0
                || x == grid.Length
                || y < 0
                || y == grid[x].Length
                || grid[x][y] != 1)
                return 0;

            int asn = 1;
            grid[x][y] = 0;
            //left
            asn += _656_FindSurroundIsland(grid, x - 1, y)
            //right
                + _656_FindSurroundIsland(grid, x + 1, y)
            //up
                + _656_FindSurroundIsland(grid, x, y - 1)
            //dow
                + _656_FindSurroundIsland(grid, x, y + 1);

            return asn;
        }

        #endregion

        #region 733. 图像渲染 

        /// <summary>
        /// 
        /// https://leetcode-cn.com/problems/flood-fill/
        /// </summary>
        /// <param name="image"></param>
        /// <param name="sr"></param>
        /// <param name="sc"></param>
        /// <param name="newColor"></param>
        /// <returns></returns>
        public static int[][] _733_FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            return image;
        }
        #endregion
    }
}
