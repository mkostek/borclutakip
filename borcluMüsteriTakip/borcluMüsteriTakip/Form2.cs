/*
 * SharpDevelop tarafından düzenlendi.
 * Kullanıcı: graem
 * Tarih: 17.11.2025
 * Zaman: 20:59
 * 
 * Bu şablonu değiştirmek için Araçlar | Seçenekler | Kodlama | Standart Başlıkları Düzenle 'yi kullanın.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace borcluMüsteriTakip
{
	/// <summary>
	/// Description of Form2.
	/// </summary>
	public partial class Form2 : Form
	{
		public Form2()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Button1Click(object sender, EventArgs e)
		{
	Form3 yeniForm = new Form3();
    			yeniForm.Show();
		}
		void Form2Load(object sender, EventArgs e)
		{
	
		}
	}
}
