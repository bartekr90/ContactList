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

        private FileHelper<List<Contact>> _fileHelper =
            new FileHelper<List<Contact>>(Program._FilePath);

        public MainWindow()
        {
            InitializeComponent();
            InitCombobox();
            DgvRefresh();
            SetColumnsHeader();
            CheckType();
            butSave.MouseEnter += ButSave_MouseEnter;
            butSave.MouseLeave += ButSave_MouseLeave;
            butSaveAsNew.MouseEnter += ButSaveAsNew_MouseEnter;
            butSaveAsNew.MouseLeave += ButSaveAsNew_MouseLeave;
            tbFirstName.Select();
        }

        private void ButSaveAsNew_MouseLeave(object sender, EventArgs e)
        {
            butSaveAsNew.Text = "Zapisz Nowy";
        }

        private void ButSaveAsNew_MouseEnter(object sender, EventArgs e)
        {
            butSaveAsNew.Text = "Modyfikuje dane";
            ValidateTextboxes();
        }

        private void ButSave_MouseLeave(object sender, EventArgs e)
        {
            butSave.Text = "Zapisz";
        }

        private void ButSave_MouseEnter(object sender, EventArgs e)
        {
            butSave.Text = "Modyfikuje dane";
            ValidateTextboxes();
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_editedIdOfContact != 0)
                {
                    _contactList.RemoveAll(x => x.Id == _editedIdOfContact);
                    _contact = CreateNewContact(_editedIdOfContact);
                }
                else
                    _contact = CreateNewContact(GetNewId());

                _contactList.Add(_contact);
                _fileHelper.Serialization(_contactList);
                _editedIdOfContact = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd zapisywania kontaktu: " +
                    $"{ex.Message} {ex.Source} ");
            }
            finally
            {
                butPictureDelete.Enabled = false;
                DgvRefresh();
            }
        }

        private void butSaveAsNew_Click(object sender, EventArgs e)
        {
            try
            {
                _contactList = _fileHelper.Deserialization();
                _contact = CreateNewContact(GetNewId());
                _contactList.Add(_contact);
                _fileHelper.Serialization(_contactList);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd zapisywania nowego kontaktu:" +
                    $" {ex.Message} {ex.Source} ");
            }
            finally
            {
                butPictureDelete.Enabled = false;
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
                _contactList = _fileHelper.Deserialization();
                PrepareToEditContact();
                var confirm = MessageBox.Show
                     ($"Czy napewno chcesz usnunąć: {_contact.FirstName + " " + _contact.LastName.Trim()}",
                     "Usuwanie kontaktu",
                     MessageBoxButtons.OKCancel);
                if (confirm == DialogResult.OK)
                {
                    PictureDelete(_contact);
                    _contactList.RemoveAll(x => x.Id == _editedIdOfContact);
                    _editedIdOfContact = 0;
                    _fileHelper.Serialization(_contactList);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd usuwania kontaktu: " +
                    $"{ex.Message} {ex.Source} ");
            }
            finally
            {
                butPictureDelete.Enabled = false;
                DgvRefresh();
            }

        }

        private void butPictureDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_contact == null)
                {
                    MessageBox.Show("Proszę zaznacz pozycję do edycji", "Usuwanie zdjęcia");
                    return;
                }
                PictureDelete(_contact);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd edycji: {ex.Message} {ex.Source} ", "Usuwanie zdjęcia");
            }
            finally
            {
                butPictureDelete.Enabled = false;
                DgvRefresh();
            }
        }

        private void FillTextBoxes(Contact contact)
        {
            _editedIdOfContact = contact.Id;
            tbFirstName.Text = contact.FirstName;
            tbLastName.Text = contact.LastName;
            tbPhoneNr.Text = contact.PhoneNr;
            tbEmail.Text = contact.Email;
            cmbType.Text = contact.Type;
            tbCompany.Text = contact.Company;
            tbPosition.Text = contact.Position;
            rtbComment.Text = contact.Comments;
            pbProfilPicture.ImageLocation = contact.Photo;
        }

        private Contact CreateNewContact(int newId)
        {
            var contact = new Contact
            {
                Id = newId,
                Photo = pbProfilPicture.ImageLocation,
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                PhoneNr = tbPhoneNr.Text,
                Email = tbEmail.Text,
                Type = cmbType.Text,
                Company = tbCompany.Text,
                Position = tbPosition.Text,
                Comments = rtbComment.Text,
            };
            var photoPath = Path.Combine(Program._DataFolder, $"{contact.Id}.jpg");

            if (contact.Photo != photoPath && !string.IsNullOrEmpty(contact.Photo))
            {
                File.Copy(pbProfilPicture.ImageLocation, photoPath, true);
                contact.Photo = photoPath;
            }
            return contact;
        }

        private void AddPicture()
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

        private void dialog_FileOk(object sender, CancelEventArgs e)
        {
            OpenFileDialog dialog = sender as OpenFileDialog;
            var size = new FileInfo(dialog.FileName).Length;
            if (size > 250000)
            {
                MessageBox.Show("File size exceeded");
                e.Cancel = true;
            }
        }

        private void DgvRefresh()
        {
            _contactList = _fileHelper.Deserialization();
            dgvContactList.DataSource = _contactList;
        }

        private int GetNewId()
        {
            var contactHighestId = _contactList.OrderByDescending(x => x.Id).FirstOrDefault();
            var contactId = contactHighestId == null ? 1 : contactHighestId.Id + 1;
            return contactId;
        }

        private void PrepareToEditContact()
        {
            try
            {
                if (dgvContactList.SelectedRows.Count == 0)
                {
                    return;
                }

                _contact = dgvContactList.SelectedRows[0].DataBoundItem as Contact;
                _editedIdOfContact = _contact.Id;
                FillTextBoxes(_contact);
                butPictureDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd edycji: {ex.Message} {ex.Source} ");
            }
        }

        private void InitCombobox()
        {
            cmbType.DataSource = ContactHelper.TypeList;
        }

        private void SetColumnsHeader()
        {
            dgvContactList.Columns[nameof(_contact.Id)].Visible = false;
            dgvContactList.Columns[nameof(_contact.Photo)].Visible = false;
            dgvContactList.Columns[nameof(_contact.Picture)].HeaderText = "Zdjęcie";
            dgvContactList.Columns[nameof(_contact.FirstName)].HeaderText = "Imię";
            dgvContactList.Columns[nameof(_contact.LastName)].HeaderText = "Nazwisko";
            dgvContactList.Columns[nameof(_contact.PhoneNr)].HeaderText = "Telefon";
            dgvContactList.Columns[nameof(_contact.Email)].HeaderText = "Adres email";
            dgvContactList.Columns[nameof(_contact.Type)].HeaderText = "Typ kontaktu";
            dgvContactList.Columns[nameof(_contact.Company)].HeaderText = "Firma";
            dgvContactList.Columns[nameof(_contact.Position)].HeaderText = "Stanowisko";
            dgvContactList.Columns[nameof(_contact.Comments)].HeaderText = "Uwagi";
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

        private void ValidateTextboxes()
        {
            tbFirstName.Text = ContactHelper.LetterValidation(tbFirstName.Text);
            tbLastName.Text = ContactHelper.LetterValidation(tbLastName.Text);
            tbPhoneNr.Text = ContactHelper.NumberValidation(tbPhoneNr.Text, 9);
            tbEmail.Text = ContactHelper.LetterValidation(tbEmail.Text);
            tbCompany.Text = ContactHelper.LetterValidation(tbCompany.Text);
            tbPosition.Text = ContactHelper.LetterValidation(tbPosition.Text);
        }

        private void PictureDelete(Contact contact)
        {
            try
            {
                var confirm = MessageBox.Show
                     ($"Czy napewno chcesz usnunąć zdjęcie: {_contact.FirstName + " " + _contact.LastName.Trim()}",
                     "Usuwanie zdjęcia",
                     MessageBoxButtons.OKCancel);
                if (confirm == DialogResult.OK)
                {
                    pbProfilPicture.ImageLocation = "";
                    _contactList.FirstOrDefault(x => x.Id == _contact.Id).Photo = "";
                    dgvContactList.DataSource = _contactList;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    var photoPath = Path.Combine(Program._DataFolder, $"{contact.Id}.jpg");

                    if (!string.IsNullOrEmpty(photoPath))
                    {
                        if (File.Exists(photoPath))
                            File.Delete(photoPath);
                        else
                            MessageBox.Show("Plik nie istnieje", "Usuwanie zdjęcia");
                    }
                    else
                        MessageBox.Show("Brak ścieżki do pliku", "Usuwanie zdjęcia");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas usuwania zdjęcia: " +
                    $"{ex.Message} {ex.Source} ", "Usuwanie zdjęcia");
            }

        }

        private void dgvContactList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            PrepareToEditContact();
        }
         
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            butSave.MouseEnter -= ButSave_MouseEnter;
            butSave.MouseLeave -= ButSave_MouseLeave;
            butSaveAsNew.MouseEnter -= ButSaveAsNew_MouseEnter;
            butSaveAsNew.MouseLeave -= ButSaveAsNew_MouseLeave;
        }

        private void MainWindow_Click(object sender, EventArgs e)
        {
            _editedIdOfContact = 0;
            tbFirstName.Text = "";
            tbLastName.Text = "";
            tbPhoneNr.Text = "";
            tbEmail.Text = "";
            cmbType.Text = "";
            tbCompany.Text = "";
            tbPosition.Text = "";
            rtbComment.Text = "";
            pbProfilPicture.ImageLocation = "";
        }
    }
}
