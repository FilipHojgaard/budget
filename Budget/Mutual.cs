using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget {
    class Mutual {
        // Income
        public float mieIndkomst;
        public float filipIndkomst;
        public float boligTilskud;
        public float totalMutualIncome;

        // Apartment Outcome
        public float rent;
        public float heat;
        public float water;
        public float electricity;
        public float apartmentTotal;
        public float homeInsurance;

        // Mutual outcomes
        public float food;
        public float households;
        public float television;
        public float internet;
        public float netflix;
        public float spotify;
        public float mutualOutcomeTotal;
        public float otherOutcomes;

        // Total left over
        public float total;

        // Other fields
        public static string note = "";

        public void Calculate() {
            totalMutualIncome = mieIndkomst + filipIndkomst + boligTilskud;
            apartmentTotal = rent + heat + water + electricity + homeInsurance;
            mutualOutcomeTotal = food + households + television + internet + netflix + spotify + otherOutcomes;
            total = totalMutualIncome - apartmentTotal - mutualOutcomeTotal;
        }
    }
}
