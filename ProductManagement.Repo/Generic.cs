using Microsoft.EntityFrameworkCore;
using ProductManagement.IRepo;
using ProductManagement.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Repo
{
    public class Generic<T> : IGeneric<T> where T : class
    {

        protected QuanLySanPhamContext db { get; set; }
        protected DbSet<T> table = null;
        public Generic()
        {
            db = new QuanLySanPhamContext();
            table = db.Set<T>();
        }
        public int Create(T item)
        {
            try
            {
                table.Add(item);
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public int Delete(int id)
        {
            try
            {
                T model = table.Find(id);
                table.Remove(model);
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<T> GetAll()
        {
            try
            {
                return table.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public int Update(T item)
        {
            try
            {
                table.Attach(item);
                db.Entry(item).State = EntityState.Modified;
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public T Get(int id)
        {
            try
            {
                T model = table.Find(id);
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
