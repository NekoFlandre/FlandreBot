using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlandreBotBeta
{

        class Dice
        {
                public int Amount = 1;
                public int MaxValue = 20;
                public int Bonus = 0;
                public override string ToString()
                {
                        if (Bonus > 0)
                                return Amount + "d" + MaxValue + "+" + Bonus;
                        else
                        {
                                if (Bonus == 0)
                                {
                                        return Amount + "d" + MaxValue;
                                }
                                else
                                {
                                        return Amount + "d" + MaxValue + Bonus;
                                }
                        }

                }
                public int Roll()
                {
                        var r = new Random(BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0));
                        int res = 0;
                        for (int i = 0; i != Amount; ++i)
                                res += r.Next(1, MaxValue + 1);
                        res += Bonus;
                        return res;
                }
                public Dice(int amount, int max_value, int bonus)
                {
                        Amount = amount;
                        MaxValue = max_value;
                        Bonus = bonus;
                }
                public Dice(string d)
                {
                        ///<summary>
                        ///利用"1d8"等简化语法构造骰子类型实例
                        ///</summary>
                        int type = 0;//0:nobonus 1:positive bonus -1:negative bonus
                        int a = 0, m = 0, b = 0;
                        foreach (char c in d)
                        {
                                if (c == '+')
                                {
                                        type = 1;
                                        break;
                                }
                                if (c == '-')
                                {
                                        type = -1;
                                        break;
                                }
                        }
                        if (type == 0)
                        {
                                int IndexofD = d.IndexOf('d');
                                string amt = d.Substring(0, IndexofD);
                                string max = d.Substring(IndexofD + 1, d.Length - IndexofD - 1);
                                a = Convert.ToInt32(amt);
                                m = Convert.ToInt32(max);
                                b = 0;
                        }
                        if (type == 1)
                        {
                                int IndexofD = d.IndexOf('d');
                                int IndexofP = d.IndexOf('+');
                                string amt = d.Substring(0, IndexofD);
                                string max = d.Substring(IndexofD + 1, IndexofP - IndexofD - 1);
                                string bon = d.Substring(IndexofP + 1, d.Length - IndexofP - 1);
                                a = Convert.ToInt32(amt);
                                m = Convert.ToInt32(max);
                                b = Convert.ToInt32(bon);
                        }
                        if (type == -1)
                        {
                                int IndexofD = d.IndexOf('d');
                                int IndexofS = d.IndexOf('-');
                                string amt = d.Substring(0, IndexofD);
                                string max = d.Substring(IndexofD + 1, IndexofS - IndexofD - 1);
                                string bon = '-' + d.Substring(IndexofS + 1, d.Length - IndexofS - 1);
                                a = Convert.ToInt32(amt);
                                m = Convert.ToInt32(max);
                                b = Convert.ToInt32(bon);
                        }
                        Amount = a;
                        MaxValue = m;
                        Bonus = b;
                }
        }

}
