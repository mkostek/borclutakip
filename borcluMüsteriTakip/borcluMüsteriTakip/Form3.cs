/*
 * SharpDevelop tarafından düzenlendi.
 * Kullanıcı: graem
 * Tarih: 18.11.2025
 * Zaman: 22:48
 * 
 * Bu şablonu değiştirmek için Araçlar | Seçenekler | Kodlama | Standart Başlıkları Düzenle 'yi kullanın.
 */
using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace borcluMüsteriTakip
{
	/// <summary>
	/// Description of Form3.
	/// </summary>
	public partial class Form3 : Form
	{
		public Form3()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public DataTable dt = new DataTable();
		public DataColumn sütun;
		void Form3Load(object sender, EventArgs e)
		{
			OleDbConnection myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=borcluTakip.accdb;Persist Security Info=False;");
			myConn.Open();
			OleDbCommand myQuery = new OleDbCommand("select *from Danismanlar;", myConn);
			OleDbDataReader rd = myQuery.ExecuteReader();
			while(rd.Read())
			{
				comboBox1.Items.Add(rd["Alan1"].ToString());
			}
			myQuery = new OleDbCommand("select *from Magazalar;", myConn);
			rd = myQuery.ExecuteReader();
			while(rd.Read())
			{
				comboBox2.Items.Add(rd["magazaAdi"].ToString());
			}
			myConn.Close();
			
			dateTimePicker1.CustomFormat = "dd-MM-yyyy";
			DateTime today = DateTime.Today;

			dateTimePicker1.Text=today.ToShortDateString();
			
		}
		void Button2Click(object sender, EventArgs e)
		{
			OleDbConnection myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=borcluTakip.accdb;Persist Security Info=False;");
			myConn.Open();
			OleDbCommand myQuery = new OleDbCommand("select *from UrunListesi where Alan2='"+textBox2.Text.ToString()+"';", myConn);
			OleDbDataReader rd = myQuery.ExecuteReader();
			while(rd.Read())
			{
				textBox1.Text=rd["Alan1"].ToString();
				textBox3.Text=rd["Alan3"].ToString();
				textBox4.Text=rd["Alan4"].ToString();
				textBox5.Text=rd["Alan5"].ToString();
				textBox6.Text=rd["Alan6"].ToString();
			}
			myConn.Close();
		}
		void Button3Click(object sender, EventArgs e)
		{
			OleDbConnection myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=borcluTakip.accdb;Persist Security Info=False;");
			myConn.Open();
			OleDbCommand myQuery = new OleDbCommand("select *from UrunListesi where Alan1='"+textBox1.Text.ToString()+"';", myConn);
			OleDbDataReader rd = myQuery.ExecuteReader();
			while(rd.Read())
			{
				textBox2.Text=rd["Alan2"].ToString();
				textBox3.Text=rd["Alan3"].ToString();
				textBox4.Text=rd["Alan4"].ToString();
				textBox5.Text=rd["Alan5"].ToString();
				textBox6.Text=rd["Alan6"].ToString();
			}
			myConn.Close();
		}
		void Button4Click(object sender, EventArgs e)
		{
			listBox1.Items.Clear();

			OleDbConnection myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=borcluTakip.accdb;Persist Security Info=False;");
			myConn.Open();
			OleDbCommand myQuery = new OleDbCommand("select *from BekleyenTeslimatlar where MusteriAdi like '%"+textBox7.Text.ToString()+"%';", myConn);
			OleDbDataReader dr = myQuery.ExecuteReader();
			while(dr.Read())
			{
				string f1 = dr["KayitNo"].ToString();
				string f2 = dr["KayitTarihi"].ToString();
				string f3 = dr["UrunKodu"].ToString();
				string f4 =dr["barkod"].ToString();
				string f5 = dr["urunAdi"].ToString();
				string f6 = dr["UrunAnaGrubu"].ToString();
				string f7 = dr["urunAltGrubu"].ToString();
				string f8 = dr["Turu"].ToString();
				string f9 = dr["MusteriAdi"].ToString();
				string f10 = dr["Telefon"].ToString();
				string f11= dr["SatisDanismani"].ToString();
				string f12 = dr["Magazalar"].ToString();
				string f13 = dr["adet"].ToString();
				string f14 = dr["Not"].ToString();
				string f15 = dr["Durum"].ToString();
				string f16 = dr["TerminTarihi"].ToString();
				
				string f17 = dr["TeslimTarihi"].ToString();
				if(f17=="")f17="1.1.2021";
				listBox1.Items.Add(f1+"$"+f2+"$"+f3+"$"+f4+"$"+f5+"$"+f6+"$"+f7+"$"+f8+"$"+f9+"$"+f10+"$"+f11+"$"+f12+"$"+f13+"$"+f14+"$"+f15+"$"+f16+"$"+f17);
			}
			myConn.Close();

			
		}
		void DataGridView1CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			
		}
		void Button1Click(object sender, EventArgs e)
		{
			
		}
		void ListBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			String sozce=listBox1.SelectedItem.ToString();
			string[] subStrings = sozce.Split('$');
			label18.Text=subStrings[0].ToString();//ürün güncelleme e numarası
			//MessageBox.Show(subStrings[1]);
			dateTimePicker1.Value =DateTime.Parse(subStrings[1]);//oluşturma tarih
			textBox1.Text=subStrings[2].ToString();//ürün kod
			textBox2.Text=subStrings[3].ToString();//barkod
			textBox3.Text=subStrings[4].ToString();//ürün ad
			textBox4.Text=subStrings[5].ToString();//ürün ana grup
			textBox5.Text=subStrings[6].ToString();//ürün alt grup
			textBox6.Text=subStrings[7].ToString();//ürün grup
			textBox7.Text=subStrings[8].ToString();//alan kişi
			textBox8.Text=subStrings[9].ToString();//telefon numarası
			comboBox1.SelectedIndex = comboBox1.FindStringExact(subStrings[10].ToString());//satıs danısmanı
			comboBox2.SelectedIndex = comboBox2.FindStringExact(subStrings[11].ToString());//depo sec
			textBox11.Text=subStrings[12].ToString();//ürün adet
			textBox12.Text=subStrings[13].ToString();//ürün not bilgisi
			comboBox3.SelectedIndex = comboBox3.FindStringExact(subStrings[14].ToString());//ürün durum
			if(subStrings[15].ToString()!="")
				dateTimePicker2.Value =DateTime.Parse(subStrings[15]);//ürün isteme tarihi
			if(subStrings[16].ToString()!="")
				dateTimePicker3.Value =DateTime.Parse(subStrings[16]);//ürün gelme tarihi
			
		}
		void Button5Click(object sender, EventArgs e)
		{
			OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=borcluTakip.accdb;Persist Security Info=False;");
			OleDbCommand cmd = new OleDbCommand(@"UPDATE BekleyenTeslimatlar SET KayitTarihi = @kayittarihi, UrunKodu = @urunkodu, Barkod = @barkod, UrunAdi = @urunadi, UrunAnaGrubu = @urunanagrubu,UrunAltGrubu =@urunaltgrubu,Turu=@turu,MusteriAdi = @musteriadi,Telefon=@telefon,SatisDanismani=@satisdanismani,Magazalar=@magazalar,adet=@adet,Not=@not,Durum=@durum,TerminTarihi=@termintarihi,Teslimtarihi = @teslimtarihi WHERE KayitNo = @No",cn);
		
			cn.Open();
			//cmd.Connection = cn;
			//cmd.CommandText = ("UPDATE BekleyenTeslimatlar SET KayitTarihi='" + dateTimePicker1.Text + "',UrunKodu='" + textBox1.Text +"',Barkod='" + textBox2.Text +"',UrunAdi='" + textBox3.Text +"',UrunAnaGrubu='" + textBox4.Text +"',UrunAltGrubu='" + textBox5.Text +"',Turu='" + textBox6.Text +"',MusteriAdi='" + textBox7.Text +"',Telefon='" + textBox8.Text +"',SatisDanismani='" + comboBox1.SelectedItem +"',Magazalar='" + comboBox2.SelectedItem +"',Adet='" + textBox11.Text +"',Not='" + textBox12.Text +"',Durum='" + comboBox3.SelectedItem +"',TerminTarihi='" + dateTimePicker2.Text +"',TeslimTarihi='" + dateTimePicker3.Text+"' where KayitNo="+label18.Text+"");
			MessageBox.Show(dateTimePicker1.Text);
			cmd.Parameters.AddWithValue("@kayittarihi", dateTimePicker1.Text.ToString());
			cmd.Parameters.AddWithValue("@urunkodu", textBox1.Text.ToString());
			cmd.Parameters.AddWithValue("@barkod", textBox2.Text.ToString());
			cmd.Parameters.AddWithValue("@urunadi", textBox3.Text.ToString());
			cmd.Parameters.AddWithValue("@urunanagrubu", textBox4.Text.ToString());
			cmd.Parameters.AddWithValue("@urunaltgrubu", textBox5.Text.ToString());
			cmd.Parameters.AddWithValue("@turu", textBox6.Text.ToString());
			cmd.Parameters.AddWithValue("@musteriadi", textBox7.Text.ToString());
			cmd.Parameters.AddWithValue("@telefon", textBox8.Text.ToString());
			cmd.Parameters.AddWithValue("@satisdanismani", comboBox1.SelectedItem.ToString());
			cmd.Parameters.AddWithValue("@magazalar", comboBox2.SelectedItem.ToString());
			cmd.Parameters.AddWithValue("@adet", Convert.ToInt32(textBox11.Text));
			cmd.Parameters.AddWithValue("@not", textBox12.Text.ToString());
			cmd.Parameters.AddWithValue("@durum", comboBox3.SelectedItem.ToString());
			cmd.Parameters.AddWithValue("@termintarihi", dateTimePicker2.Text.ToString());
			cmd.Parameters.AddWithValue("@teslimtarihi", dateTimePicker3.Text.ToString());
			cmd.Parameters.AddWithValue("@No", Convert.ToInt32(label18.Text));
			cmd.ExecuteNonQuery();
			{
				MessageBox.Show("Update Success!");
				cn.Close();
			}
			cn.Close();
		}
	}
}
