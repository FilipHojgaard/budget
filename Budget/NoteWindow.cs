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

        public NoteWindow(string udeNote) {
            InitializeComponent();
            this.note = udeNote;
            noteTextBox.Text = note;
        }

        private void button1_Click(object sender, EventArgs e) {
            note = noteTextBox.Text;
            Mutual.note = note;
            Hide();
        }

        private void button2_Click(object sender, EventArgs e) {
            Hide();
        }

    }
}
