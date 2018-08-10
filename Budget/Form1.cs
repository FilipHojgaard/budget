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
using Filib;

namespace Budget
{
    public partial class Form1 : Form {


        Person mie = new Person();
        Person filip = new Person();
        Mutual mutual = new Mutual();

        int[] altMad;
        int[] altMieHygge;
        int[] altFilipHygge;
        int[] altMieTransport;
        int[] altFilipTransport;

        int mutualLines = 0;
        
        public Form1() {
            InitializeComponent();
        }

        public void DrawCharts() {
            // clearer series og laver en ny der hedder "udgifter"
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

            // Mad statistik
            overallMadChart.Series.Clear();
            overallMadChart.Legends.Clear();
            overallMadChart.Series.Add("mad udgifter");
            overallMadChart.Legends.Add("mad udgifterer");
            overallMadChart.Series["mad udgifter"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            overallMadChart.Series["mad udgifter"].Color = Color.Chocolate;
            overallMadChart.Series["mad udgifter"].Points.DataBindY(altMad);

            // Hygge Statistik
            overallHyggeChart.Series.Clear();
            overallHyggeChart.Legends.Clear();
            overallHyggeChart.Series.Add("Mie Hygge");
            overallHyggeChart.Series.Add("Filip Hygge");
            overallHyggeChart.Legends.Add("Mie Hygge");
            overallHyggeChart.Legends.Add("Filip Hygge");
            overallHyggeChart.Series["Mie Hygge"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            overallHyggeChart.Series["Filip Hygge"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            overallHyggeChart.Series["Mie Hygge"].Color = Color.Purple;
            overallHyggeChart.Series["Filip Hygge"].Color = Color.Blue;
            overallHyggeChart.Series["Mie Hygge"].Points.DataBindY(altMieHygge);
            overallHyggeChart.Series["Filip Hygge"].Points.DataBindY(altFilipHygge);

            // Transport Statistik
            overallTransportChart.Series.Clear();
            overallTransportChart.Legends.Clear();
            overallTransportChart.Series.Add("Mie Transport");
            overallTransportChart.Series.Add("Filip Transport");
            overallTransportChart.Legends.Add("Mie Transport");
            overallTransportChart.Legends.Add("Filip Transport");
            overallTransportChart.Series["Mie Transport"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            overallTransportChart.Series["Filip Transport"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            overallTransportChart.Series["Mie Transport"].Color = Color.Purple;
            overallTransportChart.Series["Filip Transport"].Color = Color.Blue;
            overallTransportChart.Series["Mie Transport"].Points.DataBindY(altMieTransport);
            overallTransportChart.Series["Filip Transport"].Points.DataBindY(altFilipTransport);
        }


        public void SaveFile() {
            Console.WriteLine("Attempting to save budget file");
            StreamWriter writer = new StreamWriter(saveNameBox.Text + ".bf", false);
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
            writer.WriteLine(mutualOthersUp.Value);
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
            writer.WriteLine(mieBogOp.Value);
            writer.WriteLine(mieAndetUp.Value);
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
            writer.WriteLine(filipBogUp.Value);
            writer.WriteLine(filipAndetUp.Value);
            // filip skat
            writer.WriteLine(filipASkatOp.Value);
            writer.WriteLine(filipAMOp.Value);
            writer.WriteLine(filipFradragOp.Value);

            // note
            // erstatter alle '\n' med et tegn. Jeg valgte '$' fordi der  er lav sandsynlighed for at en bruger bruger dette. 
            // så kan hele teksten stå på en linje. 
            string str = Mutual.note;
            str = str.Replace("\n", "$");
            Console.WriteLine("efter replace: " + str);
            writer.WriteLine(str);

            string miestr = Person.mieNote;
            miestr = miestr.Replace("\n", "$");
            writer.WriteLine(miestr);

            string filipstr = Person.filipNote;
            filipstr = filipstr.Replace("\n", "$");
            writer.WriteLine(filipstr);

            writer.Close();
            MessageBox.Show("Saved succesfully", "Saving Budget");
            Console.WriteLine("Saved succesfully");
        }

        public void LoadFile() {
            Console.WriteLine("attempting to load budget file");
            string[] allLines = File.ReadAllLines(saveNameBox.Text + ".bf");
            // fælles økonomi
            // fælles økonomi
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
            mutualOthersUp.Value = Int32.Parse(allLines[12]);
            // mie økonomi
            miePay.Value = Int32.Parse(allLines[13]);
            mieSU.Value = Int32.Parse(allLines[14]);
            mieTelefonOp.Value = Int32.Parse(allLines[15]);
            mieDagligTransportOp.Value = Int32.Parse(allLines[16]);
            mieLinserOp.Value = Int32.Parse(allLines[17]);
            mieAndenTransportOp.Value = Int32.Parse(allLines[18]);
            mieTandlageOp.Value = Int32.Parse(allLines[19]);
            mieFrisorOp.Value = Int32.Parse(allLines[20]);
            mieTojOp.Value = Int32.Parse(allLines[21]);
            mieHyggeOp.Value = Int32.Parse(allLines[22]);
            miePigeOp.Value = Int32.Parse(allLines[23]);
            mieBogOp.Value = Int32.Parse(allLines[24]);
            mieAndetUp.Value = Int32.Parse(allLines[25]);
            // mie skat
            mieASkat.Value = Int32.Parse(allLines[26]);
            MieAMBidrag.Value = Int32.Parse(allLines[27]);
            MieFradrag.Value = Int32.Parse(allLines[28]);
            // filip økonomi
            numericUpDown11.Value = Int32.Parse(allLines[29]);
            numericUpDown10.Value = Int32.Parse(allLines[30]);
            numericUpDown9.Value = Int32.Parse(allLines[31]);
            numericUpDown8.Value = Int32.Parse(allLines[32]);
            numericUpDown5.Value = Int32.Parse(allLines[33]);
            numericUpDown6.Value = Int32.Parse(allLines[34]);
            numericUpDown4.Value = Int32.Parse(allLines[35]);
            numericUpDown3.Value = Int32.Parse(allLines[36]);
            numericUpDown2.Value = Int32.Parse(allLines[37]);
            filipBogUp.Value = Int32.Parse(allLines[38]);
            filipAndetUp.Value = Int32.Parse(allLines[39]);
            // filip skat
            filipASkatOp.Value = Int32.Parse(allLines[40]);
            filipAMOp.Value = Int32.Parse(allLines[41]);
            filipFradragOp.Value = Int32.Parse(allLines[42]);

            // note
            // læser linjen på 41 som er ordet. erstatter '$' med '\n' så der kommer new lines tilbage når man loader.
            Mutual.note = "";
            string word = "";
            string orgword = allLines[43];
            for (int i = 0; i < orgword.Length; i++) {
                if (orgword[i].Equals('$')) {
                    Mutual.note += word;
                    Mutual.note += "\n";
                    word = "";
                } else {
                    word += orgword[i];
                }
            }
            Mutual.note += word;

            // mie note
            Person.mieNote = Filib.Filib.UnPackLines(allLines[44], '$');
            Person.filipNote = Filib.Filib.UnPackLines(allLines[45], '$');

            Syncronize();
        }

        public void calculateIndividualPercentage() {
            // awesome kode
            mieScrollbarLabel.Text = (mie.total - ((mutual.apartmentTotal + mutual.mutualOutcomeTotal) / 100 * mie.procent)).ToString();
            filipScrollbarLabel.Text = (filip.total - ((mutual.apartmentTotal + mutual.mutualOutcomeTotal) / 100 * filip.procent)).ToString();
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
            getStatistics();
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

            // scrollbar
            calculateProcent();
            calculateIndividualPercentage();
            calculateTransferAmount();

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

        // MÅNEDLIG STATISTIK
        //Gemmer alle filerne der slutter med .bf i "allFiles".
        // altMad er et array af længden af filer der slutter med .bf.
        // allLines er alle linjerne i hver fil med .bf, men vi skal kun bruge det vi skal lave statistik af. Heraf "Mad" som er nummer [6].
        // altMad arrayet gemmer hver fils mad budget. 
        private void getStatistics(){
            String[] allFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.bf");
            altMad = new int[allFiles.Length];
            altMieHygge = new int[allFiles.Length];
            altFilipHygge = new int[allFiles.Length];
            altMieTransport = new int[allFiles.Length];
            altFilipTransport = new int[allFiles.Length];
            for (int i = 0; i < allFiles.Length; i++) {
                Console.WriteLine("File " + (i+1) + " is " + allFiles[i]);
                string[] allLines = File.ReadAllLines(allFiles[i]);
                altMad[i] = Int32.Parse(allLines[6]);
                altMieHygge[i] = Int32.Parse(allLines[22]);
                altFilipHygge[i] = Int32.Parse(allLines[37]);
                altMieTransport[i] = Int32.Parse(allLines[18]);
                altFilipTransport[i] = Int32.Parse(allLines[33]);
                Console.WriteLine(altMad[i]);
                Console.WriteLine("mie hygge: " + altMieHygge[i]);
                Console.WriteLine("filip hygge: " + altFilipHygge[i]);
            }


        }

        private void mieBogOp_ValueChanged(object sender, EventArgs e) {
            mie.books = (float)mieBogOp.Value;
        }

        private void filipØkonomi_Click(object sender, EventArgs e) {

        }

        private void filipBogUp_ValueChanged(object sender, EventArgs e) {
            filip.books = (float)filipBogUp.Value;
        }

        // Method to set person.procent. Is used each time the track_bar/slider is manipulated.
        public void calculateProcent() {
            mie.procent = procentTrackBar.Value;
            filip.procent = 100 - mie.procent;
            Console.WriteLine("Procent bar: " + mie.procent + " " + filip.procent);
        }

        // Method to set person.transferAmount. Is called each time the slider is manipulated
        public void calculateTransferAmount() {
            mie.transferAmount = ((mutual.apartmentTotal + mutual.mutualOutcomeTotal - mutual.boligTilskud) * mie.procent / 100);
            filip.transferAmount = ((mutual.apartmentTotal + mutual.mutualOutcomeTotal - mutual.boligTilskud) * filip.procent / 100);
            mieTransferLabel.Text = mie.transferAmount.ToString();
            filipTransferLabel.Text = filip.transferAmount.ToString();
        }

        // slider. Manipulates the percentages. This gives info on how much money each person have left. And how much each person should have 
        // Inserted to the mutual bank account this month for a perfect budget.
        private void procentTrackBar_Scroll(object sender, EventArgs e) {
            procentLabel.Text = procentTrackBar.Value.ToString() + " %";
            calculateProcent();
            calculateIndividualPercentage();
            calculateTransferAmount();
        }

        private void procentHelpBtn_Click(object sender, EventArgs e) {
            MessageBox.Show("Sommetider er den ene person i plus og den anden " +
                "i negativ på bundlinjen. Dette værktøj hjælper med at visualisere " +
                "hvor mange penge hver person i hustanden har tilbage efter alle " +
                "udgifter er betalt. Her kan man lege med hvor meget hver især bør " +
                "betale for de fælles udgifter. Heraf Bolig udgifter i alt og de " +
                "fælles udgifter i alt. " +
                "\n\nVenstre er Mie. Højre er Filip.\n" +
                "Øverste viser hvor meget hver peson har tilbage efter alt er betalt.\n" +
                "Nederste viser hvor meget hver person burde have overført til fælles kontoen for en helt optimal måned.", "Procent hjælper");
        }


        private void mutualOthersUp_ValueChanged(object sender, EventArgs e) {
            mutual.otherOutcomes = (float)mutualOthersUp.Value;
        }

        // Skriv noter til ekstra udgifter
        private void mutualNoteButton_Click(object sender, EventArgs e) {
            NoteWindow mutualNote = new NoteWindow(Mutual.note, 0);
            mutualNote.Show();
            //DialogResult dr = mutualNote.ShowDialog();
            //if (DialogResult == DialogResult.OK) {
            //    Console.WriteLine("Du trykkede OK i noten");
            //}else if (DialogResult == DialogResult.Cancel) {
            //    Console.WriteLine("Du trykkede annuller i noten");
            //}
            //mutualNote.Dispose();

        }

        private void mieAndetUp_ValueChanged(object sender, EventArgs e) {
            mie.andet = (float)mieAndetUp.Value;
        }

        private void filipAndetUp_ValueChanged(object sender, EventArgs e) {
            filip.andet = (float)filipAndetUp.Value;
        }

        private void mieAndetBtn_Click(object sender, EventArgs e) {
            NoteWindow mieNote = new NoteWindow(Person.mieNote, 1);
            mieNote.Show();
        }

        private void filipAndetBtn_Click(object sender, EventArgs e) {
            NoteWindow filipNote = new NoteWindow(Person.filipNote, 2);
            filipNote.Show();
        }
    }
}