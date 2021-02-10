using EFCreateSeeder.DAL;
using EFCreateSeeder.DAL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFCreateSeeder
{
    public partial class MainForm : Form
    {
        private EFContext _context { get; set; }
        public MainForm()
        {
            _context = new EFContext();
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DBSeeder.SeedAll(_context);
        }
    }
}
