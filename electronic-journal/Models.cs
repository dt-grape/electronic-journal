﻿

namespace electronic_journal
{
    public class Models
    {
        public class Teacher
        {
            public int id { get; set; }
            public string name { get; set; }
            public int user { get; set; }
        }
        public class Token
        {
            public string Auth_Token { get; set; }
        }

        public class User
        {
            public string email { get; set; }
            public int id { get; set; }
            public string username { get; set; }
        }

        public class Subject
        {
            public int id { get; set; }
            public string name { get; set; }
            public string group_number { get; set;}
            public int teacher { get; set; }
        }

        public class Student
        {
            public int id { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public int subject { get; set; }
        }

        public class Date
        {
            public int id { get; set; }
            public string date { get; set; }
            public int subject { get; set; }
        }
        
        public class Mark
        {
            public int id;
            public string mark;
            public int student;
            public int date;
        }
    }
}
