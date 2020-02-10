using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo01
{
    class Triangle
    {
        //private unless marked otherwise
        int s1, s2, s3;
        bool valid = true;

        public Triangle()
        {
            Set(1, 1, 1);
        }

        public Triangle(int s1, int s2, int s3)
        {
            Set(s1, s2, s3);
        }

        public void Set(int s1,int s2,int s3)
        {
            if(s1>0 && s2>0 && s3>0 && s1+s2>s3 && s1+s3>s2 && s2 + s3 > s1)
            {
                this.s1 = s1;
                this.s2 = s2;
                this.s3 = s3;
                valid = true;
            }
            else
            {
                valid = false;
            }
        }

        public bool IsValid()
        {
            return valid;
        }

        public int Perimeter()
        {
            if (IsValid())
                return s1 + s2 + s3;
            else
                return -1; //indicates error
        }

        public void Draw()
        {
            if(IsValid())
                Console.WriteLine("Triangle <{0},{1},{2}> drawn",s1,s2,s3);
            else
                Console.WriteLine("Invalid Triangle");
        }
    }
}
