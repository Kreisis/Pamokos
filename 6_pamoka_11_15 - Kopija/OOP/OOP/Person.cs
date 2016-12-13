﻿using System;

namespace OOP
{
    //naudodamas klasę, gali susikurti savo kintamųjų tipus
    //ji apibrėžia duomenis, kuriuos gali turėti tipas
    //ir veiksmus (metodus), kuriuos gali turėti tipas

    public class Person
    {
        //name ir age yra vadinami "fields"
        //tai kintamieji, kurie gyvena klasės viduje
        private string name = "N/A";

        //private yra access modifier
        //jis reiškia, kad šitas laukas yra pasislėpęs
        //klasės viduje. Lauko reikšmės negalėsi pakeisti tiesiogiai
        private int age = 0;

        //static reiškia, kad jei sukursi du Person objektus
        //ir vienam pakeisti weight reiškmę,
        //ji pasikeis ir kitam, t.y.
        //objektai naudosis tuo pačiu field'u
        public static string secret = "123";

        //cia yra du konstruktoriai
        //tai specialios struktūros, kurių pagalba
        //galim greitai sukurti objektą
        public Person()
        {
            
        }

        public Person(string _name, int _age, string _favouriteMeal)
        {
            name = _name;
            age = _age;
            FavoriteMeal = _favouriteMeal;
        }

        //Name ir Age yra properties
        //Jie gali keisti fields reikšmes
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Length > 0)
                    name = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value;
            }
        }

        //gali aprašyti tik property,
        //o laukus aprašyti tik kai tau reikia sudėtingesnių getters ir setters
        public string FavoriteMeal { get; set; }

        //klasė gali turėti metodus,
        //kurie gali atlikti veiksmus su klasės duomenimis
        public override string ToString()
        {
            return Name + " yra " + Age + " metų amžiaus";
        }

        //public yra access modifier. jis reiškia, 
        //kad šitą metodą galėsi kviesti iš visur
        //t.y. jis nėra pasislėpęs
        public int GetBirthYear()
        {
            return DateTime.Now.Year - age;
        }
    }
}
