<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>CCN İş Başvurusu</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="stylesheet" href="css/bootstrap.min.css">
    <style type="text/css">
        body {
            padding-top: 60px;
            padding-bottom: 40px;
        }


        .bgcolor {
            background-color: none;
        }

        .lightblue {
            background-color: none;
        }

        .form-horizontal .control-label {
            width: 70px;
        }

        .form-horizontal .controls {
            margin-left: 90px;
        }

        .auto-style1 {
            width: 379px;
        }
    </style>

    <script src="js/sweetalert.min.js"></script>
    <script>
        function swalert(adres, mtitle, micon) {
            swal(mtitle, '', micon, { button: 'Tamam', })
                .then(function () {
                    if (adres != '')
                        window.location = adres;
                });
        };
    </script>
</head>
<body>

    <div class="container">
        <div class="jumbotron">
            <h1>İş Başvuru Formu</h1>
            <p>Merhaba,</p>
            <p>Öncelikle şirketimize göstermiş olduğunuz ilgiye teşekkür ederiz.</p>
            <p>Özgeçmişinizi değerlendirme altına alabilmemiz için özgeçmiş bilgilerinizi sistem üzerinden detaylıca oluşturmanızı rica ederiz.</p>
            <p>Özgeçmişiniz aranılan pozisyonlara uygun olması halinde, sizinle mutlaka irtibata geçeceğiz.</p>
            <p>Saygılarımızla,</p>
            <p>CCN Holding İnsan Kaynakları</p>
        </div>

        <div class="container">

            <form role="form" runat="server" class="form-horizontal">

                <div class="form-group">
                    <label class="col-md-3"></label>
                    <label class="col-md-2" for="cmbSirketSec">Hangi Şirketimiz için Başvuru Yapıyorsunuz?</label>
                    <div class="col-md-4">
                        <asp:DropDownList ID="cmbSirketSec" runat="server" CssClass="form-control">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>CCN YATIRIM HOLDİNG A.Ş.</asp:ListItem>
                            <asp:ListItem>CCN SAĞLIK YATIRIMLARI A.Ş.</asp:ListItem>
                            <asp:ListItem>CCN ALTYAPI YATIRIMLARI VE İNŞAAT A.Ş.</asp:ListItem>
                            <asp:ListItem>CCN SERVİS VE İŞLETME HİZMLERİ A.Ş.</asp:ListItem>
                            <asp:ListItem>CCN BİYOMEDİKAL SAĞLIK HİZMETLERİ A.Ş</asp:ListItem>
                            <asp:ListItem>CCN TEKNİK VE MAKİNE HİZMETLERİ A.Ş</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-3">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Şirket seçiniz..." ControlToValidate="cmbSirketSec" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-md-3"></label>
                    <label class="col-md-2" for="cmbSirketSec">Başvuru tipi</label>
                    <div class="col-md-4">
                        <asp:RadioButtonList ID="rdTuru" runat="server" CssClass="radio">
                            <asp:ListItem>Yeni Mezun ve Stajyer Başvurusu</asp:ListItem>
                            <asp:ListItem>Deneyimli Profesyonel Başvurusu</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-md-3"></label>
                    <label class="col-md-2" for="txtAdSoyad">Adı Soyadı *</label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtAdSoyad" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Ad Soyad giriniz..." ControlToValidate="txtAdSoyad" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-md-3"></label>
                    <label class="col-md-2" for="txtPozisyon">Başvurulan Pozisyon *</label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtPozisyon" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Pozisyon giriniz..." ControlToValidate="txtPozisyon" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <legend>Adres Bilgileri</legend>

                <div class="form-group">
                    <label class="col-md-3"></label>
                    <label class="col-md-2" for="txtAdresUlke">Ülke *</label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtAdresUlke" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-md-3"></label>
                    <label class="col-md-2" for="txtAdresSehir">İl *</label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtAdresSehir" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-md-3"></label>
                    <label class="col-md-2" for="txtAdresIlce">İlçe *</label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtAdresIlce" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-md-3"></label>
                    <label class="col-md-2" for="txtCepTel">Cep Telefonu *</label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtCepTel" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-md-3"></label>
                    <label class="col-md-2" for="txtCalismakIstedigiYer">Çalışmak İstediğiniz Şehir / Ülke *</label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtCalismakIstedigiYer" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-md-3"></label>
                    <label class="col-md-2" for="txtDogumTarihi">Doğum Tarihi *</label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtDogumTarihi" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <legend>Yabancı Dil Bilgisi</legend>

                <div class="form-group">
                    <label class="col-md-3"></label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtDil1" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:DropDownList ID="cmbDil1" runat="server" CssClass="form-control">
                            <asp:ListItem>Seçiniz...</asp:ListItem>
                            <asp:ListItem>Başlangıç</asp:ListItem>
                            <asp:ListItem>Orta</asp:ListItem>
                            <asp:ListItem>İleri</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-md-3"></label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtDil2" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:DropDownList ID="cmbDil2" runat="server" CssClass="form-control">
                            <asp:ListItem>Seçiniz...</asp:ListItem>
                            <asp:ListItem>Başlangıç</asp:ListItem>
                            <asp:ListItem>Orta</asp:ListItem>
                            <asp:ListItem>İleri</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-md-3"></label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtDil3" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:DropDownList ID="cmbDil3" runat="server" CssClass="form-control">
                            <asp:ListItem>Seçiniz...</asp:ListItem>
                            <asp:ListItem>Başlangıç</asp:ListItem>
                            <asp:ListItem>Orta</asp:ListItem>
                            <asp:ListItem>İleri</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <legend>Eğitim Durumu</legend>

                <div class="form-group">
                    <label class="col-md-3"></label>
                    <label class="col-md-2" for="cmbEgitimSeviye">Seviye</label>
                    <div class="col-md-4">
                        <asp:DropDownList ID="cmbEgitimSeviye" runat="server" CssClass="form-control">
                            <asp:ListItem>Seçiniz...</asp:ListItem>
                            <asp:ListItem>İlköğretim (İlkokul ve Ortaokul)</asp:ListItem>
                            <asp:ListItem>Lise</asp:ListItem>
                            <asp:ListItem>Önlisans</asp:ListItem>
                            <asp:ListItem>Üniversite</asp:ListItem>
                            <asp:ListItem>Yüksek Lisans</asp:ListItem>
                            <asp:ListItem>Doktora</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-md-3"></label>
                    <label class="col-md-2" for="txtEgitimLise">Okul</label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtEgitimOkul" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-md-3"></label>
                    <label class="col-md-2" for="txtEgitimUniversite">Bölüm</label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtEgitimBolum" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-md-3"></label>
                    <label class="col-md-2" for="txtEgitimBasTar">Başlama Tarihi</label>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtEgitimBasTar" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-md-3"></label>
                    <label class="col-md-2" for="txtEgitimBitTar">Bitiş Tarihi</label>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtEgitimBitTar" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <label class="col-md-4" for="txtBitTar">Devam ediyorsanız boş bırakınız.</label>
                </div>


                <legend>İş Deneyimi</legend>

                <div class="form-group">

                    <table class="table col-md-8">
                        <thead>
                            <tr>
                                <th>
                                    <label class="col-md-12">İş Yerinin Ünvanı</label></th>
                                <th>
                                    <label class="col-md-12">Ünvan / Görev</label></th>
                                <th>
                                    <label class="col-md-12">Giriş Tarihi</label></th>
                                <th>
                                    <label class="col-md-12">Çıkış Tarihi</label></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtIsIsyeri1" runat="server" CssClass="form-control"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtIsUnvan1" runat="server" CssClass="form-control"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtIsBasTar1" runat="server" CssClass="form-control"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtIsBitTar1" runat="server" CssClass="form-control"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtIsIsyeri2" runat="server" CssClass="form-control"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtIsUnvan2" runat="server" CssClass="form-control"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtIsBasTar2" runat="server" CssClass="form-control"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtIsBitTar2" runat="server" CssClass="form-control"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtIsIsyeri3" runat="server" CssClass="form-control"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtIsUnvan3" runat="server" CssClass="form-control"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtIsBasTar3" runat="server" CssClass="form-control"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtIsBitTar3" runat="server" CssClass="form-control"></asp:TextBox></td>
                            </tr>
                        </tbody>
                    </table>

                </div>

                <%--<legend>CV (word veya pdf)</legend>--%>
                <%--<div class="form-group">--%>
                <%--<label class="col-md-3"></label>--%>
                <asp:FileUpload ID="FileUpload1" runat="server" Visible="False" />
                <%--</div>--%>

                <legend>KVKK Bilgilendirme.</legend>

                <div class="form-group">
                    <label class="col-md-3"></label>
                    <div class="col-md-9">
                        <table class="table col-md-12">
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="KVKKOnay1" runat="server" CssClass="checkbox" /></td>
                                    <td>
                                        <p class="col-md-12">Kişisel Verilerinin İşlenmesine İlişkin <a href="http://www.ccnholding.com/sayfalar.asp?LanguageID=1&cid=2&id=274" target="_blank">Aydınlatma Metni</a>’ni okudum.</p>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="KVKKOnay2" runat="server" CssClass="checkbox" /></td>
                                    <td>
                                        <p class="col-md-12">CCN Yatırım Holding A.Ş (“Şirket”) tarafından kişisel verilerimin işlenmesine ilişkin bilgilendirmeleri içeren Kişisel Verilerinin İşlenmesine İlişkin Aydınlatma Metni’ni okuduğumu, anladığımı, haklarım konusunda aydınlatıldığımı, paylaşmış olduğum kişisel verilerimin Kişisel Verilerinin İşlenmesine İlişkin Aydınlatma Metni’nde yer alan şartlar dâhilinde işlenmesine açık bir şekilde rıza verdiğimi kabul ve beyan ederim.</p>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="KVKKOnay3" runat="server" CssClass="checkbox" /></td>
                                    <td>
                                        <p class="col-md-12">Paylaşmış olduğum kişisel verilerimin uygun pozisyon bulunması halinde değerlendirilmek üzere CCN Yatırım Holding A.Ş.’nin iştirak şirketleri ile paylaşılmasına rıza verdiğimi kabul ve beyan ederim.</p>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>



                <br />


                <legend>Güvenlik resmi</legend>

                <div class="form-group">
                    <label class="col-md-3"></label>
                    <label class="col-md-4">Güvenlik resminde gördüğünüz 4 harfi yazınız.</label>
                </div>

                <div class="form-group">
                    <label class="col-md-3"></label>
                    <div class="col-md-4">
                        <img rel="lightbox" src="/Resim.aspx" runat="server" alt="Güvenlik Resmi" />
                        <input type="text" name="txtSecurityCode" runat="server" id="txtSecurityCode" value="" cssclass="form-control" />
                    </div>
                </div>



                <br />
                <legend>Kayıt</legend>
                <div class="form-group">
                    <div class="col-sm-6">
                        <asp:Button ID="Button1" runat="server" Text="Kaydet" CssClass="btn btn-info pull-right btn-lg" OnClick="Button1_Click" />
                    </div>
                </div>

                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />

            </form>
            <hr>
        </div>
    </div>

    <footer>
        <p>&copy; CCN 2019</p>
    </footer>
</body>
</html>

