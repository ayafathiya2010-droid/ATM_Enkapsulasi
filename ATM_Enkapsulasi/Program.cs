using System.IO.Pipes;
using System.Security.Cryptography.X509Certificates;
Rekening rekening = new Rekening("111222333444555");

bool ulang =true;
int jumlah;
string pilihan;

while(ulang)
{
    Console.WriteLine("Menu ATM");
    Console.WriteLine("1. display info \n2. setor uang \n3. tarik uang \n4. keluar" );
    Console.Write("Input pilihan: ");
    pilihan = Console.ReadLine();

    switch (pilihan)
    {
        case "1":
            rekening.DisplayInfo();
            break;
        case "2":
            Console.WriteLine("Masukan jumlah uang: ");
            jumlah = int.Parse(Console.ReadLine());
            rekening.SetorUang(jumlah);
            break;
        case "3":
            Console.WriteLine("Masukan jumlah uang: ");
            jumlah = int.Parse(Console.ReadLine());
            rekening.TarikTunai(jumlah);
            break;
        case "4":
            Console.WriteLine("Terimakasih sudah menggunakan layanan kami");
            ulang = false;
            break;
        default:
            Console.WriteLine("Pilihan tidak valid");
            break;


    }
   
}

class Rekening
{
    private string _noRekening;
    private int _saldo;

    public string NoRekening
    {
        get { return _noRekening; }
    }

    public int Saldo
    {
        get { return _saldo; }
        set
        {
            if (value < 0) Console.WriteLine("Saldo tidak boleh negatif!!");
            else _saldo = value;
        }
    }

    public Rekening(string no_rekening)
    {
        _noRekening = no_rekening;
        _saldo = 100000;
    }

    public void DisplayInfo()
    {
        Console.WriteLine("Menampilkan info...");
        Console.WriteLine($"No rekening saat ini: {NoRekening}");
        Console.WriteLine($"Saldo saat ini: {Saldo}");
    }

    public void SetorUang(int jumlah)
    {
        if (jumlah < 0)
        {
            Console.WriteLine("Jumlah uang tidak boleh negatif!");
        }
        else
        {
            Saldo += jumlah;
            Console.WriteLine("Berhasil setor uang!");
            Console.WriteLine($"Saldo saat ini: Rp {Saldo}");
        }

    }

    public void TarikTunai(int jumlah)
    {
        if (jumlah > Saldo)
        {
            Console.WriteLine("Mohon maaf saldo tidak mencukupi!");
        }
        else
        {
            Saldo -= jumlah;
            Console.WriteLine("Berhasil tarik uang!");
            Console.WriteLine($"Saldo saat ini: Rp {Saldo}");
        }

    }

}
