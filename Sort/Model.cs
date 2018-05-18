using System;
using System.Collections.Generic;
using System.Text;

namespace Sort
{
    public class School
    {
        public int? Order { get; set; }
        public string Name { get; set; }
    }

    public class Class
    {
        public int? Order { get; set; }

        public string Name { get; set; }

        public School School { get; set; }
    }

    public class Student : IComparable<Student>
    {
        public int? Order { get; set; }

        public string Name { get; set; }

        public Class Class { get; set; }

        public int CompareTo(Student other)
        {
            if (ReferenceEquals(this, other)) return 0;  //如果两个值的引用相同，那么直接返回相等。
            if (ReferenceEquals(null, other)) return 1;  //如果该实例是空的，但是传入的实例不是空的，那么返回1

            //比较学校的序号
            var compareResult = CompareInit(this.Class.School.Order, other.Class.School.Order);
            if (compareResult != 0) return compareResult;

            //比较班级的序号
            compareResult = CompareInit(this.Class.Order, other.Class.Order);
            if (compareResult != 0) return compareResult;

            //比较学生的学号
            compareResult = CompareInit(this.Order, other.Order);
            if (compareResult != 0) return compareResult;
            
            //如果以上还未区分出大小，比较学校的名称
            compareResult = String.CompareOrdinal(this.Class.School.Name, other.Class.School.Name);
            if (compareResult != 0) return compareResult;

            //比较班级的名称
            compareResult = String.CompareOrdinal(this.Class.Name, other.Class.Name);
            if (compareResult != 0) return compareResult;

            //比较学生的名称
            return String.CompareOrdinal(this.Name, other.Name);

        }

        private int CompareInit(int? x, int? y)
        {
            if (x == null && y == null)  //如果都是空 那么返回0相等
                return 0;

            if (x.HasValue && y == null)  //如果传入X有值，但是Y是空的，那么X比Y小 返回-1。
                return -1;

            if (x == null && y.HasValue) //如果传入X为空，但是Y有值，那么X比Y大 返回1。
                return 1;

            if (x.Value > y.Value)
                return 1;

            if (x.Value < y.Value)
                return -1;

            return 0;                    //否则两个数相等
        }
    }
}
