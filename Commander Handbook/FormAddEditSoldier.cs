using System;
using System.Windows.Forms;

namespace Commander_Handbook
{
    public partial class FormAddEditSoldier : Form
    {
        private bool edit = false;
        private FormMain formMain;
        private Soldier soldier;

        public FormAddEditSoldier(FormMain formMain)
        {
            InitializeComponent();
            buttonSave.Text = "Add";
            edit = false;
            this.formMain = formMain;
            soldier = new Soldier();
            Fill(soldier);
        }

        public FormAddEditSoldier(FormMain formMain, Soldier soldier)      
        {
            InitializeComponent();
            buttonSave.Text = "Edit";
            edit = true;
            this.formMain = formMain;
            this.soldier = soldier;
            Fill(soldier);
        }

        private void Fill(Soldier soldier)
        {
            textBoxAddress.Text = soldier.Address;
            textBoxParentsAddress.Text = soldier.ParentsAddress;
            textBoxProfession.Text = soldier.Profession;
            textBoxMilitaryFormation.Text = soldier.MilitaryFormation;
            textBoxFIO.Text = soldier.FIO;
            textBoxEducation.Text = soldier.Education;
            textBoxCitizenship.Text = soldier.Citizenship;
            textBoxRank.Text = soldier.Rank;
            textBoxServiceForm.Text = soldier.ServiceForm;
            dateTimePickerDateOfReceivingRank.Value = soldier.DateOfReceivingRank;
            dateTimePickerStartOfService.Value = soldier.StartOfService;
            dateTimePickerEndOfService.Value = soldier.EndOfService;
        }

        private Soldier CollectSoldier()
        {
            return new Soldier()
            {
                FIO = textBoxFIO.Text,
                Address = textBoxAddress.Text,
                ParentsAddress = textBoxParentsAddress.Text,
                Profession = textBoxProfession.Text,
                Education = textBoxEducation.Text,
                Citizenship = textBoxCitizenship.Text,
                MilitaryFormation = textBoxMilitaryFormation.Text,
                Rank = textBoxRank.Text,
                ServiceForm = textBoxServiceForm.Text,
                DateOfReceivingRank = dateTimePickerDateOfReceivingRank.Value,
                StartOfService = dateTimePickerStartOfService.Value,
                EndOfService = dateTimePickerEndOfService.Value
            };
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            soldier = CollectSoldier();
            if (!edit)
            {
                formMain.AddSoldier(soldier);
            }
            else
            {
                formMain.EditSoldier(soldier);
            }

            MessageBox.Show("Save!", "Message", MessageBoxButtons.OK);
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
