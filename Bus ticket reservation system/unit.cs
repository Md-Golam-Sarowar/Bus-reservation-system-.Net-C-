using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace WindowsFormsApplication1
{
    [TestFixture]
    public class unit
    {
        EntryDeleteView w = new EntryDeleteView();
        Database ob = new Database();
        Business oe = new Business();
        [Test]
        public void entrysucc()
        {
            bool r = ob.entrybusdata(7, "Asia", "Dhaka", "Comilla", "16/11/2018", "6:00pm", "9:00pm", 40, 250);
            Assert.IsTrue(r);
        }
        [Test]
        public void deletesucc()
        {
            bool r = ob.deletebusdata(7);
            Assert.IsTrue(r);
        }
        [Test]
        public void updatesucc()
        {
            bool r = ob.updatebusdata(7, "Asia", "Dhaka", "Comilla", "16/11/2018", "6:00pm", "9:00pm", 40, 250);
            Assert.IsTrue(r);
        }
        [Test]
        public void IntConversion()
        {
            int s = ob.Conv("123");
            Assert.AreEqual(123, s);
        }
        [Test]
        public void CharConversion()
        {
            Assert.Throws<FormatException>(() => ob.Conv("tre"));
        }
        [Test]
        public void NullConversion()
        {
            Assert.AreEqual("Can not be null", Assert.Throws<ArgumentNullException>(() => ob.Conv(null)).ParamName);
        }
        [Test]
        public void entryupdatenull1()
        {
            Assert.AreEqual("Can not be null", Assert.Throws<ArgumentNullException>(() => ob.Nullcheck(null, null, null, null, null, null, null, null, null)).ParamName);
        }
        [Test]
        public void deletenull()
        {
            Assert.AreEqual("Can not be null", Assert.Throws<ArgumentNullException>(() => ob.Nullcheck1(null)).ParamName);
        }
        [Test]
        public void loaddata() 
        {
            bool r = w.LoadData();
            Assert.IsTrue(r);
        }
        [Test]
        public void entryupdatenull2()
        {
            Assert.AreEqual("Can not be null", Assert.Throws<ArgumentNullException>(() => ob.Nullcheck("0", null, "la", "20", null, "kallu", null, "10", null)).ParamName);
        }
        [Test]
        public void entryupdatenull3()
        {
            Assert.AreEqual("Can not be null", Assert.Throws<ArgumentNullException>(() => ob.Nullcheck("11", "2", null, null, "gb", null, "87", "cg", "7")).ParamName);
        }
        [Test]
        public void entryupdatenull4()
        {
            Assert.AreEqual("Can not be null", Assert.Throws<ArgumentNullException>(() => ob.Nullcheck(null, "2", "45", "dfag", "32", "821", "fg", null, null)).ParamName);
        }
        [Test]
        public void entryupdatenull5()
        {
            Assert.AreEqual("Can not be null", Assert.Throws<ArgumentNullException>(() => ob.Nullcheck("urw", "rwe", null, "23", null, null, "hd", "-1", "-7")).ParamName);
        }
        [Test]
        public void entryupdatenull6()
        {
            Assert.AreEqual("Can not be null", Assert.Throws<ArgumentNullException>(() => ob.Nullcheck("ew", "eq", "sa", "ds", "gb", null, null, null, "cgs")).ParamName);
        }
        [Test]
        public void entryupdatenull7()
        {
            Assert.AreEqual("Can not be null", Assert.Throws<ArgumentNullException>(() => ob.Nullcheck("jk", "hy", "3", null, null, "90", "87", "bg", null)).ParamName);
        }
        [Test]
        public void entryupdatenull8()
        {
            Assert.AreEqual("Can not be null", Assert.Throws<ArgumentNullException>(() => ob.Nullcheck("80", null, "kj", null, "7", "nh", "6", null, "-2")).ParamName);
        }
        [Test]
        public void entryupdatenull9()
        {
            Assert.AreEqual("Can not be null", Assert.Throws<ArgumentNullException>(() => ob.Nullcheck("8", null, "89", "8", "8", "9", null, "-3", "mn")).ParamName);
        }
        [Test]
        public void entryupdatenull10()
        {
            Assert.AreEqual("Can not be null", Assert.Throws<ArgumentNullException>(() => ob.Nullcheck(null, null, null, "oi", "gb", "kl", null, "-2", "7")).ParamName);
        }
        [Test]
        public void entryupdatenull11()
        {
            Assert.AreEqual("Can not be null", Assert.Throws<ArgumentNullException>(() => ob.Nullcheck(null, "bh", null, null, "98", null, "87", "4", "uy")).ParamName);
        }
        [Test]
        public void entryupdatenull12()
        {
            Assert.AreEqual("Can not be null", Assert.Throws<ArgumentNullException>(() => ob.Nullcheck(null, "2", "mk", "9", "gb", "6", null, "yt", "-4")).ParamName);
        }
        [Test]
        public void entryupdatenull13()
        {
            Assert.AreEqual("Can not be null", Assert.Throws<ArgumentNullException>(() => ob.Nullcheck("-2", "fd", "9", null, "gb", "5", "gf", "4", "7")).ParamName);
        }
        [Test]
        public void entryupdatenull14()
        {
            Assert.AreEqual("Can not be null", Assert.Throws<ArgumentNullException>(() => ob.Nullcheck("0", "2", null, "wq", null, null, "87", null, "7")).ParamName);
        }
        [Test]
        public void entryupdatenull15()
        {
            bool r = ob.Nullcheck("qw", "2", "mz", "3", "3", "lp", "io", "4", "7");
            Assert.IsTrue(r);
        }
        [Test]
        public void entryupdatenull16()
        {
            Assert.AreEqual("Can not be null", Assert.Throws<ArgumentNullException>(() => ob.Nullcheck("1", null, "2", "sa", null, "vb", "yt", "po", "jh")).ParamName);
        }
        [Test]
        public void entryupdatenull17()
        {
            Assert.AreEqual("Can not be null", Assert.Throws<ArgumentNullException>(() => ob.Nullcheck("-4", "2", "3", "bn", "98", null, "87", "0", "-3")).ParamName);
        }
        [Test]
        public void entryupdatenull18()
        {
            Assert.AreEqual("Can not be null", Assert.Throws<ArgumentNullException>(() => ob.Nullcheck("bg", null, "3", "ou", null, null, null, "4", "-5")).ParamName);
        }
        [Test]
        public void entryupdatenull19()
        {
            Assert.AreEqual("Can not be null", Assert.Throws<ArgumentNullException>(() => ob.Nullcheck("6", "bh", null, "5", "gb", null, "87", null, null)).ParamName);
        }
        [Test]
        public void entryupdatenull20()
        {
            Assert.AreEqual("Can not be null", Assert.Throws<ArgumentNullException>(() => ob.Nullcheck("4", "2", null, null, null, "3", null, "4", "er")).ParamName);
        }
        [Test]
        public void entryupdatenull21()
        {
            bool r = ob.Nullcheck("-9", "hj", "vc", "4", "7", "ty", "87", "mn", "po");
            Assert.IsTrue(r);
        }
        [Test]
        public void entryupdatenull22()
        {
            Assert.AreEqual("Can not be null", Assert.Throws<ArgumentNullException>(() => ob.Nullcheck(null, "fg", "bv", null, null, null, "xz", "0", null)).ParamName);
        }
    }
}
