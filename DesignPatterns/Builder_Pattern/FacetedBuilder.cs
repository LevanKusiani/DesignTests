namespace DesignPatterns.Builder_Pattern
{
    public class Human
    {
        //Address info
        public string streetAddress, postcode, city;

        //Employment info
        public string companyName, position;
        public int annualIncome;

        public override string ToString()
        {
            return $"lives at: {streetAddress}, {city}; works at: {companyName}, position: {position}, income: {annualIncome}";
        }
    }

    public class HumanBuilder //Facade
    {
        //reference!
        protected Human human = new Human();

        public HumanAddressBuilder Lives => new HumanAddressBuilder(human);
        public HumanJobBuilder Works => new HumanJobBuilder(human);

        public static implicit operator Human(HumanBuilder hb) => hb.human;
    }

    public class HumanAddressBuilder : HumanBuilder
    {
        public HumanAddressBuilder(Human human)
        {
            this.human = human;
        }

        public HumanAddressBuilder LivesAt(string streetAddress)
        {
            human.streetAddress = streetAddress;
            return this;
        }

        public HumanAddressBuilder Postcode(string postcode)
        {
            human.postcode = postcode;
            return this;
        }

        public HumanAddressBuilder LivesIn(string city)
        {
            human.city = city;
            return this;
        }
    }

    public class HumanJobBuilder : HumanBuilder
    {
        public HumanJobBuilder(Human human)
        {
            this.human = human;
        }

        public HumanJobBuilder At(string companyName)
        {
            human.companyName = companyName;
            return this;
        }

        public HumanJobBuilder AsA(string position)
        {
            human.position = position;
            return this;
        }

        public HumanJobBuilder Earning(int amount)
        {
            human.annualIncome = amount;
            return this;
        }
    }
}
