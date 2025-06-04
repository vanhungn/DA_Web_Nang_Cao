using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DA_Web_Nang_Cao.src.model
{
    public class modelItems
    {
            public string idItem { get; set; }
            public string nameItem { get; set; }
            public string descs { get; set; }
            public string img0 { get; set; }
            public string img1 { get; set; }
            public string img2 { get; set; }
            public int price { get; set; }
            public int promotion { get; set; }
            public string satus { get; set; }
            public string origin { get; set; }
            public string weights { get; set; }
            public int totalQuantity { get; set; }
            public int quantitySold { get; set; }
            public string kindOfItem { get; set; }
            public int quantity { get; set; }
           public int percentPromotion { get; set; }
            public int idOrder { get; set; }


    }
    public class modelUsers {
        public int idUsers { get; set; }
        public string names { get; set; }
        public string phones { get; set; }
        public string emails { get; set; }
        public string userNames { get; set; }
        public string passwords { get; set; }
        public string roles { get; set; }
        public string addresss { get; set; }
        public int moneys { get; set; }
    }
}