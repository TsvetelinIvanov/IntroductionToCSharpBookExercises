using System;

namespace _04Workers
{
    public abstract class Human : IComparable<Human>
    {
        private string personalName;
        private string familyName;

        public Human(string personalName, string familyName)
        {
            this.personalName = personalName;
            this.familyName = familyName;
        }

        public string PersonalName => this.personalName;

        public string FamilyName => this.familyName;

        public override string ToString()
        {
            return $"Personal Name: {this.PersonalName}; Family Name: {this.FamilyName};";
        }

        public int CompareTo(Human otherHuman)
        {
            int comparsion = this.PersonalName.CompareTo(otherHuman.PersonalName);
            if (comparsion == 0)
            {
                comparsion = this.FamilyName.CompareTo(otherHuman.FamilyName);
            }

            return comparsion;
        }
    }
}