﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prog_Areas_Plantilla.Modelos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_PLANTILLA : DbContext
    {
        public DB_PLANTILLA()
            : base("name=DB_PLANTILLA")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<T_AF_Metro_Cuadrado> T_AF_Metro_Cuadrado { get; set; }
        public virtual DbSet<T_AF_Persona> T_AF_Persona { get; set; }
        public virtual DbSet<T_Aire_Fresco> T_Aire_Fresco { get; set; }
        public virtual DbSet<T_Alojamiento> T_Alojamiento { get; set; }
        public virtual DbSet<T_Alojamiento_Tipo> T_Alojamiento_Tipo { get; set; }
        public virtual DbSet<T_ALTV> T_ALTV { get; set; }
        public virtual DbSet<T_Ambiente> T_Ambiente { get; set; }
        public virtual DbSet<T_Catalogo_Impermeable> T_Catalogo_Impermeable { get; set; }
        public virtual DbSet<T_Catalogo_Pared> T_Catalogo_Pared { get; set; }
        public virtual DbSet<T_Catalogo_Rodapie> T_Catalogo_Rodapie { get; set; }
        public virtual DbSet<T_Catalogo_Suelo> T_Catalogo_Suelo { get; set; }
        public virtual DbSet<T_Catalogo_Techo> T_Catalogo_Techo { get; set; }
        public virtual DbSet<T_Climatizacion> T_Climatizacion { get; set; }
        public virtual DbSet<T_CoefArea> T_CoefArea { get; set; }
        public virtual DbSet<T_Comunicaciones_Tv> T_Comunicaciones_Tv { get; set; }
        public virtual DbSet<T_Criterio> T_Criterio { get; set; }
        public virtual DbSet<T_DI> T_DI { get; set; }
        public virtual DbSet<T_Equipamiento> T_Equipamiento { get; set; }
        public virtual DbSet<T_Grupo_Locales> T_Grupo_Locales { get; set; }
        public virtual DbSet<T_Local> T_Local { get; set; }
        public virtual DbSet<T_LocalTipo> T_LocalTipo { get; set; }
        public virtual DbSet<T_Mod> T_Mod { get; set; }
        public virtual DbSet<T_Porciento_BD> T_Porciento_BD { get; set; }
        public virtual DbSet<T_Renovaciones> T_Renovaciones { get; set; }
        public virtual DbSet<T_Subsistema_Area> T_Subsistema_Area { get; set; }
        public virtual DbSet<T_Subsistema_Tipo> T_Subsistema_Tipo { get; set; }
        public virtual DbSet<T_TD> T_TD { get; set; }
        public virtual DbSet<T_TD_Pos> T_TD_Pos { get; set; }
        public virtual DbSet<T_TF> T_TF { get; set; }
        public virtual DbSet<T_Tipo_Edificio> T_Tipo_Edificio { get; set; }
        public virtual DbSet<T_Tratamiento> T_Tratamiento { get; set; }
        public virtual DbSet<T_TT_TV> T_TT_TV { get; set; }
        public virtual DbSet<T_UPSC> T_UPSC { get; set; }
        public virtual DbSet<T_UPSI> T_UPSI { get; set; }
        public virtual DbSet<T_W_Aire> T_W_Aire { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<T_sysdiagrams> T_sysdiagrams { get; set; }
        public virtual DbSet<a_sysdiagrams> sysdiagrams { get; set; }
    }
}
