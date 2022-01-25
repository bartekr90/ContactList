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
            tbFirstName.Select();
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_editedIdOfContact != 0)
                {
                    _contactList.RemoveAll(x => x._id == _editedIdOfContact);
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
                    _contactList.RemoveAll(x => x._id == _editedIdOfContact);
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
                _id = newId,
                _photo = pbProfilPicture.ImageLocation,
                _FirstName = tbFirstName.Text,
                _LastName = tbLastName.Text,
                _PhoneNr = tbPhoneNr.Text,
                _Email = tbEmail.Text,
                _Type = cmbType.Text,
                _Company = tbCompany.Text,
                _Position = tbPosition.Text,
                _Comments = rtbComment.Text,
            };
            var photoPath = Path.Combine(Program._DataFolder, $"{contact._id}.jpg");

            if (contact._photo != photoPath && !string.IsNullOrEmpty(contact._photo))
            {
                File.Copy(pbProfilPicture.ImageLocation, photoPath, true);
                contact._photo = photoPath;
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
            var contactHighestId = _contactList.OrderByDescending(x => x._id).FirstOrDefault();
            var contactId = contactHighestId == null ? 1 : contactHighestId._id + 1;
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
                _editedIdOfContact = _contact._id;
                FillTextBoxes(_contact);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd edycji: {ex.Message} {ex.Source} ");
            }
        }

        void FillTextBoxes(Contact contact)
        {
            _editedIdOfContact = contact._id;
            tbFirstName.Text = contact._FirstName;
            tbLastName.Text = contact._LastName;
            tbPhoneNr.Text = contact._PhoneNr;
            tbEmail.Text = contact._Email;
            cmbType.Text = contact._Type;
            tbCompany.Text = contact._Company;
            tbPosition.Text = contact._Position;
            rtbComment.Text = contact._Comments;
            pbProfilPicture.ImageLocation = contact._photo;
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
    }
}
