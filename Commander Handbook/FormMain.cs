using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Commander_Handbook
{
    public partial class FormMain : Form
    {
        private List<Soldier> soldiers;
        private string pathToDatabase = "../../Database.txt";
        private Soldier edittingSolder;

        public FormMain()
        {
            InitializeComponent();
        }

        public void AddSoldier(Soldier soldier)
        {
            soldiers.Add(soldier);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = soldiers;
        }

        public void EditSoldier(Soldier newSoldier)
        {
            soldiers.Remove(edittingSolder);
            soldiers.Add(newSoldier);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = soldiers;
        }

        private List<Soldier> GetSoldiers()
        {
            List<Soldier> soldiers = new List<Soldier>();
            using(StreamReader streamReader = new StreamReader(pathToDatabase))
            {
                string line;
                while((line = streamReader.ReadLine()) != null)
                {
                    soldiers.Add(new Soldier(line));
                }
            }
            return soldiers;
        }

        private void SaveSoldiers(List<Soldier> soldiers)
        {
            using(StreamWriter streamWriter = new StreamWriter(pathToDatabase))
            {
                foreach(var s in soldiers)
                {
                    streamWriter.WriteLine(s.ToString());
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormAddEditSoldier formAddEdit = new FormAddEditSoldier(this);
            formAddEdit.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            string fio = "";
            try
            {
                fio = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch{}

            Soldier soldier = soldiers.Where(s => s.FIO == fio).FirstOrDefault();
            if (soldier == null)
            {
                MessageBox.Show("Select Soldier!");
                return;
            }
            else
            {
                edittingSolder = soldier;
                FormAddEditSoldier formAddEditSoldier = new FormAddEditSoldier(this, soldier);
                formAddEditSoldier.ShowDialog();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string fio = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            for(int i = 0;i < soldiers.Count;i++)
            {
                if (soldiers[i].FIO == fio)
                {
                    soldiers.Remove(soldiers[i]);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = soldiers;
                    MessageBox.Show($"Delete \"{fio}\"", "Message", MessageBoxButtons.OK);
                    break;
                }
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchFio = textBoxSearch.Text;
            if (searchFio == "")
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = soldiers;
            }
            else
            {
                var searchSolders = soldiers.Where(s => s.FIO.IndexOf(searchFio) > -1).ToList();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = searchSolders;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            soldiers = GetSoldiers();
            dataGridView1.DataSource = soldiers;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSoldiers(soldiers);
        }
    }
}
