using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuasBangunDatar
{
    class Program
    {
        static void Main(string[] args)
        {
            StartProgram mulai = new StartProgram();
            mulai.ShowChoice();
            mulai.Choice();
            BackAfterRestart startAgain = new BackAfterRestart();
            startAgain.ReturnStart();
        }
    }
    // Encapsulation
    public class Restart
    {
        private string yes;
        public string GetYes()
        {
            return yes;
        }
        public void SetYes(string yes)
        {
            this.yes = yes;
        }
    }

    public class BackAfterRestart
    {
        public void ReturnStart()
        {
            Restart restart = new Restart();
            restart.SetYes("Yes");
            string yesDefault = restart.GetYes();
            bool i = true;
            while (i)
            {
                Console.WriteLine("Type Yes To Restart The Programm\n ");
                string YesConfirm = Console.ReadLine();
                if (yesDefault.Equals(YesConfirm, StringComparison.CurrentCultureIgnoreCase))
                {
                    StartProgram mulai2 = new StartProgram();
                    mulai2.ShowChoice();
                    mulai2.Choice();
                }
                else
                {
                    i = false;
                }
            }
        }
    }
    // Tampilkan Menu
    public class StartProgram
    {
        private int pilihan;

        public void ShowChoice()
        {
            Console.WriteLine("Input Number From 1-5\n" +
                "1. Luas dan Keliling Persegi  \n" +
                "2. Luas dan Keliling Persegi Panjang\n" +
                "3. Luas dan Keliling Segitiga\n" +
                "4. Luas dan Keliling Trapesium\n" +
                "5. Luas dan Keliling Lingkaran");
        }
        public void Choice()
        {
            try
            {
                this.pilihan = int.Parse(Console.ReadLine());
                switch (pilihan)
                {
                    case 1:
                        AllMethod Number1 = new AllMethod();
                        Number1.Number1Persegi();
                        break;
                    case 2:
                        AllMethod Number2 = new AllMethod();
                        Number2.Number2PersegiPanjang();
                        break;
                    case 3:
                        AllMethod Number3 = new AllMethod();
                        Number3.Number3Segitiga();
                        break;
                    case 4:
                        AllMethod Number4 = new AllMethod();
                        Number4.Number4Trapesium();
                        break;
                    case 5:
                        AllMethod Number5 = new AllMethod();
                        Number5.Number5Lingkaran();
                        break;
                    default:
                        Console.WriteLine("Please Input Number From 1-5");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please Input Number Only");
            }
        }
    }

    // Parent Class
    public class Input
    {
        private double inputdouble;
        private int inputInteger;


        public double ReqInputdouble()
        {
            try
            {
                this.inputdouble = double.Parse((Console.ReadLine()));
            }
            catch (Exception)
            {
                Console.WriteLine("Please Input Number Only");
            }
            return inputdouble;
        }
        public int ReqInputInteger()
        {
            try
            {
                this.inputInteger = int.Parse((Console.ReadLine()));
            }
            catch (FormatException)
            {
                Console.WriteLine("Please Input Number Only");
            }
            return inputInteger;
        }
    }
    // Inheritance 
    public class Command : Input
    {
        public void AskSisi()
        {
            Console.WriteLine("Input Sisi");
        }
        public void AskPanjang()
        {
            Console.WriteLine("Input Panjang");
        }
        public void AskLebar()
        {
            Console.WriteLine("Input Lebar");
        }
        public void AskAlas()
        {
            Console.WriteLine("Input Alas");
        }
        public void AskTinggi()
        {
            Console.WriteLine("Input Tinggi");
        }
        public void AskTutup()
        {
            Console.WriteLine("Input Panjang Tutup");
        }
        public void AskJariJari()
        {
            Console.WriteLine("Input Jari - jari");
        }
    }

    // Inheritance
    public class Persegi : Command
    {
        public virtual double GetLuas(double sisi)
        {
            if (sisi == 0)
            {
                throw new Exception("Don't Input Zero/Empty Number");
            }
            return Math.Round((sisi * sisi), 2);

        }

        public virtual void ShowLuas(double luas)
        {
            Console.WriteLine("Luas Persegi adalah " + luas);
        }
        // Overload for integer luas    
        public void ShowLuas(int luas)
        {
            Console.WriteLine("Luas Persegi adalah " + luas);
        }
        public virtual double GetKeliling(double sisi)
        {
            if (sisi == 0)
            {
                throw new Exception("Don't Input Zero/Empty Number");
            }
            return Math.Round((4 * sisi), 2);

        }
        //Overload for integer Keliling
        public void ShowKeliling(int keliling)
        {
            Console.WriteLine("Keliling Persegi adalah " + keliling);
        }
        public virtual void ShowKeliling(double keliling)
        {
            Console.WriteLine("Keliling Persegi adalah " + keliling);
        }
    }
    //polymorphism
    // override ShowLuas and ShowKeliling
    public class PersegiPanjang : Persegi
    {
        public virtual double GetLuas(double panjang, double lebar)
        {
            if (panjang == 0 || lebar == 0)
            {
                throw new Exception("Don't Input Zero/Empty Number");
            }
            return Math.Round((panjang * lebar), 2);
        }
        public override void ShowLuas(double luas)
        {
            Console.WriteLine("Luas Persegi Panjang adalah " + luas);
        }
        //Overload For Luas
        public void ShowLuas(int luas)
        {
            Console.WriteLine("Luas Persegi Panjang adalah " + luas);
        }

        public virtual double GetKeliling(double panjang, double lebar)
        {
            if (panjang == 0 || lebar == 0)
            {
                throw new Exception("Don't Input Zero/Empty Number");
            }
            return Math.Round((2 * (panjang + lebar)), 2);
        }
        public virtual void ShowKeliling(double keliling)
        {
            Console.WriteLine("Keliling Persegi Panjang adalah " + keliling);
        }
        // Overload For Keliling
        public void ShowKeliling(int keliling)
        {
            Console.WriteLine("Keliling Persegi Panjang adalah " + keliling);
        }

    }
    // polymorphism
    //override GetLuas, GetKeliling

    public class Segitiga : PersegiPanjang
    {
        public override double GetLuas(double alas, double tinggi)
        {
            if (alas == 0 || tinggi == 0)
            {
                throw new Exception("Don't Input Zero/Empty Number");
            }
            // Luas Segitiga = 1/2 * alas * tinggi
            return Math.Round((0.5 * alas * tinggi), 2);

        }

        public override void ShowLuas(double luas)
        {
            Console.WriteLine("Luas Segitiga adalah " + luas);
        }

        public override double GetKeliling(double alas, double tinggi)
        {
            if (alas == 0 || tinggi == 0)
            {
                throw new Exception("Don't Input Zero/Empty Number");
            }
            // Keliling Segitiga = sisi a + sisi b + sisi c
            return Math.Round((alas + 2 * (Math.Sqrt(Math.Pow(tinggi, 2) - Math.Pow((0.5 * alas), 2)))), 2);
        }
        public override void ShowKeliling(double keliling)
        {
            Console.WriteLine("Keliling Segitiga adalah " + keliling);
        }
    }

    public class Trapesium : Segitiga
    {

        public double GetLuas(double alas, double tinggi, double tutup)
        {
            if (alas == 0 || tinggi == 0)
            {
                throw new Exception("Don't Input Zero/Empty Number");
            }
            //luas Trapesium = 1/2 * (alas + tutup) * tinggi
            return Math.Round((0.5 * (alas + tutup) * tinggi), 2);

        }

        public override void ShowLuas(double luas)
        {
            Console.WriteLine("Luas trapesium adalah " + luas);
        }
        public double GetKeliling(double alas, double tinggi, double tutup)
        {
            if (alas == 0 || tinggi == 0 || tutup == 0)
            {
                throw new Exception("Don't Input Zero/Empty Number");
            }
            //Keliling Trapesium = alas + tutup + 2*sisi miring
            return Math.Round((alas + tutup + 2 * (Math.Sqrt(Math.Pow(tinggi, 2) - Math.Pow((alas - tutup), 2)))), 2);

        }
        public override void ShowKeliling(double keliling)
        {
            Console.WriteLine("Keliling Trapesium adalah " + keliling);
        }
    }

    public class Lingkaran : Trapesium
    {
        // Constructor
        public string askjarijari;
        public Lingkaran(string jarijari)
        {
            askjarijari = jarijari;
        }
        public override double GetLuas(double jarijari)
        {
            if (jarijari == 0)
            {
                throw new Exception("Don't Input Zero/Empty Number");
            }
            // Luas Lingkaran = 3.14 * (jarijari^2)
            return Math.Round((3.14 * jarijari * jarijari), 2);
        }

        public override void ShowLuas(double luas)
        {
            Console.WriteLine("Luas Lingkaran adalah " + luas);
        }

        public override double GetKeliling(double jarijari)
        {
            if (jarijari == 0)
            {
                throw new Exception("Don't Input Zero/Empty Number");
            }
            //Keliling Lingkaran = 2 * 3.14 * jarijari
            return Math.Round((2 * 3.14 * jarijari), 2);
        }

        public override void ShowKeliling(double keliling)
        {
            Console.WriteLine("Keliling Lingkaran adalah " + keliling);
        }

    }

    //interface
    public interface IAllMethod
    {
        void Number1Persegi();
        void Number2PersegiPanjang();
        void Number3Segitiga();
        void Number4Trapesium();
        void Number5Lingkaran();
    }
    //Implementation Interface
    public class AllMethod : IAllMethod
    {
        public void Number1Persegi()
        {
            try
            {
                Persegi persegi = new Persegi();
                persegi.AskSisi();
                double sisi = persegi.ReqInputdouble();
                int luas = Convert.ToInt32(persegi.GetLuas(sisi));
                //double luas = persegi.GetLuas(sisi);
                int keliling = Convert.ToInt32(persegi.GetKeliling(sisi));
                // double keliling = persegi.GetKeliling(sisi);
                persegi.ShowLuas(luas);
                persegi.ShowKeliling(keliling);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Number2PersegiPanjang()
        {
            try
            {
                PersegiPanjang persegipanjang = new PersegiPanjang();
                persegipanjang.AskPanjang();
                double panjang = persegipanjang.ReqInputdouble();
                persegipanjang.AskLebar();
                double lebar = persegipanjang.ReqInputdouble();
                int luas = Convert.ToInt32(persegipanjang.GetLuas(panjang, lebar));
                int keliling = Convert.ToInt32(persegipanjang.GetKeliling(panjang, lebar));
                // double luas = persegipanjang.GetLuas(panjang,lebar);
                //double keliling = persegipanjang.GetKeliling(panjang,lebar);
                persegipanjang.ShowLuas(luas);
                persegipanjang.ShowKeliling(keliling);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void Number3Segitiga()
        {
            try
            {
                Segitiga segitiga = new Segitiga();
                segitiga.AskAlas();
                double alas = segitiga.ReqInputdouble();
                segitiga.AskTinggi();
                double tinggi = segitiga.ReqInputdouble();
                double luas = segitiga.GetLuas(alas, tinggi);
                double keliling = segitiga.GetKeliling(alas, tinggi);
                segitiga.ShowLuas(luas);
                segitiga.ShowKeliling(keliling);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void Number4Trapesium()
        {
            try
            {
                Trapesium trapesium = new Trapesium();
                trapesium.AskAlas();
                double alas = trapesium.ReqInputdouble();
                trapesium.AskTinggi();
                double tinggi = trapesium.ReqInputdouble();
                trapesium.AskTutup();
                double tutup = trapesium.ReqInputdouble();
                double luas = trapesium.GetLuas(alas, tinggi, tutup);
                double keliling = trapesium.GetKeliling(alas, tinggi, tutup);
                trapesium.ShowLuas(luas);
                trapesium.ShowKeliling(keliling);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Number5Lingkaran()
        {
            try
            {
                Lingkaran lingkaran = new Lingkaran("Input Jari-jari");
                //lingkaran.AskJariJari();
                Console.WriteLine(lingkaran.askjarijari);
                double jarijari = lingkaran.ReqInputdouble();
                double luas = lingkaran.GetLuas(jarijari);
                double keliling = lingkaran.GetKeliling(jarijari);
                lingkaran.ShowLuas(luas);
                lingkaran.ShowKeliling(keliling);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

}
