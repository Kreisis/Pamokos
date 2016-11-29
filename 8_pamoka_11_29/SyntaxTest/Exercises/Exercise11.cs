using System;
using System.Collections.Generic;
using System.Linq;

namespace SyntaxTest.Exercises
{
    public class DrivingLicence
    {
        int _age;
        public DrivingLicence()
        {
            Random rnd = new Random();
            _age = rnd.Next(10, 30);
        }
    }

    public class Exercise11
    {
        /*
          Parašykite viešą metodą pavadinimu WhoCanDriveATractor, kuris grąžina string tipo sąrašo rezultatą. Įsidėmėkite, kad sąrašas yra aprašomas kitaip nei masyvas.
          Metodas turi priimti vieną DrivingLicence tipo masyvo elementą pavadinimu licences.
          DrivingLicence tipas yra klasė, kuri dar neegzistuoja, jūs turite ją parašyti šalia šiame faile.
        */
        
        public List<string> WhoCanDriveATractor(DrivingLicence[] licences)
        {
            return new List<string>();
        }
    }
}
