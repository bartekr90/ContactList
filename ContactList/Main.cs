using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ContactList
{
    public partial class MainWindow : Form
    {
        private int _editedIdOfContact = 0;
        private Contact _contact;
        private List<Contact> _contactList;

        private FileHelper<List<Contact>> fileHelper =
            new FileHelper<List<Contact>>(Program._FilePath);

        public MainWindow()
        {
            InitializeComponent();
            InitCombobox();
            DgvRefresh();
            SetColumnsHeader();
            CheckType();
            tbFirstName.Select();
        }       

        private void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_editedIdOfContact != 0)
                {
                    _contactList.RemoveAll(x => x._Id == _editedIdOfContact);
                    _contact = CreateNewContact(_editedIdOfContact);
                }
                else
                    _contact = CreateNewContact(GetNewId());

                _contactList.Add(_contact);
                fileHelper.Serialization(_contactList);
                _editedIdOfContact = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd zapisywania kontaktu: " +
                    $"{ex.Message} {ex.Source} ");
            }
            finally
            {
                DgvRefresh();
            }
        }

        private void burRefresh_Click(object sender, EventArgs e)
        {
            DgvRefresh();
        }

        private void butSaveAsNew_Click(object sender, EventArgs e)
        {
            try
            {
                _contactList = fileHelper.Deserialization();
                _contact = CreateNewContact(GetNewId());
                _contactList.Add(_contact);
                fileHelper.Serialization(_contactList);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd zapisywania nowego kontaktu:" +
                    $" {ex.Message} {ex.Source} ");
            }
            finally
            {
                DgvRefresh();
            }
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckType();
        }

        private void pbProfilPicture_Click(object sender, EventArgs e)
        {
            AddPicture();
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            try
            {
                _contactList = fileHelper.Deserialization();
                PrepareToEditContact();
                var confirm = MessageBox.Show
                     ($"Czy napewno chcesz usnunąć: {_contact._FirstName + " " + _contact._LastName.Trim()}",
                     "Usuwanie kontaktu",
                     MessageBoxButtons.OKCancel);
                if (confirm == DialogResult.OK)
                {
                    _contactList.RemoveAll(x => x._Id == _editedIdOfContact);
                    _editedIdOfContact = 0;
                    fileHelper.Serialization(_contactList);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd usuwania: {ex.Message} {ex.Source} ");
            }
            finally
            {
                DgvRefresh();
            }

        }

        private void butAddPicture_Click(object sender, EventArgs e)
        {
            AddPicture();
        }

        private void bEditContact_Click(object sender, EventArgs e)
        {
            _contactList = fileHelper.Deserialization();
            PrepareToEditContact();
        }

        Contact CreateNewContact(int newId)
        {
            var contact = new Contact
            {
                _Id = newId,
                _Photo = pbProfilPicture.ImageLocation,
                _FirstName = tbFirstName.Text,
                _LastName = tbLastName.Text,
                _PhoneNr = tbPhoneNr.Text,
                _Email = tbEmail.Text,
                _Type = cmbType.Text,
                _Company = tbCompany.Text,
                _Position = tbPosition.Text,
                _Comments = rtbComment.Text,
            };
            var photoPath = Path.Combine(Program._DataFolder, $"{contact._Id}.jpg");

            if (contact._Photo != photoPath && !string.IsNullOrEmpty(contact._Photo))
            {
                File.Copy(pbProfilPicture.ImageLocation, photoPath, true);
                contact._Photo = photoPath;
            }
            return contact;
        }

        void AddPicture()
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.FileOk += new CancelEventHandler(dialog_FileOk);
                dialog.Filter = "Jpeg files, Bmp files|*.jpg;*.bmp";
                dialog.ShowDialog();
                pbProfilPicture.ImageLocation = dialog.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd dodawania zdjęcia: " +
                    $"{ex.Message} {ex.Source} ");
            }
        }

        void DgvRefresh()
        {
            _contactList = fileHelper.Deserialization();
            dgvContactList.DataSource = _contactList;
        }

        int GetNewId()
        {
            var contactHighestId = _contactList.OrderByDescending(x => x._Id).FirstOrDefault();
            var contactId = contactHighestId == null ? 1 : contactHighestId._Id + 1;
            return contactId;
        }

        void PrepareToEditContact()
        {
            try
            {
                if (dgvContactList.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Proszę zaznacz pozycję do edycji");
                    return;
                }

                _contact = dgvContactList.SelectedRows[0].DataBoundItem as Contact;
                _editedIdOfContact = _contact._Id;
                FillTextBoxes(_contact);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd edycji: {ex.Message} {ex.Source} ");
            }
        }

        void FillTextBoxes(Contact contact)
        {
            _editedIdOfContact = contact._Id;
            tbFirstName.Text = contact._FirstName;
            tbLastName.Text = contact._LastName;
            tbPhoneNr.Text = contact._PhoneNr;
            tbEmail.Text = contact._Email;
            cmbType.Text = contact._Type;
            tbCompany.Text = contact._Company;
            tbPosition.Text = contact._Position;
            rtbComment.Text = contact._Comments;
            pbProfilPicture.ImageLocation = contact._Photo;
        }

        void dialog_FileOk(object sender, CancelEventArgs e)
        {
            OpenFileDialog dialog = sender as OpenFileDialog;
            var size = new FileInfo(dialog.FileName).Length;
            if (size > 250000)
            {
                MessageBox.Show("File size exceeded");
                e.Cancel = true;
            }
        }

        void InitCombobox()
        {
            cmbType.DataSource = ContactHelper.TypeList;
        }

        private void SetColumnsHeader()
        {
            dgvContactList.Columns[nameof(_contact._Id)].Visible = false;
            dgvContactList.Columns[nameof(_contact._Photo)].Visible = false;
            dgvContactList.Columns[nameof(_contact._Picture)].HeaderText = "Zdjęcie";
            dgvContactList.Columns[nameof(_contact._FirstName)].HeaderText = "Imię";
            dgvContactList.Columns[nameof(_contact._LastName)].HeaderText = "Nazwisko";
            dgvContactList.Columns[nameof(_contact._PhoneNr)].HeaderText = "Telefon";
            dgvContactList.Columns[nameof(_contact._Email)].HeaderText = "Adres email";
            dgvContactList.Columns[nameof(_contact._Type)].HeaderText = "Typ kontaktu";
            dgvContactList.Columns[nameof(_contact._Company)].HeaderText = "Firma";
            dgvContactList.Columns[nameof(_contact._Position)].HeaderText = "Stanowisko";
            dgvContactList.Columns[nameof(_contact._Comments)].HeaderText = "Uwagi";
            for (int i = 0; i < dgvContactList.Columns.Count; i++)
                if (dgvContactList.Columns[i] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dgvContactList.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                    break;
                }
        }

        private void CheckType()
        {
            if (cmbType.Text == "Prywatny")
            {
                tbCompany.ReadOnly = true;
                tbPosition.ReadOnly = true;
                tbCompany.Text = "";
                tbPosition.Text = "";
            }
            else
            {
                tbCompany.ReadOnly = false;
                tbPosition.ReadOnly = false;
            }
        }

    }
}
