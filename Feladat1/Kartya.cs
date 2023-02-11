using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Feladat1
{
    class Kartya
    {
        public string pid { get; private set; }
        public int byr { get; private set; }
        public string cid { get; private set; }
        public int iyr { get; private set; }
        public int eyr { get; private set; }
        public string hgt { get; private set; }
        public string hcl { get; private set; }
        public string ecl { get; private set; }


        public Kartya(string s)
        {
            string[] adatok = s.Trim().Split(" ");
            PropertyInfo[] infos = this.GetType().GetProperties();
            for (int i = 0; i < adatok.Length; i++)
            {
                string[] egyadat = adatok[i].Split(":");
                foreach (PropertyInfo item in infos)
                {
                    if (item.Name == egyadat[0])
                    {
                        if (item.PropertyType == typeof(int))
                        {
                            item.SetValue(this, int.Parse(egyadat[1]));
                        }
                        else { item.SetValue(this, egyadat[1], null); }
                    }
                }
            }
        }

        public override string ToString()
        {
            return "pid:" + pid + " byr:" + byr + " cid:" + cid + " iyr:" + iyr + " eyr:" + eyr + " hgt:" + hgt + " hcl:" + hcl + " ecl:" + ecl;
        }

        public bool OkesAKartya()
        {
            PropertyInfo[] infos = this.GetType().GetProperties();
            bool retInfo = false;
            foreach (PropertyInfo item in infos)
            {
                if(item.PropertyType == typeof(int))
                {
                    if((int)item.GetValue(this) == 0)
                    {
                        return false;
                    }
                }
                
                if (item.GetValue(this) != null && item.Name != "cid")
                {
                    retInfo = true;
                }
                else if (item.GetValue(this) == null && item.Name != "cid")
                {
                    return false;
                }
              
            }


            return retInfo;
        }

        public bool OkesAKartyaMech() //ezt csak teszteléshez írtam
        {
            if(pid == null)
            {
                return false;
            }
            if (byr == null || byr == 0)
            {
                return false;
            }
            if (iyr == null ||iyr ==0)
            {
                return false;
            }
            if (eyr == null || eyr ==0)
            {
                return false;
            }
            if (hgt == null)
            {
                return false;
            }
            if (hcl == null)
            {
                return false;
            }
            if (ecl == null)
            {
                return false;
            }

            return true;

        }

        public bool KorrektAdatok()
        {
            return PidIsOk() && ByrIsOk() && IyrIsOk() && EyrIsOk() && HgtIsOk() && HclIsOk() && EclIsOk();
        }

        private bool PidIsOk()
        {
            if (pid == null)
            {
                return false;
            }
            bool okes = false;
            char[] karakterek = pid.ToCharArray();
            if (karakterek.Length == 9)
            {
                for (int i = 0; i < karakterek.Length; i++)
                {
                    if ((int)karakterek[i] >= 48 && (int)karakterek[i] <= 57)
                    {
                        okes = true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return okes;
        }

        private bool ByrIsOk()
        {
            if (byr == null)
            {
                return false;
            }
            return (byr >= 1920 && byr <= 2002);
        }

        private bool IyrIsOk()
        {
            if (iyr == null)
            {
                return false;
            }
            return (iyr >= 2010 && iyr <= 2021);
        }

        private bool EyrIsOk()
        {
            if (eyr == null)
            {
                return false;
            }
            return (eyr >= 2021 && eyr <= 2031);
        }

        private bool HgtIsOk()
        {
            if (hgt == null)
            {
                return false;
            }
            if (hgt.Contains("cm"))
            {
                int meret = int.Parse(hgt.Substring(0, hgt.Length - 2));
                if (meret >= 50 && meret <= 220)
                {
                    return true;
                }
            }
            else if (hgt.Contains("in"))
            {
                int meret = int.Parse(hgt.Substring(0, hgt.Length - 2));
                if (meret >= 20 && meret <= 90)
                {
                    return true;
                }
            }
            return false;
        }

        private bool HclIsOk()
        {
            if (hcl == null)
            {
                return false;
            }
            if (hcl.Length != 7)
            {
                return false;
            }
            if (hcl[0] != '#')
            {
                return false;
            }
            for (int i = 1; i < hcl.Length; i++)
            {
                if (((int)hcl[i] < 48 && (int)hcl[i] > 57) || ((int)hcl[i] < 97 && (int)hcl[i] > 102))
                {
                    return false;
                }
            }
            return true;
        }

        private bool EclIsOk()
        {
            if (ecl == null)
            {
                return false;
            }
            return ecl.Equals("grn") || ecl.Equals("blu") || ecl.Equals("brn") || ecl.Equals("hzl") || ecl.Equals("oth") || ecl.Equals("amb") || ecl.Equals("gry");
        }
    }
}

