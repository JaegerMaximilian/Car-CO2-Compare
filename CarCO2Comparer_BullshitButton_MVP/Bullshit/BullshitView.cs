using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarCO2Comparer_BullshitButton_MVP.Bullshit
{
    public partial class BullshitView : Form
    {
        public BullshitView(string text)
        {
            InitializeComponent();

            txtBox_Joke.Text = text;
        }
    }
}
