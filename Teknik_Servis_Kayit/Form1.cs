using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teknik_Servis_Kayit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PersonelEntities PersonelEntities = new PersonelEntities();
        
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            dataGridView1.DataSource = PersonelEntities.Tbl_Personel.ToList();
        }

        private void button_Ekle_Click(object sender, EventArgs e)
        {
            Tbl_Personel tbl_Personel = new Tbl_Personel();
            tbl_Personel.M_Ad = textBoxAd.Text;
            tbl_Personel.M_Soyad = textBoxSoyad.Text;
            tbl_Personel.M_Tel = textBoxTelefon.Text;
            tbl_Personel.UrunAd = textBoxUrunAd.Text;
            tbl_Personel.SeriNo = textBoxSeriNo.Text;
            tbl_Personel.Sikayet = textBoxSikayet.Text;
            tbl_Personel.Islem = textBoxIslem.Text;
            tbl_Personel.Islem_Durumu = textBoxIslemDurum.Text;
            tbl_Personel.Tutar = short.Parse(textBoxTutar.Text);
            tbl_Personel.Odeme_Durumu = textBoxOdemeDurumu.Text;
            PersonelEntities.Tbl_Personel.Add(tbl_Personel);
            PersonelEntities.SaveChanges();
            MessageBox.Show("İşlem Başarılı");

            foreach (Control item in Controls)
            {
                if(item is TextBox)
                {
                    item.Text = "";
                }
            }
            dataGridView1.DataSource = PersonelEntities.Tbl_Personel.ToList();

        }

        private void button_Sil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var sil = PersonelEntities.Tbl_Personel.Where(w => w.M_id == id).FirstOrDefault();
            PersonelEntities.Tbl_Personel.Remove(sil);

            MessageBox.Show("İşlem Başarılı");

            PersonelEntities.SaveChanges();
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }

            dataGridView1.DataSource = PersonelEntities.Tbl_Personel.ToList();

        }

        private void button_Guncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var guncelle = PersonelEntities.Tbl_Personel.Where(w => w.M_id == id).FirstOrDefault();

            guncelle.M_Ad = textBoxAd.Text;
            guncelle.M_Soyad = textBoxSoyad.Text;
            guncelle.M_Tel = textBoxTelefon.Text;
            guncelle.UrunAd = textBoxUrunAd.Text;
            guncelle.SeriNo = textBoxSeriNo.Text;
            guncelle.Sikayet = textBoxSikayet.Text;
            guncelle.Islem = textBoxIslem.Text;
            guncelle.Islem_Durumu = textBoxIslemDurum.Text;
            guncelle.Tutar = short.Parse(textBoxTutar.Text);
            guncelle.Odeme_Durumu = textBoxOdemeDurumu.Text;
            MessageBox.Show("İşlem Başarılı");
            PersonelEntities.SaveChanges();
            foreach (Control item in Controls)
            {
                if(item is TextBox)
                {
                    item.Text = "";
                }
            }
            dataGridView1.DataSource = PersonelEntities.Tbl_Personel.ToList();
        }

        private void button_Listele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = PersonelEntities.Tbl_Personel.ToList();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBoxAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxSoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBoxTelefon.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBoxUrunAd.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBoxSeriNo.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBoxSikayet.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBoxIslem.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBoxIslemDurum.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBoxTutar.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBoxOdemeDurumu.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();

        }

        private void textBoxUrun_Sorgula_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = PersonelEntities.Tbl_Personel.Where(w => w.UrunAd.Contains(textBoxUrun_Sorgula.Text)).ToList();
        }

        private void textBoxMusteri_Sorgula_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = PersonelEntities.Tbl_Personel.Where(w => w.M_Ad.Contains(textBoxMusteri_Sorgula.Text) || w.M_Soyad.Contains(textBoxMusteri_Sorgula.Text)).ToList();
        }

        private void textBoxDurum_Sorgula_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = PersonelEntities.Tbl_Personel.Where(w => w.Islem_Durumu.Contains(textBoxDurum_Sorgula.Text)).ToList();
        }

        private void textBoxOdeme_Sorgula_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = PersonelEntities.Tbl_Personel.Where(w => w.Odeme_Durumu.Contains(textBoxOdeme_Sorgula.Text)).ToList();
        }
    }
}
