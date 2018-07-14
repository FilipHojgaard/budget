using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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

        public void DrawCharts() {
            // clearer series og laver en ny der hedder "abe"
            UdgifterChart.Series.Clear();
            UdgifterChart.Legends.Clear();
            UdgifterChart.Series.Add("udgifter");

            // make it look good
            UdgifterChart.Legends.Add("Udgifter");
            UdgifterChart.Legends[0].LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Table;
            UdgifterChart.Legends[0].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            UdgifterChart.Legends[0].Alignment = StringAlignment.Center;
            UdgifterChart.Legends[0].Title = "Udgifter";
            UdgifterChart.Legends[0].BorderColor = Color.Black;

            // sætter typen for "abe" series til at være en pie chart.
            UdgifterChart.Series["udgifter"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            // indsætter data til "abe"
            UdgifterChart.Series["udgifter"].Points.AddXY("Bolig Udgifter", mutual.apartmentTotal);
            UdgifterChart.Series["udgifter"].Points.AddXY("Fælles udgifter", mutual.mutualOutcomeTotal);
            UdgifterChart.Series["udgifter"].Points.AddXY("Mie Udgifter", mie.outcome);
            UdgifterChart.Series["udgifter"].Points.AddXY("Filip Udgifter", filip.outcome);
            //UdgifterChart.Series["udgifter"].Points.AddXY("Bolig Udgifter" + " #PERCENT{P2}", mutual.apartmentTotal);
            //UdgifterChart.Series["udgifter"].Points.AddXY("Fælles udgifter" + " #PERCENT{P2}", mutual.mutualOutcomeTotal);
            //UdgifterChart.Series["udgifter"].Points.AddXY("Mie Udgifter" + " #PERCENT{P2}", mie.outcome);
            //UdgifterChart.Series["udgifter"].Points.AddXY("Filip Udgifter" + " #PERCENT{P2}", filip.outcome);

            //UdgifterChart.Series["udgifter"].IsValueShownAsLabel = true;
            //UdgifterChart.Series["udgifter"].Label = "#PERCENT{P2}";
        }


        public void SaveFile() {
            Console.WriteLine("Attempting to save budget file");
            StreamWriter writer = new StreamWriter(@"budget_file_01.txt", false);
            // saves every bit of information on each line
            // fælles økonomi
            writer.WriteLine(boligTilskudOp.Value);
            writer.WriteLine(huslejeOp.Value);
            writer.WriteLine(varmeOp.Value);
            writer.WriteLine(vandOp.Value);
            writer.WriteLine(elektricitetOp.Value);
            writer.WriteLine(boligForsikringOp.Value);
            writer.WriteLine(madOp.Value);
            writer.WriteLine(husholdningOp.Value);
            writer.WriteLine(fjernsynOp.Value);
            writer.WriteLine(internetOp.Value);
            writer.WriteLine(netflixOp.Value);
            writer.WriteLine(spotifyOp.Value);
            // mie økonomi
            writer.WriteLine(miePay.Value);
            writer.WriteLine(mieSU.Value);
            writer.WriteLine(mieTelefonOp.Value);
            writer.WriteLine(mieDagligTransportOp.Value);
            writer.WriteLine(mieLinserOp.Value);
            writer.WriteLine(mieAndenTransportOp.Value);
            writer.WriteLine(mieTandlageOp.Value);
            writer.WriteLine(mieFrisorOp.Value);
            writer.WriteLine(mieTojOp.Value);
            writer.WriteLine(mieHyggeOp.Value);
            writer.WriteLine(miePigeOp.Value);
            // mie skat
            writer.WriteLine(mieASkat.Value);
            writer.WriteLine(MieAMBidrag.Value);
            writer.WriteLine(MieFradrag.Value);
            // filip økonomi
            writer.WriteLine(numericUpDown11.Value);
            writer.WriteLine(numericUpDown10.Value);
            writer.WriteLine(numericUpDown9.Value);
            writer.WriteLine(numericUpDown8.Value);
            writer.WriteLine(numericUpDown5.Value);
            writer.WriteLine(numericUpDown6.Value);
            writer.WriteLine(numericUpDown4.Value);
            writer.WriteLine(numericUpDown3.Value);
            writer.WriteLine(numericUpDown2.Value);
            // filip skat
            writer.WriteLine(filipASkatOp.Value);
            writer.WriteLine(filipAMOp.Value);
            writer.WriteLine(filipFradragOp.Value);
            writer.Close();
            MessageBox.Show("Saved succesfully", "Saving Budget");
            Console.WriteLine("Saved succesfully");
        }

        public void LoadFile() {
            Console.WriteLine("attempting to load budget file");
            string[] allLines = File.ReadAllLines(@"budget_file_01.txt");
            // fælles økonomi
            boligTilskudOp.Value = Int32.Parse(allLines[0]);
            huslejeOp.Value = Int32.Parse(allLines[1]);
            varmeOp.Value = Int32.Parse(allLines[2]);
            vandOp.Value = Int32.Parse(allLines[3]);
            elektricitetOp.Value = Int32.Parse(allLines[4]);
            boligForsikringOp.Value = Int32.Parse(allLines[5]);
            madOp.Value = Int32.Parse(allLines[6]);
            husholdningOp.Value = Int32.Parse(allLines[7]);
            fjernsynOp.Value = Int32.Parse(allLines[8]);
            internetOp.Value = Int32.Parse(allLines[9]);
            netflixOp.Value = Int32.Parse(allLines[10]);
            spotifyOp.Value = Int32.Parse(allLines[11]);
            // mie økonomi
            miePay.Value = Int32.Parse(allLines[12]);
            mieSU.Value = Int32.Parse(allLines[13]);
            mieTelefonOp.Value = Int32.Parse(allLines[14]);
            mieDagligTransportOp.Value = Int32.Parse(allLines[15]);
            mieLinserOp.Value = Int32.Parse(allLines[16]);
            mieAndenTransportOp.Value = Int32.Parse(allLines[17]);
            mieTandlageOp.Value = Int32.Parse(allLines[18]);
            mieFrisorOp.Value = Int32.Parse(allLines[19]);
            mieTojOp.Value = Int32.Parse(allLines[20]);
            mieHyggeOp.Value = Int32.Parse(allLines[21]);
            miePigeOp.Value = Int32.Parse(allLines[22]);
            // mie skat
            mieASkat.Value = Int32.Parse(allLines[23]);
            MieAMBidrag.Value = Int32.Parse(allLines[24]);
            MieFradrag.Value = Int32.Parse(allLines[25]);
            // filip økonomi
            numericUpDown11.Value = Int32.Parse(allLines[26]);
            numericUpDown10.Value = Int32.Parse(allLines[27]);
            numericUpDown9.Value = Int32.Parse(allLines[28]);
            numericUpDown8.Value = Int32.Parse(allLines[29]);
            numericUpDown5.Value = Int32.Parse(allLines[30]);
            numericUpDown6.Value = Int32.Parse(allLines[31]);
            numericUpDown4.Value = Int32.Parse(allLines[32]);
            numericUpDown3.Value = Int32.Parse(allLines[33]);
            numericUpDown2.Value = Int32.Parse(allLines[34]);
            // filip skat
            filipASkatOp.Value = Int32.Parse(allLines[35]);
            filipAMOp.Value = Int32.Parse(allLines[36]);
            filipFradragOp.Value = Int32.Parse(allLines[37]);

            Syncronize();
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
            // Skat numerics
            mie.aSkat = (float)mieASkat.Value;
            mie.am = (float)MieAMBidrag.Value;
            mie.fradrag = (float)MieFradrag.Value;

            // Økonomi numerics
            mie.pay = (float)miePay.Value;
            mie.su = (float)mieSU.Value;
            mie.phone = (float)mieTelefonOp.Value;
            mie.transportDaily = (float)mieDagligTransportOp.Value;
            mie.lenses = (float)mieLinserOp.Value;
            mie.transportOther = (float)mieAndenTransportOp.Value;
            mie.hair = (float)mieFrisorOp.Value;
            mie.dentist = (float)mieTandlageOp.Value;
            mie.clothes = (float)mieTojOp.Value;
            mie.fun = (float)mieHyggeOp.Value;
            mie.girlStuff = (float)miePigeOp.Value;

            mie.Calculate();
            // skat labels
            mieBeforeTax.Text = mie.income.ToString();
            mieAfterTax.Text = mie.postTax.ToString();
            mieSkat1.Text = mie.income.ToString();
            mieSkat2.Text = mie.amBidrag.ToString();
            mieSkat3.Text = mie.payAfterAM.ToString();
            mieSkat4.Text = mie.payAfterFradrag.ToString();
            mieSkat5.Text = mie.taxToPay.ToString();
            mieSkat6.Text = mie.payAfterTax.ToString();
            mieSkat7.Text = mie.totalTax.ToString();
            // Økonomi labels
            mieUdgifterLabel.Text = mie.outcome.ToString();
            mieTotalLabel.Text = mie.total.ToString();

            // FILIP
            // Skat numerics
            filip.aSkat = (float)filipASkatOp.Value;
            filip.am = (float)filipAMOp.Value;
            filip.fradrag = (float)filipFradragOp.Value;

            // Økonomi numerics
            filip.pay = (float)numericUpDown11.Value;
            filip.su = (float)numericUpDown10.Value;
            filip.phone = (float)numericUpDown9.Value;
            filip.transportDaily = (float)numericUpDown8.Value;
            filip.transportOther = (float)numericUpDown5.Value;
            filip.dentist = (float)numericUpDown6.Value;
            filip.hair = (float)numericUpDown4.Value;
            filip.clothes = (float)numericUpDown3.Value;
            filip.fun = (float)numericUpDown2.Value;

            filip.Calculate();
            // skat labels
            filipBeforeTax.Text = filip.income.ToString();
            filipAfterTax.Text = filip.postTax.ToString();
            filipSkat1.Text = filip.income.ToString();
            filipSkat2.Text = filip.amBidrag.ToString();
            filipSkat3.Text = filip.payAfterAM.ToString();
            filipSkat4.Text = filip.payAfterFradrag.ToString();
            filipSkat5.Text = filip.taxToPay.ToString();
            filipSkat6.Text = filip.payAfterTax.ToString();
            filipSkat7.Text = filip.totalTax.ToString();
            // Økonomi labels
            filipUdgifterLabel.Text = filip.outcome.ToString();
            filipTotalLabel.Text = filip.total.ToString();

            // FÆLLES
            // numerics
            mutual.boligTilskud = (float)boligTilskudOp.Value;
            mutual.rent = (float)huslejeOp.Value;
            mutual.heat = (float)varmeOp.Value;
            mutual.water = (float)vandOp.Value;
            mutual.electricity = (float)elektricitetOp.Value;
            mutual.homeInsurance = (float)boligForsikringOp.Value;
            mutual.food = (float)madOp.Value;
            mutual.households = (float)husholdningOp.Value;
            mutual.television = (float)fjernsynOp.Value;
            mutual.internet = (float)internetOp.Value;
            mutual.netflix = (float)netflixOp.Value;
            mutual.spotify = (float)spotifyOp.Value;

            // labels
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

            // statistics
            DrawCharts();
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

        private void button6_Click(object sender, EventArgs e) {
            SaveFile();
        }

        private void button7_Click(object sender, EventArgs e) {
            LoadFile();
        }

        private void button8_Click(object sender, EventArgs e) {
            Syncronize();
        }
    }
}