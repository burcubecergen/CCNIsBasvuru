using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        if (Session["gResim"].ToString() != txtSecurityCode.Value)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", script: "swalert('','Güvenlik kodunu kontrol ediniz, doğrulanmadı.','error');", addScriptTags: true);
            return;
        }

        if (!KVKKOnay1.Checked)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", script: "swalert('','KVKK başlığı altında Aydınlatma metnini okuduğunuzu onaylayınız.','error');", addScriptTags: true);
            return;
        }

        if (!KVKKOnay2.Checked)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", script: "swalert('','İş başvurunuzu internet sitemiz üzerinden tamamlayabilmeniz için Kişisel Verilerinin İşlenmesine İlişkin Aydınlatma Metni’ni onaylamanız gerekmektedir. Onaylamayı tercih etmemeniz halinde iş başvurularınızı Şirket adresimize şahsen başvurarak ya da ilan açılması halinde istihdam platformları üzerinden tamamlayabilirsiniz.','error');", addScriptTags: true);
            return;
        }

        string CVDosyaAdi = "";
        if (FileUpload1.HasFile)
        {
            bool fileExtensionOk = false; 
            String fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
            String[] allowedExtensions = { ".doc", ".docx", ".pdf" };

            for (int i = 0; i < allowedExtensions.Length; i++)
            {
                if (fileExtension == allowedExtensions[i])
                {
                    CVDosyaAdi = txtAdSoyad.Text + "_CV_" + DateTime.Now.ToString("ddMMyyyyHHmmss").Replace(".", "") + System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                    fileExtensionOk = true;
                    break;
                }
            }

            if (!fileExtensionOk)
            { 
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", script: "swalert('','Eklemiş olduğunuz CV dosyası formatı uygun değildir.','error');", addScriptTags: true);
                return;
            }

            if (FileUpload1.PostedFile.ContentLength > 2048000)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", script: "swalert('','Yüklediğiniz dosya boyutu 2 MB dan büyük olamaz.','error');", addScriptTags: true);
                return;
            }

        }



        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        SqlConnection conn = new SqlConnection(cs);

        SqlCommand cmd = new SqlCommand(@"INSERT INTO dbo.Basvuru(Olusturma,
        Sirket,BasvuruTipi,
        AdSoyad,Pozisyon,AdresUlke,AdresSehir,AdresIlce,CepTel,CalismaUlke,DogumTarihi,
        YD1,YD1Seviye,YH2,YD2Seviye,YD3,YD3Seviye,
        EgitimSeviye,EgitimOkul,EgitimBolum,EgitimBasTar,EgitimBitTar,
        Tecrube1IsYeri,Tecrube1Unvan,Tecrube1BasTar,Tecrube1BitTar,
        Tecrube2IsYeri,Tecrube2Unvan,Tecrube2BasTar,Tecrube2BitTar,
        Tecrube3IsYeri,Tecrube3Unvan,Tecrube3BasTar,Tecrube3BitTar,CVDosyaAdi,
        KVKKOnay1AydinlatmaMetni,KVKKOnay2AcikRiza,KVKKOnay3IstirakPaylasim,
        YakinAdi,YakinDerece,YakinSirket,YakinSirketPoz,
        YakinAdi1,YakinDerecesi1,YakinSirket1,YakinSirketPoz1,
        YakinAdi2,YakinDerecesi2,YakinSirket2,YakinSirketPoz2)
        VALUES
        (getdate(),@Sirket,@BasvuruTipi,
        @AdSoyad,@Pozisyon,@AdresUlke,@AdresSehir,@AdresIlce,@CepTel,@CalismaUlke,@DogumTarihi,
        @YD1,@YD1Seviye,@YH2,@YD2Seviye,@YD3,@YD3Seviye,
        @EgitimSeviye,@EgitimOkul,@EgitimBolum,@EgitimBasTar,@EgitimBitTar,
        @Tecrube1IsYeri,@Tecrube1Unvan,@Tecrube1BasTar,@Tecrube1BitTar,
        @Tecrube2IsYeri,@Tecrube2Unvan,@Tecrube2BasTar,@Tecrube2BitTar,
        @Tecrube3IsYeri,@Tecrube3Unvan,@Tecrube3BasTar,@Tecrube3BitTar,@CVDosyaAdi,@KVKKOnay1,@KVKKOnay2,@KVKKOnay3,
        @YakinAdi,@YakinDerece,@YakinSirket,@YakinSirketPoz,
        @YakinAdi1,@YakinDerecesi1,@YakinSirket1,@YakinSirketPoz1,
        @YakinAdi2,@YakinDerecesi2,@YakinSirket2,@YakinSirketPoz2)");

        cmd.Parameters.AddWithValue("@Sirket", cmbSirketSec.Text);
        cmd.Parameters.AddWithValue("@BasvuruTipi", rdTuru.SelectedValue);
        cmd.Parameters.AddWithValue("@AdSoyad", txtAdSoyad.Text);
        cmd.Parameters.AddWithValue("@Pozisyon", txtPozisyon.Text);
        cmd.Parameters.AddWithValue("@AdresUlke", txtAdresUlke.Text);
        cmd.Parameters.AddWithValue("@AdresSehir", txtAdresSehir.Text);
        cmd.Parameters.AddWithValue("@AdresIlce", txtAdresIlce.Text);
        cmd.Parameters.AddWithValue("@CepTel", txtCepTel.Text);
        cmd.Parameters.AddWithValue("@CalismaUlke", txtCalismakIstedigiYer.Text);
        cmd.Parameters.AddWithValue("@DogumTarihi", txtDogumTarihi.Text);
        cmd.Parameters.AddWithValue("@YD1", txtDil1.Text);
        cmd.Parameters.AddWithValue("@YD1Seviye", cmbDil1.Text);
        cmd.Parameters.AddWithValue("@YH2", txtDil2.Text);
        cmd.Parameters.AddWithValue("@YD2Seviye", cmbDil2.Text);
        cmd.Parameters.AddWithValue("@YD3", txtDil3.Text);
        cmd.Parameters.AddWithValue("@YD3Seviye", cmbDil3.Text);
        cmd.Parameters.AddWithValue("@EgitimSeviye", cmbEgitimSeviye.Text);
        cmd.Parameters.AddWithValue("@EgitimOkul", txtEgitimOkul.Text);
        cmd.Parameters.AddWithValue("@EgitimBolum", txtEgitimBolum.Text);
        cmd.Parameters.AddWithValue("@EgitimBasTar", txtEgitimBasTar.Text);
        cmd.Parameters.AddWithValue("@EgitimBitTar", txtEgitimBitTar.Text);
        cmd.Parameters.AddWithValue("@Tecrube1IsYeri", txtIsIsyeri1.Text);
        cmd.Parameters.AddWithValue("@Tecrube1Unvan", txtIsUnvan1.Text);
        cmd.Parameters.AddWithValue("@Tecrube1BasTar", txtIsBasTar1.Text);
        cmd.Parameters.AddWithValue("@Tecrube1BitTar", txtIsBitTar1.Text);
        cmd.Parameters.AddWithValue("@Tecrube2IsYeri", txtIsIsyeri2.Text);
        cmd.Parameters.AddWithValue("@Tecrube2Unvan", txtIsUnvan2.Text);
        cmd.Parameters.AddWithValue("@Tecrube2BasTar", txtIsBasTar2.Text);
        cmd.Parameters.AddWithValue("@Tecrube2BitTar", txtIsBitTar2.Text);
        cmd.Parameters.AddWithValue("@Tecrube3IsYeri", txtIsIsyeri3.Text);
        cmd.Parameters.AddWithValue("@Tecrube3Unvan", txtIsUnvan3.Text);
        cmd.Parameters.AddWithValue("@Tecrube3BasTar", txtIsBasTar3.Text);
        cmd.Parameters.AddWithValue("@Tecrube3BitTar", txtIsBitTar3.Text);
        cmd.Parameters.AddWithValue("@CVDosyaAdi", CVDosyaAdi);
        cmd.Parameters.AddWithValue("@KVKKOnay1", (KVKKOnay1.Checked ? 1 : 0));
        cmd.Parameters.AddWithValue("@KVKKOnay2", (KVKKOnay2.Checked ? 1 : 0));
        cmd.Parameters.AddWithValue("@KVKKOnay3", (KVKKOnay3.Checked ? 1 : 0));
        cmd.Parameters.AddWithValue("@YakinAdi", txtYakinAdi.Text);
        cmd.Parameters.AddWithValue("@YakinDerece", txtYakinDerece.Text);
        cmd.Parameters.AddWithValue("@YakinSirket", txtYakinSirket.Text);
        cmd.Parameters.AddWithValue("@YakinSirketPoz", txtYakinSirketPoz.Text);
        cmd.Parameters.AddWithValue("@YakinAdi1", txtYakinAdi1.Text);
        cmd.Parameters.AddWithValue("@YakinDerecesi1", txtYakinDerece1.Text);
        cmd.Parameters.AddWithValue("@YakinSirket1", txtYakinSirket1.Text);
        cmd.Parameters.AddWithValue("@YakinSirketPoz1", txtYakinSirketPoz1.Text);
        cmd.Parameters.AddWithValue("@YakinAdi2", txtYakinAdi2.Text);
        cmd.Parameters.AddWithValue("@YakinDerecesi2", txtYakinDerece2.Text);
        cmd.Parameters.AddWithValue("@YakinSirket2", txtYakinSirket2.Text);
        cmd.Parameters.AddWithValue("@YakinSirketPoz2", txtYakinSirketPoz2.Text);

        cmd.Connection = conn;
        conn.Open();
        cmd.ExecuteNonQuery();

        SqlCommand cmdKayitID = new SqlCommand("select max(rowid) from dbo.Basvuru", conn);
        int KayitId = (int)cmdKayitID.ExecuteScalar();

        conn.Close();
        string path = "";

        if (CVDosyaAdi != "")
        {
            path = @"C:\inetpub\wwwroot\CCNIsBasvuruList\CVDosyalar\";
            //path = @"C:\SHARE\cvs\";
            path = path + CVDosyaAdi;
            FileUpload1.PostedFile.SaveAs(path);
        }
        //FileUpload1.SaveAs(Server.MapPath("~/CVDosyalar/") + CVDosyaAdi);

        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", script: "swalert('','Başvurunuz Kayıtlarımıza alınmıştır.','success');", addScriptTags: true);

        //mail gönderiliyor...
        SmtpClient sc = new SmtpClient();
        sc.Port = 587;
        sc.Host = "smtp.office365.com";
        sc.EnableSsl = true;
        sc.Credentials = new NetworkCredential("dys@ccnholding.com", "*06-Dys%/");

        MailMessage mail = new MailMessage();

        mail.From = new MailAddress("dys@ccnholding.com", "Doküman Yönetim Sistemi");

        mail.To.Add("bkeser@ccngroup.com.tr");
        //mail.To.Add("zbaysal@ccnsaglik.com");
        mail.To.Add("zbozkurt@ccninsaat.com");
        mail.To.Add("bguney@ccngroup.com.tr");
        mail.To.Add("ftasdemir@ccnsaglik.com");
        mail.To.Add("emsal.orhan@tedizmir.k12.tr");

        mail.CC.Add("vogur@ccngroup.com.tr");
        //mail.Bcc.Add("hbozkurt@ccnholding.com");

        mail.Subject = "İnternet Üzerinden İş Başvurusu";
        mail.IsBodyHtml = true;
        mail.Body = @"<br><br>İnternet üzerinden iş başvurusu yapılmıştır."
        + "<br><br> <b>Başvuru yapılan şirket : </b>" + cmbSirketSec.Text
        + "<br><br> <b>Başvuru Tipi : </b>" + rdTuru.SelectedValue
        + "<br><br> <b>Ad Soyad : </b>" + txtAdSoyad.Text
        + "<br><br> <b>Pozisyon : </b>" + txtPozisyon.Text
        + "<br><br> <a href=\"http://ccnisbasvurulist.ccnholding.com/BasvuruDetay.aspx?rowid=" + KayitId.ToString() + "\">Başvuruyu görmek için tıklayınız.<a/>";

        if (CVDosyaAdi != "")
            mail.Attachments.Add(new Attachment(path));
        
        sc.Send(mail);


        cmbSirketSec.Text = "";
        rdTuru.SelectedValue = "";
        txtAdSoyad.Text = "";
        txtPozisyon.Text = "";
        txtAdresUlke.Text = "";
        txtAdresSehir.Text = "";
        txtAdresIlce.Text = "";
        txtCepTel.Text = "";
        txtCalismakIstedigiYer.Text = "";
        txtDogumTarihi.Text = "";
        txtDil1.Text = "";
        cmbDil1.Text = "";
        txtDil2.Text = "";
        cmbDil2.Text = "";
        txtDil3.Text = "";
        cmbDil3.Text = "";
        cmbEgitimSeviye.Text = "";
        txtEgitimOkul.Text = "";
        txtEgitimBolum.Text = "";
        txtEgitimBasTar.Text = "";
        txtEgitimBitTar.Text = "";
        txtIsIsyeri1.Text = "";
        txtIsUnvan1.Text = "";
        txtIsBasTar1.Text = "";
        txtIsBitTar1.Text = "";
        txtIsIsyeri2.Text = "";
        txtIsUnvan2.Text = "";
        txtIsBasTar2.Text = "";
        txtIsBitTar2.Text = "";
        txtIsIsyeri3.Text = "";
        txtIsUnvan3.Text = "";
        txtIsBasTar3.Text = "";
        txtIsBitTar3.Text = "";
        txtSecurityCode.Value = "";
        KVKKOnay1.Checked = false;
        KVKKOnay2.Checked = false;
        KVKKOnay3.Checked = false;
        txtYakinAdi.Text = "";
        txtYakinDerece.Text = "";
        txtYakinSirket.Text = "";
        txtYakinSirketPoz.Text = "";
        txtYakinAdi1.Text = "";
        txtYakinDerece1.Text = "";
        txtYakinSirket1.Text = "";
        txtYakinSirketPoz1.Text = "";
        txtYakinAdi2.Text = "";
        txtYakinDerece2.Text = "";
        txtYakinSirket2.Text = "";
        txtYakinSirketPoz2.Text = "";


        //Response.Redirect("basarili.aspx");
    }
}