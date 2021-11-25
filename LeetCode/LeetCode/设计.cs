using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class 设计
    {
        #region 1603. 设计停车系统 2021-11-25 20:51:53
        //https://leetcode-cn.com/problems/design-parking-system/
        public class ParkingSystem
        {
            Dictionary<int,int> Dic { get; set; }


            public ParkingSystem(int big, int medium, int small)
            {
                Dic = new Dictionary<int, int>();
                Dic[1] = big;
                Dic[2] = medium;
                Dic[3] = small;
            }

            public bool AddCar(int carType)
            {
                if (Dic.ContainsKey(carType) && Dic[carType] > 0)
                {
                    Dic[carType]--;
                    return true;
                }

                return false;
            }
        }

        /**
         * Your ParkingSystem object will be instantiated and called as such:
         * ParkingSystem obj = new ParkingSystem(big, medium, small);
         * bool param_1 = obj.AddCar(carType);
         */


        #endregion

        #region 1656. 设计有序流


        #endregion
    }
}
