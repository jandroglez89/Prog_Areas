using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using Prog_Areas_Plantilla.Modelos;
using System.Data.Entity.Infrastructure;

namespace Prog_Areas_Plantilla.Controllers
{
    public static class DataBaseController
    {
        public static void AddElemento(this DbContext ctx, Type type, object obj)
        {
            ctx.Set(type).Add(obj);
            ctx.SaveChanges();
        }

        public static T AddBasicElement<T>(this DbContext ctx, object obj, Expression<Func<T, bool>> expression) where T : class
        {
            var _record = ctx.Set<T>().Where(expression).FirstOrDefault();

            if (_record == null)
            {
                _record = ctx.Set(typeof(T)).Add(obj) as T;
                ctx.SaveChanges();
            }

            return _record;
        }

        //ESTA VARIANTE INICIA LOS ID EN 0, POR ESO NO SE UTILIZA
        public static T AddElemento<T>(this DbContext ctx, object obj) where T : class
        {
            var _record = ctx.Set<T>().Add((T)obj);
            ctx.SaveChanges();

            return _record;
        }


        public static void DeleteAllRecords<T>(this DbContext ctx) where T : class
        {
            var _records = ctx.Set<T>().ToList();
            ctx.Set<T>().RemoveRange(_records);
            ctx.SaveChanges();
        }

        public static int DeleteSingleRecord<T>(this DbContext ctx, Expression<Func<T, bool>> expression) where T : class
        {
            var _record = ctx.Set<T>().Where(expression).FirstOrDefault();
            ctx.Set<T>().Remove(_record);
            ctx.SaveChanges();

            return 1;
        }

        public static void ReseedTable(this DbContext ctx, Type type)
        {
            ctx.Database.ExecuteSqlCommand("DBCC CHECKIDENT('" + type.Name + "', RESEED, 0)");
        }

        public static T GetSingleRecord<T>(this DbContext ctx, Expression<Func<T, bool>> expression) where T : class
        {
            return ctx.Set<T>().Where(expression).FirstOrDefault();
        }

        public static List<T> GetRecordsBy<T>(this DbContext ctx, Expression<Func<T, bool>> expression) where T : class
        {
            return ctx.Set<T>().Where(expression).ToList<T>();
        }
        
        public static List<T> GetAllRecords<T>(this DbContext ctx) where T : class
        {
            return ctx.Set<T>().ToList();
        }

        public static int GetNumberOfRecords<T>(this DbContext ctx) where T : class
        {
            return ctx.Set<T>().Count();
        }

        //public static T UpdateRecord<T>(this DbContext ctx, T obj, Expression<Func<T, bool>> expression) where T : class
        //{
        //    var _Record = ctx.Set<T>().Where
        //}
    }
}
