function tckimlikkontorolu(tcno) {
    var tckontrol, toplam; tckontrol = tcno; tcno = tcno.value; toplam = Number(tcno.substring(0, 1)) + Number(tcno.substring(1, 2)) +
        Number(tcno.substring(2, 3)) + Number(tcno.substring(3, 4)) +
        Number(tcno.substring(4, 5)) + Number(tcno.substring(5, 6)) +
        Number(tcno.substring(6, 7)) + Number(tcno.substring(7, 8)) +
        Number(tcno.substring(8, 9)) + Number(tcno.substring(9, 10));
    strtoplam = String(toplam); onunbirlerbas = strtoplam.substring(strtoplam.length, strtoplam.length - 1);

    if (onunbirlerbas == tcno.substring(10, 11)) {
        alert("doğru");
    } else {
        alert("yanlış");
    }
}