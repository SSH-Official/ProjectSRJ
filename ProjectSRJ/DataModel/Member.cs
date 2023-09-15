using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSRJ
{
    public class Member
    {
        public string ID { get; }
        public string Password { get; }
        public string Name { get; }
        public int Age { get; }
        public string Gender { get; }

        public enum Alias
        {
            Index, ID, Password, Name, Age, Gender
        }

        public Member(string iD, string password, string name, int age, string gender)
        {
            ID = iD;
            Password = password;
            Name = name;
            Age = age;
            Gender = gender;
        }

        public override string ToString()
        {
            return $"Member : [ID = {ID}, Password = {Password}, Name = {Name}, Age = {Age}, Gender = {Gender}]";
        }
    }
}
