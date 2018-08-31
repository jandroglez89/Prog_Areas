using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prog_Areas_Proyecto.Modelos;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Prog_Areas_Proyecto.Controllers
{
    public static class ProyectoDataBaseController
    {
        public static List<T> GetAllElements<T>(this DbContext ctx) where T : class
        {
            return ctx.Set<T>().ToList<T>();
        }

        public static T GetSingleElement<T>(this DbContext ctx, Expression<Func<T,bool>> expression) where T : class
        {
            return ctx.Set<T>().Where(expression).FirstOrDefault();
        }

        public static List<T> GetElements<T>(this DbContext ctx, Expression<Func<T, bool>> expression) where T : class
        {
            return ctx.Set<T>().Where(expression).ToList<T>();
        }

        public static List<Local> GetLocales(this DbContext ctx, int proyectoID)
        {
            var _LocalesProyecto = ctx.Set<Locales_Proyecto>().Where(x => x.Proyecto == proyectoID);
            var _locales = new List<Local>();

            foreach (var item in _LocalesProyecto)
            {
                _locales.Add(ctx.Set<Local>().Where(x => x.Id == item.Local).FirstOrDefault());
            }

            return _locales;
        }

        public static T AddElemento<T>(this DbContext ctx, Type type, object obj) where T : class
        {
            var _record = ctx.Set(type).Add(obj);
            ctx.SaveChanges();
            return _record as T;
        }

        public static T AddBasicElement<T>(this DbContext ctx, Type type, string Value) where T : class
        {
            dynamic _parameter = Activator.CreateInstance(typeof(T));

            _parameter.Value = Value;

            return ProyectoDataBaseController.AddElemento(new DB_BIM(), typeof(T), _parameter);
        }

        public static void DeleteElement<T>(this DbContext ctx, Expression<Func<T, bool>> expression, Type type) where T : class
        {
            var _record = ctx.Set<T>().Where(expression).FirstOrDefault();
            ctx.Set(type).Remove(_record);
            ctx.SaveChanges();
        }

        public static T UpdateElement<T>(this DbContext ctx, Expression<Func<T, bool>> expression, Type type, object obj) where T : class
        {
            var _record = ctx.Set<T>().Where(expression).FirstOrDefault();
            _record = (T)obj;
            ctx.SaveChanges();
            return _record;
        }
    }
}
