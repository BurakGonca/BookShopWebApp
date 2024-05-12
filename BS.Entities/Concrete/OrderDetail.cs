﻿using BS.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BS.Entities.Concrete
{
	public class OrderDetail : BaseEntity
	{
        
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double Discount { get; set; }
        public double TotalPrice { get; set; }




        //iliskiler


        public Order Order { get; set; }


        public IQueryable<Book> Books { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }



    }
}
