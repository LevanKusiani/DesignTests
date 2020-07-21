using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Builder_Pattern
{
    public class Person
    {
        public string name;
        public bool gender;
        public string position;

        public class Builder : PersonGenderBuilder<Builder>
        {

        }

        public static Builder New => new Builder();

        public override string ToString()
        {
            return $"name: {name ?? "undefined"}, position: {position ?? "undefined"}, gender: {(gender ? "male" : "female" )}";
        }
    }

    //Recursive generics on a fluent builder
    public abstract class PersonBuilder
    {
        protected Person person = new Person();

        public Person Build()
        {
            return person;
        }
    }

    //Fluent builder approach
    public class PersonInfoBuilder<T> : PersonBuilder where T : PersonInfoBuilder<T>
    {
        public T Called(string name)
        {
            person.name = name;
            return (T)this;
        }

        public override string ToString()
        {
            return person.ToString();
        }
    }

    public class PersonJobBuilder<T> : PersonInfoBuilder<PersonJobBuilder<T>> where T : PersonJobBuilder<T>
    {
        public T WorksAs(string position)
        {
            person.position = position;
            return (T)this;
        }
    }

    public class PersonGenderBuilder<T> : PersonJobBuilder<PersonGenderBuilder<T>> where T : PersonGenderBuilder<T>
    {
        public T IsOfGender(bool gender)
        {
            person.gender = gender;
            return (T)this;
        }
    }
}
