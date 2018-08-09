using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget
{
    class Person
    {
        // Income
        public float pay;
        public float su;
        public float income;
        public float postTax;

        // Tax
        public float aSkat;
        public float am;
        public float fradrag;

        public float amBidrag;
        public float payAfterAM;
        public float payAfterFradrag;
        public float taxToPay;
        public float payAfterTax;
        public float totalTax;

        // Outcome
        public float phone;
        public float transportDaily;
        public float fun;
        public float lenses;
        public float dentist;
        public float hair;
        public float clothes;
        public float transportOther;
        public float girlStuff;
        public float outcome;
        public float books;

        // total left overs
        public float total;

        // other fields
        public int procent;
        public float transferAmount;

        public void Calculate() {
            income = pay + su;
            postTax = Taxes(income);
            outcome = phone + transportDaily + fun + lenses + dentist + hair + clothes + transportOther + girlStuff + books;
            total = postTax - outcome;

        }

        // Beregner skatten med samme fremgangsmåde som excel arket. (Formegentlig ikke så pålidelig).
        public float Taxes(float inc) {
            Console.WriteLine("income: " + inc);
            Console.WriteLine("am er: " + am);
            amBidrag = inc * am / 100;
            payAfterAM = inc - amBidrag;
            payAfterFradrag = payAfterAM - fradrag;
            taxToPay = payAfterFradrag * aSkat / 100;
            payAfterTax = payAfterFradrag - taxToPay;
            totalTax = payAfterTax + fradrag;
            return totalTax;
        }
    }
}
