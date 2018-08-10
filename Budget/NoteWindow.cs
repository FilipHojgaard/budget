using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Budget {


    public partial class NoteWindow : Form {

        string note;
        int mode; //0 er mutual. 1 er Mie. 2 er Filip.

        public NoteWindow(string udeNote, int mode) {
            this.mode = mode;
            InitializeComponent();
            this.note = udeNote;
            noteTextBox.Text = note;
        }

        private void button1_Click(object sender, EventArgs e) {
            note = noteTextBox.Text;
            switch (mode) {
                case 0:
                    Mutual.note = note;
                    MessageBox.Show("TEST: Trykkede på mutual");
                    break;
                case 1:
                    Person.mieNote = note;
                    MessageBox.Show("TEST: Trykkede på mie");
                    break;
                case 2:
                    Person.filipNote = note;
                    MessageBox.Show("TEST: Trykkede på filip");
                    break;
            }
            Hide();
        }

        private void button2_Click(object sender, EventArgs e) {
            Hide();
        }

    }
}
