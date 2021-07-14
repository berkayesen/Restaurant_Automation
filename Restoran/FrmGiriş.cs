using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restoran
{
    public partial class FrmGiriş : Form
    {
        public FrmGiriş()
        {
            InitializeComponent();
        }

       
        private void Form1_Load(object sender, EventArgs e)
        {
            cPersoneller p = new cPersoneller();
            p.personelGetByInformation(cbKullanici);
        }

        private void txtSifre_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak İstediğinizden Emin Misiniz?","UYARI!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cGenel gnl = new cGenel();
            cPersoneller p = new cPersoneller();
                
                bool result = p.personelEntryControl(txtSifre.Text, cGenel._Personel_ID);

                if (result)
                {
                cPersonelHareketleri ch = new cPersonelHareketleri();
                ch.Personel_ID = cGenel._Personel_ID;
                ch.Islem = "Giriş Yaptı!";
                ch.Tarih = DateTime.Now;
                ch.personelActionSave(ch);

                    this.Hide();
                    Menu menu = new Menu();
                    menu.Show();
                }
            else 
            {
                MessageBox.Show("Şifreniz Yanlış!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cbKullanici_SelectedIndexChanged(object sender, EventArgs e)
        {
            cPersoneller p = (cPersoneller)cbKullanici.SelectedItem;
            cGenel._Personel_ID = p.Personel_ID;
            cGenel._Personel_Gorev_ID = p.Personel_Gorev_ID;
        }
    }
}
