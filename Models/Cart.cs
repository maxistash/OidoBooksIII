﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assign5.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        public virtual void AddItem(Project pro, int quantity)
            // added the virtual above because it's being used twice
        {
            CartLine line = Lines.Where(p => p.Project.BookId == pro.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Project = pro,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public virtual void RemoveLine(Project pro) =>
            Lines.RemoveAll(x => x.Project.BookId == pro.BookId);
        public virtual void Clear() => Lines.Clear();
        public decimal ComputeTotalSum() =>
            //hard coding price
            (decimal)Lines.Sum(e => e.Project.Price * e.Quantity);
        public class CartLine
        {
            public int CartLineID { get; set; }
            public Project Project { get; set; }
            public int Quantity { get; set; }
        }
    }
}
