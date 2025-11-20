/*
 * Created by SharpDevelop.
 * User: graem
 * Date: 17.11.2025
 * Time: 20:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace borcluMüsteriTakip
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void TextBox1TextChanged(object sender, EventArgs e)
		{
	
		}
		void Button1Click(object sender, EventArgs e)
		{
			if(textBox1.Text=="gallery" && textBox2.Text=="111"){
				Form2 yeniForm = new Form2();
    			yeniForm.Show();
			}else{
				MessageBox.Show("şifre ya da kullanıcı ad hatası","");
			}
		}
	}
}
