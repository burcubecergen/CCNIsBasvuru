using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Resim : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //100px genişliğinde 30px yüksekliğinde sanal resim oluşturuyor
        Bitmap bmp = new Bitmap(100, 30);
        //Çizimlerimi yapabilmek için grafik nesnesi oluşturuluyor
        Graphics g = Graphics.FromImage(bmp);
        //Resim arkaplanı Beige(bej) renge boyanıyor
        g.Clear(Color.Beige);

        //Rastgele metin metodundan 6 karakterli kelime oluştuluyor
        string metin = RastgeleKelime();
        //Oluşturulan kelime daha sonra eşitlik kontrlü için session'a gönderiliyor
        Session["gResim"] = metin;

        //Comic Sans MS adında 14px boyutunda font oluşturuluyor
        Font font = new Font("Comic Sans MS", 14);
        //Oluşturulan kelime siyah renk olarak soldan 4px üstten 1px içerde olarak yazılıyor
        g.DrawString(metin, font, Brushes.Black, 4, 1);

        //Botlar için anlaşılması daha zor hale getirmek için-
        //3 tane çizgi oluşturuyor farklı renklerde
        Random rnd = new Random();
        g.DrawLine(new Pen(Color.Green, 1), rnd.Next(0, 100), rnd.Next(0, 30), rnd.Next(0, 100), rnd.Next(0, 30));
        g.DrawLine(new Pen(Color.LawnGreen, 1), rnd.Next(0, 100), rnd.Next(0, 30), rnd.Next(0, 100), rnd.Next(0, 30));
        g.DrawLine(new Pen(Color.OrangeRed,1), rnd.Next(0, 100), rnd.Next(0, 30), rnd.Next(0, 100), rnd.Next(0, 30));
        g.DrawLine(new Pen(Color.Yellow, 1), rnd.Next(0, 100), rnd.Next(0, 30), rnd.Next(0, 100), rnd.Next(0, 30));
        g.DrawLine(new Pen(Color.Turquoise, 1), rnd.Next(0, 100), rnd.Next(0, 30), rnd.Next(0, 100), rnd.Next(0, 30));
        g.DrawLine(new Pen(Color.Black, 1), rnd.Next(0, 100), rnd.Next(0, 30), rnd.Next(0, 100), rnd.Next(0, 30));

        //Son olarak sayfaya resonse ediliyor jpeg formatında
        bmp.Save(Response.OutputStream, ImageFormat.Jpeg);
    }


    public string RastgeleKelime()
    {
        string kelime = "";
        var rnd = new Random();
        for (int i = 0; i < 4; i++)
        {
            kelime += ((char)rnd.Next('A', 'Z')).ToString();
        }
        return kelime;
    }
}