using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Budget
{
    public partial class Form1 : Form
    {
            Person mie = new Person();
            Person filip = new Person();
            Mutual mutual = new Mutual();
        public Form1()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) {
            mie.aSkat = (float)mieASkat.Value;
            Console.WriteLine(mie.aSkat);
        }

        private void MieAMBidrag_ValueChanged(object sender, EventArgs e) {
            mie.am = (float)MieAMBidrag.Value;
            Console.WriteLine(mie.am);
        }

        private void MieFradrag_ValueChanged(object sender, EventArgs e) {
            mie.fradrag = (float)MieFradrag.Value;
            Console.WriteLine(mie.fradrag);
        }

        private void mieSkat_Click(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            Syncronize();
        }

        private void button2_Click(object sender, EventArgs e) {
            Syncronize();
        }

        private void Syncronize() {
            // MIE
            mie.aSkat = (float)mieASkat.Value;
            mie.am = (float)MieAMBidrag.Value;
            mie.fradrag = (float)MieFradrag.Value;
            mie.Calculate();
            mieBeforeTax.Text = mie.income.ToString();
            mieAfterTax.Text = mie.postTax.ToString();
            mieSkat1.Text = mie.income.ToString();
            mieSkat2.Text = mie.amBidrag.ToString();
            mieSkat3.Text = mie.payAfterAM.ToString();
            mieSkat4.Text = mie.payAfterFradrag.ToString();
            mieSkat5.Text = mie.taxToPay.ToString();
            mieSkat6.Text = mie.payAfterTax.ToString();
            mieSkat7.Text = mie.totalTax.ToString();
            mieUdgifterLabel.Text = mie.outcome.ToString();
            mieTotalLabel.Text = mie.total.ToString();

            // FILIP
            filip.aSkat = (float)filipASkatOp.Value;
            filip.am = (float)filipAMOp.Value;
            filip.fradrag = (float)filipFradragOp.Value;
            filip.Calculate();
            filipBeforeTax.Text = filip.income.ToString();
            filipAfterTax.Text = filip.postTax.ToString();
            filipSkat1.Text = filip.income.ToString();
            filipSkat2.Text = filip.amBidrag.ToString();
            filipSkat3.Text = filip.payAfterAM.ToString();
            filipSkat4.Text = filip.payAfterFradrag.ToString();
            filipSkat5.Text = filip.taxToPay.ToString();
            filipSkat6.Text = filip.payAfterTax.ToString();
            filipSkat7.Text = filip.totalTax.ToString();
            filipUdgifterLabel.Text = filip.outcome.ToString();
            filipTotalLabel.Text = filip.total.ToString();

            // FÆLLES
            mieIndkomstLabel.Text = mie.total.ToString();
            filipIndkomstLabel.Text = filip.total.ToString();
            mutual.mieIndkomst = mie.total;
            mutual.filipIndkomst = filip.total;
            mutual.Calculate();
            fallesIndkomstLabel.Text = mutual.totalMutualIncome.ToString();
            boligUdgifterIAlt.Text = mutual.apartmentTotal.ToString();
            tilbageKapital1Label.Text = (mutual.totalMutualIncome - mutual.apartmentTotal).ToString();
            fallesUdgifterIAltLabel.Text = mutual.mutualOutcomeTotal.ToString();
            totalTilbageLabel.Text = mutual.total.ToString();
        }

        private void miePay_ValueChanged(object sender, EventArgs e) {
            mie.pay = (float)miePay.Value;
        }

        private void mieSU_ValueChanged(object sender, EventArgs e) {
            mie.su = (float)mieSU.Value;
        }

        private void mieTelefonOp_ValueChanged(object sender, EventArgs e) {
            mie.phone = (float)mieTelefonOp.Value;
        }

        private void mieDagligTransportOp_ValueChanged(object sender, EventArgs e) {
            mie.transportDaily = (float)mieDagligTransportOp.Value;
        }

        private void mieLinserOp_ValueChanged(object sender, EventArgs e) {
            mie.lenses = (float)mieLinserOp.Value;
        }

        private void mieAndenTransportOp_ValueChanged(object sender, EventArgs e) {
            mie.transportOther = (float)mieAndenTransportOp.Value;
        }

        private void mieTandlageOp_ValueChanged(object sender, EventArgs e) {
            mie.dentist = (float)mieTandlageOp.Value;
        }

        private void mieFrisorOp_ValueChanged(object sender, EventArgs e) {
            mie.hair = (float)mieFrisorOp.Value;
        }

        private void mieTojOp_ValueChanged(object sender, EventArgs e) {
            mie.clothes = (float)mieTojOp.Value;
        }

        private void mieHyggeOp_ValueChanged(object sender, EventArgs e) {
            mie.fun = (float)mieHyggeOp.Value;
        }

        private void miePigeOp_ValueChanged(object sender, EventArgs e) {
            mie.girlStuff = (float)miePigeOp.Value;
        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e) {
            filip.phone = (float)numericUpDown9.Value;
        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e) {
            filip.transportDaily = (float)numericUpDown8.Value;
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e) {
            filip.transportOther = (float)numericUpDown5.Value;
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e) {
            filip.dentist = (float)numericUpDown6.Value;
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e) {
            filip.hair = (float)numericUpDown4.Value;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e) {
            filip.clothes = (float)numericUpDown3.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e) {
            filip.fun = (float)numericUpDown2.Value;
        }

        private void numericUpDown11_ValueChanged(object sender, EventArgs e) {
            filip.pay = (float)numericUpDown11.Value;
            //Console.WriteLine("løn er " + filip.pay);
        }

        private void numericUpDown10_ValueChanged(object sender, EventArgs e) {
            filip.su = (float)numericUpDown10.Value;
            //Console.WriteLine("su er " + filip.su);
        }

        private void button3_Click(object sender, EventArgs e) {
            Syncronize();
        }

        private void filipASkatOp_ValueChanged(object sender, EventArgs e) {
            filip.aSkat = (float)filipASkatOp.Value;
        }

        private void filipAMOp_ValueChanged(object sender, EventArgs e) {
            filip.am = (float)filipAMOp.Value;
        }

        private void filipFradragOp_ValueChanged(object sender, EventArgs e) {
            filip.fradrag = (float)filipFradragOp.Value;
        }

        private void button4_Click(object sender, EventArgs e) {
            Syncronize();
        }

        private void label64_Click(object sender, EventArgs e) {

        }

        private void boligTilskudOp_ValueChanged(object sender, EventArgs e) {
            mutual.boligTilskud = (float)boligTilskudOp.Value;
        }

        private void button5_Click(object sender, EventArgs e) {
            Syncronize();
        }

        private void huslejeOp_ValueChanged(object sender, EventArgs e) {
            mutual.rent = (float)huslejeOp.Value;
        }

        private void varmeOp_ValueChanged(object sender, EventArgs e) {
            mutual.heat = (float)varmeOp.Value;
        }

        private void vandOp_ValueChanged(object sender, EventArgs e) {
            mutual.water = (float)vandOp.Value;
        }

        private void elektricitetOp_ValueChanged(object sender, EventArgs e) {
            mutual.electricity = (float)elektricitetOp.Value;
        }

        private void boligForsikringOp_ValueChanged(object sender, EventArgs e) {
            mutual.homeInsurance = (float)boligForsikringOp.Value;
        }

        private void madOp_ValueChanged(object sender, EventArgs e) {
            mutual.food = (float)madOp.Value;
        }

        private void husholdningOp_ValueChanged(object sender, EventArgs e) {
            mutual.households = (float)husholdningOp.Value;
        }

        private void fjernsynOp_ValueChanged(object sender, EventArgs e) {
            mutual.television = (float)fjernsynOp.Value;
        }

        private void internetOp_ValueChanged(object sender, EventArgs e) {
            mutual.internet = (float)internetOp.Value;
        }

        private void netflixOp_ValueChanged(object sender, EventArgs e) {
            mutual.netflix = (float)netflixOp.Value;
        }

        private void spotifyOp_ValueChanged(object sender, EventArgs e) {
            mutual.spotify = (float)spotifyOp.Value;
        }

        private void groupBox10_Enter(object sender, EventArgs e) {

        }
    }
}